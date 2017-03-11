namespace DS.MSClient
{
    partial class FormColumnConfig
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormColumnConfig));
            this.gridCol_FixedStyle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gc_ColumnConfig = new DevExpress.XtraGrid.GridControl();
            this.gv_ColumnConfig = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridCol_Visible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_ColumnIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_VisibleIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_ColumnEditName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.ckb_ChooseAll = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnRestoreViewLayout = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_ColumnConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ColumnConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_ChooseAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridCol_FixedStyle
            // 
            this.gridCol_FixedStyle.Caption = "FixedStyle";
            this.gridCol_FixedStyle.FieldName = "FixedStyle";
            this.gridCol_FixedStyle.Name = "gridCol_FixedStyle";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gc_ColumnConfig);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(244, 364);
            this.panelControl1.TabIndex = 0;
            // 
            // gc_ColumnConfig
            // 
            this.gc_ColumnConfig.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_ColumnConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_ColumnConfig.Location = new System.Drawing.Point(2, 2);
            this.gc_ColumnConfig.MainView = this.gv_ColumnConfig;
            this.gc_ColumnConfig.Name = "gc_ColumnConfig";
            this.gc_ColumnConfig.Size = new System.Drawing.Size(240, 360);
            this.gc_ColumnConfig.TabIndex = 0;
            this.gc_ColumnConfig.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_ColumnConfig});
            // 
            // gv_ColumnConfig
            // 
            this.gv_ColumnConfig.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridCol_Visible,
            this.gridCol_ColumnIndex,
            this.gridCol_VisibleIndex,
            this.gridCol_ColumnEditName,
            this.gridCol_FixedStyle});
            styleFormatCondition1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            styleFormatCondition1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            styleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            styleFormatCondition1.Appearance.Options.HighPriority = true;
            styleFormatCondition1.Appearance.Options.UseBorderColor = true;
            styleFormatCondition1.Appearance.Options.UseFont = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.gridCol_FixedStyle;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Expression;
            styleFormatCondition1.Expression = "[FixedStyle]   != NULL";
            this.gv_ColumnConfig.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gv_ColumnConfig.GridControl = this.gc_ColumnConfig;
            this.gv_ColumnConfig.Name = "gv_ColumnConfig";
            this.gv_ColumnConfig.OptionsCustomization.AllowGroup = false;
            this.gv_ColumnConfig.OptionsCustomization.AllowSort = false;
            this.gv_ColumnConfig.OptionsMenu.EnableColumnMenu = false;
            this.gv_ColumnConfig.OptionsView.ShowGroupPanel = false;
            // 
            // gridCol_Visible
            // 
            this.gridCol_Visible.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol_Visible.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol_Visible.Caption = " ";
            this.gridCol_Visible.FieldName = "Visible";
            this.gridCol_Visible.Name = "gridCol_Visible";
            this.gridCol_Visible.OptionsColumn.AllowShowHide = false;
            this.gridCol_Visible.Visible = true;
            this.gridCol_Visible.VisibleIndex = 0;
            this.gridCol_Visible.Width = 38;
            // 
            // gridCol_ColumnIndex
            // 
            this.gridCol_ColumnIndex.Caption = "顺序";
            this.gridCol_ColumnIndex.FieldName = "ColumnIndex";
            this.gridCol_ColumnIndex.Name = "gridCol_ColumnIndex";
            this.gridCol_ColumnIndex.OptionsColumn.AllowEdit = false;
            this.gridCol_ColumnIndex.OptionsColumn.AllowShowHide = false;
            this.gridCol_ColumnIndex.Visible = true;
            this.gridCol_ColumnIndex.VisibleIndex = 1;
            this.gridCol_ColumnIndex.Width = 48;
            // 
            // gridCol_VisibleIndex
            // 
            this.gridCol_VisibleIndex.Caption = "VisibleIndex";
            this.gridCol_VisibleIndex.FieldName = "VisibleIndex";
            this.gridCol_VisibleIndex.Name = "gridCol_VisibleIndex";
            this.gridCol_VisibleIndex.OptionsColumn.AllowShowHide = false;
            this.gridCol_VisibleIndex.Width = 50;
            // 
            // gridCol_ColumnEditName
            // 
            this.gridCol_ColumnEditName.Caption = "列名";
            this.gridCol_ColumnEditName.FieldName = "ColumnEditName";
            this.gridCol_ColumnEditName.Name = "gridCol_ColumnEditName";
            this.gridCol_ColumnEditName.OptionsColumn.AllowEdit = false;
            this.gridCol_ColumnEditName.OptionsColumn.AllowShowHide = false;
            this.gridCol_ColumnEditName.OptionsColumn.ReadOnly = true;
            this.gridCol_ColumnEditName.Visible = true;
            this.gridCol_ColumnEditName.VisibleIndex = 2;
            this.gridCol_ColumnEditName.Width = 136;
            // 
            // btnDown
            // 
            this.btnDown.Image = global::DS.MSClient.Properties.Resources.down;
            this.btnDown.Location = new System.Drawing.Point(8, 136);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 23);
            this.btnDown.TabIndex = 0;
            // 
            // btnUp
            // 
            this.btnUp.Image = global::DS.MSClient.Properties.Resources.up;
            this.btnUp.Location = new System.Drawing.Point(8, 87);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 23);
            this.btnUp.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(124, 374);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(210, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            // 
            // ckb_ChooseAll
            // 
            this.ckb_ChooseAll.Location = new System.Drawing.Point(14, 373);
            this.ckb_ChooseAll.Name = "ckb_ChooseAll";
            this.ckb_ChooseAll.Properties.Caption = "全选";
            this.ckb_ChooseAll.Size = new System.Drawing.Size(72, 19);
            this.ckb_ChooseAll.TabIndex = 11;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnRestoreViewLayout);
            this.panelControl2.Controls.Add(this.btnUp);
            this.panelControl2.Controls.Add(this.btnDown);
            this.panelControl2.Location = new System.Drawing.Point(250, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(44, 362);
            this.panelControl2.TabIndex = 12;
            // 
            // btnRestoreViewLayout
            // 
            this.btnRestoreViewLayout.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnRestoreViewLayout.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.btnRestoreViewLayout.Appearance.Options.UseBackColor = true;
            this.btnRestoreViewLayout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestoreViewLayout.Location = new System.Drawing.Point(9, 280);
            this.btnRestoreViewLayout.Name = "btnRestoreViewLayout";
            this.btnRestoreViewLayout.Size = new System.Drawing.Size(24, 23);
            this.btnRestoreViewLayout.TabIndex = 1;
            this.btnRestoreViewLayout.ToolTip = "恢复默认";
            // 
            // FormColumnConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 409);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.ckb_ChooseAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormColumnConfig";
            this.Text = "列配置";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_ColumnConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ColumnConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_ChooseAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraGrid.GridControl gc_ColumnConfig;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_ColumnConfig;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_Visible;
        private DevExpress.XtraEditors.SimpleButton btnDown;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_ColumnIndex;
        private DevExpress.XtraEditors.CheckEdit ckb_ChooseAll;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnRestoreViewLayout;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_ColumnEditName;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_VisibleIndex;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FixedStyle;
    }
}