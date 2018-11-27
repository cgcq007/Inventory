namespace InventoryTest
{
    partial class Recycle_Bin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.itemOutboundsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.inventoryManagementDataSet1 = new InventoryTest.InventoryManagementDataSet1();
            this.inventoryManagementDataSet = new InventoryTest.InventoryManagementDataSet();
            this.inventoryManagementDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.itemOutboundsTableAdapter = new InventoryTest.InventoryManagementDataSet1TableAdapters.ItemOutboundsTableAdapter();
            this.fillBy1ToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillBy1ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.itemOutboundIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trackingNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manipulatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemOutboundsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryManagementDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryManagementDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryManagementDataSetBindingSource)).BeginInit();
            this.fillBy1ToolStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.itemOutboundIdDataGridViewTextBoxColumn,
            this.itemTitleDataGridViewTextBoxColumn,
            this.sNDataGridViewTextBoxColumn,
            this.trackingNumDataGridViewTextBoxColumn,
            this.manipulatorDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.itemOutboundsBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(901, 862);
            this.dataGridView1.TabIndex = 1;
            // 
            // itemOutboundsBindingSource
            // 
            this.itemOutboundsBindingSource.DataMember = "ItemOutbounds";
            this.itemOutboundsBindingSource.DataSource = this.inventoryManagementDataSet1;
            // 
            // inventoryManagementDataSet1
            // 
            this.inventoryManagementDataSet1.DataSetName = "InventoryManagementDataSet1";
            this.inventoryManagementDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryManagementDataSet
            // 
            this.inventoryManagementDataSet.DataSetName = "InventoryManagementDataSet";
            this.inventoryManagementDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryManagementDataSetBindingSource
            // 
            this.inventoryManagementDataSetBindingSource.DataSource = this.inventoryManagementDataSet;
            this.inventoryManagementDataSetBindingSource.Position = 0;
            // 
            // itemOutboundsTableAdapter
            // 
            this.itemOutboundsTableAdapter.ClearBeforeFill = true;
            // 
            // fillBy1ToolStrip
            // 
            this.fillBy1ToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fillBy1ToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fillBy1ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillBy1ToolStripButton});
            this.fillBy1ToolStrip.Location = new System.Drawing.Point(0, 857);
            this.fillBy1ToolStrip.Name = "fillBy1ToolStrip";
            this.fillBy1ToolStrip.Size = new System.Drawing.Size(1176, 31);
            this.fillBy1ToolStrip.TabIndex = 3;
            this.fillBy1ToolStrip.Text = "fillBy1ToolStrip";
            // 
            // fillBy1ToolStripButton
            // 
            this.fillBy1ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillBy1ToolStripButton.Name = "fillBy1ToolStripButton";
            this.fillBy1ToolStripButton.Size = new System.Drawing.Size(78, 28);
            this.fillBy1ToolStripButton.Text = "Refresh";
            this.fillBy1ToolStripButton.Click += new System.EventHandler(this.fillBy1ToolStripButton_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Location = new System.Drawing.Point(954, 38);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 51);
            this.button1.TabIndex = 4;
            this.button1.Text = "Restore";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button3.Location = new System.Drawing.Point(954, 96);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(196, 51);
            this.button3.TabIndex = 6;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // itemOutboundIdDataGridViewTextBoxColumn
            // 
            this.itemOutboundIdDataGridViewTextBoxColumn.DataPropertyName = "ItemOutboundId";
            this.itemOutboundIdDataGridViewTextBoxColumn.HeaderText = "ItemOutboundId";
            this.itemOutboundIdDataGridViewTextBoxColumn.Name = "itemOutboundIdDataGridViewTextBoxColumn";
            this.itemOutboundIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemOutboundIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemTitleDataGridViewTextBoxColumn
            // 
            this.itemTitleDataGridViewTextBoxColumn.DataPropertyName = "ItemTitle";
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
            // trackingNumDataGridViewTextBoxColumn
            // 
            this.trackingNumDataGridViewTextBoxColumn.DataPropertyName = "TrackingNum";
            this.trackingNumDataGridViewTextBoxColumn.HeaderText = "TrackingNum";
            this.trackingNumDataGridViewTextBoxColumn.Name = "trackingNumDataGridViewTextBoxColumn";
            this.trackingNumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // manipulatorDataGridViewTextBoxColumn
            // 
            this.manipulatorDataGridViewTextBoxColumn.DataPropertyName = "Manipulator";
            this.manipulatorDataGridViewTextBoxColumn.HeaderText = "Manipulator";
            this.manipulatorDataGridViewTextBoxColumn.Name = "manipulatorDataGridViewTextBoxColumn";
            this.manipulatorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Recycle_Bin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 888);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fillBy1ToolStrip);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Recycle_Bin";
            this.Text = "Recycle_Bin";
            this.Load += new System.EventHandler(this.Recycle_Bin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemOutboundsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryManagementDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryManagementDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryManagementDataSetBindingSource)).EndInit();
            this.fillBy1ToolStrip.ResumeLayout(false);
            this.fillBy1ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private InventoryManagementDataSet inventoryManagementDataSet;
        private System.Windows.Forms.BindingSource inventoryManagementDataSetBindingSource;
        private InventoryManagementDataSet1 inventoryManagementDataSet1;
        private System.Windows.Forms.BindingSource itemOutboundsBindingSource;
        private InventoryManagementDataSet1TableAdapters.ItemOutboundsTableAdapter itemOutboundsTableAdapter;
        private System.Windows.Forms.ToolStrip fillBy1ToolStrip;
        private System.Windows.Forms.ToolStripButton fillBy1ToolStripButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemOutboundIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTitleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trackingNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manipulatorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
    }
}