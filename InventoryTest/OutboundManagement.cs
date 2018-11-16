using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryTest
{
    public partial class OutboundManagement : Form
    {
        string utype;
        string uname;

        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行
        DataTable dtInfo = new DataTable();
        SetPositionTool st = new SetPositionTool();
        public OutboundManagement(string uname, string utype)
        {
            this.uname = uname;
            this.utype = utype;
            InitializeComponent();
        }
        private void SetAuthority(string utype)
        {
            if (utype == "admin")
            {
                //admin mode
                //multiple delete
                label7.Visible = true;
                clearDatePicker.Visible = true;
                multipleDeleteButton.Visible = true;

            }
            else
            {
                //normal mode
                Modify.Enabled = false;
            }
        }

        private void OutboundManagement_Load(object sender, EventArgs e)
        {

            ReLoadData();
            SetAuthority(utype);
        }
        private void ReLoadData()
        {
            AddSelect();

            using (ItemContext ctx = new ItemContext())
            {
                var itemOutbounds = ctx.ItemOutbounds.Where(x => x.isDelete == false).Select(x => new { x.ItemOutboundId, x.TrackingNum, x.ItemTitle, x.Qty, x.SN, x.Manipulator, x.Date }).OrderByDescending(order => order.Date).ToList();
                dtInfo = ToDataSet(itemOutbounds);
            }


            InitDataSet();
        }

        private void AddSelect()
        {
            DataGridViewCheckBoxColumn isSelected = new DataGridViewCheckBoxColumn();
            {
                isSelected.HeaderText = "Selected";
                isSelected.Name = "Selected";
                isSelected.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            //ugly caculation of pagesize
            pageSize = pageSize == 0 ? nMax : pageSize;
            pageSize = pageSize > nMax ? nMax : pageSize;
            if (toolStripComboBox1.SelectedIndex == -1 || toolStripComboBox1.SelectedIndex == 5) { pageSize = nMax; }
            if (pageSize == 0) { pageSize = 1; }

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
        private void setFridViewProperty()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                //设置自定义排序
                if (column.GetType() == typeof(DataGridViewCheckBoxColumn))
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                else
                {
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            }
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.Columns["ItemTitle"].FillWeight = 150;
            this.dataGridView1.Columns["ItemOutboundId"].FillWeight = 30;
            this.dataGridView1.Columns["Date"].FillWeight = 50;
            this.dataGridView1.Columns["TrackingNum"].FillWeight = 100;
            this.dataGridView1.Columns["Selected"].FillWeight = 30;
            this.dataGridView1.Columns["Qty"].FillWeight = 30;
            this.dataGridView1.Columns["SN"].FillWeight = 150;
            //this.dataGridView1.Columns["SN"].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.Columns["Manipulator"].FillWeight = 30;

            /*FillWeights
             * 
             * 
             * 
             * 
             */
            dataGridView1.ClearSelection();
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text == "All")
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
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {

            if (toolStripTextBox1.Text.Trim().Length != 0 && Regex.IsMatch(toolStripTextBox1.Text.Trim().ToString(), StrRegex(3)))
            {
                if (Convert.ToInt32(toolStripTextBox1.Text) > 0 && Convert.ToInt32(toolStripTextBox1.Text) <= pageCount)
                {
                    pageCurrent = Convert.ToInt32(toolStripTextBox1.Text);
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }
            else if (!Regex.IsMatch(toolStripTextBox1.Text.Trim().ToString(), StrRegex(3)))
            {
                MessageBox.Show("The page can only be number.");
            }
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            int selected = 0;//选中条目计数器
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected) selected += 1;
            }
            if (selected <= 1)//单选情况
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.Selected) row.Cells["Selected"].Value = false;//清空其他为选中条目
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

            selectedCount.Text = selected.ToString();
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            //form clearance
            ItemTitle.Text = "";
            OutBoundDate.Text = "";
            SN.Text = "";
            Manipulator.Text = "";
            TrackingNum.Text = "";
            OutBoundDate.Checked = false;
            //items/page
            toolStripComboBox1.SelectedIndex = toolStripComboBox1.SelectedIndex;
            OutboundManagement_Load(this, e);

        }

        private void Add_Click(object sender, EventArgs e)
        {
            OutboundItemAdd outboundItemAdd = new OutboundItemAdd(uname);
            outboundItemAdd.Show();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
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
                if (MessageBox.Show("This record will be deleted!", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Selected"].Value))
                        {
                            int idDelete = Convert.ToInt32(row.Cells["ItemOutboundId"].Value.ToString());
                            indexDelete = indexDelete == 0 ? row.Index - 1 : indexDelete;
                            //string trackingDelete = row.Cells["TrackingNum"].Value.ToString();
                            try
                            {
                                using (var ctx = new ItemContext())
                                {
                                    ItemOutbound itemOutboundDel = new ItemOutbound();
                                    itemOutboundDel.ItemOutboundId = idDelete;
                                    itemOutboundDel.isDelete = true;
                                    ctx.ItemOutbounds.Attach(itemOutboundDel);
                                    ctx.Entry(itemOutboundDel).Property(x => x.isDelete).IsModified = true;
                                    ctx.SaveChanges();
                                    del = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                del = false;
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No item selected!");
            }
            if (del) // deleted
            {
                del = false;
                if (ItemTitle.Text.Length != 0 || SN.Text.Length != 0 ||
                    OutBoundDate.Checked || Manipulator.Text.Length != 0
                     || TrackingNum.Text.Trim().Length != 0)
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
            try
            {
                using (ItemContext ctx = new ItemContext())
                {
                    var res = ctx.ItemOutbounds.Where(x => x.isDelete == false).Select(x => new { x.ItemOutboundId, x.TrackingNum, x.ItemTitle, x.Qty, x.SN, x.Manipulator, x.Date }).OrderByDescending(order => order.Date).Where(a => true);
                    if (ItemTitle.Text.Trim().Length != 0)
                    {
                        res = res.Where(title => title.ItemTitle.Contains(ItemTitle.Text.Trim()));
                    }
                    if (Manipulator.Text.Trim().Length != 0)
                    {
                        res = res.Where(m => m.Manipulator == Manipulator.Text.Trim());
                    }
                    if (SN.Text.Trim().Length != 0)
                    {
                        res = res.Where(s => s.SN.Contains(SN.Text.Trim()));
                    }
                    if (TrackingNum.Text.Trim().Length != 0)
                    {
                        res = res.Where(tracking => tracking.TrackingNum.Contains(TrackingNum.Text.Trim()));
                        //res = res.Where(tracking => tracking.TrackingNum == TrackingNum.Text.Trim());
                    }
                    if (this.OutBoundDate.Checked == true)
                    {
                        var obd = Convert.ToDateTime(OutBoundDate.Text);
                        res = res.Where(time => DbFunctions.DiffDays(time.Date, obd) == 0);
                    }
                    var list = res.ToList();
                    dtInfo = ToDataSet(list);
                    InitDataSet();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            int first = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            string idxUpdate = this.dataGridView1.Rows[first].Cells["ItemOutboundId"].Value.ToString();
            if (first >= 0)
            {
                OutboundModify modified = new OutboundModify(Convert.ToInt32(idxUpdate));
                modified.ShowDialog();
            }
            if (ItemTitle.Text.Length != 0 || SN.Text.Length != 0 || Manipulator.Text.Length != 0 ||
                OutBoundDate.Checked || TrackingNum.Text.Trim().Length != 0)
            {
                Search_Click(this, e);
            }
            else
            {
                ReLoadData();
            }
            st.returnCurrentOutboundRow(idxUpdate, dataGridView1);
        }

        //private void multipleDeleteButton_Click(object sender, EventArgs e)
        //{
        //    DateTime time1 = Convert.ToDateTime(clearDatePicker.Text);
        //    if (MessageBox.Show("The Log before " + time1.Date + " will be deleted", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //        using (ItemContext ctx = new ItemContext())
        //        {

        //            var list = ctx.ItemOutbounds.Where(a=>a.isDelete == false).Where(a => a.Date.CompareTo(time1) < 0);
        //            foreach (var it in list)
        //            {
        //                it.isDelete = true;
        //                ctx.ItemOutbounds.Attach(it);
        //                ctx.Entry(it).Property(x => x.isDelete).IsModified = true;
        //            };
        //            ctx.SaveChanges();
        //            MessageBox.Show("Clearance Successfully!");
        //        }
        //    OutboundManagement_Load(this, e);
        //}

        private void SaveToLocal_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.Description = "Pleas Choose a Path:";
            string file;

            if (path.ShowDialog() == DialogResult.OK)
            {
                //file = path.SafeFileName;
                file = path.SelectedPath;
            }
            else
            {
                return;
            }

            using (ItemContext ctx = new ItemContext())
            {
                try
                {
                    var ib = ctx.ItemOutbounds.Where(available => available.isDelete == false).Select(x => new
                    {
                        x.TrackingNum,
                        x.ItemTitle,
                        x.SN,
                        x.Date,
                        x.Manipulator,
                        x.Qty
                    }).ToList();
                    DataTable dt = ToDataSet(ib);
                    ExcelTool et = new ExcelTool(dt, file);
                    MessageBox.Show(et.writeToExcel());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.Programmatic)
            {
                string columnBindingName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
                switch (dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection)
                {
                    case SortOrder.None:
                    case SortOrder.Ascending:
                        //CustomSort(dataGridView1.Columns[e.ColumnIndex], ListSortDirection.Descending);
                        CustomSort(columnBindingName, "desc");
                        dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        //CustomSort(dataGridView1.Columns[e.ColumnIndex], ListSortDirection.Ascending);
                        CustomSort(columnBindingName, "asc");
                        dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                        break;
                }
            }
        }
        private void CustomSort(string columnBindingName, string sortMode)
        {
            DataTable dt = dtInfo;
            DataView dv = dt.DefaultView;
            dv.Sort = columnBindingName + " " + sortMode;
            dataGridView1.DataSource = dv.ToTable();
            setFridViewProperty();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //this.dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            if (e.RowIndex >= 0)
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;//将当前单元格设为可读
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];//获取当前单元格
                this.dataGridView1.BeginEdit(true);//将单元格设为编辑状态
                Clipboard.SetText(dataGridView1.CurrentCell.Value == null ? "" : dataGridView1.CurrentCell.Value.ToString());
            }

        }
    }
}
