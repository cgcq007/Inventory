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
    public partial class Pwd : Form
    {
        private string uname;
        public Pwd(string uname)
        {
            this.uname = uname;
            InitializeComponent();
        }
        private void Pwd_Load(object sender, EventArgs e)
        {
            textBox1.Text = uname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pwd = textBox2.Text.Trim().ToString();
            if(textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim() != textBox2.Text.Trim())
            {
                MessageBox.Show("Failed, password and confirm password are not equal or empty!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (var ctx = new ItemContext())
                    {
                        User user = new User() {UserName = uname, UserPwd = textBox2.Text.Trim().ToString()};
                        ctx.Users.Attach(user);
                        ctx.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        ctx.Entry(user).Property(x => x.UserType).IsModified = false;
                        ctx.SaveChanges();
                        MessageBox.Show("Password Successfully Changed!");
                    }
                }
                catch(Exception ex)
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
