namespace DS.MSClient.UICommon
{
    partial class FormSelectService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectService));
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gc_Service = new DS.MSClient.UIControl.CGridControl();
            this.gv_Service = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Checked = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Choose = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl_Bottom = new DevExpress.XtraEditors.PanelControl();
            this.Btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Canel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl_Class = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Checked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Choose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).BeginInit();
            this.panelControl_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Class)).BeginInit();
            this.groupControl_Class.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // gridView2
            // 
            this.gridView2.Name = "gridView2";
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.gc_Service;
            this.gridView4.Name = "gridView4";
            // 
            // gc_Service
            // 
            this.gc_Service.AdvanceSearchMethod = null;
            this.gc_Service.GetPageSizeMethod = null;
            this.gc_Service.GetTotalRecordCountMethod = null;
            this.gc_Service.PageSortOrderSearchMethod = null;
            this.gc_Service.CallCustomNavicationButtonClick = null;
            this.gc_Service.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_Service.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Service.ImmediatelyDownLoad = false;
            this.gc_Service.Location = new System.Drawing.Point(2, 22);
            this.gc_Service.MainView = this.gv_Service;
            this.gc_Service.Name = "gc_Service";
            this.gc_Service.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.Checked,
            this.Choose});
            this.gc_Service.ShowCustomHeaderMenu = true;
            this.gc_Service.ShowCustomNavigationButtons = false;
            this.gc_Service.ShowCustomRowHeightButton = true;
            this.gc_Service.ShowImmediatelyDownLoadMenu = true;
            this.gc_Service.Size = new System.Drawing.Size(424, 270);
            this.gc_Service.TabIndex = 1;
            this.gc_Service.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Service,
            this.gridView6,
            this.gridView4});
            // 
            // gv_Service
            // 
            this.gv_Service.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_Choose,
            this.gridColumn2});
            this.gv_Service.GridControl = this.gc_Service;
            this.gv_Service.Name = "gv_Service";
            this.gv_Service.OptionsView.ColumnAutoWidth = false;
            this.gv_Service.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_Service.OptionsView.EnableAppearanceOddRow = true;
            // 
            // gridColumn_Choose
            // 
            this.gridColumn_Choose.Caption = "选择";
            this.gridColumn_Choose.FieldName = "Choose";
            this.gridColumn_Choose.Name = "gridColumn_Choose";
            this.gridColumn_Choose.OptionsColumn.AllowEdit = false;
            this.gridColumn_Choose.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "培训类型";
            this.gridColumn2.FieldName = "ServiceName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 125;
            // 
            // Checked
            // 
            this.Checked.AutoHeight = false;
            this.Checked.Caption = "";
            this.Checked.Name = "Checked";
            // 
            // Choose
            // 
            this.Choose.AutoHeight = false;
            this.Choose.Caption = "Check";
            this.Choose.Name = "Choose";
            // 
            // gridView6
            // 
            this.gridView6.GridControl = this.gc_Service;
            this.gridView6.Name = "gridView6";
            // 
            // panelControl_Bottom
            // 
            this.panelControl_Bottom.Controls.Add(this.Btn_OK);
            this.panelControl_Bottom.Controls.Add(this.Btn_Canel);
            this.panelControl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl_Bottom.Location = new System.Drawing.Point(2, 292);
            this.panelControl_Bottom.Name = "panelControl_Bottom";
            this.panelControl_Bottom.Size = new System.Drawing.Size(424, 48);
            this.panelControl_Bottom.TabIndex = 2;
            // 
            // Btn_OK
            // 
            this.Btn_OK.Location = new System.Drawing.Point(250, 15);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(75, 23);
            this.Btn_OK.TabIndex = 1;
            this.Btn_OK.Text = "确定";
            // 
            // Btn_Canel
            // 
            this.Btn_Canel.Location = new System.Drawing.Point(344, 15);
            this.Btn_Canel.Name = "Btn_Canel";
            this.Btn_Canel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Canel.TabIndex = 0;
            this.Btn_Canel.Text = "取消";
            // 
            // groupControl_Class
            // 
            this.groupControl_Class.Controls.Add(this.gc_Service);
            this.groupControl_Class.Controls.Add(this.panelControl_Bottom);
            this.groupControl_Class.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl_Class.Location = new System.Drawing.Point(0, 0);
            this.groupControl_Class.Name = "groupControl_Class";
            this.groupControl_Class.Size = new System.Drawing.Size(428, 342);
            this.groupControl_Class.TabIndex = 3;
            this.groupControl_Class.Text = "选择培训方式";
            // 
            // FormSelectService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 342);
            this.Controls.Add(this.groupControl_Class);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectService";
            this.Text = "绑定培训方式";
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Checked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Choose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).EndInit();
            this.panelControl_Bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl_Class)).EndInit();
            this.groupControl_Class.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private UIControl.CGridControl gc_Service;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Service;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Checked;
        private DevExpress.XtraEditors.PanelControl panelControl_Bottom;
        private DevExpress.XtraEditors.SimpleButton Btn_OK;
        private DevExpress.XtraEditors.SimpleButton Btn_Canel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraEditors.GroupControl groupControl_Class;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Choose;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit Choose;

    }
}