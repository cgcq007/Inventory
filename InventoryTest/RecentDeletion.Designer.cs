namespace InventoryTest
{
    partial class RecentDeletion
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inventoryManagementDataSet = new InventoryTest.InventoryManagementDataSet();
            this.itemBaksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemBaksTableAdapter = new InventoryTest.InventoryManagementDataSetTableAdapters.ItemBaksTableAdapter();
            this.itemTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uPCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfRcvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originalTrackingNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outTrackingNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conditionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryManagementDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBaksBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(46, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(82, 23);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Save);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Clear);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(607, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 280);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Clearance";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(53, 152);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 7;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "will be clear";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(53, 184);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 5;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data Before";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemTitleDataGridViewTextBoxColumn,
            this.sNDataGridViewTextBoxColumn,
            this.uPCDataGridViewTextBoxColumn,
            this.orderIdDataGridViewTextBoxColumn,
            this.listedDataGridViewTextBoxColumn,
            this.dateOfRcvDataGridViewTextBoxColumn,
            this.dateOfOutDataGridViewTextBoxColumn,
            this.originalTrackingNumDataGridViewTextBoxColumn,
            this.outTrackingNumberDataGridViewTextBoxColumn,
            this.conditionDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn,
            this.returnCodeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.itemBaksBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(601, 561);
            this.dataGridView1.TabIndex = 0;
            // 
            // inventoryManagementDataSet
            // 
            this.inventoryManagementDataSet.DataSetName = "InventoryManagementDataSet";
            this.inventoryManagementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // itemBaksBindingSource
            // 
            this.itemBaksBindingSource.DataMember = "ItemBaks";
            this.itemBaksBindingSource.DataSource = this.inventoryManagementDataSet;
            // 
            // itemBaksTableAdapter
            // 
            this.itemBaksTableAdapter.ClearBeforeFill = true;
            // 
            // itemTitleDataGridViewTextBoxColumn
            // 
            this.itemTitleDataGridViewTextBoxColumn.DataPropertyName = "ItemTitle";
            this.itemTitleDataGridViewTextBoxColumn.FillWeight = 150F;
            this.itemTitleDataGridViewTextBoxColumn.HeaderText = "ItemTitle";
            this.itemTitleDataGridViewTextBoxColumn.Name = "itemTitleDataGridViewTextBoxColumn";
            this.itemTitleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sNDataGridViewTextBoxColumn
            // 
            this.sNDataGridViewTextBoxColumn.DataPropertyName = "SN";
            this.sNDataGridViewTextBoxColumn.HeaderText = "SN";
            this.sNDataGridViewTextBoxColumn.Name = "sNDataGridViewTextBoxColumn";
            this.sNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // uPCDataGridViewTextBoxColumn
            // 
            this.uPCDataGridViewTextBoxColumn.DataPropertyName = "UPC";
            this.uPCDataGridViewTextBoxColumn.HeaderText = "UPC";
            this.uPCDataGridViewTextBoxColumn.Name = "uPCDataGridViewTextBoxColumn";
            this.uPCDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            this.orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.HeaderText = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            this.orderIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // listedDataGridViewTextBoxColumn
            // 
            this.listedDataGridViewTextBoxColumn.DataPropertyName = "Listed";
            this.listedDataGridViewTextBoxColumn.FillWeight = 50F;
            this.listedDataGridViewTextBoxColumn.HeaderText = "Listed";
            this.listedDataGridViewTextBoxColumn.Name = "listedDataGridViewTextBoxColumn";
            this.listedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateOfRcvDataGridViewTextBoxColumn
            // 
            this.dateOfRcvDataGridViewTextBoxColumn.DataPropertyName = "DateOfRcv";
            this.dateOfRcvDataGridViewTextBoxColumn.FillWeight = 50F;
            this.dateOfRcvDataGridViewTextBoxColumn.HeaderText = "DateOfRcv";
            this.dateOfRcvDataGridViewTextBoxColumn.Name = "dateOfRcvDataGridViewTextBoxColumn";
            this.dateOfRcvDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateOfOutDataGridViewTextBoxColumn
            // 
            this.dateOfOutDataGridViewTextBoxColumn.DataPropertyName = "DateOfOut";
            this.dateOfOutDataGridViewTextBoxColumn.FillWeight = 50F;
            this.dateOfOutDataGridViewTextBoxColumn.HeaderText = "DateOfOut";
            this.dateOfOutDataGridViewTextBoxColumn.Name = "dateOfOutDataGridViewTextBoxColumn";
            this.dateOfOutDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // originalTrackingNumDataGridViewTextBoxColumn
            // 
            this.originalTrackingNumDataGridViewTextBoxColumn.DataPropertyName = "OriginalTrackingNum";
            this.originalTrackingNumDataGridViewTextBoxColumn.HeaderText = "OriginalTrackingNum";
            this.originalTrackingNumDataGridViewTextBoxColumn.Name = "originalTrackingNumDataGridViewTextBoxColumn";
            this.originalTrackingNumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // outTrackingNumberDataGridViewTextBoxColumn
            // 
            this.outTrackingNumberDataGridViewTextBoxColumn.DataPropertyName = "OutTrackingNumber";
            this.outTrackingNumberDataGridViewTextBoxColumn.HeaderText = "OutTrackingNumber";
            this.outTrackingNumberDataGridViewTextBoxColumn.Name = "outTrackingNumberDataGridViewTextBoxColumn";
            this.outTrackingNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // conditionDataGridViewTextBoxColumn
            // 
            this.conditionDataGridViewTextBoxColumn.DataPropertyName = "Condition";
            this.conditionDataGridViewTextBoxColumn.FillWeight = 50F;
            this.conditionDataGridViewTextBoxColumn.HeaderText = "Condition";
            this.conditionDataGridViewTextBoxColumn.Name = "conditionDataGridViewTextBoxColumn";
            this.conditionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.FillWeight = 150F;
            this.noteDataGridViewTextBoxColumn.HeaderText = "Note";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // returnCodeDataGridViewTextBoxColumn
            // 
            this.returnCodeDataGridViewTextBoxColumn.DataPropertyName = "ReturnCode";
            this.returnCodeDataGridViewTextBoxColumn.HeaderText = "ReturnCode";
            this.returnCodeDataGridViewTextBoxColumn.Name = "returnCodeDataGridViewTextBoxColumn";
            this.returnCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RecentDeletion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RecentDeletion";
            this.Text = "RecentDeletion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RecentDeletion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryManagementDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBaksBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
  
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.DataGridView dataGridView1;
        private InventoryManagementDataSet inventoryManagementDataSet;
        private System.Windows.Forms.BindingSource itemBaksBindingSource;
        private InventoryManagementDataSetTableAdapters.ItemBaksTableAdapter itemBaksTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uPCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn listedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfRcvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn originalTrackingNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn outTrackingNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn conditionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnCodeDataGridViewTextBoxColumn;
    }
}