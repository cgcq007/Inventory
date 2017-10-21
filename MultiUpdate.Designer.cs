namespace InventoryTest
{
    partial class MultiUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.location = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.listed = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.note = new System.Windows.Forms.TextBox();
            this.condition = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.itemTitile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveAll = new System.Windows.Forms.Button();
            this.Return = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "You are updating multiple items:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(27, 90);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 15);
            this.label12.TabIndex = 32;
            this.label12.Text = "Location";
            // 
            // location
            // 
            this.location.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.location.Location = new System.Drawing.Point(97, 87);
            this.location.Margin = new System.Windows.Forms.Padding(2);
            this.location.MaxLength = 32;
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(226, 21);
            this.location.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(41, 137);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 15);
            this.label10.TabIndex = 43;
            this.label10.Text = "Listed";
            // 
            // listed
            // 
            this.listed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listed.FormattingEnabled = true;
            this.listed.Items.AddRange(new object[] {
            "Not Yet",
            "Amazon",
            "eBay"});
            this.listed.Location = new System.Drawing.Point(97, 134);
            this.listed.Margin = new System.Windows.Forms.Padding(2);
            this.listed.Name = "listed";
            this.listed.Size = new System.Drawing.Size(226, 23);
            this.listed.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(48, 213);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 42;
            this.label5.Text = "Note";
            // 
            // note
            // 
            this.note.AcceptsReturn = true;
            this.note.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.note.Location = new System.Drawing.Point(97, 210);
            this.note.Margin = new System.Windows.Forms.Padding(2);
            this.note.MaxLength = 300;
            this.note.Multiline = true;
            this.note.Name = "note";
            this.note.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.note.Size = new System.Drawing.Size(226, 87);
            this.note.TabIndex = 40;
            // 
            // condition
            // 
            this.condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.condition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.condition.FormattingEnabled = true;
            this.condition.Items.AddRange(new object[] {
            "Unchecked",
            "New",
            "Like New",
            "Very Good",
            "Good",
            "Acceptable",
            "Refurbished",
            "Defective ServiceMan",
            "Defective Warrenty",
            "Defective No Warranty",
            "Defective Cannot Repair ",
            "Other..."});
            this.condition.Location = new System.Drawing.Point(97, 172);
            this.condition.Margin = new System.Windows.Forms.Padding(2);
            this.condition.Name = "condition";
            this.condition.Size = new System.Drawing.Size(226, 23);
            this.condition.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 41;
            this.label9.Text = "Condition";
            // 
            // itemTitile
            // 
            this.itemTitile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemTitile.Location = new System.Drawing.Point(97, 43);
            this.itemTitile.MaxLength = 128;
            this.itemTitile.Name = "itemTitile";
            this.itemTitile.Size = new System.Drawing.Size(226, 21);
            this.itemTitile.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "Item Title";
            // 
            // SaveAll
            // 
            this.SaveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAll.Location = new System.Drawing.Point(97, 323);
            this.SaveAll.Name = "SaveAll";
            this.SaveAll.Size = new System.Drawing.Size(75, 26);
            this.SaveAll.TabIndex = 44;
            this.SaveAll.Text = "Save All";
            this.SaveAll.UseVisualStyleBackColor = true;
            this.SaveAll.Click += new System.EventHandler(this.SaveAll_Click);
            // 
            // Return
            // 
            this.Return.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Return.Location = new System.Drawing.Point(248, 323);
            this.Return.Name = "Return";
            this.Return.Size = new System.Drawing.Size(75, 26);
            this.Return.TabIndex = 45;
            this.Return.Text = "Return";
            this.Return.UseVisualStyleBackColor = true;
            this.Return.Click += new System.EventHandler(this.Return_Click);
            // 
            // MultiUpdate
            // 
            this.AcceptButton = this.SaveAll;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Return;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.Return);
            this.Controls.Add(this.SaveAll);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.note);
            this.Controls.Add(this.condition);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.itemTitile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.location);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Name = "MultiUpdate";
            this.Text = "MultiUpdate";
            this.Load += new System.EventHandler(this.MultiUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox location;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox listed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox note;
        private System.Windows.Forms.ComboBox condition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox itemTitile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveAll;
        private System.Windows.Forms.Button Return;
    }
}