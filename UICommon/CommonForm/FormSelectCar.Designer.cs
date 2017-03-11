namespace DS.MSClient.UICommon.CommonForm
{
    partial class FormSelectCar
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectCar));
			DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
			DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
			DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
			DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
			this.gc_Car = new DS.MSClient.UIControl.CGridControl();
			this.Copy = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.btnCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.gv_Car = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.Column_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.chkCheckAll = new DevExpress.XtraEditors.CheckEdit();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			this.gcSelect = new DS.MSClient.UIControl.CGridControl();
			this.gvSelect = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
			this.btnSelAdd = new DevExpress.XtraEditors.SimpleButton();
			this.btnSelRemove = new DevExpress.XtraEditors.SimpleButton();
			this.btnSelClear = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
			this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
			((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
			this.lcMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gc_Car)).BeginInit();
			this.Copy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gv_Car)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chkCheckAll.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gcSelect)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSelect)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(817, 595);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(902, 595);
			// 
			// lcMain
			// 
			this.lcMain.Controls.Add(this.btnSelAdd);
			this.lcMain.Controls.Add(this.btnSelRemove);
			this.lcMain.Controls.Add(this.btnSelClear);
			this.lcMain.Controls.Add(this.chkCheckAll);
			this.lcMain.Controls.Add(this.gcSelect);
			this.lcMain.Controls.Add(this.gc_Car);
			this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(991, 392, 250, 350);
			this.lcMain.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lcMain.Size = new System.Drawing.Size(988, 624);
			this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
			this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
			this.lcMain.Controls.SetChildIndex(this.gc_Car, 0);
			this.lcMain.Controls.SetChildIndex(this.gcSelect, 0);
			this.lcMain.Controls.SetChildIndex(this.chkCheckAll, 0);
			this.lcMain.Controls.SetChildIndex(this.btnSelClear, 0);
			this.lcMain.Controls.SetChildIndex(this.btnSelRemove, 0);
			this.lcMain.Controls.SetChildIndex(this.btnSelAdd, 0);
			// 
			// lcgMain
			// 
			this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
			this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
			this.lcgMain.Name = "Root";
			this.lcgMain.Size = new System.Drawing.Size(988, 624);
			this.lcgMain.Text = "Root";
			// 
			// lciOK
			// 
			this.lciOK.Location = new System.Drawing.Point(810, 588);
			this.lciOK.MaxSize = new System.Drawing.Size(85, 0);
			// 
			// lciCancel
			// 
			this.lciCancel.Location = new System.Drawing.Point(895, 588);
			this.lciCancel.MaxSize = new System.Drawing.Size(83, 0);
			// 
			// ssOp
			// 
			this.ssOp.Location = new System.Drawing.Point(0, 586);
			this.ssOp.Size = new System.Drawing.Size(978, 2);
			// 
			// esiOpEmpty
			// 
			this.esiOpEmpty.Location = new System.Drawing.Point(79, 588);
			this.esiOpEmpty.Size = new System.Drawing.Size(731, 26);
			// 
			// lcgContainer
			// 
			this.lcgContainer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.splitterItem1,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.emptySpaceItem2,
            this.layoutControlGroup1,
            this.layoutControlGroup2});
			this.lcgContainer.Size = new System.Drawing.Size(978, 586);
			// 
			// gc_Car
			// 
			this.gc_Car.AdvanceSearchMethod = null;
			this.gc_Car.CallCustomNavicationButtonClick = null;
			this.gc_Car.ContextMenuStrip = this.Copy;
			this.gc_Car.Cursor = System.Windows.Forms.Cursors.Default;
			this.gc_Car.GetPageSizeMethod = null;
			this.gc_Car.GetTotalRecordCountMethod = null;
			this.gc_Car.ImmediatelyDownLoad = false;
			this.gc_Car.Location = new System.Drawing.Point(10, 30);
			this.gc_Car.MainView = this.gv_Car;
			this.gc_Car.Name = "gc_Car";
			this.gc_Car.PageSortOrderSearchMethod = null;
			this.gc_Car.ShowCustomHeaderMenu = true;
			this.gc_Car.ShowCustomNavigationButtons = false;
			this.gc_Car.ShowCustomRowHeightButton = true;
			this.gc_Car.ShowImmediatelyDownLoadMenu = true;
			this.gc_Car.Size = new System.Drawing.Size(697, 556);
			this.gc_Car.TabIndex = 11;
			this.gc_Car.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Car});
			// 
			// Copy
			// 
			this.Copy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCopy});
			this.Copy.Name = "Btn_Copy";
			this.Copy.Size = new System.Drawing.Size(101, 26);
			this.Copy.Text = "复制";
			// 
			// btnCopy
			// 
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(100, 22);
			this.btnCopy.Text = "复制";
			// 
			// gv_Car
			// 
			this.gv_Car.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Choose,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn5,
            this.gridColumn6});
			this.gv_Car.GridControl = this.gc_Car;
			this.gv_Car.Name = "gv_Car";
			this.gv_Car.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.gv_Car.OptionsView.ColumnAutoWidth = false;
			this.gv_Car.OptionsView.EnableAppearanceEvenRow = true;
			this.gv_Car.OptionsView.EnableAppearanceOddRow = true;
			this.gv_Car.OptionsView.ShowAutoFilterRow = true;
			this.gv_Car.OptionsView.ShowDetailButtons = false;
			this.gv_Car.OptionsView.ShowFooter = true;
			this.gv_Car.OptionsView.ShowGroupPanel = false;
			// 
			// Column_Choose
			// 
			this.Column_Choose.AppearanceCell.Options.UseTextOptions = true;
			this.Column_Choose.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.Column_Choose.AppearanceHeader.Options.UseTextOptions = true;
			this.Column_Choose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.Column_Choose.Caption = "选择";
			this.Column_Choose.FieldName = "Choose";
			this.Column_Choose.MaxWidth = 40;
			this.Column_Choose.MinWidth = 40;
			this.Column_Choose.Name = "Column_Choose";
			this.Column_Choose.OptionsFilter.AllowAutoFilter = false;
			this.Column_Choose.OptionsFilter.AllowFilter = false;
			this.Column_Choose.Visible = true;
			this.Column_Choose.VisibleIndex = 0;
			this.Column_Choose.Width = 40;
			// 
			// gridColumn2
			// 
			this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn2.Caption = "车牌号";
			this.gridColumn2.FieldName = "CarNo";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.OptionsColumn.ReadOnly = true;
			this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
			this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			this.gridColumn2.Width = 107;
			// 
			// gridColumn3
			// 
			this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn3.Caption = "车辆分队编号";
			this.gridColumn3.FieldName = "CarCode";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.OptionsColumn.ReadOnly = true;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			this.gridColumn3.Width = 100;
			// 
			// gridColumn7
			// 
			this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn7.Caption = "车辆性质";
			this.gridColumn7.FieldName = "Property";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.OptionsColumn.AllowEdit = false;
			this.gridColumn7.OptionsColumn.ReadOnly = true;
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 3;
			this.gridColumn7.Width = 103;
			// 
			// gridColumn8
			// 
			this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn8.Caption = "累计公里数";
			this.gridColumn8.FieldName = "CurrentKil";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.OptionsColumn.AllowEdit = false;
			this.gridColumn8.OptionsColumn.ReadOnly = true;
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 7;
			// 
			// gridColumn9
			// 
			this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn9.Caption = "年检到期日期";
			this.gridColumn9.FieldName = "YearCheckExpDate";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.OptionsColumn.AllowEdit = false;
			this.gridColumn9.OptionsColumn.ReadOnly = true;
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 5;
			this.gridColumn9.Width = 122;
			// 
			// gridColumn5
			// 
			this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn5.Caption = "所属驾校";
			this.gridColumn5.FieldName = "SchoolName";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.OptionsColumn.ReadOnly = true;
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			this.gridColumn5.Width = 102;
			// 
			// gridColumn6
			// 
			this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn6.Caption = "状态";
			this.gridColumn6.FieldName = "statusName";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.AllowEdit = false;
			this.gridColumn6.OptionsColumn.ReadOnly = true;
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 6;
			this.gridColumn6.Width = 118;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.gc_Car;
			this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(701, 560);
			this.layoutControlItem1.Text = "layoutControlItem1";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem1.TextToControlDistance = 0;
			this.layoutControlItem1.TextVisible = false;
			// 
			// chkCheckAll
			// 
			this.chkCheckAll.Location = new System.Drawing.Point(7, 595);
			this.chkCheckAll.Name = "chkCheckAll";
			this.chkCheckAll.Properties.AllowGrayed = true;
			this.chkCheckAll.Properties.Caption = "全选(&A)";
			this.chkCheckAll.Properties.ReadOnly = true;
			this.chkCheckAll.Size = new System.Drawing.Size(75, 19);
			this.chkCheckAll.StyleController = this.lcMain;
			this.chkCheckAll.TabIndex = 18;
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.chkCheckAll;
			this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 588);
			this.layoutControlItem3.MaxSize = new System.Drawing.Size(79, 0);
			this.layoutControlItem3.MinSize = new System.Drawing.Size(79, 23);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(79, 26);
			this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.layoutControlItem3.Text = "layoutControlItem3";
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextToControlDistance = 0;
			this.layoutControlItem3.TextVisible = false;
			// 
			// gcSelect
			// 
			this.gcSelect.AdvanceSearchMethod = null;
			this.gcSelect.CallCustomNavicationButtonClick = null;
			this.gcSelect.Cursor = System.Windows.Forms.Cursors.Default;
			this.gcSelect.GetPageSizeMethod = null;
			this.gcSelect.GetTotalRecordCountMethod = null;
			this.gcSelect.ImmediatelyDownLoad = false;
			this.gcSelect.Location = new System.Drawing.Point(776, 30);
			this.gcSelect.MainView = this.gvSelect;
			this.gcSelect.Name = "gcSelect";
			this.gcSelect.PageSortOrderSearchMethod = null;
			this.gcSelect.ShowCustomHeaderMenu = true;
			this.gcSelect.ShowCustomNavigationButtons = false;
			this.gcSelect.ShowCustomRowHeightButton = true;
			this.gcSelect.ShowImmediatelyDownLoadMenu = true;
			this.gcSelect.Size = new System.Drawing.Size(202, 556);
			this.gcSelect.TabIndex = 11;
			this.gcSelect.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSelect});
			// 
			// gvSelect
			// 
			this.gvSelect.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4});
			this.gvSelect.GridControl = this.gcSelect;
			this.gvSelect.IndicatorWidth = 50;
			this.gvSelect.Name = "gvSelect";
			this.gvSelect.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
			this.gvSelect.OptionsCustomization.AllowColumnMoving = false;
			this.gvSelect.OptionsCustomization.AllowFilter = false;
			this.gvSelect.OptionsCustomization.AllowGroup = false;
			this.gvSelect.OptionsCustomization.AllowQuickHideColumns = false;
			this.gvSelect.OptionsCustomization.AllowSort = false;
			this.gvSelect.OptionsView.EnableAppearanceEvenRow = true;
			this.gvSelect.OptionsView.EnableAppearanceOddRow = true;
			this.gvSelect.OptionsView.ShowAutoFilterRow = true;
			this.gvSelect.OptionsView.ShowDetailButtons = false;
			this.gvSelect.OptionsView.ShowFooter = true;
			this.gvSelect.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn1.Caption = "选择";
			this.gridColumn1.FieldName = "Choose";
			this.gridColumn1.MaxWidth = 40;
			this.gridColumn1.MinWidth = 40;
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
			this.gridColumn1.OptionsFilter.AllowFilter = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			this.gridColumn1.Width = 40;
			// 
			// gridColumn4
			// 
			this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
			this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.gridColumn4.Caption = "车牌号";
			this.gridColumn4.FieldName = "CarNo";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.OptionsColumn.ReadOnly = true;
			this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
			this.gridColumn4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 1;
			this.gridColumn4.Width = 103;
			// 
			// layoutControlItem5
			// 
			this.layoutControlItem5.Control = this.gcSelect;
			this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
			this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem5.Name = "layoutControlItem5";
			this.layoutControlItem5.Size = new System.Drawing.Size(206, 560);
			this.layoutControlItem5.Text = "layoutControlItem5";
			this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem5.TextToControlDistance = 0;
			this.layoutControlItem5.TextVisible = false;
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
			this.emptySpaceItem1.Location = new System.Drawing.Point(712, 315);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(54, 271);
			this.emptySpaceItem1.Text = "emptySpaceItem1";
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// splitterItem1
			// 
			this.splitterItem1.AllowHotTrack = true;
			this.splitterItem1.CustomizationFormText = "splitterItem1";
			this.splitterItem1.Location = new System.Drawing.Point(707, 0);
			this.splitterItem1.Name = "splitterItem1";
			this.splitterItem1.Size = new System.Drawing.Size(5, 586);
			// 
			// btnSelAdd
			// 
			this.btnSelAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnSelAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnSelAdd.Image")));
			this.btnSelAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.btnSelAdd.Location = new System.Drawing.Point(719, 160);
			this.btnSelAdd.MaximumSize = new System.Drawing.Size(50, 50);
			this.btnSelAdd.MinimumSize = new System.Drawing.Size(50, 50);
			this.btnSelAdd.Name = "btnSelAdd";
			this.btnSelAdd.Size = new System.Drawing.Size(50, 50);
			this.btnSelAdd.StyleController = this.lcMain;
			toolTipTitleItem1.Appearance.Options.UseImage = true;
			toolTipTitleItem1.Text = "添加";
			toolTipItem1.LeftIndent = 6;
			toolTipItem1.Text = "将查询结果中所选的内容加到已选择列表";
			superToolTip1.Items.Add(toolTipTitleItem1);
			superToolTip1.Items.Add(toolTipItem1);
			this.btnSelAdd.SuperTip = superToolTip1;
			this.btnSelAdd.TabIndex = 94;
			this.btnSelAdd.Text = "添加";
			// 
			// btnSelRemove
			// 
			this.btnSelRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnSelRemove.Image = ((System.Drawing.Image)(resources.GetObject("btnSelRemove.Image")));
			this.btnSelRemove.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.btnSelRemove.Location = new System.Drawing.Point(719, 214);
			this.btnSelRemove.MaximumSize = new System.Drawing.Size(50, 50);
			this.btnSelRemove.MinimumSize = new System.Drawing.Size(50, 50);
			this.btnSelRemove.Name = "btnSelRemove";
			this.btnSelRemove.Size = new System.Drawing.Size(50, 50);
			this.btnSelRemove.StyleController = this.lcMain;
			toolTipTitleItem2.Appearance.Options.UseImage = true;
			toolTipTitleItem2.Text = "移除";
			toolTipItem2.LeftIndent = 6;
			toolTipItem2.Text = "将已选择列表中所选项移除，还原到结果列表中";
			superToolTip2.Items.Add(toolTipTitleItem2);
			superToolTip2.Items.Add(toolTipItem2);
			this.btnSelRemove.SuperTip = superToolTip2;
			this.btnSelRemove.TabIndex = 95;
			this.btnSelRemove.Text = "移除";
			// 
			// btnSelClear
			// 
			this.btnSelClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnSelClear.Image = ((System.Drawing.Image)(resources.GetObject("btnSelClear.Image")));
			this.btnSelClear.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.btnSelClear.Location = new System.Drawing.Point(719, 268);
			this.btnSelClear.MaximumSize = new System.Drawing.Size(50, 50);
			this.btnSelClear.MinimumSize = new System.Drawing.Size(50, 50);
			this.btnSelClear.Name = "btnSelClear";
			this.btnSelClear.Size = new System.Drawing.Size(50, 50);
			this.btnSelClear.StyleController = this.lcMain;
			toolTipTitleItem3.Appearance.Options.UseImage = true;
			toolTipTitleItem3.Text = "清除";
			toolTipItem3.LeftIndent = 6;
			toolTipItem3.Text = "清空已选择列表";
			superToolTip3.Items.Add(toolTipTitleItem3);
			superToolTip3.Items.Add(toolTipItem3);
			this.btnSelClear.SuperTip = superToolTip3;
			this.btnSelClear.TabIndex = 96;
			this.btnSelClear.Text = "清除";
			// 
			// layoutControlItem6
			// 
			this.layoutControlItem6.Control = this.btnSelClear;
			this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
			this.layoutControlItem6.Location = new System.Drawing.Point(712, 261);
			this.layoutControlItem6.Name = "layoutControlItem6";
			this.layoutControlItem6.Size = new System.Drawing.Size(54, 54);
			this.layoutControlItem6.Text = "layoutControlItem6";
			this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem6.TextToControlDistance = 0;
			this.layoutControlItem6.TextVisible = false;
			// 
			// layoutControlItem7
			// 
			this.layoutControlItem7.Control = this.btnSelRemove;
			this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
			this.layoutControlItem7.Location = new System.Drawing.Point(712, 207);
			this.layoutControlItem7.Name = "layoutControlItem7";
			this.layoutControlItem7.Size = new System.Drawing.Size(54, 54);
			this.layoutControlItem7.Text = "layoutControlItem7";
			this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem7.TextToControlDistance = 0;
			this.layoutControlItem7.TextVisible = false;
			// 
			// layoutControlItem8
			// 
			this.layoutControlItem8.Control = this.btnSelAdd;
			this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
			this.layoutControlItem8.Location = new System.Drawing.Point(712, 153);
			this.layoutControlItem8.Name = "layoutControlItem8";
			this.layoutControlItem8.Size = new System.Drawing.Size(54, 54);
			this.layoutControlItem8.Text = "layoutControlItem8";
			this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem8.TextToControlDistance = 0;
			this.layoutControlItem8.TextVisible = false;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
			this.emptySpaceItem2.Location = new System.Drawing.Point(712, 0);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(54, 153);
			this.emptySpaceItem2.Text = "emptySpaceItem2";
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "可选分队";
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "layoutControlGroup1";
			this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup1.Size = new System.Drawing.Size(707, 586);
			this.layoutControlGroup1.Text = "可选车辆";
			// 
			// layoutControlGroup2
			// 
			this.layoutControlGroup2.CustomizationFormText = "已选车辆";
			this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem5});
			this.layoutControlGroup2.Location = new System.Drawing.Point(766, 0);
			this.layoutControlGroup2.Name = "layoutControlGroup2";
			this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.layoutControlGroup2.Size = new System.Drawing.Size(212, 586);
			this.layoutControlGroup2.Text = "已选车辆";
			// 
			// FormSelectCar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(988, 624);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.LookAndFeel.SkinName = "Office 2010 Silver";
			this.Name = "FormSelectCar";
			this.Text = "选择车辆";
			this.Controls.SetChildIndex(this.lcMain, 0);
			((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
			this.lcMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gc_Car)).EndInit();
			this.Copy.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gv_Car)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chkCheckAll.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gcSelect)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvSelect)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private UIControl.CGridControl gc_Car;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Car;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.CheckEdit chkCheckAll;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private System.Windows.Forms.ContextMenuStrip Copy;
        private System.Windows.Forms.ToolStripMenuItem btnCopy;
        private DevExpress.XtraGrid.GridControl cGridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private UIControl.CGridControl gcSelect;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraEditors.SimpleButton btnSelAdd;
        private DevExpress.XtraEditors.SimpleButton btnSelRemove;
        private DevExpress.XtraEditors.SimpleButton btnSelClear;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}