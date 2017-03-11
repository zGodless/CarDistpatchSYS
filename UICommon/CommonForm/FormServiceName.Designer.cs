namespace DS.MSClient.UICommon
{
    partial class FormServiceName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormServiceName));
            this.gc_servicename = new DS.MSClient.UIControl.CGridControl();
            this.gv_servicename = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_no = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_yes = new DevExpress.XtraEditors.SimpleButton();
            this.gc_service = new DS.MSClient.UIControl.CGridControl();
            this.gv_service = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gc_servicename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_servicename)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_service)).BeginInit();
            this.SuspendLayout();
            // 
            // gc_servicename
            // 
            this.gc_servicename.AdvanceSearchMethod = null;
            this.gc_servicename.GetPageSizeMethod = null;
            this.gc_servicename.GetTotalRecordCountMethod = null;
            this.gc_servicename.PageSortOrderSearchMethod = null;
            this.gc_servicename.CallCustomNavicationButtonClick = null;
            this.gc_servicename.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_servicename.ImmediatelyDownLoad = false;
            this.gc_servicename.Location = new System.Drawing.Point(116, 7);
            this.gc_servicename.MainView = this.gv_servicename;
            this.gc_servicename.Name = "gc_servicename";
            this.gc_servicename.ShowCustomHeaderMenu = true;
            this.gc_servicename.ShowCustomNavigationButtons = false;
            this.gc_servicename.ShowCustomRowHeightButton = true;
            this.gc_servicename.ShowImmediatelyDownLoadMenu = true;
            this.gc_servicename.Size = new System.Drawing.Size(479, 353);
            this.gc_servicename.TabIndex = 4;
            this.gc_servicename.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_servicename});
            // 
            // gv_servicename
            // 
            this.gv_servicename.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Choose,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gv_servicename.GridControl = this.gc_servicename;
            this.gv_servicename.Name = "gv_servicename";
            // 
            // Column_Choose
            // 
            this.Column_Choose.Caption = "gridColumn1";
            this.Column_Choose.FieldName = "Choose";
            this.Column_Choose.Name = "Column_Choose";
            this.Column_Choose.Visible = true;
            this.Column_Choose.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "服务编号";
            this.gridColumn1.FieldName = "ServiceCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "服务名";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "助记码";
            this.gridColumn3.FieldName = "MnemonicCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "备注";
            this.gridColumn4.FieldName = "Note";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gc_servicename;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(592, 357);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(105, 14);
            this.layoutControlItem1.TextToControlDistance = 5;
            this.layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton_no);
            this.panelControl1.Controls.Add(this.simpleButton_yes);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 344);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(807, 51);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButton_no
            // 
            this.simpleButton_no.Location = new System.Drawing.Point(703, 10);
            this.simpleButton_no.Name = "simpleButton_no";
            this.simpleButton_no.Size = new System.Drawing.Size(87, 27);
            this.simpleButton_no.TabIndex = 1;
            this.simpleButton_no.Text = "取消";
            // 
            // simpleButton_yes
            // 
            this.simpleButton_yes.Location = new System.Drawing.Point(579, 10);
            this.simpleButton_yes.Name = "simpleButton_yes";
            this.simpleButton_yes.Size = new System.Drawing.Size(87, 27);
            this.simpleButton_yes.TabIndex = 0;
            this.simpleButton_yes.Text = "确定";
            // 
            // gc_service
            // 
            this.gc_service.AdvanceSearchMethod = null;
            this.gc_service.GetPageSizeMethod = null;
            this.gc_service.GetTotalRecordCountMethod = null;
            this.gc_service.PageSortOrderSearchMethod = null;
            this.gc_service.CallCustomNavicationButtonClick = null;
            this.gc_service.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_service.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_service.ImmediatelyDownLoad = false;
            this.gc_service.Location = new System.Drawing.Point(0, 0);
            this.gc_service.MainView = this.gv_service;
            this.gc_service.Name = "gc_service";
            this.gc_service.ShowCustomHeaderMenu = true;
            this.gc_service.ShowCustomNavigationButtons = false;
            this.gc_service.ShowCustomRowHeightButton = true;
            this.gc_service.ShowImmediatelyDownLoadMenu = true;
            this.gc_service.Size = new System.Drawing.Size(807, 344);
            this.gc_service.TabIndex = 2;
            this.gc_service.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_service});
            // 
            // gv_service
            // 
            this.gv_service.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_choose,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gv_service.GridControl = this.gc_service;
            this.gv_service.Name = "gv_service";
            this.gv_service.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_service.OptionsView.EnableAppearanceOddRow = true;
            // 
            // gridColumn_choose
            // 
            this.gridColumn_choose.Caption = "选择";
            this.gridColumn_choose.FieldName = "Choose";
            this.gridColumn_choose.Name = "gridColumn_choose";
            this.gridColumn_choose.OptionsColumn.AllowEdit = false;
            this.gridColumn_choose.OptionsColumn.ReadOnly = true;
            this.gridColumn_choose.Visible = true;
            this.gridColumn_choose.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "服务编号";
            this.gridColumn6.FieldName = "ServiceCode";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "服务名称";
            this.gridColumn7.FieldName = "ServiceName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "助记码";
            this.gridColumn8.FieldName = "MnemonicCode";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "备注";
            this.gridColumn9.FieldName = "Note";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            // 
            // FormServiceName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 395);
            this.Controls.Add(this.gc_service);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormServiceName";
            this.Text = "选择服务商品";
            ((System.ComponentModel.ISupportInitialize)(this.gc_servicename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_servicename)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_service)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UIControl.CGridControl gc_servicename;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_servicename;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_no;
        private DevExpress.XtraEditors.SimpleButton simpleButton_yes;
        private UIControl.CGridControl gc_service;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_service;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}