namespace DS.MSClient.UICommon.CommonForm
{
    partial class FormSubjectItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSubjectItem));
            this.gc_item = new DS.MSClient.UIControl.CGridControl();
            this.gv_item = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).BeginInit();
            this.lcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(227, 406);
            this.btnOK.Size = new System.Drawing.Size(71, 22);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(302, 406);
            this.btnCancel.Size = new System.Drawing.Size(66, 22);
            // 
            // lcMain
            // 
            this.lcMain.Controls.Add(this.gc_item);
            this.lcMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(-1335, 217, 250, 350);
            this.lcMain.Size = new System.Drawing.Size(375, 435);
            this.lcMain.Controls.SetChildIndex(this.btnOK, 0);
            this.lcMain.Controls.SetChildIndex(this.btnCancel, 0);
            this.lcMain.Controls.SetChildIndex(this.gc_item, 0);
            // 
            // lcgMain
            // 
            this.lcgMain.AppearanceItemCaption.Options.UseTextOptions = true;
            this.lcgMain.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lcgMain.Size = new System.Drawing.Size(375, 435);
            // 
            // lciOK
            // 
            this.lciOK.Location = new System.Drawing.Point(220, 399);
            this.lciOK.Size = new System.Drawing.Size(75, 26);
            // 
            // lciCancel
            // 
            this.lciCancel.Location = new System.Drawing.Point(295, 399);
            this.lciCancel.Size = new System.Drawing.Size(70, 26);
            // 
            // ssOp
            // 
            this.ssOp.Location = new System.Drawing.Point(0, 397);
            this.ssOp.Size = new System.Drawing.Size(365, 2);
            // 
            // esiOpEmpty
            // 
            this.esiOpEmpty.Location = new System.Drawing.Point(0, 399);
            this.esiOpEmpty.Size = new System.Drawing.Size(220, 26);
            // 
            // lcgContainer
            // 
            this.lcgContainer.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgContainer.Size = new System.Drawing.Size(365, 397);
            // 
            // gc_item
            // 
            this.gc_item.AdvanceSearchMethod = null;
            this.gc_item.GetPageSizeMethod = null;
            this.gc_item.GetTotalRecordCountMethod = null;
            this.gc_item.PageSortOrderSearchMethod = null;
            this.gc_item.CallCustomNavicationButtonClick = null;
            this.gc_item.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_item.ImmediatelyDownLoad = false;
            this.gc_item.Location = new System.Drawing.Point(7, 7);
            this.gc_item.MainView = this.gv_item;
            this.gc_item.Name = "gc_item";
            this.gc_item.ShowCustomHeaderMenu = true;
            this.gc_item.ShowCustomNavigationButtons = false;
            this.gc_item.ShowCustomRowHeightButton = true;
            this.gc_item.ShowImmediatelyDownLoadMenu = true;
            this.gc_item.Size = new System.Drawing.Size(361, 393);
            this.gc_item.TabIndex = 4;
            this.gc_item.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_item});
            // 
            // gv_item
            // 
            this.gv_item.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_Choose,
            this.gridColumn2});
            this.gv_item.GridControl = this.gc_item;
            this.gv_item.Name = "gv_item";
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
            this.Column_Choose.Width = 62;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "项目";
            this.gridColumn2.FieldName = "ItemName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 251;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gc_item;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(365, 397);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // FormSubjectItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 435);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSubjectItem";
            this.Text = "选择前置必学项目";
            ((System.ComponentModel.ISupportInitialize)(this.lcMain)).EndInit();
            this.lcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lcgMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssOp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esiOpEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UIControl.CGridControl gc_item;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_item;
        private DevExpress.XtraGrid.Columns.GridColumn Column_Choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;

    }
}