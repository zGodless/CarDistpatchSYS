namespace DS.MSClient.UICommon
{
    partial class FormSelectTicketRule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectTicketRule));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_no = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_yes = new DevExpress.XtraEditors.SimpleButton();
            this.gc_ticket_rule = new DS.MSClient.UIControl.CGridControl();
            this.gv_ticket_rule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Column_choose = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gc_TicketRule = new DS.MSClient.UIControl.CGridControl();
            this.gv_TicketRule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn_Choose = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_ticket_rule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ticket_rule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_TicketRule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_TicketRule)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton_no);
            this.panelControl1.Controls.Add(this.simpleButton_yes);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 343);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(805, 51);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton_no
            // 
            this.simpleButton_no.Location = new System.Drawing.Point(703, 10);
            this.simpleButton_no.Name = "simpleButton_no";
            this.simpleButton_no.Size = new System.Drawing.Size(87, 27);
            this.simpleButton_no.TabIndex = 1;
            this.simpleButton_no.Text = "取消";
            // 
            // simpleButton_yes
            // 
            this.simpleButton_yes.Location = new System.Drawing.Point(579, 10);
            this.simpleButton_yes.Name = "simpleButton_yes";
            this.simpleButton_yes.Size = new System.Drawing.Size(87, 27);
            this.simpleButton_yes.TabIndex = 0;
            this.simpleButton_yes.Text = "确定";
            // 
            // gc_ticket_rule
            // 
            this.gc_ticket_rule.AdvanceSearchMethod = null;
            this.gc_ticket_rule.GetPageSizeMethod = null;
            this.gc_ticket_rule.GetTotalRecordCountMethod = null;
            this.gc_ticket_rule.PageSortOrderSearchMethod = null;
            this.gc_ticket_rule.CallCustomNavicationButtonClick = null;
            this.gc_ticket_rule.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_ticket_rule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_ticket_rule.ImmediatelyDownLoad = false;
            this.gc_ticket_rule.Location = new System.Drawing.Point(0, 0);
            this.gc_ticket_rule.MainView = this.gv_ticket_rule;
            this.gc_ticket_rule.Name = "gc_ticket_rule";
            this.gc_ticket_rule.ShowCustomHeaderMenu = true;
            this.gc_ticket_rule.ShowCustomNavigationButtons = false;
            this.gc_ticket_rule.ShowCustomRowHeightButton = true;
            this.gc_ticket_rule.ShowImmediatelyDownLoadMenu = true;
            this.gc_ticket_rule.Size = new System.Drawing.Size(805, 343);
            this.gc_ticket_rule.TabIndex = 5;
            this.gc_ticket_rule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_ticket_rule});
            // 
            // gv_ticket_rule
            // 
            this.gv_ticket_rule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Column_choose,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn12,
            this.gridColumn10,
            this.gridColumn11,
            this.ID});
            this.gv_ticket_rule.GridControl = this.gc_ticket_rule;
            this.gv_ticket_rule.Name = "gv_ticket_rule";
            this.gv_ticket_rule.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gv_ticket_rule.OptionsView.ColumnAutoWidth = false;
            this.gv_ticket_rule.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_ticket_rule.OptionsView.EnableAppearanceOddRow = true;
            // 
            // Column_choose
            // 
            this.Column_choose.AppearanceCell.Options.UseTextOptions = true;
            this.Column_choose.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_choose.AppearanceHeader.Options.UseTextOptions = true;
            this.Column_choose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Column_choose.Caption = "选择";
            this.Column_choose.FieldName = "Choose";
            this.Column_choose.Name = "Column_choose";
            this.Column_choose.OptionsColumn.AllowEdit = false;
            this.Column_choose.OptionsColumn.ReadOnly = true;
            this.Column_choose.Visible = true;
            this.Column_choose.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "规则编号";
            this.gridColumn2.FieldName = "TicketRuleCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "卡券类型";
            this.gridColumn3.FieldName = "TicketName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "起始时间";
            this.gridColumn4.FieldName = "StartDate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "到期时间";
            this.gridColumn5.FieldName = "ExpireDate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "抵用金额";
            this.gridColumn6.FieldName = "Amount";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "抵用一次";
            this.gridColumn7.FieldName = "Time";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "可使用商品";
            this.gridColumn8.FieldName = "CommodityIDStr";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "可使用商品名称";
            this.gridColumn9.FieldName = "CommodityNameStr";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 250;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "备注";
            this.gridColumn12.FieldName = "Note";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "操作员";
            this.gridColumn10.FieldName = "OperateName";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "操作时间";
            this.gridColumn11.FieldName = "OperateTime";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // ID
            // 
            this.ID.Caption = "gridColumn1";
            this.ID.FieldName = "TicketRuleID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.OptionsColumn.ReadOnly = true;
            // 
            // gc_TicketRule
            // 
            this.gc_TicketRule.AdvanceSearchMethod = null;
            this.gc_TicketRule.GetPageSizeMethod = null;
            this.gc_TicketRule.GetTotalRecordCountMethod = null;
            this.gc_TicketRule.PageSortOrderSearchMethod = null;
            this.gc_TicketRule.CallCustomNavicationButtonClick = null;
            this.gc_TicketRule.Cursor = System.Windows.Forms.Cursors.Default;
            this.gc_TicketRule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_TicketRule.ImmediatelyDownLoad = false;
            this.gc_TicketRule.Location = new System.Drawing.Point(0, 0);
            this.gc_TicketRule.MainView = this.gv_TicketRule;
            this.gc_TicketRule.Name = "gc_TicketRule";
            this.gc_TicketRule.ShowCustomHeaderMenu = true;
            this.gc_TicketRule.ShowCustomNavigationButtons = false;
            this.gc_TicketRule.ShowCustomRowHeightButton = true;
            this.gc_TicketRule.ShowImmediatelyDownLoadMenu = true;
            this.gc_TicketRule.Size = new System.Drawing.Size(805, 343);
            this.gc_TicketRule.TabIndex = 6;
            this.gc_TicketRule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_TicketRule});
            // 
            // gv_TicketRule
            // 
            this.gv_TicketRule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn_Choose,
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
            this.gridColumn24});
            this.gv_TicketRule.GridControl = this.gc_TicketRule;
            this.gv_TicketRule.Name = "gv_TicketRule";
            this.gv_TicketRule.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gv_TicketRule.OptionsView.ColumnAutoWidth = false;
            this.gv_TicketRule.OptionsView.EnableAppearanceEvenRow = true;
            this.gv_TicketRule.OptionsView.EnableAppearanceOddRow = true;
            // 
            // gridColumn_Choose
            // 
            this.gridColumn_Choose.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn_Choose.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Choose.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn_Choose.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn_Choose.Caption = "选择";
            this.gridColumn_Choose.FieldName = "Choose";
            this.gridColumn_Choose.Name = "gridColumn_Choose";
            this.gridColumn_Choose.OptionsColumn.AllowEdit = false;
            this.gridColumn_Choose.OptionsColumn.ReadOnly = true;
            this.gridColumn_Choose.Visible = true;
            this.gridColumn_Choose.VisibleIndex = 0;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "规则编号";
            this.gridColumn13.FieldName = "TicketRuleCode";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.Caption = "卡券类型";
            this.gridColumn14.FieldName = "TicketName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.Caption = "起始时间";
            this.gridColumn15.FieldName = "StartDate";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.Caption = "到期时间";
            this.gridColumn16.FieldName = "ExpireDate";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 4;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.Caption = "抵用金额";
            this.gridColumn17.FieldName = "Amount";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 5;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn18.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn18.Caption = "抵用一次";
            this.gridColumn18.FieldName = "Time";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 6;
            // 
            // gridColumn19
            // 
            this.gridColumn19.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn19.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn19.Caption = "可使用商品";
            this.gridColumn19.FieldName = "CommodityIDStr";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn20
            // 
            this.gridColumn20.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn20.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn20.Caption = "可使用商品名称";
            this.gridColumn20.FieldName = "CommodityNameStr";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.ReadOnly = true;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 7;
            this.gridColumn20.Width = 250;
            // 
            // gridColumn21
            // 
            this.gridColumn21.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn21.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn21.Caption = "备注";
            this.gridColumn21.FieldName = "Note";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.ReadOnly = true;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 8;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn22.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn22.Caption = "操作员";
            this.gridColumn22.FieldName = "OperateName";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.ReadOnly = true;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 9;
            // 
            // gridColumn23
            // 
            this.gridColumn23.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn23.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn23.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn23.Caption = "操作时间";
            this.gridColumn23.FieldName = "OperateTime";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.ReadOnly = true;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 10;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "gridColumn1";
            this.gridColumn24.FieldName = "TicketRuleID";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.ReadOnly = true;
            // 
            // FormSelectTicketRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 394);
            this.Controls.Add(this.gc_TicketRule);
            this.Controls.Add(this.gc_ticket_rule);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelectTicketRule";
            this.Text = "选择商品规则";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc_ticket_rule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ticket_rule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc_TicketRule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_TicketRule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_no;
        private DevExpress.XtraEditors.SimpleButton simpleButton_yes;
        private UIControl.CGridControl gc_ticket_rule;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_ticket_rule;
        private DevExpress.XtraGrid.Columns.GridColumn Column_choose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private UIControl.CGridControl gc_TicketRule;
        private DevExpress.XtraGrid.Views.Grid.GridView gv_TicketRule;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn_Choose;
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
    }
}