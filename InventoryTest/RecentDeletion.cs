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
            using (var ctx = new ItemContext())
            {

                var itemsBak = ctx.ItemsBak.OrderByDescending(order => order.DateOfRcv).ToList();
                dataGridView1.DataSource = ToDataSet(itemsBak);
            }
            setFridViewProperty();
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
        private void setFridViewProperty()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.ClearSelection();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            var time1 = Convert.ToDateTime(dateTimePicker1.Text);
            if (MessageBox.Show("The Log before " + time1.Date + " will be deleted", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                using (ItemContext ctx = new ItemContext())
                {

                    var list = ctx.ItemsBak.Where(a => a.DateOfRcv.CompareTo(time1) < 0);
                    foreach (var ite in list)
                    {
                        ctx.ItemsBak.Remove(ite);
                    }
                    ctx.SaveChanges();
                    MessageBox.Show("Clearance Successfully!");
                }
            RecentDeletion_Load(this, e);
        }
    }
}
