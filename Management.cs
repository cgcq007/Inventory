using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace InventoryTest
{
    public partial class Management : Form
    {
        string utype;
        string uname;

        int pageSize = 40;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行
        DataTable dtInfo = new DataTable();
        SetPositionTool st = new SetPositionTool();

        //Dictionary<string, int> width = new Dictionary<string, int>();
        int itemTitleWidth = 150;
        int listedWidth = 30;
        int dateOfRCVWidth = 50;
        int SNWidth = 80;
        int locationWidth = 30;
        int originalTrackingNumWidth = 100;
        int UPCWidth = 80;
        int conditionWidth = 50;
        int OrderIdWidth = 100;
        int noteWidth = 150;
        int dateOfOutWidth = 50;


        //{
        //    { "Itemtitle",150 }, { "Listed", 30}, {"DateOfRcv", 50 },
        //    {"SN", 80 }, {"Location", 30 }, {"OriginalTrackingNum", 100 },
        //    {"UPC", 80 }, {"Condition", 50 }, {"OrderId", 100 },
        //    {"Note", 150 }, {"DateOfOut", 50 }
        //};


        public Management(string uname, string utype)
        {
            this.uname = uname;
            this.utype = utype;
            InitializeComponent();
        }
        private void SetAuthority(string utype)
        {
            if (utype == "serviceMan")
            {
                Add.Enabled = false;
                Delete.Enabled = false;
                Modify.Enabled = true;
                pendingBox.Enabled = true;
                ReadyToOut.Enabled = false;
                ItemOut.Enabled = false;
            }
            else if (utype == "itemOperator")
            {
                Add.Enabled = true;
                Delete.Enabled = true;
                Modify.Enabled = true;
                pendingBox.Enabled = true;
                ReadyToOut.Enabled = true;
                ItemOut.Enabled = true;
            }
            else if (utype == "admin")
            {
                Add.Enabled = true;
                Modify.Enabled = true;
                Delete.Enabled = true;
                pendingBox.Enabled = true;
                ReadyToOut.Enabled = true;
                ItemOut.Enabled = true;
                
            }
        }

        private void Management_Load(object sender, EventArgs e)
        {
            RcvTime.Checked = false;
            label7.Visible = false;
            clearDatePicker.Visible = false;
            multipleDeleteButton.Visible = false;

            ReLoadData();
            if (InOrOut.Text.Trim().ToString() == "In Inventory")
            {
                SetAuthority(utype);
            }
            else
            {
                Add.Enabled = false;
                Modify.Enabled = false;
                pendingBox.Enabled = false;
                ItemOut.Enabled = false;
                ReadyToOut.Enabled = false;
                if (utype == "admin")
                {
                    label7.Visible = true;
                    clearDatePicker.Visible = true;
                    multipleDeleteButton.Visible = true;
                }
            }

            //setFridViewProperty();
        }
        private void ReLoadData()
        {
            AddSelect();
            if (InOrOut.Text.Trim().ToString() == "In Inventory")
            {
                using (ItemContext ctx = new ItemContext())
                {
                    var items = ctx.Items.Select(x => new { x.ItemTitle, x.SN, x.DateOfRcv, x.UPC, x.OriginalTrackingNum, x.OrderId, x.Condition, x.Note, x.Listed, x.Location, x.Pending }).OrderByDescending(order => order.DateOfRcv).ToList();
                    dtInfo = ToDataSet(items);
                }
            }
            else
            {
                using (ItemContext ctx = new ItemContext())
                {
                    var itemsDisposed = ctx.ItemsDisposed.Select(x => new { x.ItemTitle, x.SN, x.DateOfRcv, x.DateOfOut, x.UPC, x.OutTrackingNumber, x.OrderId, x.Condition, x.Note, x.Listed, x.Location }).OrderByDescending(order => order.DateOfRcv).ToList();
                    dtInfo = ToDataSet(itemsDisposed);
                }
            }
            InitDataSet();
        }

        private void AddSelect()
        {
            DataGridViewCheckBoxColumn isSelected = new DataGridViewCheckBoxColumn();
            {
                isSelected.HeaderText = "Selected";
                isSelected.Name = "Selected";
                isSelected.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                isSelected.FlatStyle = FlatStyle.Standard;
                isSelected.CellTemplate = new DataGridViewCheckBoxCell();
                isSelected.CellTemplate.Style.BackColor = Color.Beige;
            }
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(isSelected);
        }

        public DataTable ToDataSet<T>(List<T> list)
        {
            Type elementType = typeof(T);
            var t = new DataTable();
            elementType.GetProperties().ToList().ForEach(propInfo => t.Columns.Add(propInfo.Name, Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType));
            foreach (T item in list)
            {
                var row = t.NewRow();
                elementType.GetProperties().ToList().ForEach(propInfo => row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value);
                t.Rows.Add(row);
            }
            return t;
        }
        private void InitDataSet()
        {
            //pageSize = Convert.ToInt32(toolStripComboBox1.Text);    //设置页面行数
            nMax = dtInfo.Rows.Count;

            pageCount = (nMax / pageSize);    //计算出总页数

            if ((nMax % pageSize) > 0) pageCount++;

            pageCurrent = 1;    //当前页数从1开始
            nCurrent = 0;       //当前记录数从0开始

            LoadData();
        }
        private void LoadData()
        {
            int nStartPos = 0;   //当前页面开始记录行
            int nEndPos = 0;     //当前页面结束记录行

            DataTable dtTemp = dtInfo.Clone();   //克隆DataTable结构框架

            if (pageCurrent == pageCount)
                nEndPos = nMax;
            else
                nEndPos = pageSize * pageCurrent;

            nStartPos = nCurrent;

            toolStripLabel1.Text = pageCount.ToString();
            toolStripTextBox1.Text = Convert.ToString(pageCurrent);
            itemCount.Text = Convert.ToString(dtInfo.Rows.Count);

            //从元数据源复制记录行
            if (dtInfo.Rows.Count == 0)
            {
                dataGridView1.DataSource = dtInfo;
                return;
            }
            for (int i = nStartPos; i < nEndPos; i++)
            {
                dtTemp.ImportRow(dtInfo.Rows[i]);
                nCurrent++;
            }
            BindingSource bdsInfo = new BindingSource();
            bdsInfo.DataSource = dtTemp;
            bindingNavigator1.BindingSource = bdsInfo;
            dataGridView1.DataSource = bdsInfo;
            setFridViewProperty();
        }
        //private void setWith()
        //{
        //    foreach (string name in width.Keys)
        //    {
        //        if (name == "DateOfOut" && InOrOut.Text == "Out Inventory")
        //        {
        //            this.dataGridView1.Columns[name].FillWeight = width[name];
        //        }
        //        else
        //        {
        //            this.dataGridView1.Columns[name].FillWeight = width[name];
        //        }
        //    }
        //}
        private void setPendingRowColor()
        {
            //using (ItemContext ctx = new ItemContext())
            //{
            //    ctx.Items.
            //}
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (((row.Cells["Pending"].Value == DBNull.Value) ? false : Convert.ToBoolean(row.Cells["Pending"].Value)) == true)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.DarkOrange;
            //    }
            //}

        }

        private void setFridViewProperty()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                //设置自定义排序
                if (column.Name == "Selected") continue;
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.Columns["ItemTitle"].FillWeight = itemTitleWidth;
            this.dataGridView1.Columns["Listed"].FillWeight = listedWidth;
            this.dataGridView1.Columns["DateOfRcv"].FillWeight = dateOfRCVWidth;
            if (InOrOut.Text == "Out Inventory")
            {
                this.dataGridView1.Columns["DateOfOut"].FillWeight = dateOfOutWidth;
                if(this.dataGridView1.Columns.Contains(dataGridView1.Columns["DateOfRcv"])) this.dataGridView1.Columns["DateOfRcv"].Visible = false;
            }
            this.dataGridView1.Columns["SN"].FillWeight = SNWidth;
            this.dataGridView1.Columns["Location"].FillWeight = locationWidth;
            if (InOrOut.Text == "In Inventory")
            {
                //this.dataGridView1.Columns["Pending"].Visible = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (((row.Cells["Pending"].Value == DBNull.Value) ? false : Convert.ToBoolean(row.Cells["Pending"].Value)) == true)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }
                this.dataGridView1.Columns["OriginalTrackingNum"].FillWeight = originalTrackingNumWidth;
                if (this.dataGridView1.Columns.Contains(dataGridView1.Columns["Pending"])) this.dataGridView1.Columns["Pending"].Visible = false;

            }
            this.dataGridView1.Columns["UPC"].FillWeight = UPCWidth;
            this.dataGridView1.Columns["Condition"].FillWeight = conditionWidth;
            this.dataGridView1.Columns["OrderId"].FillWeight = OrderIdWidth;
            this.dataGridView1.Columns["Note"].FillWeight = noteWidth;
            
            //width.Add("ItemTitle", itemTitleWidth);
            //width.Add("Listed", listedWidth);
            //width.Add("DateOfRcv", dateOfRCVWidth);
            //width.Add("SN", SNWidth);
            //width.Add("Location", locationWidth);
            //width.Add("OriginalTrackingNum", originalTrackingNumWidth);
            //width.Add("UPC", UPCWidth);
            //width.Add("Condition", conditionWidth);
            //width.Add("OrderId", OrderIdWidth);
            //width.Add("Note", noteWidth);
            //width.Add("DateOfOut", dateOfOutWidth);

            //width.Add("ItemTitle", 150);
            //width.Add("Listed", 100);
            //width.Add("DateOfRcv", 100);
            //width.Add("SN", 100);
            //width.Add("Location", 100);
            //width.Add("OriginalTrackingNum", 100);
            //width.Add("UPC", 100);
            //width.Add("Condition", 100);
            //width.Add("OrderId", 100);
            //width.Add("Note", 100);
            //width.Add("DateOfOut", 100);


            //setWith();
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ClearSelection();

            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            //dataGridView1.ReadOnly = true;
            //dataGridView1.RowHeadersVisible = false;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //float width = 0;
            //foreach (DataGridViewColumn col in dataGridView1.Columns)
            //{
            //    width += col.FillWeight;
            //}
            //if(width > 100)
            //{
            //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //}else
            //{
            //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //}

            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ////dataGridView1.RowTemplate.Height = 100;
            //dataGridView1.AllowUserToResizeRows = false;
            //dataGridView1.AllowUserToResizeColumns = true;
            //dataGridView1.AllowUserToAddRows = false;
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(toolStripComboBox1.Text == "All")
            {
                pageSize = nMax;
            }
            else
            {
                pageSize = Convert.ToInt32(toolStripComboBox1.Text.ToString());
            }
            InitDataSet();
            
        }
        private void bindingNavigator1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Previous Page")
            {
                pageCurrent--;
                if (pageCurrent <= 0)
                {
                    pageCurrent = 0;
                    return;
                }
                else
                {
                    nCurrent = pageSize * (pageCurrent - 1);
                }

                LoadData();
            }
            if (e.ClickedItem.Text == "Next Page")
            {
                pageCurrent++;
                if (pageCurrent > pageCount)
                {
                    pageCurrent = pageCount;
                    return;
                }
                else
                { 
                   nCurrent=pageSize*(pageCurrent-1);
                }
                LoadData();
            }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            if(toolStripTextBox1.Text.Trim().Length != 0 && Regex.IsMatch(toolStripTextBox1.Text.Trim().ToString(), StrRegex(3)))
            {
                if (Convert.ToInt32(toolStripTextBox1.Text) > 0 && Convert.ToInt32(toolStripTextBox1.Text) <= pageCount)
                {
                    pageCurrent = Convert.ToInt32(toolStripTextBox1.Text);
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }
            else if(!Regex.IsMatch(toolStripTextBox1.Text.Trim().ToString(), StrRegex(3)))
            {
                MessageBox.Show("The page can only be number.");
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selected = 0;//选中条目计数器
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected) selected += 1;
            }
            if (selected <= 1)//单选情况
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if(!row.Selected) row.Cells["Selected"].Value = false;//清空其他为选中条目
                    else dataGridView1.Rows[e.RowIndex].Cells["Selected"].Value = !Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Selected"].Value);
                }
            }
            else//多选情况
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.Selected)
                    {
                        row.Cells["Selected"].Value = false;
                    }
                    else
                    {
                        row.Cells["Selected"].Value = row.Selected;
                    }
                }
            }


            //dataGridView1.Rows[e.RowIndex].Cells["Selected"].Value = dataGridView1.Rows[e.RowIndex].Selected;

            //var first = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            //if (first >= 0)
            //{

            //dataGridView1.Rows[e.RowIndex].Cells["Selected"].Value = !Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Selected"].Value);

            //if (dataGridView1.Columns[e.ColumnIndex].Name == "Selected")
            //{
            //}
            //}

        }
        private void Clear_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (Convert.ToBoolean(row.Cells["isSelected"].Value))
            //    {
            //        MessageBox.Show(row.ToString());
            //    }
            //}
            ItemTitle.Text = "";
            RcvTime.Text = "";
            UPC.Text = "";
            SN.Text = "";
            OrderId.Text = "";
            location.Text = "";
            Condition.SelectedIndex = -1;
            toolStripComboBox1.SelectedIndex = toolStripComboBox1.SelectedIndex;
            pendingBox.Checked = false;
            RcvTime.Checked = false;
            Management_Load(this,e);
        }
        private void Add_Click(object sender, EventArgs e)
        {
            Item_In itemIn = new Item_In(uname);
            itemIn.Show();
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            int multi = 0;
            List<string> multiUpdateSN = new List<string>();
            var first = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            string snUpdate = this.dataGridView1.Rows[first].Cells["SN"].Value.ToString();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    multi += 1;
                    multiUpdateSN.Add(row.Cells["SN"].Value.ToString());
                }
            }
            if (multi > 1)
            {
                MultiUpdate mu = new MultiUpdate() { uname = uname, SN = multiUpdateSN };
                mu.ShowDialog();
            }
            else
            {
                if (first >= 0)
                {
                    Update up = new Update(snUpdate, uname, "serviceMan");
                    up.ShowDialog();
                    //if (utype == "serviceMan")
                    //{
                    //    Update sn = new Update(snUpdate, uname, utype);
                    //    sn.ShowDialog();
                    //}
                    //else
                    //{
                    //    Update sn = new Update(snUpdate);
                    //    sn.ShowDialog();
                    //}
                }
                else
                {
                    MessageBox.Show("Please Select One Item!");
                }

            }
            if (ItemTitle.Text.Length != 0 || OrderId.Text.Length != 0 || UPC.Text.Length != 0 || SN.Text.Length != 0 || RcvTime.Checked || Condition.Text.Length != 0 || pendingBox.Checked || location.Text.Trim().Length != 0)
            {
                Search_Click(this, e);
            }
            else
            {
                ReLoadData();
            }
            st.returnCurrentRow(snUpdate, dataGridView1);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //var first = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            //string snDelete = this.dataGridView1.Rows[first].Cells["SN"].Value.ToString();
            bool del = false;
            bool select = false;
            int indexDelete = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Selected"].Value))
                {
                    select = true;
                }
            }
            if (select)
            {
                if (MessageBox.Show("This item will be permanently deleted!", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Selected"].Value))
                        {
                            string snDelete = row.Cells["SN"].Value.ToString();
                            string oIdDelete = row.Cells["OrderId"].Value.ToString();
                            string inventoryDelete = InOrOut.Text.ToString();
                            indexDelete = indexDelete == 0 ? row.Index - 1 : indexDelete;

                            try
                            {
                                using (var ctx = new ItemContext())
                                {
                                    //int id = ctx.ItemBaks.Count() + 1;
                                    if (inventoryDelete == "In Inventory")
                                    {
                                        Item it = ctx.Items.Where(u => u.SN == snDelete).First<Item>();
                                        ctx.Items.Remove(it);
                                        ctx.SaveChanges();
                                        del = true;
                                    }
                                    else
                                    {

                                        //MessageBox.Show(id.ToString());
                                        ItemDisposed it = ctx.ItemsDisposed.Where(o => o.OrderId == oIdDelete).Where(u => u.SN == snDelete).First<ItemDisposed>();
                                        ItemBak bak = new ItemBak() { ItemTitle = it.ItemTitle, SN = it.SN, UPC = it.UPC, Condition = it.Condition, DateOfOut = it.DateOfOut, DateOfRcv = it.DateOfRcv, ItemInOperator = it.ItemInOperator,
                                        ItemOutOperator = it.ItemOutOperator, Listed = it.Listed, Location = it.Location, Note = it.Note, OrderId = it.OrderId,
                                        OriginalTrackingNum = it.OriginalTrackingNum, OutTrackingNumber = it.OutTrackingNumber, ReturnCode = it.ReturnCode, ServiceMan = it.ServiceMan};
                                        ctx.ItemBaks.Add(bak);
                                        ctx.ItemsDisposed.Remove(it);
                                        ctx.SaveChanges();
                                        del = true;
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                del = false;
                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                
                            }
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("No item selected!");
            }
            if (del)
            {
                //MessageBox.Show("Delete Successfully!");
                del = false;
                if (ItemTitle.Text.Length != 0 || OrderId.Text.Length != 0 || UPC.Text.Length != 0 || SN.Text.Length != 0 || RcvTime.Checked || Condition.Text.Length != 0 || pendingBox.Checked || location.Text.Trim().Length != 0)
                {
                    Search_Click(this, e);
                }
                else
                {
                    ReLoadData();
                }
                st.returnCurrentRow(indexDelete, dataGridView1);
            }
        }


        private void Search_Click(object sender, EventArgs e)
        {
            //具体判断条件根据最终数据结构确定
            if (ItemTitle.Text.Trim().Length != 0 || OrderId.Text.Trim().Length != 0 || UPC.Text.Trim().Length != 0 || SN.Text.Trim().Length != 0 || RcvTime.Checked || pendingBox.Checked || Condition.Text.Trim().Length != 0 || location.Text.Trim().Length != 0)
            {
                if (OrderId.Text.Trim().Length != 0 && !(Regex.IsMatch(Regex.Replace(OrderId.Text.Trim().ToString(), "-", ""), StrRegex(1))))
                {
                    //MessageBox.Show(orderId.Text.Trim().ToString().Split('-')[0].ToString());
                    MessageBox.Show("Order Number has to be number or alphabet!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (UPC.Text.Length != 0 && !(Regex.IsMatch(UPC.Text.Trim().ToString(), StrRegex(3))))
                {
                    MessageBox.Show("UPC has to be number!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (SN.Text.Trim().Length != 0 && !Regex.IsMatch(SN.Text.Trim().ToString(), StrRegex(1)))
                {
                    MessageBox.Show("SN has to be number or alphabet!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var ctx = new ItemContext())
                {
                    //var blur = ctx.Items.Where(title => title.ItemTitle.Contains(ItemTitle.Text.Trim()));

                    //var blur = ctx.Items.Where(a => true);

                    if (InOrOut.Text.Trim().ToString() == "Out Inventory")
                    {
                        var blur = ctx.ItemsDisposed.Select( x => new { x.ItemTitle, x.SN, x.DateOfRcv, x.DateOfOut, x.UPC, x.OriginalTrackingNum, x.OrderId, x.Note, x.Condition, x.Listed, x.Location }).OrderByDescending(order => order.DateOfRcv).Where(a => true);
                        if (ItemTitle.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(title => title.ItemTitle.Contains(ItemTitle.Text.Trim()));
                        }
                        if (UPC.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(upc => upc.UPC == UPC.Text.Trim());
                        }
                        if (OrderId.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(oid => oid.OrderId == OrderId.Text.Trim());
                        }
                        if (SN.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(sn => sn.SN.Contains(SN.Text.Trim()));
                        }
                        if (Condition.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(condition => condition.Condition.Contains(Condition.Text));
                        }
                        if(location.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(loc => loc.Location.Contains(location.Text));
                        }
                        if (this.RcvTime.Checked == true)
                        {
                            var rcv = Convert.ToDateTime(RcvTime.Text);
                            //MessageBox.Show(RcvTime.Text.ToString().Substring(0, 3));
                            //var tmp = blur.Select(time => time.DateOfRcv.ToString().Substring(0, 3));
                            //MessageBox.Show(tmp.ToList()[0].ToString());
                            blur = blur.Where(time => DbFunctions.DiffDays(time.DateOfRcv, rcv) == 0);
                            //blur = blur.Where(time => time.DateOfRcv == rcv);
                            
                        }
                        var blurResult = blur.OrderByDescending(order => order.DateOfRcv).ToList();
                        //AddSelect();
                        dtInfo = ToDataSet(blurResult);
                        InitDataSet();
                        //dataGridView1.DataSource = ToDataSet(blurResult);
                        //setFridViewProperty();
                    }
                    else
                    {
                        var blur = ctx.Items.Select(x => new { x.ItemTitle, x.SN, x.DateOfRcv, x.UPC, x.OriginalTrackingNum, x.OrderId, x.Note, x.Condition, x.Listed, x.Location,x.Pending }).OrderByDescending(order => order.DateOfRcv).Where(a=>true);
                        if (ItemTitle.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(title => title.ItemTitle.Contains(ItemTitle.Text.Trim()));
                        }
                        if (UPC.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(upc => upc.UPC == UPC.Text.Trim());
                        }
                        if (OrderId.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(oid => oid.OrderId == OrderId.Text.Trim());
                        }
                        if (SN.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(sn => sn.SN.Contains(SN.Text.Trim()));
                        }
                        if (Condition.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(condition => condition.Condition.Contains(Condition.Text));
                        }
                        if (pendingBox.Checked == true)
                        {
                            blur = blur.Where(pending => pending.Pending == true);
                        }
                        if (location.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(loc => loc.Location.Contains(location.Text));
                        }
                        if (this.RcvTime.Checked == true)
                        {
                            var rcv = Convert.ToDateTime(RcvTime.Text);
                            blur = blur.Where(time => DbFunctions.DiffDays(time.DateOfRcv, rcv) == 0);
                            
                        }
                        //var blurResult = blur.Select(x => new { x.ItemTitle, x.SN, x.DateOfRcv, x.UPC, x.OriginalTrackingNum, x.OrderId, x.Note, x.Condition, x.Listed, x.Location }).ToList();
                        //AddSelect();
                        var blurResult = blur.ToList();
                        dtInfo = ToDataSet(blurResult);
                        InitDataSet();
                        //setFridViewProperty();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input at least one condition!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ItemOut_Click(object sender, EventArgs e)
        {
            bool select = false;
            string outTrackingNum = "";
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Selected"].Value))
                {
                    select = true;
                }
            }
            if (select)
            {
                ConfirmForm cf = new ConfirmForm(outTrackingNum);
                cf.ShowDialog();
                outTrackingNum = cf.getTracking();
                if (outTrackingNum.Length == 0)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("No item selected.");
                return;
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Selected"].Value))
                {
                    string itemOut = row.Cells["SN"].Value.ToString();

                    using (var ctx = new ItemContext())
                    {
                        //var it = ctx.Items.Where(sn => sn.SN == itemOut);
                        var item = ctx.Items.Where(sn => sn.SN == itemOut).First();
                        ItemDisposed itemDis = new ItemDisposed();
                        {
                            itemDis.ItemTitle = row.Cells["ItemTitle"].Value.ToString();
                            itemDis.SN = row.Cells["SN"].Value.ToString();
                            itemDis.UPC = row.Cells["UPC"].Value.ToString();
                            itemDis.OrderId = row.Cells["OrderId"].Value.ToString();
                            itemDis.DateOfRcv = Convert.ToDateTime(row.Cells["DateOfRcv"].Value);
                            itemDis.DateOfOut = DateTime.Now;
                            itemDis.OriginalTrackingNum = row.Cells["OriginalTrackingNum"].Value.ToString();
                            itemDis.OutTrackingNumber = outTrackingNum;
                            itemDis.Condition = row.Cells["Condition"].Value.ToString();
                            itemDis.Listed = row.Cells["Listed"].Value.ToString();
                            itemDis.ItemInOperator = item.ItemInOperator;
                            itemDis.ServiceMan = item.ServiceMan;
                            itemDis.ItemOutOperator = uname;
                            itemDis.Note = row.Cells["Note"].Value.ToString();
                            itemDis.ReturnCode = item.ReturnCode;
                            itemDis.Location = row.Cells["Location"].Value.ToString();
                        }
                        ctx.ItemsDisposed.Add(itemDis);
                        ctx.SaveChanges();
                    }
                }
            }
            Delete_Click(this, e);
        }

        private void InOrOut_CheckedChanged(object sender, EventArgs e)
        {
            if (InOrOut.Checked)
            {
                InOrOut.Text = "In Inventory";
            }
            else
            {
                InOrOut.Text = "Out Inventory";
            }
            Clear_Click(this, e);
            //Management_Load(this, e);

        }
        public static string StrRegex(int iType)
        {
            switch (iType)
            {
                //number+alphabet
                case 1: return "^[A-Za-z0-9,]+$";
                //alphabet+number+chinese
                case 2: return "^[a-zA-Z0-9\u4e00-\u9fa5]+$";
                //number
                default: return "^[0-9]*$";
            }
        }

        private void ReadyToOut_Click(object sender, EventArgs e)
        {
            int position = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            string currentRow = dataGridView1.Rows[position].Cells["SN"].Value.ToString();
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (Convert.ToBoolean(row.Cells["Selected"].Value))
                    {
                        using (var ctx = new ItemContext())
                        {
                            string rdy = row.Cells["SN"].Value.ToString();
                            var pending = ctx.Items.Where(sn => sn.SN == rdy).Select(x=>x.Pending).First();
                            var condition = ctx.Items.Where(sn => sn.SN == rdy).Select(x => x.Condition).First();
                            if(pending == null)
                            {
                                pending = false;
                            }
                            if(condition == null)
                            {
                                MessageBox.Show("The item without condition cannot set to rdy.");
                                return;
                            }
                            if (condition.Contains("unchecked")||condition.Contains("Unchecked")||condition.Contains("Defective"))
                            {
                                MessageBox.Show(condition.ToString() + " Item Cannot set to rdy to out");
                                return;
                            }
                            Item ite = new Item() {SN = row.Cells["SN"].Value.ToString(), Pending = !Convert.ToBoolean(pending.Value) };
                            ctx.Entry<Item>(ite).State = EntityState.Unchanged;
                            ctx.Entry<Item>(ite).Property(p => p.Pending).IsModified = true;
                            ctx.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (ItemTitle.Text.Length != 0 || OrderId.Text.Length != 0 || UPC.Text.Length != 0 || SN.Text.Length != 0 || RcvTime.Checked || Condition.Text.Length != 0 || pendingBox.Checked || location.Text.Trim().Length != 0)
                {
                    Search_Click(this, e);
                }
                else
                {
                    ReLoadData();
                }
                st.returnCurrentRow(currentRow, dataGridView1);
            }
        }

        private void moreInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if(item >= 0)
            {
                string snDetail = this.dataGridView1.Rows[item].Cells["SN"].Value.ToString();
                string orderDetail = this.dataGridView1.Rows[item].Cells["OrderId"].Value.ToString();
                Detail detail = new Detail(snDetail, orderDetail, InOrOut.Text);
                detail.ShowDialog();
            }
            else
            {
                MessageBox.Show("Pleas select one item!");
            }
            
        }


        private void multipleDeleteButton_Click(object sender, EventArgs e)
        {
            DateTime time1 = Convert.ToDateTime(clearDatePicker.Text);
            if (MessageBox.Show("The Log before " + time1.Date + " will be deleted", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                using (ItemContext ctx = new ItemContext())
                {

                    var list = ctx.ItemsDisposed.Where(a => a.DateOfOut.CompareTo(time1) < 0);
                    foreach (var it in list)
                    {
                        ItemBak bak = new ItemBak()
                        {
                            ItemTitle = it.ItemTitle,
                            SN = it.SN,
                            UPC = it.UPC,
                            Condition = it.Condition,
                            DateOfOut = it.DateOfOut,
                            DateOfRcv = it.DateOfRcv,
                            ItemInOperator = it.ItemInOperator,
                            ItemOutOperator = it.ItemOutOperator,
                            Listed = it.Listed,
                            Location = it.Location,
                            Note = it.Note,
                            OrderId = it.OrderId,
                            OriginalTrackingNum = it.OriginalTrackingNum,
                            OutTrackingNumber = it.OutTrackingNumber,
                            ReturnCode = it.ReturnCode,
                            ServiceMan = it.ServiceMan
                        };
                        ctx.ItemBaks.Add(bak);
                        ctx.ItemsDisposed.Remove(it);
                    }
                    ctx.SaveChanges();
                    MessageBox.Show("Clearance Successfully!");
                }
            Management_Load(this, e);
        }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //if(dataGridView1.Columns.Contains(dataGridView1.Columns["ItemTitle"])) MessageBox.Show(dataGridView1.Columns["ItemTitle"].FillWeight.ToString());

            //itemTitleWidth = (dataGridView1.Columns.Contains(dataGridView1.Columns["ItemTitle"])) ? Convert.ToInt32(dataGridView1.Columns["ItemTitle"].Width) : itemTitleWidth;
            //listedWidth = (dataGridView1.Columns.Contains(dataGridView1.Columns["Listed"])) ? itemTitleWidth : Convert.ToInt32(dataGridView1.Columns["Listed"].FillWeight);
            //SNWidth = (dataGridView1.Columns.Contains(dataGridView1.Columns["SN"])) ? itemTitleWidth : Convert.ToInt32(dataGridView1.Columns["SN"].FillWeight);
            //locationWidth = (dataGridView1.Columns.Contains(dataGridView1.Columns["Location"])) ? itemTitleWidth : Convert.ToInt32(dataGridView1.Columns["Location"].FillWeight);
            //UPCWidth = (dataGridView1.Columns.Contains(dataGridView1.Columns["UPC"])) ? itemTitleWidth : Convert.ToInt32(dataGridView1.Columns["UPC"].FillWeight);
            //conditionWidth = (dataGridView1.Columns.Contains(dataGridView1.Columns["Condition"])) ? itemTitleWidth : Convert.ToInt32(dataGridView1.Columns["Condition"].FillWeight);
            //OrderIdWidth = (dataGridView1.Columns.Contains(dataGridView1.Columns["OrderId"])) ? itemTitleWidth : Convert.ToInt32(dataGridView1.Columns["OrderId"].FillWeight);
            //noteWidth = (dataGridView1.Columns.Contains(dataGridView1.Columns["Note"])) ? itemTitleWidth : Convert.ToInt32(dataGridView1.Columns["Note"].FillWeight);

            //if (InOrOut.Text == "Out Inventory")
            //{
            //    dateOfOutWidth = (dataGridView1.Columns.Contains(dataGridView1.Columns["DateOfOut"])) ? itemTitleWidth : Convert.ToInt32(dataGridView1.Columns["DateOfOut"].FillWeight);
            //    originalTrackingNumWidth = (dataGridView1.Columns.Contains(dataGridView1.Columns["OutTrackingNum"])) ? itemTitleWidth : Convert.ToInt32(dataGridView1.Columns["OutTrackingNum"].FillWeight);
            //}
            //if (InOrOut.Text == "In Inventory")
            //{
            //    dateOfRCVWidth = (dataGridView1.Columns.Contains(dataGridView1.Columns["DateOfRcv"])) ? itemTitleWidth : Convert.ToInt32(dataGridView1.Columns["DateOfRcv"].FillWeight);
            //}

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;//将当前单元格设为可读
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];//获取当前单元格
            this.dataGridView1.BeginEdit(true);//将单元格设为编辑状态
        }


        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.Selected = true;
                row.Cells["Selected"].Value = true;
               
            }
        }
        private void clearSelectionStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.Selected = false;
                row.Cells["Selected"].Value = false;
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   if (e.ColumnIndex<=0) return;
            if (dataGridView1.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.Programmatic)
            {
                string columnBindingName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
                switch (dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection)
                {
                    case SortOrder.None:
                    case SortOrder.Ascending:
                        CustomSort(columnBindingName, "desc");
                        dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        CustomSort(columnBindingName, "asc");
                        dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                        break;
                }
            }
        }
        private void CustomSort(string columnBindingName, string sortMode)
        {
            DataView dv = dtInfo.DefaultView;
            
            dv.Sort = columnBindingName + " " + sortMode;
            dataGridView1.DataSource = dv.ToTable();
            if(InOrOut.Text =="In Inventory")
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (((row.Cells["Pending"].Value == DBNull.Value) ? false : Convert.ToBoolean(row.Cells["Pending"].Value)) == true)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }
            }
            dataGridView1.Refresh();
        }
    }
}


