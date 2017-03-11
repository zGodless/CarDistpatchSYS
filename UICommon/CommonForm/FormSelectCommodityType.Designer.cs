namespace DS.MSClient.UICommon
{
    partial class FormSelectCommodityType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectCommodityType));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.trl_Left = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListCol_sort = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trl_Left)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.Btn_Cancel);
            this.panelControl2.Controls.Add(this.Btn_Ok);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 487);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(442, 34);
            this.panelControl2.TabIndex = 2;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Cancel.Location = new System.Drawing.Point(362, 6);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 1;
            this.Btn_Cancel.Text = "取消(&C)";
            // 
            // Btn_Ok
            // 
            this.Btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Ok.Location = new System.Drawing.Point(281, 6);
            this.Btn_Ok.Name = "Btn_Ok";
            this.Btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.Btn_Ok.TabIndex = 0;
            this.Btn_Ok.Text = "确定(&O)";
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Name = "treeListColumn1";
            // 
            // trl_Left
            // 
            this.trl_Left.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn2,
            this.treeListCol_sort});
            this.trl_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trl_Left.Location = new System.Drawing.Point(0, 0);
            this.trl_Left.Name = "trl_Left";
            this.trl_Left.OptionsView.ShowColumns = false;
            this.trl_Left.OptionsView.ShowHorzLines = false;
            this.trl_Left.OptionsView.ShowIndicator = false;
            this.trl_Left.Size = new System.Drawing.Size(442, 487);
            this.trl_Left.TabIndex = 3;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "CommoditytypeName";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            // 
            // treeListCol_sort
            // 
            this.treeListCol_sort.Caption = "treeListColumn3";
            this.treeListCol_sort.FieldName = "Array";
            this.treeListCol_sort.Name = "treeListCol_sort";
            this.treeListCol_sort.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            // 
            // FormSelectCommodityType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 521);
            this.Controls.Add(this.trl_Left);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectCommodityType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单选商品分类";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trl_Left)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton Btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton Btn_Ok;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.TreeList trl_Left;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_sort;
    }
}