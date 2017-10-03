namespace InventoryTest
{
    partial class ConfirmForm
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
            this.trackingNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yes = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trackingNum
            // 
            this.trackingNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trackingNum.Location = new System.Drawing.Point(72, 82);
            this.trackingNum.MaxLength = 32;
            this.trackingNum.Name = "trackingNum";
            this.trackingNum.Size = new System.Drawing.Size(226, 26);
            this.trackingNum.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please input the tracking number";
            // 
            // yes
            // 
            this.yes.Location = new System.Drawing.Point(38, 136);
            this.yes.Name = "yes";
            this.yes.Size = new System.Drawing.Size(91, 33);
            this.yes.TabIndex = 2;
            this.yes.Text = "Yes";
            this.yes.UseVisualStyleBackColor = true;
            this.yes.Click += new System.EventHandler(this.yes_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(241, 136);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(91, 33);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 196);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.yes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackingNum);
            this.Name = "ConfirmForm";
            this.Text = "Tracking Number";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox trackingNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button yes;
        private System.Windows.Forms.Button cancel;
    }
}