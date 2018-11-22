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
                        ItemOutbound itemOutboundNew = new ItemOutbound()
                        {
                            ItemOutboundId = itemOutboundId,
                            ItemTitle = itemTitile.Text,
                            Date = Convert.ToDateTime(date.Text),
                            Qty = Convert.ToInt32(Qty.Text),
                            SN = SN.Text,
                            TrackingNum = TrackingNumLabel.Text
                        };
                        ctx.ItemOutbounds.Attach(itemOutboundNew);
                        ctx.Entry(itemOutboundNew).State = System.Data.Entity.EntityState.Modified;
                        ctx.Entry(itemOutboundNew).Property(x => x.ItemOutboundId).IsModified = false;
                        ctx.Entry(itemOutboundNew).Property(x => x.isDelete).IsModified = false;
                        ctx.Entry(itemOutboundNew).Property(x => x.Manipulator).IsModified = false;
                        ctx.SaveChanges();
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
