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
    public partial class ConfirmForm : Form
    {
        string tracking;
        public ConfirmForm(string trackingNum)
        {
            this.tracking = trackingNum;
            InitializeComponent();
        }
        public string getTracking()
        {
            return tracking;
        }
        private void yes_Click(object sender, EventArgs e)
        {
            if(trackingNum.Text.Trim().Length == 0)
            {
                tracking = "Unknown";
            }
            else
            {
                tracking = trackingNum.Text.Trim();
            }
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
