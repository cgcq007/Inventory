using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryTest
{
    public partial class Recycle_Bin : Form
    {
        public Recycle_Bin()
        {
            InitializeComponent();
        }

        private void Recycle_Bin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'inventoryManagementDataSet1.ItemOutbounds' table. You can move, or remove it, as needed.
            this.itemOutboundsTableAdapter.Fill(this.inventoryManagementDataSet1.ItemOutbounds);
            fillBy1ToolStripButton_Click(this, e);
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.itemOutboundsTableAdapter.FillByOutboundItems(this.inventoryManagementDataSet1.ItemOutbounds);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    try
                    {
                        using (var ctx = new ItemContext())
                        {
                            ItemOutbound it = new ItemOutbound();
                            it.ItemOutboundId = Convert.ToInt32(row.Cells[0].Value.ToString());
                            it.isDelete = false;
                            ctx.ItemOutbounds.Attach(it);
                            ctx.Entry(it).State = System.Data.Entity.EntityState.Unchanged;
                            ctx.Entry(it).Property(p => p.isDelete).IsModified = true;
                            ctx.SaveChanges();
                            MessageBox.Show("Restore successfully.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            fillBy1ToolStripButton_Click(this, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Selected)
                {
                    try
                    {
                        int selectedId = Convert.ToInt32(row.Cells[0].Value.ToString());
                        using (var ctx = new ItemContext())
                        {
                            ItemOutbound it = ctx.ItemOutbounds.Where(id => id.ItemOutboundId == selectedId).First<ItemOutbound>();
                            ctx.ItemOutbounds.Remove(it);
                            ctx.SaveChanges();
                            MessageBox.Show("Delete successfully.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            fillBy1ToolStripButton_Click(this, e);
        }
    }
}
