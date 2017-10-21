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
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }
        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadDGV();
        }
        private void LoadDGV()
        {
            using (var ctx = new ItemContext())
            {
                    var users = ctx.Users.ToList();
                    dataGridView1.DataSource = ToDataSet(users);
            }
            setFridViewProperty();
        }
        private void setFridViewProperty()
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.Rows[0].Selected = false;
            }
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = true;
            dataGridView1.AllowUserToAddRows = false;
        }
        public DataTable ToDataSet<T>(List<T> list)
        {
            Type elementType = typeof(T);
            var t = new DataTable();
            elementType.GetProperties().ToList().ForEach(propInfo => t.Columns.Add(propInfo.Name, Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType));
            foreach (T item in list)
            {
                var row = t.NewRow();
                elementType.GetProperties().ToList().ForEach(propInfo => row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value);
                t.Rows.Add(row);
            }
            return t;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var first = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (first >= 0)
            {
                try
                {
                    using (var ctx = new ItemContext())
                    {
                        userName.Text = dataGridView1.Rows[first].Cells["UserName"].Value.ToString();
                        pwd.Text = dataGridView1.Rows[first].Cells["UserPwd"].Value.ToString();
                        userType.Text = dataGridView1.Rows[first].Cells["UserType"].Value.ToString();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            userName.Text = "";
            pwd.Text = "";
            userType.Text = "";
            LoadDGV();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (userName.Text.Trim().Length != 0 && pwd.Text.Trim().Length != 0 && userType.Text.Length != 0)
            {
                try
                {
                    using (var ctx = new ItemContext())
                    {
                        User u = new User() { UserName = userName.Text.Trim(), UserPwd = pwd.Text.Trim(), UserType = userType.Text.Trim()};
                        ctx.Users.Add(u);
                        ctx.SaveChanges();
                        MessageBox.Show("Successfully added new user!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Clear_Click(this,e);
                }
            }else
            {
                MessageBox.Show("Please complete the information!");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (userName.Text.Trim().Length != 0)
            {
                try
                {
                    using (var ctx = new ItemContext())
                    {
                        User u = ctx.Users.Where(uname => uname.UserName == userName.Text.Trim()).First<User>();
                        ctx.Users.Remove(u);
                        ctx.SaveChanges();
                        MessageBox.Show(userName.Text.ToString() + " is deleted successfully!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Clear_Click(this, e);
                }
            }
            else
            {
                MessageBox.Show("Pleas Select one user!");
            }
        }

        private void Modify_Click(object sender, EventArgs e)
        {
            if(userName.Text.Trim().Length != 0)
            {
                try
                {
                    using (var ctx = new ItemContext())
                    {
                        User u = new User() { UserName = userName.Text.Trim(), UserPwd = pwd.Text.Trim(), UserType = userType.Text};
                        ctx.Users.Attach(u);
                        ctx.Entry(u).State = System.Data.Entity.EntityState.Modified;
                        ctx.SaveChanges();
                        MessageBox.Show("Successfully Updated!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Clear_Click(this, e);
                }
            }
            else
            {
                MessageBox.Show("Please select one user!");
            }
        }
    }
}
