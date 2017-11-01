namespace InventoryTest
{
    partial class Item_In
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
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.itemTitile = new System.Windows.Forms.TextBox();
            this.orderId = new System.Windows.Forms.TextBox();
            this.UPC = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SN = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.condition = new System.Windows.Forms.ComboBox();
            this.dateOfRcv = new System.Windows.Forms.DateTimePicker();
            this.Note = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.originalTrackingNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listed = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.returnCode = new System.Windows.Forms.TextBox();
            this.location = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.noSNCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Item Title";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(60, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "DateOfRcv";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(73, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Order ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "UPC";
            // 
            // itemTitile
            // 
            this.itemTitile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemTitile.Location = new System.Drawing.Point(132, 22);
            this.itemTitile.MaxLength = 128;
            this.itemTitile.Name = "itemTitile";
            this.itemTitile.Size = new System.Drawing.Size(226, 21);
            this.itemTitile.TabIndex = 0;
            // 
            // orderId
            // 
            this.orderId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderId.Location = new System.Drawing.Point(132, 61);
            this.orderId.MaxLength = 32;
            this.orderId.Name = "orderId";
            this.orderId.Size = new System.Drawing.Size(226, 21);
            this.orderId.TabIndex = 1;
            // 
            // UPC
            // 
            this.UPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UPC.Location = new System.Drawing.Point(132, 99);
            this.UPC.MaxLength = 32;
            this.UPC.Name = "UPC";
            this.UPC.Size = new System.Drawing.Size(226, 21);
            this.UPC.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(89, 535);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 25);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save(&s)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(268, 535);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 25);
            this.button2.TabIndex = 13;
            this.button2.Text = "Return";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(100, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "SN";
            // 
            // SN
            // 
            this.SN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SN.Location = new System.Drawing.Point(132, 137);
            this.SN.MaxLength = 32;
            this.SN.Name = "SN";
            this.SN.Size = new System.Drawing.Size(226, 21);
            this.SN.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(68, 367);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "Condition";
            // 
            // condition
            // 
            this.condition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.condition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
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
            "Defective Warranty",
            "Defective No Warranty",
            "Defective Cannot Repair ",
            "Other..."});
            this.condition.Location = new System.Drawing.Point(132, 365);
            this.condition.Margin = new System.Windows.Forms.Padding(2);
            this.condition.Name = "condition";
            this.condition.Size = new System.Drawing.Size(226, 23);
            this.condition.TabIndex = 10;
            // 
            // dateOfRcv
            // 
            this.dateOfRcv.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateOfRcv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfRcv.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateOfRcv.Location = new System.Drawing.Point(132, 287);
            this.dateOfRcv.Margin = new System.Windows.Forms.Padding(2);
            this.dateOfRcv.Name = "dateOfRcv";
            this.dateOfRcv.Size = new System.Drawing.Size(226, 24);
            this.dateOfRcv.TabIndex = 8;
            // 
            // Note
            // 
            this.Note.AcceptsReturn = true;
            this.Note.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Note.Location = new System.Drawing.Point(132, 405);
            this.Note.Margin = new System.Windows.Forms.Padding(2);
            this.Note.MaxLength = 300;
            this.Note.Multiline = true;
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(226, 87);
            this.Note.TabIndex = 11;
            this.Note.Tag = "fashdufhas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(60, 407);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Detail Note";
            // 
            // originalTrackingNum
            // 
            this.originalTrackingNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.originalTrackingNum.Location = new System.Drawing.Point(132, 176);
            this.originalTrackingNum.Margin = new System.Windows.Forms.Padding(2);
            this.originalTrackingNum.MaxLength = 32;
            this.originalTrackingNum.Name = "originalTrackingNum";
            this.originalTrackingNum.Size = new System.Drawing.Size(226, 21);
            this.originalTrackingNum.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 180);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "OriginalTrackingNum";
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
            this.listed.Location = new System.Drawing.Point(132, 325);
            this.listed.Margin = new System.Windows.Forms.Padding(2);
            this.listed.Name = "listed";
            this.listed.Size = new System.Drawing.Size(226, 23);
            this.listed.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(86, 327);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Listed";
            // 
            // returnCode
            // 
            this.returnCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnCode.Location = new System.Drawing.Point(132, 217);
            this.returnCode.Margin = new System.Windows.Forms.Padding(2);
            this.returnCode.MaxLength = 32;
            this.returnCode.Name = "returnCode";
            this.returnCode.Size = new System.Drawing.Size(226, 21);
            this.returnCode.TabIndex = 6;
            // 
            // location
            // 
            this.location.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.location.Location = new System.Drawing.Point(132, 252);
            this.location.Margin = new System.Windows.Forms.Padding(2);
            this.location.MaxLength = 32;
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(226, 21);
            this.location.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(52, 219);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Return Code";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(72, 252);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 15);
            this.label12.TabIndex = 28;
            this.label12.Text = "Location";
            // 
            // noSNCheckBox
            // 
            this.noSNCheckBox.AutoSize = true;
            this.noSNCheckBox.Location = new System.Drawing.Point(364, 141);
            this.noSNCheckBox.Name = "noSNCheckBox";
            this.noSNCheckBox.Size = new System.Drawing.Size(58, 17);
            this.noSNCheckBox.TabIndex = 29;
            this.noSNCheckBox.Text = "No-SN";
            this.noSNCheckBox.UseVisualStyleBackColor = true;
            this.noSNCheckBox.CheckedChanged += new System.EventHandler(this.noSNCheckBox_CheckedChanged);
            // 
            // Item_In
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 612);
            this.Controls.Add(this.noSNCheckBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.location);
            this.Controls.Add(this.returnCode);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.originalTrackingNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Note);
            this.Controls.Add(this.dateOfRcv);
            this.Controls.Add(this.condition);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UPC);
            this.Controls.Add(this.orderId);
            this.Controls.Add(this.itemTitile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Item_In";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item_In";
            this.Load += new System.EventHandler(this.Item_In_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox itemTitile;
        private System.Windows.Forms.TextBox orderId;
        private System.Windows.Forms.TextBox UPC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox condition;
        private System.Windows.Forms.DateTimePicker dateOfRcv;
        private System.Windows.Forms.TextBox Note;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox originalTrackingNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox listed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SN;
        private System.Windows.Forms.TextBox returnCode;
        private System.Windows.Forms.TextBox location;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox noSNCheckBox;
    }
}