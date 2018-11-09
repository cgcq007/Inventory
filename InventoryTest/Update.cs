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
        public string snCode { get; set; }
        private string uname;
        private string utype;
        private string editor="";

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
            try
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
                    editor = item.ServiceMan;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private string editorMaker(string editor)
        {
            if (editor != null)
            {
                if (!editor.Contains(uname))
                {
                    editor += ", " + uname;
                }
            }
            else
            {
                editor = uname;
            }
            return editor;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (itemTitile.Text.Length != 0 && orderId.Text.Length != 0 && SN.Text.Length != 0 && condition.Text.Length != 0)
            {
                try
                {
                    //determine editors
                    editor = editorMaker(editor);
                    if (SN.ReadOnly)
                    {
                        using (var ctx = new ItemContext())
                        {
                            Item ite;
                            if (utype == "serviceMan")
                            {
                                //Item it = ctx.Items.SingleOrDefault(a => a.SN == snCode);
                                //it.ItemTitle = itemTitile.Text.Trim();
                                //it.DateOfRcv = Convert.ToDateTime(dateOfRcv.Text);
                                //it.OrderId = orderId.Text.Trim();
                                //it.UPC = UPC.Text.Trim();
                                //it.SN = SN.Text.Trim();
                                //it.ReturnCode = returnCode.Text.Trim();
                                //it.Location = location.Text.Trim();
                                //it.Listed = listed.Text;
                                //it.ServiceMan = uname;
                                //it.Condition = condition.Text;
                                //it.OriginalTrackingNum = originalTrackingNum.Text.Trim();
                                //it.Note = Note.Text.Trim();

                                //ctx.Items.Attach(it);
                                //ctx.Entry(it).State = System.Data.Entity.EntityState.Modified;

                                ite = new Item()
                                {
                                    ItemTitle = itemTitile.Text.Trim(),
                                    DateOfRcv = Convert.ToDateTime(dateOfRcv.Text),
                                    OrderId = orderId.Text.Trim(),
                                    UPC = UPC.Text.Trim(),
                                    SN = SN.Text.Trim(),
                                    OriginalTrackingNum = originalTrackingNum.Text.Trim(),
                                    ReturnCode = returnCode.Text.Trim(),
                                    Location = location.Text.Trim(),
                                    Listed = listed.Text,
                                    ServiceMan = editor,
                                    Condition = condition.Text,
                                    Note = Note.Text.Trim()
                                };
                                ctx.Items.Attach(ite);
                                ctx.Entry(ite).State = System.Data.Entity.EntityState.Modified;
                                ctx.Entry(ite).Property(x => x.ItemInOperator).IsModified = false;
                                ctx.Entry(ite).Property(y => y.Pending).IsModified = false;
                            }
                            else
                            {
                                ite = new Item()
                                {
                                    ItemTitle = itemTitile.Text.Trim(),
                                    DateOfRcv = Convert.ToDateTime(dateOfRcv.Text),
                                    OrderId = orderId.Text.Trim(),
                                    UPC = UPC.Text.Trim(),
                                    SN = SN.Text.Trim(),
                                    OriginalTrackingNum = originalTrackingNum.Text.Trim(),
                                    ReturnCode = returnCode.Text.Trim(),
                                    Location = location.Text.Trim(),
                                    Listed = listed.Text,
                                    Condition = condition.Text,
                                    Note = Note.Text.Trim()
                                };
                                ctx.Items.Attach(ite);
                                ctx.Entry(ite).State = System.Data.Entity.EntityState.Modified;
                                ctx.Entry(ite).Property(x => x.ItemInOperator).IsModified = false;
                                ctx.Entry(ite).Property(x => x.ServiceMan).IsModified = false;
                                ctx.Entry(ite).Property(y => y.Pending).IsModified = false;
                            }
                            ctx.SaveChanges();
                            MessageBox.Show("Successfully updated!");
                            this.Dispose(true);
                        }

                    }
                    else
                    {
                        try
                        {
                            using (ItemContext ctx = new ItemContext())
                            {
                                Item it = ctx.Items.SingleOrDefault(a => a.SN == snCode);
                                Item itNew = new Item()
                                {
                                    ItemTitle = itemTitile.Text.Trim(),
                                    OrderId = orderId.Text.Trim(),
                                    UPC = UPC.Text.Trim(),
                                    SN = SN.Text.Trim(),
                                    OriginalTrackingNum = originalTrackingNum.Text.Trim(),
                                    ReturnCode = returnCode.Text.Trim(),
                                    Location = location.Text.Trim(),
                                    DateOfRcv = Convert.ToDateTime(dateOfRcv.Text.ToString()),
                                    Listed = listed.Text,
                                    ItemInOperator = it.ItemInOperator,
                                    Condition = condition.Text,
                                    Note = Note.Text.Trim(),
                                    Pending = it.Pending,
                                    ServiceMan = editorMaker(editor)
                                };
                                ctx.Items.Remove(it);
                                ctx.Items.Add(itNew);
                                ctx.SaveChanges();
                                MessageBox.Show("Successfully updated!");
                                snCode = SN.Text;
                                this.Dispose(true);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
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
                MessageBox.Show("Item title, order ID, and Condition are required. ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void SN_DoubleClick(object sender, EventArgs e)
        {
            SN.ReadOnly = !SN.ReadOnly;
        }
    }

}
