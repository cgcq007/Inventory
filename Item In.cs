using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace InventoryTest
{
    public partial class Item_In : Form
    {
        string uname;
        public Item_In(string uname)
        {
            this.uname = uname;
            InitializeComponent();
        }
        private void Item_In_Load(object sender, EventArgs e)
        {
            dateOfRcv.Value = DateTime.Now;
            listed.SelectedIndex = 0;
            condition.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (itemTitile.Text.Length != 0 && dateOfRcv.Text.Length != 0 && orderId.Text.Length != 0 &&  SN.Text.Length != 0)
            {
                if (!(Regex.IsMatch(Regex.Replace(orderId.Text.Trim().ToString(), "-",""), StrRegex(1))))
                {
                    //MessageBox.Show(orderId.Text.Trim().ToString().Split('-')[0].ToString());
                    MessageBox.Show("Order Number has to be number, alphabet and '-'!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (UPC.Text.Trim().Length != 0 && !(Regex.IsMatch(UPC.Text.Trim().ToString(), StrRegex(3))))
                {
                    MessageBox.Show("UPC has to be number!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //if (!Regex.IsMatch(SN.Text.Trim().ToString(), StrRegex(1)))
                //{
                //    MessageBox.Show("SN has to be number or alphabet!", "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                try
                {
                    using (var ctx = new ItemContext())
                    {
                        //MessageBox.Show(dateOfRcv.Text.ToString());
                        Item Ite = new Item() {  ItemTitle = itemTitile.Text.Trim(), OrderId = orderId.Text.Trim(), UPC = UPC.Text.Trim(), SN = SN.Text.Trim(), OriginalTrackingNum = originalTrackingNum.Text.Trim(), ReturnCode = returnCode.Text.Trim(), Location = location.Text.Trim(), DateOfRcv = Convert.ToDateTime(dateOfRcv.Text.ToString()), Listed = listed.Text, ItemInOperator = uname, Condition = condition.Text, Note = Note.Text.Trim(), Pending = false };
                        //var WholeRecord = ctx.Items.Select(a => a.SN).Union(ctx.ItemsDisposed.Select(b => b.SN));
                        var WholeRecord = ctx.Items.Select(a => a.SN);
                        //MessageBox.Show(WholeRecord.Where(x => x.Equals(SN.Text.Trim())).ToList().ToString());
                        if (WholeRecord.Where(x => x.Equals(SN.Text.Trim())).ToList().Count == 0)
                        {
                            ctx.Items.Add(Ite);
                            ctx.SaveChanges();
                            MessageBox.Show("Successfully added!");
                            //MessageBox.Show(WholeRecord.Where(x => x.Equals(SN.Text.Trim())).ToList().ToString());
                            foreach (Control ctr in this.Controls)
                            {
                                if (ctr is TextBox)
                                {
                                    if (ctr.Name == itemTitile.Name || ctr.Name == originalTrackingNum.Name || ctr.Name == orderId.Name||ctr.Name== location.Name)
                                    {
                                        continue;
                                    }
                                    ctr.Text = "";
                                }
                            }

                            noSNCheckBox.Checked = false;
                            dateOfRcv.Value = DateTime.Now;
                            listed.SelectedIndex = 0;
                            //condition.SelectedIndex = 0;

                        }
                        else
                        {
                            MessageBox.Show("Item already exists in inventory!");
                            //MessageBox.Show(WholeRecord.ToString());
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                }
            }
            else
            {
                MessageBox.Show("Item title, orderID, and SN are required.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            //using (var ctx = new ItemContext())
            //{
            //    //Item Ite = new Item() { ItemId = Convert.ToInt32(textBox1.Text.Trim()), ItemTitle = textBox2.Text.Trim(), DateOfRcv = DateTime.Now, OrderId = textBox3.Text.Trim(), UPC = textBox4.Text.Trim(), SN = textBox5.Text.Trim(), Condition = comboBox1.Text };
            //    var it = ctx.Items.Where(i => i.UPC == "12").ToList();
            //    MessageBox.Show(it[0].DateOfRcv.ToString());
            //}
        }

        public static string StrRegex(int iType)
        {
            switch (iType)
            {
                //number+alphabet
                case 1: return "^[A-Za-z0-9,]+$";
                    //alphabet+number+chinese
                case 2: return "^[a-zA-Z0-9\u4e00-\u9fa5]+$";
                    //number
                default: return "^[0-9]*$";
            }
        }

        private void noSNCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (noSNCheckBox.Checked)
            {
                SN.ReadOnly = true;
                SN.Text = "No " + dateOfRcv.Text;
            }else
            {
                SN.Text = "";
                SN.ReadOnly = false;
            }
        }
    }
}
