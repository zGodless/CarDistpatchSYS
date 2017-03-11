namespace DS.MSClient.UICommon
{
    partial class FormSelectCommodity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectCommodity));
            this.gc_Commodity = new DS.MSClient.UIControl.CGridControl();
            this.gv_Commodity = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Commodity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Commodity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(369, 406);
            this.btnOK.Size = new System.Drawing.Size(118, 22);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(491, 406);
            this.btnCancel.Size = new System.Drawing.Size(112, 22);
            // 
            // lcMain
            // 
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1335, 217, 250, 350);
            this.lcMain.Size = new System.Drawing.Size(610, 435);
            this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
            this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
            // 
            // lcgMain
            // 
            this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcgMain.Size = new System.Drawing.Size(610, 435);
            // 
            // lciOK
            // 
            this.lciOK.Location = new System.Drawing.Point(362, 399);
            this.lciOK.Size = new System.Drawing.Size(122, 26);
            // 
            // lciCancel
            // 
            this.lciCancel.Location = new System.Drawing.Point(484, 399);
            this.lciCancel.Size = new System.Drawing.Size(116, 26);
            // 
            // ssOp
            // 
            this.ssOp.Location = new System.Drawing.Point(0, 397);
            this.ssOp.Size = new System.Drawing.Size(600, 2);
            // 
            // esiOpEmpty
            // 
            this.esiOpEmpty.Location = new System.Drawing.Point(0, 399);
            this.esiOpEmpty.Size = new System.Drawing.Size(362, 26);
            // 
            // lcgContainer
            // 
            this.lcgContainer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgContainer.Size = new System.Drawing.Size(600, 397);
            // 
            // gc_Commodity
            // 
            this.gc_Commodity.AdvanceSearchMethod = null;
            this.gc_Commodity.GetPageSizeMethod = null;
            this.gc_Commodity.GetTotalRecordCountMethod = null;
            this.gc_Commodity.PageSortOrderSearchMethod = null;
            this.gc_Commodity.CallCustomNavicationButtonClick = null;
            this.gc_Commodity.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_Commodity.ImmediatelyDownLoad = false;
            this.gc_Commodity.Location = new System.Drawing.Point(7, 7);
            this.gc_Commodity.MainView = this.gv_Commodity;
            this.gc_Commodity.Name = "gc_Commodity";
            this.gc_Commodity.ShowCustomHeaderMenu = true;
            this.gc_Commodity.ShowCustomNavigationButtons = false;
            this.gc_Commodity.ShowCustomRowHeightButton = true;
            this.gc_Commodity.ShowImmediatelyDownLoadMenu = true;
            this.gc_Commodity.Size = new System.Drawing.Size(596, 393);
            this.gc_Commodity.TabIndex = 5;
            this.gc_Commodity.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Commodity});
            // 
            // gv_Commodity
            // 
            this.gv_Commodity.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Choose,
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn9});
            this.gv_Commodity.GridControl = this.gc_Commodity;
            this.gv_Commodity.Name = "gv_Commodity";
            this.gv_Commodity.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gv_Commodity.OptionsDetail.EnableMasterViewMode = false;
            this.gv_Commodity.OptionsView.ColumnAutoWidth = false;
            this.gv_Commodity.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_Commodity.OptionsView.EnableAppearanceOddRow = true;
            this.gv_Commodity.OptionsView.ShowDetailButtons = false;
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
            this.Column_Choose.Width = 50;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "商品名称";
            this.gridColumn3.FieldName = "CommodityName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 127;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "商品分类";
            this.gridColumn1.FieldName = "CommoditytypeName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "商品编号";
            this.gridColumn4.FieldName = "CommodityCode";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 100;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "定价";
            this.gridColumn7.DisplayFormat.FormatString = "c";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "Price";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "是否优惠";
            this.gridColumn10.FieldName = "IsDiscount";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "是否累加积分";
            this.gridColumn9.FieldName = "IsIntegral";
            this.gridColumn9.MinWidth = 40;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 80;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gc_Commodity;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(600, 397);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // FormSelectCommodity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 435);
            this.Controls.Add(this.gc_Commodity);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelectCommodity";
            this.Text = "选择商品";
            this.Controls.SetChildIndex(this.lcMain, 0);
            this.Controls.SetChildIndex(this.gc_Commodity, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Commodity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Commodity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UIControl.CGridControl gc_Commodity;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_Commodity;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;

    }
}