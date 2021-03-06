﻿namespace DS.MSClient.UICommon.CommonForm
{
    partial class FormService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormService));
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
            this.txt_MnemonicCode = new DevExpress.XtraEditors.TextEdit();
            this.txt_ServiceName = new DevExpress.XtraEditors.TextEdit();
            this.txt_ServiceCode = new DevExpress.XtraEditors.TextEdit();
            this.txt_Note = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gc_Service = new DS.MSClient.UIControl.CGridControl();
            this.gv_Service = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl4)).BeginInit();
            this.layoutControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_MnemonicCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Note.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Service)).BeginInit();
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
            this.layoutControl4.Controls.Add(this.txt_MnemonicCode);
            this.layoutControl4.Controls.Add(this.txt_ServiceName);
            this.layoutControl4.Controls.Add(this.txt_ServiceCode);
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
            // txt_MnemonicCode
            // 
            this.txt_MnemonicCode.Location = new System.Drawing.Point(70, 36);
            this.txt_MnemonicCode.Name = "txt_MnemonicCode";
            this.txt_MnemonicCode.Size = new System.Drawing.Size(188, 20);
            this.txt_MnemonicCode.StyleController = this.layoutControl4;
            this.txt_MnemonicCode.TabIndex = 6;
            // 
            // txt_ServiceName
            // 
            this.txt_ServiceName.Location = new System.Drawing.Point(320, 12);
            this.txt_ServiceName.Name = "txt_ServiceName";
            this.txt_ServiceName.Size = new System.Drawing.Size(187, 20);
            this.txt_ServiceName.StyleController = this.layoutControl4;
            this.txt_ServiceName.TabIndex = 5;
            // 
            // txt_ServiceCode
            // 
            this.txt_ServiceCode.Location = new System.Drawing.Point(70, 12);
            this.txt_ServiceCode.Name = "txt_ServiceCode";
            this.txt_ServiceCode.Size = new System.Drawing.Size(188, 20);
            this.txt_ServiceCode.StyleController = this.layoutControl4;
            this.txt_ServiceCode.TabIndex = 4;
            // 
            // txt_Note
            // 
            this.txt_Note.Location = new System.Drawing.Point(320, 36);
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.Size = new System.Drawing.Size(187, 20);
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
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(519, 69);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem1.Control = this.txt_ServiceCode;
            this.layoutControlItem1.CustomizationFormText = "职位代码";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(250, 24);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(250, 24);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(250, 24);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "*服务代码";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_MnemonicCode;
            this.layoutControlItem3.CustomizationFormText = "助记码";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(250, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(250, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(250, 25);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "助记码";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.ForeColor = System.Drawing.Color.Red;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem2.Control = this.txt_ServiceName;
            this.layoutControlItem2.CustomizationFormText = "职位名称";
            this.layoutControlItem2.Location = new System.Drawing.Point(250, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(249, 24);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(249, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(249, 24);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.Text = "*服务名称";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(55, 14);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txt_Note;
            this.layoutControlItem9.CustomizationFormText = "备注";
            this.layoutControlItem9.Location = new System.Drawing.Point(250, 24);
            this.layoutControlItem9.MinSize = new System.Drawing.Size(50, 25);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(249, 25);
            this.layoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem9.Text = "备注";
            this.layoutControlItem9.TextSize = new System.Drawing.Size(55, 14);
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
            this.gc_Service.Location = new System.Drawing.Point(0, 94);
            this.gc_Service.MainView = this.gv_Service;
            this.gc_Service.Name = "gc_Service";
            this.gc_Service.ShowCustomHeaderMenu = true;
            this.gc_Service.ShowCustomNavigationButtons = false;
            this.gc_Service.ShowCustomRowHeightButton = true;
            this.gc_Service.ShowImmediatelyDownLoadMenu = true;
            this.gc_Service.Size = new System.Drawing.Size(448, 321);
            this.gc_Service.TabIndex = 24;
            this.gc_Service.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Service});
            // 
            // gv_Service
            // 
            this.gv_Service.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn7});
            this.gv_Service.GridControl = this.gc_Service;
            this.gv_Service.IndicatorWidth = 50;
            this.gv_Service.Name = "gv_Service";
            this.gv_Service.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gv_Service.OptionsView.ColumnAutoWidth = false;
            this.gv_Service.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_Service.OptionsView.EnableAppearanceOddRow = true;
            this.gv_Service.OptionsView.ShowDetailButtons = false;
            this.gv_Service.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "服务代码";
            this.gridColumn1.FieldName = "ServiceCode";
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
            this.gridColumn3.Caption = "服务名称";
            this.gridColumn3.FieldName = "ServiceName";
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
            this.gridColumn2.Caption = "助记码";
            this.gridColumn2.FieldName = "MnemonicCode";
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
            // FormService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 415);
            this.Controls.Add(this.gc_Service);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务编辑";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl4)).EndInit();
            this.layoutControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_MnemonicCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_ServiceCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Note.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Service)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txt_MnemonicCode;
        private DevExpress.XtraEditors.TextEdit txt_ServiceName;
        private DevExpress.XtraEditors.TextEdit txt_ServiceCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private UIControl.CGridControl gc_Service;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Service;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.TextEdit txt_Note;
    }
}