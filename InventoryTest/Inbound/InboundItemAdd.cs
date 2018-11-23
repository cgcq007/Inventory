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
    public partial class InboundItemAdd : Form
    {
        string manipulator;
        public InboundItemAdd(string uname)
        {
            this.manipulator = uname;
            //date.Refresh();
            InitializeComponent();
        }

        private void UPC_TextChanged(object sender, EventArgs e)
        {
            long numLines = UPC.Text.Split('\n').Where(x => x.Trim().Length != 0).LongCount();

            Qty.Text = Convert.ToString(numLines);
        }

        #region Add
        private void button1_Click(object sender, EventArgs e)
        {
            if (itemTitile.Text.Trim().Length != 0 && TrackingNum.Text.Trim().Length != 0 && UPC.Text.Trim().Length != 0)
            {
                try
                {
                    using (var ctx = new ItemContext())
                    {
                        ItemInbound II = new ItemInbound() { ItemTitle = itemTitile.Text.Trim(), TrackingNum = TrackingNum.Text.Trim(), Date = Convert.ToDateTime(date.Text.ToString()), Qty = Convert.ToInt32(Qty.Text), Manipulator = manipulator, UPC = UPC.Text.Trim(), ShipperId = tbShipperID.Text.Trim(), isDelete = false };
                        ctx.ItemInbounds.Add(II);
                        ctx.SaveChanges();
                    }
                    MessageBox.Show("Record successfully added!");
                    UPC.Text = "";
                    TrackingNum.Text = "";
                    date.Value = DateTime.Now;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("itemTitile, TrackingNum, UPC cannot be null.");
            }
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
