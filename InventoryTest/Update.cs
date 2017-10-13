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
    public partial class Update : Form
    {
        private string snCode;
        private string uname;
        private string utype;
        public Update(string SN)
        {
            snCode = SN;
            InitializeComponent();
        }
        public Update(string SN, string uname, string utype)
        {
            snCode = SN;
            this.uname = uname;
            this.utype = utype;
            InitializeComponent();
        }
        private void Update_Load(object sender, EventArgs e)
        {
            using (var ctx = new ItemContext())
            {
                var item = ctx.Items.Find(snCode);
                itemTitile.Text = item.ItemTitle;
                orderId.Text = item.OrderId;
                UPC.Text = item.UPC;
                SN.Text = item.SN;
                originalTrackingNum.Text = item.OriginalTrackingNum;
                returnCode.Text = item.ReturnCode;
                location.Text = item.Location;
                listed.Text = item.Listed;
                dateOfRcv.Text = item.DateOfRcv.ToString();
                condition.Text = item.Condition;
                Note.Text = item.Note;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (itemTitile.Text.Length != 0  && orderId.Text.Length != 0 && SN.Text.Length != 0 && condition.Text.Length != 0)
            {
                try
                {
                    using (var ctx = new ItemContext())
                    {
                        Item ite;
                        if (utype == "serviceMan")
                        {
                            ite = new Item() { ItemTitle = itemTitile.Text.Trim(), DateOfRcv = Convert.ToDateTime(dateOfRcv.Text), OrderId = orderId.Text.Trim(), UPC = UPC.Text.Trim(), SN = SN.Text.Trim(),
                                  OriginalTrackingNum = originalTrackingNum.Text.Trim(), ReturnCode = returnCode.Text.Trim(), Location = location.Text.Trim(), Listed = listed.Text, ServiceMan = uname, Condition = condition.Text, Note = Note.Text.Trim() };
                            ctx.Items.Attach(ite);
                            ctx.Entry(ite).State = System.Data.Entity.EntityState.Modified;
                            ctx.Entry(ite).Property(x => x.ItemInOperator).IsModified = false;
                        }
                        else
                        {
                            ite = new Item() { ItemTitle = itemTitile.Text.Trim(), DateOfRcv = Convert.ToDateTime(dateOfRcv.Text), OrderId = orderId.Text.Trim(), UPC = UPC.Text.Trim(), SN = SN.Text.Trim(),
                                  OriginalTrackingNum = originalTrackingNum.Text.Trim(), ReturnCode = returnCode.Text.Trim(), Location = location.Text.Trim(), Listed = listed.Text, Condition = condition.Text, Note = Note.Text.Trim() };
                            ctx.Items.Attach(ite);
                            ctx.Entry(ite).State = System.Data.Entity.EntityState.Modified;
                            ctx.Entry(ite).Property(x => x.ItemInOperator).IsModified = false;
                            ctx.Entry(ite).Property(x => x.ServiceMan).IsModified = false;
                        }
                        ctx.SaveChanges();
                        MessageBox.Show("Successfully updated!");
                        this.Dispose(true);
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
                MessageBox.Show("Item title, order ID ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(true);

        }
    }

}
