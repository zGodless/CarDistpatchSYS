namespace DS.MSClient.UICommon
{
    partial class FormSearchCondition
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Confirm = new DevExpress.XtraEditors.SimpleButton();
            this.lb_Name = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gc_Condition = new DevExpress.XtraGrid.GridControl();
            this.ds_MyDataSet = new System.Data.DataSet();
            this.dt_MyDataSet = new System.Data.DataTable();
            this.Choose = new System.Data.DataColumn();
            this.ColumnName = new System.Data.DataColumn();
            this.Operater = new System.Data.DataColumn();
            this.ValueDisplay = new System.Data.DataColumn();
            this.ColumnFiledName = new System.Data.DataColumn();
            this.Type = new System.Data.DataColumn();
            this.ButtonEdit = new System.Data.DataColumn();
            this.TextDisplay = new System.Data.DataColumn();
            this.gv_Condition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.comb_Operater = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridCol_Value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.comb_TrueOrFalse = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridCol_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dateEdit_Time = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnEdit_Value = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.dateEdit_Value = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.comb_ChooseValue = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ckb_Value = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemComboBox_VehicleType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox_DutyType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox_NJDutyType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox_IsCreatedByPDA = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Condition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_MyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_MyDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Condition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comb_Operater)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comb_TrueOrFalse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Time.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Value.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comb_ChooseValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_VehicleType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_DutyType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_NJDutyType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_IsCreatedByPDA)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btn_Cancel);
            this.panelControl2.Controls.Add(this.btn_Confirm);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 382);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(660, 40);
            this.panelControl2.TabIndex = 8;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(512, 9);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(407, 9);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 0;
            this.btn_Confirm.Text = "确定";
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // lb_Name
            // 
            this.lb_Name.Location = new System.Drawing.Point(21, 12);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(36, 14);
            this.lb_Name.TabIndex = 0;
            this.lb_Name.Text = "查询：";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lb_Name);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(660, 40);
            this.panelControl1.TabIndex = 6;
            // 
            // gc_Condition
            // 
            this.gc_Condition.DataMember = "dt_MyDataSet";
            this.gc_Condition.DataSource = this.ds_MyDataSet;
            this.gc_Condition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc_Condition.Location = new System.Drawing.Point(0, 40);
            this.gc_Condition.MainView = this.gv_Condition;
            this.gc_Condition.Name = "gc_Condition";
            this.gc_Condition.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.comb_Operater,
            this.btnEdit_Value,
            this.dateEdit_Value,
            this.comb_ChooseValue,
            this.ckb_Value,
            this.comb_TrueOrFalse,
            this.dateEdit_Time,
            this.repositoryItemComboBox_VehicleType,
            this.repositoryItemComboBox_DutyType,
            this.repositoryItemComboBox_NJDutyType,
            repositoryItemComboBox_IsCreatedByPDA});
            this.gc_Condition.Size = new System.Drawing.Size(660, 342);
            this.gc_Condition.TabIndex = 15;
            this.gc_Condition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv_Condition});
            // 
            // ds_MyDataSet
            // 
            this.ds_MyDataSet.DataSetName = "NewDataSet";
            this.ds_MyDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.dt_MyDataSet});
            // 
            // dt_MyDataSet
            // 
            this.dt_MyDataSet.Columns.AddRange(new System.Data.DataColumn[] {
            this.Choose,
            this.ColumnName,
            this.Operater,
            this.ValueDisplay,
            this.ColumnFiledName,
            this.Type,
            this.ButtonEdit,
            this.TextDisplay});
            this.dt_MyDataSet.TableName = "dt_MyDataSet";
            // 
            // Choose
            // 
            this.Choose.Caption = "选择";
            this.Choose.ColumnName = "Choose";
            this.Choose.DataType = typeof(bool);
            // 
            // ColumnName
            // 
            this.ColumnName.ColumnName = "ColumnName";
            // 
            // Operater
            // 
            this.Operater.Caption = "Operater";
            this.Operater.ColumnName = "Operater";
            // 
            // ValueDisplay
            // 
            this.ValueDisplay.Caption = "ValueDisplay";
            this.ValueDisplay.ColumnName = "ValueDisplay";
            // 
            // ColumnFiledName
            // 
            this.ColumnFiledName.Caption = "ColumnFiledName";
            this.ColumnFiledName.ColumnName = "ColumnFiledName";
            // 
            // Type
            // 
            this.Type.Caption = "Type";
            this.Type.ColumnName = "Type";
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.ColumnName = "ButtonEdit";
            // 
            // TextDisplay
            // 
            this.TextDisplay.ColumnName = "TextDisplay";
            // 
            // gv_Condition
            // 
            this.gv_Condition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridCol_Value,
            this.gridCol_date});
            this.gv_Condition.GridControl = this.gc_Condition;
            this.gv_Condition.Name = "gv_Condition";
            this.gv_Condition.OptionsCustomization.AllowFilter = false;
            this.gv_Condition.OptionsCustomization.AllowGroup = false;
            this.gv_Condition.OptionsCustomization.AllowQuickHideColumns = false;
            this.gv_Condition.OptionsCustomization.AllowSort = false;
            this.gv_Condition.OptionsView.ShowDetailButtons = false;
            this.gv_Condition.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gv_Condition.OptionsView.ShowGroupPanel = false;
            this.gv_Condition.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_LoadGroup_FocusedRowChanged);
            this.gv_Condition.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv_Condition_CellValueChanging);
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "选择";
            this.gridColumn13.FieldName = "Choose";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            this.gridColumn13.Width = 60;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.Caption = "列名";
            this.gridColumn14.FieldName = "ColumnName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            this.gridColumn14.Width = 199;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.Caption = "运算符";
            this.gridColumn15.ColumnEdit = this.comb_Operater;
            this.gridColumn15.FieldName = "Operater";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 2;
            this.gridColumn15.Width = 110;
            // 
            // comb_Operater
            // 
            this.comb_Operater.AutoHeight = false;
            this.comb_Operater.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comb_Operater.Items.AddRange(new object[] {
            "等于",
            "大于",
            "小于",
            "大于等于",
            "小于等于",
            "不等于",
            "近似等于"});
            this.comb_Operater.Name = "comb_Operater";
            // 
            // gridCol_Value
            // 
            this.gridCol_Value.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCol_Value.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCol_Value.Caption = "值";
            this.gridCol_Value.ColumnEdit = this.comb_TrueOrFalse;
            this.gridCol_Value.FieldName = "TextDisplay";
            this.gridCol_Value.Name = "gridCol_Value";
            this.gridCol_Value.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedCell;
            this.gridCol_Value.Visible = true;
            this.gridCol_Value.VisibleIndex = 3;
            this.gridCol_Value.Width = 270;
            // 
            // comb_TrueOrFalse
            // 
            this.comb_TrueOrFalse.AutoHeight = false;
            this.comb_TrueOrFalse.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comb_TrueOrFalse.Items.AddRange(new object[] {
            "是",
            "否"});
            this.comb_TrueOrFalse.Name = "comb_TrueOrFalse";
            this.comb_TrueOrFalse.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gridCol_date
            // 
            this.gridCol_date.ColumnEdit = this.dateEdit_Time;
            this.gridCol_date.Name = "gridCol_date";
            // 
            // dateEdit_Time
            // 
            this.dateEdit_Time.AutoHeight = false;
            this.dateEdit_Time.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_Time.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateEdit_Time.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit_Time.EditFormat.FormatString = "yyyy-MM-dd";
            this.dateEdit_Time.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit_Time.Mask.EditMask = "yyyy-MM-dd";
            this.dateEdit_Time.Name = "dateEdit_Time";
            this.dateEdit_Time.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "等于",
            "大于",
            "小于",
            "近似等于"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            this.repositoryItemComboBox1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // btnEdit_Value
            // 
            this.btnEdit_Value.AutoHeight = false;
            this.btnEdit_Value.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEdit_Value.Name = "btnEdit_Value";
            this.btnEdit_Value.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnEdit_Value.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEdit_Value_ButtonClick);
            // 
            // dateEdit_Value
            // 
            this.dateEdit_Value.AutoHeight = false;
            this.dateEdit_Value.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_Value.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateEdit_Value.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit_Value.Mask.EditMask = "yyyy-MM-dd";
            this.dateEdit_Value.Mask.UseMaskAsDisplayFormat = true;
            this.dateEdit_Value.Name = "dateEdit_Value";
            this.dateEdit_Value.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_Value.VistaTimeProperties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.dateEdit_Value.VistaTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEdit_Value.VistaTimeProperties.Mask.EditMask = "yyyy-MM-dd";
            // 
            // comb_ChooseValue
            // 
            this.comb_ChooseValue.AutoHeight = false;
            this.comb_ChooseValue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comb_ChooseValue.Name = "comb_ChooseValue";
            // 
            // ckb_Value
            // 
            this.ckb_Value.AutoHeight = false;
            this.ckb_Value.Name = "ckb_Value";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox_VehicleType.AutoHeight = false;
            this.repositoryItemComboBox_VehicleType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox_VehicleType.Items.AddRange(new object[] {
            "泥浆车",
            "运输车",
            "铲车",
            "工具车",
            "钩机",
            "加油机(车)",
            "平板车"});
            this.repositoryItemComboBox_VehicleType.Name = "repositoryItemComboBox2";
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox_DutyType.AutoHeight = false;
            this.repositoryItemComboBox_DutyType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox_DutyType.Items.AddRange(new object[] {
            "白班",
            "晚班"});
            this.repositoryItemComboBox_DutyType.Name = "repositoryItemComboBox3";
            // 
            // repositoryItemComboBox_NJDutyType
            // 
            this.repositoryItemComboBox_NJDutyType.AutoHeight = false;
            this.repositoryItemComboBox_NJDutyType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox_NJDutyType.Items.AddRange(new object[] {
            "上午",
            "下午"});
            this.repositoryItemComboBox_NJDutyType.Name = "repositoryItemComboBox4";

              // 
            // repositoryItemComboBox_IsCreatedByPDA
            // 
            this.repositoryItemComboBox_IsCreatedByPDA.AutoHeight = false;
            this.repositoryItemComboBox_IsCreatedByPDA.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox_IsCreatedByPDA.Items.AddRange(new object[] {
            "手工单","PDA刷车卡", "PDA手工录入"});
            this.repositoryItemComboBox_IsCreatedByPDA.Name = "repositoryItemComboBox_IsCreatedByPDA";


            
            // 
            // FormSearchCondition
            // 
            this.AcceptButton = this.btn_Confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(660, 422);
            this.Controls.Add(this.gc_Condition);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSearchCondition";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "条件查询";
            this.Load += new System.EventHandler(this.FormSearchCondition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc_Condition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ds_MyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_MyDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Condition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comb_Operater)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comb_TrueOrFalse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Time.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit_Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Value.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comb_ChooseValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckb_Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_VehicleType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_DutyType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_NJDutyType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Confirm;
        public DevExpress.XtraEditors.LabelControl lb_Name;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraGrid.GridControl gc_Condition;
        public DevExpress.XtraGrid.Views.Grid.GridView gv_Condition;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_Value;
        private System.Data.DataSet ds_MyDataSet;
        private System.Data.DataTable dt_MyDataSet;
        private System.Data.DataColumn Choose;
        private System.Data.DataColumn ColumnName;
        private System.Data.DataColumn Operater;
        private System.Data.DataColumn ValueDisplay;
        private System.Data.DataColumn ColumnFiledName;
        private System.Data.DataColumn Type;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox comb_Operater;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dateEdit_Value;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnEdit_Value;
        private System.Data.DataColumn ButtonEdit;
        private System.Data.DataColumn TextDisplay;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox comb_ChooseValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckb_Value;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox comb_TrueOrFalse;
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_date;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dateEdit_Time;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox_VehicleType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox_DutyType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox_NJDutyType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox_IsCreatedByPDA; 


    }
}