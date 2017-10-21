namespace InventoryTest
{
    partial class Detail
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
            this.itemInOperator = new System.Windows.Forms.TextBox();
            this.serviceMan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.itemOutOperator = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.returnCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item In Operator";
            // 
            // itemInOperator
            // 
            this.itemInOperator.Location = new System.Drawing.Point(113, 8);
            this.itemInOperator.Name = "itemInOperator";
            this.itemInOperator.ReadOnly = true;
            this.itemInOperator.Size = new System.Drawing.Size(160, 20);
            this.itemInOperator.TabIndex = 1;
            // 
            // serviceMan
            // 
            this.serviceMan.Location = new System.Drawing.Point(113, 41);
            this.serviceMan.Name = "serviceMan";
            this.serviceMan.ReadOnly = true;
            this.serviceMan.Size = new System.Drawing.Size(160, 20);
            this.serviceMan.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Updated Man";
            // 
            // itemOutOperator
            // 
            this.itemOutOperator.Location = new System.Drawing.Point(113, 74);
            this.itemOutOperator.Name = "itemOutOperator";
            this.itemOutOperator.ReadOnly = true;
            this.itemOutOperator.Size = new System.Drawing.Size(160, 20);
            this.itemOutOperator.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Item Out Operator";
            // 
            // returnCode
            // 
            this.returnCode.Location = new System.Drawing.Point(113, 107);
            this.returnCode.Name = "returnCode";
            this.returnCode.ReadOnly = true;
            this.returnCode.Size = new System.Drawing.Size(160, 20);
            this.returnCode.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Return Code";
            // 
            // Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 141);
            this.Controls.Add(this.returnCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.itemOutOperator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.serviceMan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itemInOperator);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Detail";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "More Information";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Deatil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemInOperator;
        private System.Windows.Forms.TextBox serviceMan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox itemOutOperator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox returnCode;
        private System.Windows.Forms.Label label4;
    }
}