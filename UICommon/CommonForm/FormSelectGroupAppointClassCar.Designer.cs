namespace DS.MSClient.UICommon.CommonForm
{
    partial class FormSelectGroupAppointClassCar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectGroupAppointClassCar));
            this.gc_GroupAppointClassCar = new DS.MSClient.UIControl.CGridControl();
            this.gv_GroupAppointClassCar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Column = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.text_Car = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Btn_Search = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_GroupAppointClassCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_GroupAppointClassCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_Car.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(484, 356);
            this.btnOK.MinimumSize = new System.Drawing.Size(65, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(569, 356);
            this.btnCancel.MinimumSize = new System.Drawing.Size(65, 0);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.Btn_Search);
            this.lcMain.Controls.Add(this.text_Car);
            this.lcMain.Controls.Add(this.gc_GroupAppointClassCar);
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1000, 430, 250, 350);
            this.lcMain.Size = new System.Drawing.Size(655, 385);
            this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
            this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
            this.lcMain.Controls.SetChildIndex(this.gc_GroupAppointClassCar, 0);
            this.lcMain.Controls.SetChildIndex(this.text_Car, 0);
            this.lcMain.Controls.SetChildIndex(this.Btn_Search, 0);
            // 
            // lcgMain
            // 
            this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcgMain.Name = "Root";
            this.lcgMain.Size = new System.Drawing.Size(655, 385);
            this.lcgMain.Text = "Root";
            // 
            // lciOK
            // 
            this.lciOK.Location = new System.Drawing.Point(477, 349);
            // 
            // lciCancel
            // 
            this.lciCancel.Location = new System.Drawing.Point(562, 349);
            // 
            // ssOp
            // 
            this.ssOp.Location = new System.Drawing.Point(0, 347);
            this.ssOp.Size = new System.Drawing.Size(645, 2);
            // 
            // esiOpEmpty
            // 
            this.esiOpEmpty.Location = new System.Drawing.Point(0, 349);
            this.esiOpEmpty.Size = new System.Drawing.Size(477, 26);
            // 
            // lcgContainer
            // 
            this.lcgContainer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.lcgContainer.Size = new System.Drawing.Size(645, 347);
            // 
            // gc_GroupAppointClassCar
            // 
            this.gc_GroupAppointClassCar.AdvanceSearchMethod = null;
            this.gc_GroupAppointClassCar.CallCustomNavicationButtonClick = null;
            this.gc_GroupAppointClassCar.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_GroupAppointClassCar.GetPageSizeMethod = null;
            this.gc_GroupAppointClassCar.GetTotalRecordCountMethod = null;
            this.gc_GroupAppointClassCar.ImmediatelyDownLoad = false;
            this.gc_GroupAppointClassCar.Location = new System.Drawing.Point(7, 33);
            this.gc_GroupAppointClassCar.MainView = this.gv_GroupAppointClassCar;
            this.gc_GroupAppointClassCar.Name = "gc_GroupAppointClassCar";
            this.gc_GroupAppointClassCar.PageSortOrderSearchMethod = null;
            this.gc_GroupAppointClassCar.ShowCustomHeaderMenu = true;
            this.gc_GroupAppointClassCar.ShowCustomNavigationButtons = false;
            this.gc_GroupAppointClassCar.ShowCustomRowHeightButton = true;
            this.gc_GroupAppointClassCar.ShowImmediatelyDownLoadMenu = true;
            this.gc_GroupAppointClassCar.Size = new System.Drawing.Size(641, 317);
            this.gc_GroupAppointClassCar.TabIndex = 4;
            this.gc_GroupAppointClassCar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_GroupAppointClassCar});
            // 
            // gv_GroupAppointClassCar
            // 
            this.gv_GroupAppointClassCar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Choose,
            this.gridColumn2,
            this.gridColumn6,
            this.gridColumn5,
            this.Column,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4});
            this.gv_GroupAppointClassCar.GridControl = this.gc_GroupAppointClassCar;
            this.gv_GroupAppointClassCar.Name = "gv_GroupAppointClassCar";
            this.gv_GroupAppointClassCar.OptionsView.ColumnAutoWidth = false;
            this.gv_GroupAppointClassCar.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_GroupAppointClassCar.OptionsView.EnableAppearanceOddRow = true;
            // 
            // Column_Choose
            // 
            this.Column_Choose.AppearanceCell.Options.UseTextOptions = true;
            this.Column_Choose.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Choose.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_Choose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_Choose.Caption = "选择";
            this.Column_Choose.FieldName = "Choose";
            this.Column_Choose.Name = "Column_Choose";
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
            this.gridColumn2.Caption = "车辆类型";
            this.gridColumn2.FieldName = "CarType";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 57;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "车辆分队编号";
            this.gridColumn6.FieldName = "GroupCarCode";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 112;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "负责教练";
            this.gridColumn5.FieldName = "CoachName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 65;
            // 
            // Column
            // 
            this.Column.AppearanceCell.Options.UseTextOptions = true;
            this.Column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column.AppearanceHeader.Options.UseTextOptions = true;
            this.Column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column.Caption = "车牌号";
            this.Column.FieldName = "CarNo";
            this.Column.Name = "Column";
            this.Column.OptionsColumn.AllowEdit = false;
            this.Column.OptionsColumn.ReadOnly = true;
            this.Column.Visible = true;
            this.Column.VisibleIndex = 1;
            this.Column.Width = 152;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "备注";
            this.gridColumn1.FieldName = "Note";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 60;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "操作员";
            this.gridColumn3.FieldName = "OperateName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 60;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "操作时间";
            this.gridColumn4.FieldName = "OperateTime";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            this.gridColumn4.Width = 80;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gc_GroupAppointClassCar;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(645, 321);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(394, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(251, 26);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // text_Car
            // 
            this.text_Car.Location = new System.Drawing.Point(59, 7);
            this.text_Car.Name = "text_Car";
            this.text_Car.Size = new System.Drawing.Size(223, 20);
            this.text_Car.StyleController = this.lcMain;
            this.text_Car.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.text_Car;
            this.layoutControlItem2.CustomizationFormText = "车辆搜索";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(279, 26);
            this.layoutControlItem2.Text = "车辆搜索";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 14);
            // 
            // Btn_Search
            // 
            this.Btn_Search.Location = new System.Drawing.Point(286, 7);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(111, 22);
            this.Btn_Search.StyleController = this.lcMain;
            this.Btn_Search.TabIndex = 6;
            this.Btn_Search.Text = "确定";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.Btn_Search;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(279, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(115, 26);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // FormSelectGroupAppointClassCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 385);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2010 Silver";
            this.Name = "FormSelectGroupAppointClassCar";
            this.Text = "选择分队车辆";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_GroupAppointClassCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_GroupAppointClassCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.text_Car.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UIControl.CGridControl gc_GroupAppointClassCar;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_GroupAppointClassCar;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Column;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton Btn_Search;
        private DevExpress.XtraEditors.TextEdit text_Car;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;

    }
}