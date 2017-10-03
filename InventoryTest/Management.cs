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

        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行
        DataTable dtInfo = new DataTable();

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
            using (var ctx = new ItemContext())
            {
                AddSelect();
                if (InOrOut.Text.Trim().ToString() == "In Inventory")
                {
                    var items = ctx.Items.OrderByDescending(order => order.DateOfRcv).ToList();
                    dtInfo = ToDataSet(items);
                    InitDataSet();
                    SetAuthority(utype);
                }
                else
                {
                    var itemsDisposed = ctx.ItemsDisposed.OrderByDescending(order => order.DateOfRcv).ToList();
                    dtInfo = ToDataSet(itemsDisposed);
                    InitDataSet();
                    Add.Enabled = false;
                    Modify.Enabled = false;
                    pendingBox.Enabled = false;
                    ItemOut.Enabled = false;
                    ReadyToOut.Enabled = false;
                }
            }
            setFridViewProperty();
        }
        private void AddSelect()
        {
            DataGridViewCheckBoxColumn isSelected = new DataGridViewCheckBoxColumn();
            {
                isSelected.HeaderText = "isSelected";
                isSelected.Name = "isSelected";
                isSelected.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                isSelected.FlatStyle = FlatStyle.Standard;
                isSelected.CellTemplate = new DataGridViewCheckBoxCell();
                isSelected.CellTemplate.Style.BackColor = Color.Beige;
            }
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(isSelected);
        }
