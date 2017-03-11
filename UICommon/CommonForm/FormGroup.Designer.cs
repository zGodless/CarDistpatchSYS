namespace DS.MSClient.UICommon.CommonForm
{
    partial class FormGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGroup));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.Btn_NewAdd = new DevExpress.XtraBars.BarButtonItem();
            this.Btn_Del = new DevExpress.XtraBars.BarButtonItem();
            this.Btn_Cancel = new DevExpress.XtraBars.BarButtonItem();
            this.Btn_Apply = new DevExpress.XtraBars.BarButtonItem();
            this.Btn_Refresh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl4 = new DevExpress.XtraLayout.LayoutControl();
            this.cl_TrainPlace = new DS.MSClient.UIControl.CLookTrainPlace();
            this.cl_School = new DS.MSClient.UIControl.CLookSchool();
            this.txt_GroupName = new DevExpress.XtraEditors.TextEdit();
            this.txt_Note = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gc_Group = new DS.MSClient.UIControl.CGridControl();
            this.gv_Group = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl4)).BeginInit();
            this.layoutControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cl_TrainPlace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cl_School.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GroupName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Note.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Group)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.Btn_NewAdd,
            this.Btn_Del,
            this.Btn_Cancel,
            this.Btn_Apply,
            this.Btn_Refresh});
            this.barManager1.MaxItemId = 5;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_NewAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_Del),
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_Cancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_Apply),
            new DevExpress.XtraBars.LinkPersistInfo(this.Btn_Refresh)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // Btn_NewAdd
            // 
            this.Btn_NewAdd.Caption = "新建";
            this.Btn_NewAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("Btn_NewAdd.Glyph")));
            this.Btn_NewAdd.Id = 0;
            this.Btn_NewAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("Btn_NewAdd.LargeGlyph")));
            this.Btn_NewAdd.Name = "Btn_NewAdd";
            this.Btn_NewAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // Btn_Del
            // 
            this.Btn_Del.Caption = "删除";
            this.Btn_Del.Glyph = ((System.Drawing.Image)(resources.GetObject("Btn_Del.Glyph")));
            this.Btn_Del.Id = 1;
            this.Btn_Del.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("Btn_Del.LargeGlyph")));
            this.Btn_Del.Name = "Btn_Del";
            this.Btn_Del.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Caption = "取消";
            this.Btn_Cancel.Glyph = ((System.Drawing.Image)(resources.GetObject("Btn_Cancel.Glyph")));
            this.Btn_Cancel.Id = 2;
            this.Btn_Cancel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("Btn_Cancel.LargeGlyph")));
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.Caption = "应用";
            this.Btn_Apply.Glyph = ((System.Drawing.Image)(resources.GetObject("Btn_Apply.Glyph")));
            this.Btn_Apply.Id = 3;
            this.Btn_Apply.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("Btn_Apply.LargeGlyph")));
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // Btn_Refresh
            // 
            this.Btn_Refresh.Caption = "刷新";
            this.Btn_Refresh.Glyph = ((System.Drawing.Image)(resources.GetObject("Btn_Refresh.Glyph")));
            this.Btn_Refresh.Id = 4;
            this.Btn_Refresh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("Btn_Refresh.LargeGlyph")));
            this.Btn_Refresh.Name = "Btn_Refresh";
            this.Btn_Refresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(448, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 415);
            this.barDockControlBottom.Size = new System.Drawing.Size(448, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 384);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(448, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 384);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(448, 63);
            this.panelControl1.TabIndex = 4;
            // 
            // layoutControl4
            // 
            this.layoutControl4.AllowCustomizationMenu = false;
            this.layoutControl4.Controls.Add(this.cl_TrainPlace);
            this.layoutControl4.Controls.Add(this.cl_School);
            this.layoutControl4.Controls.Add(this.txt_GroupName);
            this.layoutControl4.Controls.Add(this.txt_Note);
            this.layoutControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl4.Location = new System.Drawing.Point(2, 2);
            this.layoutControl4.Name = "layoutControl4";
            this.layoutControl4.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(599, 141, 250, 350);
            this.layoutControl4.Root = this.layoutControlGroup1;
            this.layoutControl4.Size = new System.Drawing.Size(444, 59);
            this.layoutControl4.TabIndex = 2;
            this.layoutControl4.Text = "layoutControl4";
            // 
            // cl_TrainPlace
            // 
            this.cl_TrainPlace.Currenttrainplace = null;
            this.cl_TrainPlace.ListIsValid = null;
            this.cl_TrainPlace.Location = new System.Drawing.Point(70, 36);
            this.cl_TrainPlace.MaximumSize = new System.Drawing.Size(0, 17);
            this.cl_TrainPlace.MenuManager = this.barManager1;
            this.cl_TrainPlace.Name = "cl_TrainPlace";
            this.cl_TrainPlace.NewButton = true;
            this.cl_TrainPlace.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cl_TrainPlace.Properties.AutoHeight = false;
            this.cl_TrainPlace.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.cl_TrainPlace.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "刷新", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "新增", null, null, true)});
            this.cl_TrainPlace.Properties.CaseSensitiveSearch = true;
            this.cl_TrainPlace.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cl_TrainPlace.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TrainPlaceCode", "训练场地编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TrainPlaceName", "训练场地"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MnemonicCode", "助记码")});
            this.cl_TrainPlace.Properties.NullText = "";
            this.cl_TrainPlace.Properties.NullValuePromptShowForEmptyValue = true;
            this.cl_TrainPlace.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            
            this.cl_TrainPlace.Size = new System.Drawing.Size(141, 17);
            this.cl_TrainPlace.StyleController = this.layoutControl4;
            this.cl_TrainPlace.TabIndex = 14;
            this.cl_TrainPlace.ToolTip = "清除选择:[CTRL + 0]";
            // 
            // cl_School
            // 
            this.cl_School.Currentschool = null;
            this.cl_School.ListIsValid = null;
            this.cl_School.Location = new System.Drawing.Point(320, 12);
            this.cl_School.MaximumSize = new System.Drawing.Size(0, 17);
            this.cl_School.MenuManager = this.barManager1;
            this.cl_School.Name = "cl_School";
            this.cl_School.NewButton = true;
            this.cl_School.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cl_School.Properties.AutoHeight = false;
            this.cl_School.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.cl_School.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "刷新", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "新增", null, null, true)});
            this.cl_School.Properties.CaseSensitiveSearch = true;
            this.cl_School.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cl_School.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SchoolCode", "学校编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SchoolName", "学校名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MnemonicCode", "助记码")});
            this.cl_School.Properties.NullText = "";
            this.cl_School.Properties.NullValuePromptShowForEmptyValue = true;
            this.cl_School.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            
            this.cl_School.Size = new System.Drawing.Size(95, 17);
            this.cl_School.StyleController = this.layoutControl4;
            this.cl_School.TabIndex = 13;
            this.cl_School.ToolTip = "清除选择:[CTRL + 0]";
            // 
            // txt_GroupName
            // 
            this.txt_GroupName.Location = new System.Drawing.Point(70, 12);
            this.txt_GroupName.Name = "txt_GroupName";
            this.txt_GroupName.Size = new System.Drawing.Size(188, 20);
            this.txt_GroupName.StyleController = this.layoutControl4;
            this.txt_GroupName.TabIndex = 4;
            // 
            // txt_Note
            // 
            this.txt_Note.Location = new System.Drawing.Point(273, 36);
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.Size = new System.Drawing.Size(142, 20);
            this.txt_Note.StyleController = this.layoutControl4;
            this.txt_Note.TabIndex = 12;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem9,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(427, 69);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.txt_GroupName;
            this.layoutControlItem1.CustomizationFormText = "职位代码";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(250, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(250, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(250, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "*分队名称";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txt_Note;
            this.layoutControlItem9.CustomizationFormText = "备注";
            this.layoutControlItem9.Location = new System.Drawing.Point(203, 24);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(50, 25);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(204, 25);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "备注";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cl_School;
            this.layoutControlItem2.CustomizationFormText = "所属驾校";
            this.layoutControlItem2.Location = new System.Drawing.Point(250, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(157, 24);
            this.layoutControlItem2.Text = "所属驾校";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cl_TrainPlace;
            this.layoutControlItem3.CustomizationFormText = "训练场地";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(203, 25);
            this.layoutControlItem3.Text = "训练场地";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(55, 14);
            // 
            // gc_Group
            // 
            this.gc_Group.AdvanceSearchMethod = null;
            this.gc_Group.GetPageSizeMethod = null;
            this.gc_Group.GetTotalRecordCountMethod = null;
            this.gc_Group.PageSortOrderSearchMethod = null;
            this.gc_Group.CallCustomNavicationButtonClick = null;
            this.gc_Group.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_Group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Group.ImmediatelyDownLoad = false;
            this.gc_Group.Location = new System.Drawing.Point(0, 94);
            this.gc_Group.MainView = this.gv_Group;
            this.gc_Group.Name = "gc_Group";
            this.gc_Group.ShowCustomHeaderMenu = true;
            this.gc_Group.ShowCustomNavigationButtons = false;
            this.gc_Group.ShowCustomRowHeightButton = true;
            this.gc_Group.ShowImmediatelyDownLoadMenu = true;
            this.gc_Group.Size = new System.Drawing.Size(448, 321);
            this.gc_Group.TabIndex = 24;
            this.gc_Group.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Group});
            // 
            // gv_Group
            // 
            this.gv_Group.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn7});
            this.gv_Group.GridControl = this.gc_Group;
            this.gv_Group.IndicatorWidth = 50;
            this.gv_Group.Name = "gv_Group";
            this.gv_Group.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gv_Group.OptionsView.ColumnAutoWidth = false;
            this.gv_Group.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_Group.OptionsView.EnableAppearanceOddRow = true;
            this.gv_Group.OptionsView.ShowDetailButtons = false;
            this.gv_Group.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "分队名称";
            this.gridColumn1.FieldName = "GroupName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 104;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "所属驾校";
            this.gridColumn3.FieldName = "SchoolName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 111;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "训练场地";
            this.gridColumn2.FieldName = "TrainPlaceName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 142;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "备注";
            this.gridColumn7.FieldName = "Note";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 113;
            // 
            // FormGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 415);
            this.Controls.Add(this.gc_Group);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分队编辑";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl4)).EndInit();
            this.layoutControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cl_TrainPlace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cl_School.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_GroupName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Note.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Group)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarButtonItem Btn_NewAdd;
        private DevExpress.XtraBars.BarButtonItem Btn_Del;
        private DevExpress.XtraBars.BarButtonItem Btn_Cancel;
        private DevExpress.XtraBars.BarButtonItem Btn_Apply;
        private DevExpress.XtraBars.BarButtonItem Btn_Refresh;
        private DevExpress.XtraLayout.LayoutControl layoutControl4;
        private DevExpress.XtraEditors.TextEdit txt_GroupName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private UIControl.CGridControl gc_Group;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Group;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.TextEdit txt_Note;
        private UIControl.CLookTrainPlace cl_TrainPlace;
        private UIControl.CLookSchool cl_School;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}