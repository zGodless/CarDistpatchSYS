namespace DS.MSClient.UICommon
{
    partial class FormSelectTicketNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectTicketNumber));
            this.panelControl_Bottom = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton_no = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton_yes = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_Note = new DevExpress.XtraEditors.MemoEdit();
            this.txt_number = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.txt_Noterfr = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).BeginInit();
            this.panelControl_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Note.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_number.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Noterfr)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl_Bottom
            // 
            this.panelControl_Bottom.Controls.Add(this.simpleButton_no);
            this.panelControl_Bottom.Controls.Add(this.simpleButton_yes);
            this.panelControl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl_Bottom.Location = new System.Drawing.Point(0, 171);
            this.panelControl_Bottom.Name = "panelControl_Bottom";
            this.panelControl_Bottom.Size = new System.Drawing.Size(412, 44);
            this.panelControl_Bottom.TabIndex = 0;
            // 
            // simpleButton_no
            // 
            this.simpleButton_no.Location = new System.Drawing.Point(333, 7);
            this.simpleButton_no.Name = "simpleButton_no";
            this.simpleButton_no.Size = new System.Drawing.Size(70, 27);
            this.simpleButton_no.TabIndex = 1;
            this.simpleButton_no.Text = "取消";
            // 
            // simpleButton_yes
            // 
            this.simpleButton_yes.Location = new System.Drawing.Point(238, 7);
            this.simpleButton_yes.Name = "simpleButton_yes";
            this.simpleButton_yes.Size = new System.Drawing.Size(75, 26);
            this.simpleButton_yes.TabIndex = 0;
            this.simpleButton_yes.Text = "确定";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_Note);
            this.layoutControl1.Controls.Add(this.txt_number);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(840, 179, 250, 197);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(412, 171);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_Note
            // 
            this.txt_Note.Location = new System.Drawing.Point(63, 36);
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.Size = new System.Drawing.Size(337, 123);
            this.txt_Note.StyleController = this.layoutControl1;
            this.txt_Note.TabIndex = 5;
            this.txt_Note.UseOptimizedRendering = true;
            // 
            // txt_number
            // 
            this.txt_number.Location = new System.Drawing.Point(63, 12);
            this.txt_number.Name = "txt_number";
            this.txt_number.Properties.AutoComplete = false;
            this.txt_number.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_number.Properties.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "200"});
            this.txt_number.Size = new System.Drawing.Size(337, 20);
            this.txt_number.StyleController = this.layoutControl1;
            this.txt_number.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.txt_Noterfr});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(412, 171);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_number;
            this.layoutControlItem1.CustomizationFormText = "生成数量";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(392, 24);
            this.layoutControlItem1.Text = "生成数量";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 14);
            // 
            // txt_Noterfr
            // 
            this.txt_Noterfr.Control = this.txt_Note;
            this.txt_Noterfr.CustomizationFormText = "备注";
            this.txt_Noterfr.Location = new System.Drawing.Point(0, 24);
            this.txt_Noterfr.Name = "txt_Noterfr";
            this.txt_Noterfr.Size = new System.Drawing.Size(392, 127);
            this.txt_Noterfr.Text = "备注";
            this.txt_Noterfr.TextSize = new System.Drawing.Size(48, 14);
            // 
            // FormSelectTicketNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 215);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.panelControl_Bottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelectTicketNumber";
            this.Text = "选择生成卡券数量";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_Bottom)).EndInit();
            this.panelControl_Bottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Note.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_number.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Noterfr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl_Bottom;
        private DevExpress.XtraEditors.SimpleButton simpleButton_no;
        private DevExpress.XtraEditors.SimpleButton simpleButton_yes;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.MemoEdit txt_Note;
        private DevExpress.XtraEditors.ComboBoxEdit txt_number;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem txt_Noterfr;
    }
}