namespace DS.MSClient.UICommon
{
    partial class FormSelectStudent
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
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectStudent));
			this.panelControl_Bottom = new DevExpress.XtraEditors.PanelControl();
			this.simpleButton_no = new DevExpress.XtraEditors.SimpleButton();
			this.simpleButton_yes = new DevExpress.XtraEditors.SimpleButton();
			this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			this.cLookUpStudent = new DS.MSClient.UIControl.CLookUpStudent();
			this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).BeginInit();
			this.panelControl_Bottom.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
			this.layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cLookUpStudent.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl_Bottom
			// 
			this.panelControl_Bottom.Controls.Add(this.simpleButton_no);
			this.panelControl_Bottom.Controls.Add(this.simpleButton_yes);
			this.panelControl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl_Bottom.Location = new System.Drawing.Point(0, 65);
			this.panelControl_Bottom.Name = "panelControl_Bottom";
			this.panelControl_Bottom.Size = new System.Drawing.Size(292, 41);
			this.panelControl_Bottom.TabIndex = 0;
			// 
			// simpleButton_no
			// 
			this.simpleButton_no.Location = new System.Drawing.Point(215, 6);
			this.simpleButton_no.Name = "simpleButton_no";
			this.simpleButton_no.Size = new System.Drawing.Size(65, 23);
			this.simpleButton_no.TabIndex = 1;
			this.simpleButton_no.Text = "取消";
			// 
			// simpleButton_yes
			// 
			this.simpleButton_yes.Location = new System.Drawing.Point(130, 6);
			this.simpleButton_yes.Name = "simpleButton_yes";
			this.simpleButton_yes.Size = new System.Drawing.Size(67, 23);
			this.simpleButton_yes.TabIndex = 0;
			this.simpleButton_yes.Text = "确定";
			// 
			// layoutControl1
			// 
			this.layoutControl1.Controls.Add(this.cLookUpStudent);
			this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layoutControl1.Location = new System.Drawing.Point(0, 0);
			this.layoutControl1.Name = "layoutControl1";
			this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(661, 206, 250, 350);
			this.layoutControl1.Root = this.layoutControlGroup1;
			this.layoutControl1.Size = new System.Drawing.Size(292, 65);
			this.layoutControl1.TabIndex = 1;
			this.layoutControl1.Text = "layoutControl1";
			// 
			// cLookUpStudent
			// 
			this.cLookUpStudent.CurrentService = null;
			this.cLookUpStudent.ListIsValid = null;
			this.cLookUpStudent.Location = new System.Drawing.Point(71, 12);
			this.cLookUpStudent.MaximumSize = new System.Drawing.Size(0, 23);
			this.cLookUpStudent.Name = "cLookUpStudent";
			this.cLookUpStudent.NewButton = true;
			this.cLookUpStudent.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
			this.cLookUpStudent.Properties.AutoHeight = false;
			this.cLookUpStudent.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			this.cLookUpStudent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "刷新", null, null, true)});
			this.cLookUpStudent.Properties.CaseSensitiveSearch = true;
			this.cLookUpStudent.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.cLookUpStudent.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StudentCode", "学员编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StudentType", "学员类型"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StudentName", "姓名")});
			this.cLookUpStudent.Properties.NullText = "";
			this.cLookUpStudent.Properties.NullValuePromptShowForEmptyValue = true;
			this.cLookUpStudent.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
			this.cLookUpStudent.Size = new System.Drawing.Size(209, 23);
			this.cLookUpStudent.StyleController = this.layoutControl1;
			this.cLookUpStudent.TabIndex = 4;
			this.cLookUpStudent.ToolTip = "清除选择:[CTRL + 0]";
			// 
			// layoutControlGroup1
			// 
			this.layoutControlGroup1.CustomizationFormText = "Root";
			this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			this.layoutControlGroup1.GroupBordersVisible = false;
			this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1});
			this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlGroup1.Name = "Root";
			this.layoutControlGroup1.Size = new System.Drawing.Size(292, 65);
			this.layoutControlGroup1.Text = "Root";
			this.layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			this.layoutControlItem1.Control = this.cLookUpStudent;
			this.layoutControlItem1.CustomizationFormText = "学员        ";
			this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem1.Name = "layoutControlItem1";
			this.layoutControlItem1.Size = new System.Drawing.Size(272, 27);
			this.layoutControlItem1.Text = "学员        ";
			this.layoutControlItem1.TextSize = new System.Drawing.Size(56, 14);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
			this.emptySpaceItem1.Location = new System.Drawing.Point(0, 27);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(272, 18);
			this.emptySpaceItem1.Text = "emptySpaceItem1";
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
			// 
			// FormSelectStudent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 106);
			this.Controls.Add(this.layoutControl1);
			this.Controls.Add(this.panelControl_Bottom);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormSelectStudent";
			this.Text = "选择学员绑定";
			((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).EndInit();
			this.panelControl_Bottom.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
			this.layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cLookUpStudent.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl_Bottom;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton simpleButton_no;
        private DevExpress.XtraEditors.SimpleButton simpleButton_yes;
        private UIControl.CLookUpStudent cLookUpStudent;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}