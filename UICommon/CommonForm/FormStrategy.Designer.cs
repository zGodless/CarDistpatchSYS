namespace DS.MSClient.UICommon
{
    partial class FormStrategy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStrategy));
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gc_charge_item = new DS.MSClient.UIControl.CGridControl();
            this.gv_charge_item = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rice_Choose = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleLabelItem1 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.clbc_Strategy = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_charge_item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_charge_item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rice_Choose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbc_Strategy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(362, 333);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(447, 333);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.clbc_Strategy);
            this.lcMain.Controls.Add(this.gc_charge_item);
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(258, 219, 250, 350);
            this.lcMain.Size = new System.Drawing.Size(533, 362);
            this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
            this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
            this.lcMain.Controls.SetChildIndex(this.gc_charge_item, 0);
            this.lcMain.Controls.SetChildIndex(this.clbc_Strategy, 0);
            // 
            // lcgMain
            // 
            this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcgMain.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem2});
            this.lcgMain.Name = "Root";
            this.lcgMain.Size = new System.Drawing.Size(533, 362);
            this.lcgMain.Text = "Root";
            // 
            // lciOK
            // 
            this.lciOK.Location = new System.Drawing.Point(355, 326);
            // 
            // lciCancel
            // 
            this.lciCancel.Location = new System.Drawing.Point(440, 326);
            // 
            // ssOp
            // 
            this.ssOp.Location = new System.Drawing.Point(0, 24);
            this.ssOp.Size = new System.Drawing.Size(523, 2);
            // 
            // esiOpEmpty
            // 
            this.esiOpEmpty.Size = new System.Drawing.Size(355, 26);
            // 
            // lcgContainer
            // 
            this.lcgContainer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.simpleLabelItem1,
            this.layoutControlItem1});
            this.lcgContainer.Size = new System.Drawing.Size(523, 24);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 26);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(523, 10);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gc_charge_item
            // 
            this.gc_charge_item.AdvanceSearchMethod = null;
            this.gc_charge_item.GetPageSizeMethod = null;
            this.gc_charge_item.GetTotalRecordCountMethod = null;
            this.gc_charge_item.PageSortOrderSearchMethod = null;
            this.gc_charge_item.CallCustomNavicationButtonClick = null;
            this.gc_charge_item.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_charge_item.ImmediatelyDownLoad = false;
            this.gc_charge_item.Location = new System.Drawing.Point(7, 43);
            this.gc_charge_item.MainView = this.gv_charge_item;
            this.gc_charge_item.Name = "gc_charge_item";
            this.gc_charge_item.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rice_Choose});
            this.gc_charge_item.ShowCustomHeaderMenu = true;
            this.gc_charge_item.ShowCustomNavigationButtons = false;
            this.gc_charge_item.ShowCustomRowHeightButton = true;
            this.gc_charge_item.ShowImmediatelyDownLoadMenu = true;
            this.gc_charge_item.Size = new System.Drawing.Size(519, 286);
            this.gc_charge_item.TabIndex = 5;
            this.gc_charge_item.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_charge_item});
            // 
            // gv_charge_item
            // 
            this.gv_charge_item.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5});
            this.gv_charge_item.GridControl = this.gc_charge_item;
            this.gv_charge_item.Name = "gv_charge_item";
            this.gv_charge_item.OptionsView.ShowGroupPanel = false;
            this.gv_charge_item.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn5, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "选择";
            this.gridColumn4.ColumnEdit = this.rice_Choose;
            this.gridColumn4.FieldName = "Choose";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // rice_Choose
            // 
            this.rice_Choose.Appearance.Options.UseTextOptions = true;
            this.rice_Choose.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rice_Choose.AppearanceDisabled.Options.UseTextOptions = true;
            this.rice_Choose.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rice_Choose.AutoHeight = false;
            this.rice_Choose.Caption = "Check";
            this.rice_Choose.Name = "rice_Choose";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "项目内容";
            this.gridColumn1.FieldName = "ChargeItemName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "收费类型";
            this.gridColumn2.FieldName = "ChargeTypeName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "收费标准";
            this.gridColumn3.FieldName = "Price";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "排序";
            this.gridColumn5.FieldName = "Array";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gc_charge_item;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 36);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(523, 290);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // simpleLabelItem1
            // 
            this.simpleLabelItem1.AllowHotTrack = false;
            this.simpleLabelItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.simpleLabelItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.simpleLabelItem1.CustomizationFormText = "收费策略";
            this.simpleLabelItem1.Location = new System.Drawing.Point(0, 0);
            this.simpleLabelItem1.Name = "simpleLabelItem1";
            this.simpleLabelItem1.Size = new System.Drawing.Size(54, 24);
            this.simpleLabelItem1.Text = "收费策略";
            this.simpleLabelItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize;
            this.simpleLabelItem1.TextSize = new System.Drawing.Size(50, 20);
            // 
            // clbc_Strategy
            // 
            this.clbc_Strategy.CheckOnClick = true;
            this.clbc_Strategy.Location = new System.Drawing.Point(61, 7);
            this.clbc_Strategy.MultiColumn = true;
            this.clbc_Strategy.Name = "clbc_Strategy";
            this.clbc_Strategy.Size = new System.Drawing.Size(465, 20);
            this.clbc_Strategy.StyleController = this.lcMain;
            this.clbc_Strategy.TabIndex = 5;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.clbc_Strategy;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(54, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(469, 24);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // FormStrategy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 362);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStrategy";
            this.Text = "收费策略";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_charge_item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_charge_item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rice_Choose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleLabelItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbc_Strategy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private UIControl.CGridControl gc_charge_item;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_charge_item;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.CheckedListBoxControl clbc_Strategy;
        private DevExpress.XtraLayout.SimpleLabelItem simpleLabelItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rice_Choose;
    }
}