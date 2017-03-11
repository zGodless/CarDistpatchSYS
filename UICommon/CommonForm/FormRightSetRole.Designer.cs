namespace DS.MSClient.UICommon
{
    partial class FormRightSetRole
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
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.trl_Left = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListCol_sort = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_yes = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_no = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_RoleName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trl_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(370, 437);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.trl_Left);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(364, 408);
            this.xtraTabPage1.Text = " 权限 ";
            // 
            // trl_Left
            // 
            this.trl_Left.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListCol_sort});
            this.trl_Left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trl_Left.Location = new System.Drawing.Point(0, 0);
            this.trl_Left.Name = "trl_Left";
            this.trl_Left.OptionsView.ShowHorzLines = false;
            this.trl_Left.OptionsView.ShowIndicator = false;
            this.trl_Left.ParentFieldName = "";
            this.trl_Left.Size = new System.Drawing.Size(364, 408);
            this.trl_Left.TabIndex = 12;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "选择";
            this.treeListColumn1.FieldName = "Choose";
            this.treeListColumn1.MinWidth = 32;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 32;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "权限列表";
            this.treeListColumn2.FieldName = "RightName";
            this.treeListColumn2.MinWidth = 32;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 340;
            // 
            // treeListCol_sort
            // 
            this.treeListCol_sort.Caption = "treeListColumn3";
            this.treeListCol_sort.FieldName = "Array";
            this.treeListCol_sort.Name = "treeListCol_sort";
            this.treeListCol_sort.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(364, 37);
            this.xtraTabPage2.Text = " 报表 ";
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(1, -39);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(364, 100);
            this.panelControl1.TabIndex = 2;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lbl_RoleName);
            this.panelControl2.Controls.Add(this.simpleButton_no);
            this.panelControl2.Controls.Add(this.simpleButton_yes);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 437);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(370, 51);
            this.panelControl2.TabIndex = 1;
            // 
            // simpleButton_yes
            // 
            this.simpleButton_yes.Location = new System.Drawing.Point(164, 23);
            this.simpleButton_yes.Name = "simpleButton_yes";
            this.simpleButton_yes.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_yes.TabIndex = 0;
            this.simpleButton_yes.Text = "确定";
            // 
            // simpleButton_no
            // 
            this.simpleButton_no.Location = new System.Drawing.Point(283, 23);
            this.simpleButton_no.Name = "simpleButton_no";
            this.simpleButton_no.Size = new System.Drawing.Size(75, 23);
            this.simpleButton_no.TabIndex = 1;
            this.simpleButton_no.Text = "取消";
            // 
            // lbl_RoleName
            // 
            this.lbl_RoleName.Location = new System.Drawing.Point(13, 25);
            this.lbl_RoleName.Name = "lbl_RoleName";
            this.lbl_RoleName.Size = new System.Drawing.Size(12, 14);
            this.lbl_RoleName.TabIndex = 2;
            this.lbl_RoleName.Text = "   ";
            // 
            // FormRightSetRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 488);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "FormRightSetRole";
            this.Text = "设置角色权限";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trl_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTreeList.TreeList trl_Left;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_sort;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton_no;
        private DevExpress.XtraEditors.SimpleButton simpleButton_yes;
        private DevExpress.XtraEditors.LabelControl lbl_RoleName;
    }
}