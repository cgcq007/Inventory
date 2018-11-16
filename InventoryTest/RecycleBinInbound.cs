using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryTest
{
    public partial class RecycleBinInbound : Form
    {
        public RecycleBinInbound()
        {
            InitializeComponent();
        }

        private void Recycle_Bin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'itemInboudsDataSet.ItemInbounds' table. You can move, or remove it, as needed.
            this.itemInboundsTableAdapter.Fill(this.itemInboudsDataSet.ItemInbounds);
            //fillBy1ToolStripButton_Click(this, e);
        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            Recycle_Bin_Load(this,e);
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
                            ItemInbound it = new ItemInbound();
                            it.ItemInboundId = Convert.ToInt32(row.Cells[0].Value.ToString());
                            it.isDelete = false;
                            ctx.ItemInbounds.Attach(it);
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
                            ItemInbound it = ctx.ItemInbounds.Where(id => id.ItemInboundId == selectedId).First<ItemInbound>();
                            ctx.ItemInbounds.Remove(it);
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
