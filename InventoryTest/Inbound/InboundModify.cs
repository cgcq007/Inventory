using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryTest
{
    public partial class InboundModify : Form
    {
        int itemInboundId;

        public InboundModify(int itemInboundId)
        {
            this.itemInboundId = itemInboundId;
            InitializeComponent();
        }

        private void UPC_TextChanged(object sender, EventArgs e)
        {
            long numLines = UPC.Text.Split('\n').Where(x => x.Trim().Length != 0).LongCount();

            Qty.Text = Convert.ToString(numLines);
        }

        private void InboundModify_Load(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new ItemContext())
                {
                    ItemInbound itemInbound = ctx.ItemInbounds.Find(itemInboundId);
                    TrackingNum.Text = itemInbound.TrackingNum;
                    itemTitile.Text = itemInbound.ItemTitle;
                    date.Text = itemInbound.Date.ToString();
                    Qty.Text = itemInbound.Qty.ToString();
                    UPC.Text = itemInbound.UPC; ;
                    tbShipperID.Text = itemInbound.ShipperId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (itemTitile.Text.Length != 0 && UPC.Text.Length != 0 && date.Text.Length != 0 && TrackingNumLabel.Text.Length != 0)
            {
                try
                {
                    using (var ctx = new ItemContext())
                    {
                        ItemInbound itemInbound = ctx.ItemInbounds.Where(u => u.ItemInboundId == itemInboundId).FirstOrDefault();
                        itemInbound.ItemTitle = itemTitile.Text;
                        itemInbound.Date = Convert.ToDateTime(date.Text);
                        itemInbound.Qty = Convert.ToInt32(Qty.Text);
                        itemInbound.UPC = UPC.Text;
                        itemInbound.TrackingNum = TrackingNum.Text;
                        itemInbound.ShipperId = tbShipperID.Text;
                        ctx.Entry(itemInbound).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        MessageBox.Show("Successfully updated!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }
    }
}