/*        private void LoadDGV()
        {
            using (var ctx = new ItemContext())
            {
                //var items = ctx.Items.OrderBy(d => d.DateOfRcv).Select(a => new { a.ItemTitle, a.OrderId, a.SN, a.UPC, a.DateOfRcv, a.Condition, a.Operator }).ToList();
                ////var itemsBind = new BindingSource();
                ////itemsBind.DataSource = items;
                ////DataSet ds = new DataSet();
                ////SqlDataAdapter da = new SqlDataAdapter();


                ////MessageBox.Show(items[0].ToString());
                //var i = ToDataSet(items);

                //dataGridView1.DataSource = i;
                //dataGridView1.Columns[0].HeaderText = "ItemTitle";
                //dataGridView1.Columns[1].HeaderText = "OrderId";
                //dataGridView1.Columns[2].HeaderText = "SN";
                //dataGridView1.Columns[3].HeaderText = "UPC";
                //dataGridView1.Columns[4].HeaderText = "Condition";
                //dataGridView1.Columns[5].HeaderText = "DateOfRcv";
                //dataGridView1.Columns[6].HeaderText = "Operator";

                AddSelect();
                if (InOrOut.Text.Trim().ToString() == "In Inventory")
                {
                    var items = ctx.Items.ToList();
                    //BindingSource bs = new BindingSource();
                    //bs.DataSource = ToDataSet(items);
                    //bindingNavigator1.BindingSource = bs;
                    dtInfo = ToDataSet(items);
                    InitDataSet();
                    //dataGridView1.DataSource = dtInfo;
                    SetAuthority(utype);
                }
                else
                //if(InOrOut.Text.Trim().ToString() == "Out Inventory")
                {
                    var itemsDisposed = ctx.ItemsDisposed.ToList();
                    //BindingSource bs = new BindingSource();
                    //bs.DataSource = ToDataSet(itemsDisposed);
                    //bindingNavigator1.BindingSource = bs;
                    dtInfo = ToDataSet(itemsDisposed);
                    InitDataSet();
                    //dataGridView1.DataSource = dtInfo;
                    Add.Enabled = false;
                    Modify.Enabled = false;
                    pendingBox.Enabled = false;
                    ItemOut.Enabled = false;
                    ReadyToOut.Enabled = false;
                }
            }
            setFridViewProperty();
        }*/

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
            pageSize = 50;      //设置页面行数
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
        }
        private void setFridViewProperty()
        {
            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.ClearSelection();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.RowTemplate.Height = 100;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToAddRows = false;
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var first = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (first >= 0) { dataGridView1.Rows[first].Cells["isSelected"].Value = !Convert.ToBoolean(dataGridView1.Rows[first].Cells["isSelected"].Value); }

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
            Condition.Text = "";
            pendingBox.Checked = false;
            Management_Load(this, e);
        }
        private void Add_Click(object sender, EventArgs e)
        {
            Item_In itemIn = new Item_In(uname);
            itemIn.ShowDialog();
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            var first = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (first >= 0)
            {
                string snUpdate = this.dataGridView1.Rows[first].Cells["SN"].Value.ToString();
                if (utype == "serviceMan")
                {
                    Update sn = new Update(snUpdate, uname, utype);
                    sn.ShowDialog();
                }
                else
                {
                    Update sn = new Update(snUpdate);
                    sn.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Please Select One Item!");
            }
            InitDataSet();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //var first = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            //string snDelete = this.dataGridView1.Rows[first].Cells["SN"].Value.ToString();
            bool del = false;
            bool select = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells["isSelected"].Value))
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
                        if (Convert.ToBoolean(row.Cells["isSelected"].Value))
                        {
                            string snDelete = row.Cells["SN"].Value.ToString();
                            string inventoryDelete = InOrOut.Text.ToString();
                            try
                            {
                                using (var ctx = new ItemContext())
                                {
                                    if (inventoryDelete == "In Inventory")
                                    {
                                        Item it = ctx.Items.Where(u => u.SN == snDelete).First<Item>();
                                        ctx.Items.Remove(it);
                                        ctx.SaveChanges();
                                        del = true;
                                    }
                                    else
                                    {
                                        ItemDisposed it = ctx.ItemsDisposed.Where(u => u.SN == snDelete).FirstOrDefault<ItemDisposed>();
                                        ItemBak bak = new ItemBak() { ItemTitle = it.ItemTitle, SN = it.SN, UPC = it.UPC, Condition = it.Condition, DateOfOut = it.DateOfOut, DateOfRcv = it.DateOfRcv, ItemInOperator = it.ItemInOperator,
                                        ItemOutOperator = it.ItemOutOperator, Listed = it.Listed, Location = it.Location, LPN = it.LPN, Note = it.Note, OrderId = it.OrderId,
                                        OriginalTrackingNum = it.OriginalTrackingNum, OutTrackingNumber = it.OutTrackingNumber, ReturnCode = it.ReturnCode, ServiceMan = it.ServiceMan};
                                        ctx.ItemsBak.Add(bak);
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
                MessageBox.Show("Delete Successfully!");
                del = false;
                InitDataSet();
            }
        }


        private void Search_Click(object sender, EventArgs e)
        {
            //具体判断条件根据最终数据结构确定
            if (ItemTitle.Text.Trim().Length != 0 || OrderId.Text.Trim().Length != 0 || UPC.Text.Trim().Length != 0 || SN.Text.Trim().Length != 0 || RcvTime.Checked ||pendingBox.Checked|| Condition.Text.Trim().Length != 0)
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
                        var blur = ctx.ItemsDisposed.OrderByDescending(order => order.DateOfRcv).Where(a => true);
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
                            blur = blur.Where(sn => sn.SN == SN.Text.Trim());
                        }
                        if (Condition.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(condition => condition.Condition == Condition.Text);
                        }
                        if (this.RcvTime.Checked == true)
                        {
                            var rcv = Convert.ToDateTime(RcvTime.Text);
                            //MessageBox.Show(RcvTime.Text.ToString().Substring(0, 3));
                            //var tmp = blur.Select(time => time.DateOfRcv.ToString().Substring(0, 3));
                            //MessageBox.Show(tmp.ToList()[0].ToString());
                            blur = blur.Where(time => DbFunctions.DiffDays(time.DateOfRcv, rcv) == 0);
                            //blur = blur.Where(time => time.DateOfRcv == rcv);
                            RcvTime.Checked = false;
                        }
                        var blurResult = blur.ToList();
                        //AddSelect();
                        dtInfo = ToDataSet(blurResult);
                        InitDataSet();
                        //dataGridView1.DataSource = ToDataSet(blurResult);
                        setFridViewProperty();
                    }
                    else
                    {
                        var blur = ctx.Items.Where(a => true);
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
                            blur = blur.Where(sn => sn.SN == SN.Text.Trim());
                        }
                        if (Condition.Text.Trim().Length != 0)
                        {
                            blur = blur.Where(condition => condition.Condition == Condition.Text);
                        }
                        if (pendingBox.Checked == true)
                        {
                            blur = blur.Where(pending => pending.Pending == true);
                        }
                        if (this.RcvTime.Checked == true)
                        {
                            var rcv = Convert.ToDateTime(RcvTime.Text);
                            blur = blur.Where(time => DbFunctions.DiffDays(time.DateOfRcv, rcv) == 0);
                            RcvTime.Checked = false;
                        }
                        var blurResult = blur.ToList();
                        //AddSelect();
                        dtInfo = ToDataSet(blurResult);
                        InitDataSet();
                        setFridViewProperty();
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
                if (Convert.ToBoolean(row.Cells["isSelected"].Value))
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
                if (Convert.ToBoolean(row.Cells["isSelected"].Value))
                {
                    string itemOut = row.Cells["SN"].Value.ToString();

                    using (var ctx = new ItemContext())
                    {
                        //var it = ctx.Items.Where(sn => sn.SN == itemOut);
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
                            itemDis.ItemInOperator = row.Cells["ItemInOperator"].Value.ToString();
                            itemDis.ServiceMan = row.Cells["ServiceMan"].Value.ToString();
                            itemDis.ItemOutOperator = uname;
                            itemDis.LPN = row.Cells["LPN"].Value.ToString();
                            itemDis.Note = row.Cells["Note"].Value.ToString();
                            itemDis.ReturnCode = row.Cells["ReturnCode"].Value.ToString();
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

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["isSelected"].Value))
                    {
                        using (var ctx = new ItemContext())
                        {
                            Item ite = new Item() {SN = row.Cells["SN"].Value.ToString(), Pending = !Convert.ToBoolean(row.Cells["Pending"].Value) };
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
                Clear_Click(this, e);
            }
        }

    }
}


