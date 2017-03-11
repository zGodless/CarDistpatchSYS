namespace DS.MSClient.UICommon
{
    partial class FormBatchTopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBatchTopUp));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.trl_Left = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListCol_sort = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl_Bottom = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_no = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_yes = new DevExpress.XtraEditors.SimpleButton();
            this.pagingControl1 = new DS.MSClient.UIControl.PagingControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit_ISUse = new DevExpress.XtraEditors.CheckEdit();
            this.txt_CashAmount = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.checkEdit_All = new DevExpress.XtraEditors.CheckEdit();
            this.gc_Student = new DS.MSClient.UIControl.CGridControl();
            this.gv_Student = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trl_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).BeginInit();
            this.panelControl_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ISUse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CashAmount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_All.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Student)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(191, 566);
            this.xtraTabControl1.TabIndex = 6;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.trl_Left);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(185, 537);
            this.xtraTabPage1.Text = "驾校";
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
            this.trl_Left.Size = new System.Drawing.Size(185, 537);
            this.trl_Left.TabIndex = 7;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "GroupName";
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
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(191, 0);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 566);
            this.splitterControl1.TabIndex = 7;
            this.splitterControl1.TabStop = false;
            // 
            // panelControl_Bottom
            // 
            this.panelControl_Bottom.Controls.Add(this.simpleButton_no);
            this.panelControl_Bottom.Controls.Add(this.simpleButton_yes);
            this.panelControl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl_Bottom.Location = new System.Drawing.Point(196, 521);
            this.panelControl_Bottom.Name = "panelControl_Bottom";
            this.panelControl_Bottom.Size = new System.Drawing.Size(860, 45);
            this.panelControl_Bottom.TabIndex = 8;
            // 
            // simpleButton_no
            // 
            this.simpleButton_no.Location = new System.Drawing.Point(742, 13);
            this.simpleButton_no.Name = "simpleButton_no";
            this.simpleButton_no.Size = new System.Drawing.Size(87, 27);
            this.simpleButton_no.TabIndex = 1;
            this.simpleButton_no.Text = "取消";
            // 
            // simpleButton_yes
            // 
            this.simpleButton_yes.Location = new System.Drawing.Point(621, 13);
            this.simpleButton_yes.Name = "simpleButton_yes";
            this.simpleButton_yes.Size = new System.Drawing.Size(87, 27);
            this.simpleButton_yes.TabIndex = 0;
            this.simpleButton_yes.Text = "确定";
            // 
            // pagingControl1
            // 
            this.pagingControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pagingControl1.Location = new System.Drawing.Point(196, 480);
            this.pagingControl1.Name = "pagingControl1";
            this.pagingControl1.Size = new System.Drawing.Size(860, 41);
            this.pagingControl1.TabIndex = 9;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.checkEdit_ISUse);
            this.panelControl3.Controls.Add(this.txt_CashAmount);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.checkEdit_All);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(196, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(860, 50);
            this.panelControl3.TabIndex = 10;
            // 
            // checkEdit_ISUse
            // 
            this.checkEdit_ISUse.Location = new System.Drawing.Point(437, 16);
            this.checkEdit_ISUse.Name = "checkEdit_ISUse";
            this.checkEdit_ISUse.Properties.Caption = "是否可提现";
            this.checkEdit_ISUse.Size = new System.Drawing.Size(87, 19);
            this.checkEdit_ISUse.TabIndex = 4;
            // 
            // txt_CashAmount
            // 
            this.txt_CashAmount.Location = new System.Drawing.Point(294, 16);
            this.txt_CashAmount.Name = "txt_CashAmount";
            this.txt_CashAmount.Properties.AutoComplete = false;
            this.txt_CashAmount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_CashAmount.Properties.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "200"});
            this.txt_CashAmount.Size = new System.Drawing.Size(117, 20);
            this.txt_CashAmount.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(220, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "充值金额";
            // 
            // checkEdit_All
            // 
            this.checkEdit_All.Location = new System.Drawing.Point(26, 14);
            this.checkEdit_All.Name = "checkEdit_All";
            this.checkEdit_All.Properties.Caption = "是否全选";
            this.checkEdit_All.Size = new System.Drawing.Size(101, 19);
            this.checkEdit_All.TabIndex = 0;
            // 
            // gc_Student
            // 
            this.gc_Student.AdvanceSearchMethod = null;
            this.gc_Student.GetPageSizeMethod = null;
            this.gc_Student.GetTotalRecordCountMethod = null;
            this.gc_Student.PageSortOrderSearchMethod = null;
            this.gc_Student.CallCustomNavicationButtonClick = null;
            this.gc_Student.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_Student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Student.ImmediatelyDownLoad = false;
            this.gc_Student.Location = new System.Drawing.Point(196, 50);
            this.gc_Student.MainView = this.gv_Student;
            this.gc_Student.Name = "gc_Student";
            this.gc_Student.ShowCustomHeaderMenu = true;
            this.gc_Student.ShowCustomNavigationButtons = false;
            this.gc_Student.ShowCustomRowHeightButton = true;
            this.gc_Student.ShowImmediatelyDownLoadMenu = true;
            this.gc_Student.Size = new System.Drawing.Size(860, 430);
            this.gc_Student.TabIndex = 11;
            this.gc_Student.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Student});
            // 
            // gv_Student
            // 
            this.gv_Student.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_choose,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn27,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn30,
            this.gridColumn11,
            this.gridColumn10,
            this.gridColumn9});
            this.gv_Student.GridControl = this.gc_Student;
            this.gv_Student.Name = "gv_Student";
            this.gv_Student.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gv_Student.OptionsDetail.EnableMasterViewMode = false;
            this.gv_Student.OptionsView.ColumnAutoWidth = false;
            this.gv_Student.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_Student.OptionsView.EnableAppearanceOddRow = true;
            this.gv_Student.OptionsView.ShowDetailButtons = false;
            // 
            // Column_choose
            // 
            this.Column_choose.AppearanceCell.Options.UseTextOptions = true;
            this.Column_choose.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_choose.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_choose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_choose.Caption = "选择";
            this.Column_choose.FieldName = "Choose";
            this.Column_choose.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.Column_choose.Name = "Column_choose";
            this.Column_choose.OptionsColumn.AllowEdit = false;
            this.Column_choose.OptionsColumn.ReadOnly = true;
            this.Column_choose.Visible = true;
            this.Column_choose.VisibleIndex = 0;
            // 
            // gridColumn28
            // 
            this.gridColumn28.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn28.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn28.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn28.Caption = "是否冻结";
            this.gridColumn28.FieldName = "IsLock";
            this.gridColumn28.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.OptionsColumn.ReadOnly = true;
            this.gridColumn28.OptionsFilter.AllowFilter = false;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 1;
            // 
            // gridColumn29
            // 
            this.gridColumn29.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn29.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn29.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn29.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn29.Caption = "是否过期";
            this.gridColumn29.FieldName = "IsExpire";
            this.gridColumn29.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.OptionsColumn.ReadOnly = true;
            this.gridColumn29.OptionsFilter.AllowFilter = false;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 2;
            // 
            // gridColumn27
            // 
            this.gridColumn27.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn27.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn27.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn27.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn27.Caption = "是否已有驾驶证";
            this.gridColumn27.FieldName = "IsLicense";
            this.gridColumn27.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.OptionsColumn.ReadOnly = true;
            this.gridColumn27.OptionsFilter.AllowFilter = false;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 3;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "学员编号";
            this.gridColumn2.FieldName = "StudentCode";
            this.gridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 119;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "学员姓名";
            this.gridColumn3.FieldName = "StudentName";
            this.gridColumn3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 127;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "驾校";
            this.gridColumn6.FieldName = "SchoolName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 9;
            this.gridColumn6.Width = 130;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "类型";
            this.gridColumn1.FieldName = "StudentType";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "性别";
            this.gridColumn12.FieldName = "Sex";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.OptionsFilter.AllowFilter = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "生日";
            this.gridColumn13.FieldName = "Birthday";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.OptionsFilter.AllowFilter = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 19;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.Caption = "所住地址";
            this.gridColumn14.FieldName = "Address";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.OptionsFilter.AllowFilter = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 16;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.Caption = "证件地址";
            this.gridColumn15.FieldName = "IdentityAddress";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.OptionsFilter.AllowFilter = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 17;
            this.gridColumn15.Width = 180;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.Caption = "邮编";
            this.gridColumn16.FieldName = "Postcode";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.OptionsFilter.AllowFilter = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 18;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.Caption = "证件号";
            this.gridColumn17.FieldName = "IdentityNo";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.OptionsFilter.AllowFilter = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 15;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.Caption = "证件类型";
            this.gridColumn18.FieldName = "IdentityType";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.OptionsFilter.AllowFilter = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 14;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.Caption = "报名渠道";
            this.gridColumn19.FieldName = "ApplyWayName";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            this.gridColumn19.OptionsFilter.AllowFilter = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 12;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.Caption = "报名点";
            this.gridColumn20.FieldName = "ApplyPlaceName";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.OptionsFilter.AllowFilter = false;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 10;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.Caption = "手机";
            this.gridColumn21.FieldName = "Cellphone";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.OptionsFilter.AllowFilter = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 20;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn22.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn22.Caption = "报名时间";
            this.gridColumn22.FieldName = "ApplyDate";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.ReadOnly = true;
            this.gridColumn22.OptionsFilter.AllowFilter = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 13;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn23.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn23.Caption = "Email";
            this.gridColumn23.FieldName = "MailAddress";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.ReadOnly = true;
            this.gridColumn23.OptionsFilter.AllowFilter = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 21;
            // 
            // gridColumn24
            // 
            this.gridColumn24.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn24.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn24.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn24.Caption = "QQ";
            this.gridColumn24.FieldName = "QQ";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.ReadOnly = true;
            this.gridColumn24.OptionsFilter.AllowFilter = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 22;
            // 
            // gridColumn25
            // 
            this.gridColumn25.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn25.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn25.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn25.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn25.Caption = "申请类型";
            this.gridColumn25.FieldName = "ApplyType";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.ReadOnly = true;
            this.gridColumn25.OptionsFilter.AllowFilter = false;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 11;
            // 
            // gridColumn26
            // 
            this.gridColumn26.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn26.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn26.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn26.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn26.Caption = "训练类型";
            this.gridColumn26.FieldName = "TrainingType";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.ReadOnly = true;
            this.gridColumn26.OptionsFilter.AllowFilter = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 7;
            // 
            // gridColumn30
            // 
            this.gridColumn30.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn30.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn30.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn30.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn30.Caption = "备注";
            this.gridColumn30.FieldName = "Note";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.OptionsColumn.ReadOnly = true;
            this.gridColumn30.OptionsFilter.AllowFilter = false;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 23;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "操作员";
            this.gridColumn11.FieldName = "OperateName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 24;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "操作时间";
            this.gridColumn10.FieldName = "OperateTime";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 25;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "密码";
            this.gridColumn9.FieldName = "password";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            // 
            // FormBatchTopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 566);
            this.Controls.Add(this.gc_Student);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.pagingControl1);
            this.Controls.Add(this.panelControl_Bottom);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.xtraTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBatchTopUp";
            this.Text = "批量充值";
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trl_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).EndInit();
            this.panelControl_Bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_ISUse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_CashAmount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit_All.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Student)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTreeList.TreeList trl_Left;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListCol_sort;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.PanelControl panelControl_Bottom;
        private DevExpress.XtraEditors.SimpleButton simpleButton_no;
        private DevExpress.XtraEditors.SimpleButton simpleButton_yes;
        private UIControl.PagingControl pagingControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit checkEdit_All;
        private DevExpress.XtraEditors.CheckEdit checkEdit_ISUse;
        private DevExpress.XtraEditors.ComboBoxEdit txt_CashAmount;
        private UIControl.CGridControl gc_Student;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Student;
        private DevExpress.XtraGrid.Columns.GridColumn Column_choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}