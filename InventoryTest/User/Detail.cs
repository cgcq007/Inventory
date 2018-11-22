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
    public partial class Detail : Form
    {
        string sn;
        string orderId;
        string inOrOut;
        public Detail(string sn, string orderId, string inOrOut)
        {
            this.sn = sn;
            this.orderId = orderId;
            this.inOrOut = inOrOut;
            InitializeComponent();
        }
        private void Deatil_Load(object sender, EventArgs e)
        {
            using (ItemContext ctx = new ItemContext())
            {
                if (inOrOut == "In Inventory")
                {
                    var item = ctx.Items.Where(s => s.SN == sn).FirstOrDefault<Item>();
                    itemInOperator.Text = item.ItemInOperator;
                    serviceMan.Text = item.ServiceMan;
                    returnCode.Text = item.ReturnCode;
                }else
                {
                    var item = ctx.ItemsDisposed.Where(o => o.OrderId == orderId).Where(s => s.SN == sn).FirstOrDefault<ItemDisposed>();
                    itemInOperator.Text = item.ItemInOperator;
                    serviceMan.Text = item.ServiceMan;
                    itemOutOperator.Text = item.ItemOutOperator;
                    returnCode.Text = item.ReturnCode;
                }
            }
        }
    }
}
