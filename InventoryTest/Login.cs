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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new ItemContext())
                {
                    string uid = textBox1.Text.Trim();
                    string pwd = textBox2.Text.Trim();

                    //1.判断用户名是否存在
                    List<User> list = ctx.Users.Where(u => u.UserName == uid).ToList();
                    if (list.Count >= 1)
                    {
                        //用户存在
                        //2.判断密码是否正确
                        List<User> list2 = ctx.Users.Where(u => u.UserName == uid && u.UserPwd == pwd).ToList();
                        if (list2.Count >= 1)
                        {
                            //用户存在且密码正确
                            MessageBox.Show("Login Successfully!");
                            //MessageBox.Show(list2[0].UserType.ToString());
                            MainForm mf = new MainForm(list2[0].UserName.ToString(),list2[0].UserType.ToString());
                            mf.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("User Exist But Password Wrong!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No User Found!");
                    }
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
