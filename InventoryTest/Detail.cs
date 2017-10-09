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
        public Detail(string sn)
        {
            this.sn = sn;
            InitializeComponent();
        }
        private void Deatil_Load(object sender, EventArgs e)
        {
            using (ItemContext ctx = new ItemContext())
            {
                var item = ctx.Items.Where(s => s.SN == sn).FirstOrDefault<Item>();
                itemInOperator.Text = item.ItemInOperator;
                serviceMan.Text = item.ServiceMan;
                returnCode.Text = item.ReturnCode;
            }
        }
    }
}
