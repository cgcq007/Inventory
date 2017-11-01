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
    public partial class MultiUpdate : Form
    {
        public List<string> SN { get; set; }
        public string uname { get; set; }
        public MultiUpdate()
        {
            InitializeComponent();
        }

        private void MultiUpdate_Load(object sender, EventArgs e)
        {

        }

        private void SaveAll_Click(object sender, EventArgs e)
        {

            if (itemTitile.Text.Trim().Length > 0 || location.Text.Trim().Length > 0
                            || listed.Text.Trim().Length > 0 || condition.Text.Trim().Length > 0
                            || note.Text.Trim().Length > 0 || upc.Text.Trim().Length > 0)
            {
                foreach (string sn in SN)
                {
                    try
                    {
                        using (ItemContext ctx = new ItemContext())
                        {
                            Item it = ctx.Items.Find(sn);
                            it.ServiceMan = uname;
                            foreach (Control ctr in this.Controls)
                            {
                                if (ctr.Text.Trim().Length != 0)
                                {
                                    switch (ctr.Name)
                                    {
                                        case "itemTitile":
                                            it.ItemTitle = ctr.Text.Trim();
                                            break;
                                        case "location":
                                            it.Location = ctr.Text.Trim();
                                            break;
                                        case "listed":
                                            it.Listed = ctr.Text.Trim();
                                            break;
                                        case "condition":
                                            it.Condition = ctr.Text.Trim();
                                            break;
                                        case "upc":
                                            it.UPC = ctr.Text.Trim();
                                            break;
                                        case "note":
                                            it.Note = ctr.Text.Trim();
                                            break;
                                    }
                                }
                            }
                            ctx.Items.Attach(it);
                            ctx.Entry(it).State = System.Data.Entity.EntityState.Modified;
                            ctx.SaveChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return;
                    }
                }
                MessageBox.Show("Successfull updated multiple items!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Nothing can be updated!");
            }
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
