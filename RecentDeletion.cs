using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace InventoryTest
{
    public partial class RecentDeletion : Form
    {
        
        public RecentDeletion()
        {
            InitializeComponent();
        }

        private void RecentDeletion_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryManagementDataSet.ItemBaks' table. You can move, or remove it, as needed.
            this.itemBaksTableAdapter.Fill(this.inventoryManagementDataSet.ItemBaks);


            //using (var ctx = new ItemContext())
            //{

            //    var itemsBak = ctx.ItemBaks.OrderByDescending(order => order.DateOfRcv).ToList();
            //    dataGridView1.DataSource = ToDataSet(itemsBak);
            //}
            //setFridViewProperty();
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
        //private void setFridViewProperty()
        //{
        //    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dataGridView1.ReadOnly = true;
        //    dataGridView1.ClearSelection();
        //    dataGridView1.RowHeadersVisible = false;
        //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        //    dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //    dataGridView1.AllowUserToResizeRows = false;
        //    dataGridView1.AllowUserToResizeColumns = true;
        //    dataGridView1.AllowUserToAddRows = false;
        //}

        private void Clear_Click(object sender, EventArgs e)
        {
            DateTime time1 = Convert.ToDateTime(dateTimePicker1.Text);
            if (MessageBox.Show("The Log before " + time1.Date + " will be deleted", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                using (ItemContext ctx = new ItemContext())
                {

                    var list = ctx.ItemBaks.Where(a => a.DateOfOut.CompareTo(time1) < 0);
                    foreach (var ite in list)
                    {
                        ctx.ItemBaks.Remove(ite);
                    }
                    ctx.SaveChanges();
                    MessageBox.Show("Clearance Successfully!");
                }
            RecentDeletion_Load(this, e);
        }


        private void Save_Click(object sender, EventArgs e)
        {
            //OpenFileDialog path = new OpenFileDialog();
            //path.Title = "Please Choose a Path:";
            //path.Filter = "Excel Document(*.xls)|*.xls";
            //path.Multiselect = false;

            FolderBrowserDialog path = new FolderBrowserDialog();
            path.Description = "Pleas Choose a Path:";
            string file;
            DateTime time1 = Convert.ToDateTime(dateTimePicker1.Text);

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
                    var ib = ctx.ItemBaks.Select(x => new { x.ItemTitle, x.SN, x.DateOfRcv, x.DateOfOut,
                        x.UPC, x.OriginalTrackingNum, x.OrderId, x.Note, x.Condition,
                        x.Listed, x.ReturnCode,x.OutTrackingNumber,x.ItemOutOperator })
                        .Where(a => a.DateOfOut.CompareTo(time1) < 0).ToList();
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
    }
}
