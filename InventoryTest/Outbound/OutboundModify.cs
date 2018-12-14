using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace InventoryTest
{
    public partial class OutboundModify : Form
    {
        int itemOutboundId;

        public OutboundModify(int itemOutboundId)
        {
            this.itemOutboundId = itemOutboundId;
            InitializeComponent();
        }

        private void SN_TextChanged(object sender, EventArgs e)
        {
            long numLines = SN.Text.Split('\n').Where(x => x.Trim().Length != 0).LongCount();

            Qty.Text = Convert.ToString(numLines);
        }

        private void OutboundModify_Load(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new ItemContext())
                {
                    ItemOutbound itemOutbound = ctx.ItemOutbounds.Find(itemOutboundId);
                    TrackingNum.Text = itemOutbound.TrackingNum;
                    itemTitile.Text = itemOutbound.ItemTitle;
                    date.Text = itemOutbound.Date.ToString();
                    Qty.Text = itemOutbound.Qty.ToString();
                    SN.Text = itemOutbound.SN;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (itemTitile.Text.Length != 0 && SN.Text.Length != 0 && date.Text.Length != 0 && TrackingNumLabel.Text.Length != 0)
            {
                try
                {
                    //determine editors

                    using (var ctx = new ItemContext())
                    {
                        ItemOutbound itemOutbound = ctx.ItemOutbounds.Where(u => u.ItemOutboundId == itemOutboundId).FirstOrDefault();
                        itemOutbound.ItemTitle = itemTitile.Text;
                        itemOutbound.Date = Convert.ToDateTime(date.Text);
                        itemOutbound.Qty = Convert.ToInt32(Qty.Text);
                        itemOutbound.SN = SN.Text;
                        itemOutbound.TrackingNum = TrackingNum.Text;
                        ctx.Entry(itemOutbound).State = System.Data.Entity.EntityState.Modified;
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
