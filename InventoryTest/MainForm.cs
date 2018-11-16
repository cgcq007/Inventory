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
    public partial class MainForm : Form
    {
        public string uname;
        public string utype;

        public MainForm(string userName, string userType)
        {
            uname = userName;
            utype = userType;
            InitializeComponent();
        }

    private void MainForm_Load(object sender, EventArgs e)
        {

            if (utype == "itemOperator")
            {
                userManagementToolStripMenuItem.Enabled = false;
                backLogToolStripMenuItem.Enabled = false;
            }
            else if (utype == "serviceMan")
            {
                userManagementToolStripMenuItem.Enabled = false;
                backLogToolStripMenuItem.Enabled = false;
            }
            else if(utype == "admin")
            {
                userManagementToolStripMenuItem.Enabled = true;
                backLogToolStripMenuItem.Enabled = true;
            }
            //timer1.Enabled = true;
            //label1.ForeColor = Color.Red;
        }


        private void managementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Management Manage = new Management(uname, utype);
            Manage.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pwd p = new Pwd(uname);
            p.ShowDialog();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagement um = new UserManagement();
            um.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login lg = new Login();
            lg.ShowDialog();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Inventory Management System");
        }

        private void backLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecentDeletion recentDeletion = new RecentDeletion();
            recentDeletion.ShowDialog();
        }

        private void managementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OutboundManagement obm = new OutboundManagement(uname, utype);
            obm.Show();
        }

        private void recycleBinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recycle_Bin recycle = new Recycle_Bin();
            recycle.Show();
        }

        private void managementToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            InboundManagement ibm = new InboundManagement(uname, utype);
            ibm.Show();
        }

        private void recycleBinToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RecycleBinInbound recycle = new RecycleBinInbound();
            recycle.Show();
        }
    }
}
