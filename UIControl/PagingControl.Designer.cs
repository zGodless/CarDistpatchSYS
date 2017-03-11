namespace DS.MSClient.UIControl
{
    partial class PagingControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.Btn_toPage = new DevExpress.XtraEditors.SimpleButton();
			this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
			this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
			this.lbl_pageInfo = new DevExpress.XtraEditors.LabelControl();
			this.textEditToPage = new DevExpress.XtraEditors.TextEdit();
			this.comboBoxEditPageSize = new DevExpress.XtraEditors.ComboBoxEdit();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.Btn_End = new DevExpress.XtraEditors.SimpleButton();
			this.Btn_Next = new DevExpress.XtraEditors.SimpleButton();
			this.Btn_Prev = new DevExpress.XtraEditors.SimpleButton();
			this.Btn_First = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEditToPage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPageSize.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
			this.panelControl1.Appearance.Options.UseBackColor = true;
			this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl1.Controls.Add(this.Btn_toPage);
			this.panelControl1.Controls.Add(this.labelControl3);
			this.panelControl1.Controls.Add(this.labelControl2);
			this.panelControl1.Controls.Add(this.textEditToPage);
			this.panelControl1.Controls.Add(this.comboBoxEditPageSize);
			this.panelControl1.Controls.Add(this.labelControl1);
			this.panelControl1.Controls.Add(this.Btn_End);
			this.panelControl1.Controls.Add(this.Btn_Next);
			this.panelControl1.Controls.Add(this.Btn_Prev);
			this.panelControl1.Controls.Add(this.Btn_First);
			this.panelControl1.Location = new System.Drawing.Point(140, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.panelControl1.Size = new System.Drawing.Size(457, 27);
			this.panelControl1.TabIndex = 0;
			// 
			// Btn_toPage
			// 
			this.Btn_toPage.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.Btn_toPage.Location = new System.Drawing.Point(196, 4);
			this.Btn_toPage.Name = "Btn_toPage";
			this.Btn_toPage.Size = new System.Drawing.Size(20, 20);
			this.Btn_toPage.TabIndex = 2;
			this.Btn_toPage.Text = "go";
			// 
			// labelControl3
			// 
			this.labelControl3.Location = new System.Drawing.Point(117, 5);
			this.labelControl3.Name = "labelControl3";
			this.labelControl3.Size = new System.Drawing.Size(12, 14);
			this.labelControl3.TabIndex = 37;
			this.labelControl3.Text = "第";
			// 
			// labelControl2
			// 
			this.labelControl2.Location = new System.Drawing.Point(173, 6);
			this.labelControl2.Name = "labelControl2";
			this.labelControl2.Size = new System.Drawing.Size(12, 14);
			this.labelControl2.TabIndex = 36;
			this.labelControl2.Text = "页";
			// 
			// lbl_pageInfo
			// 
			this.lbl_pageInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lbl_pageInfo.Location = new System.Drawing.Point(15, 5);
			this.lbl_pageInfo.Name = "lbl_pageInfo";
			this.lbl_pageInfo.Size = new System.Drawing.Size(94, 14);
			this.lbl_pageInfo.TabIndex = 34;
			this.lbl_pageInfo.Text = " 共0条记录,共0页";
			// 
			// textEditToPage
			// 
			this.textEditToPage.EditValue = "1";
			this.textEditToPage.Location = new System.Drawing.Point(137, 4);
			this.textEditToPage.Name = "textEditToPage";
			this.textEditToPage.Properties.Appearance.Options.UseTextOptions = true;
			this.textEditToPage.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.textEditToPage.Properties.AutoHeight = false;
			this.textEditToPage.Properties.EditFormat.FormatString = "d";
			this.textEditToPage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.textEditToPage.Size = new System.Drawing.Size(30, 21);
			this.textEditToPage.TabIndex = 1;
			// 
			// comboBoxEditPageSize
			// 
			this.comboBoxEditPageSize.EditValue = "100";
			this.comboBoxEditPageSize.Location = new System.Drawing.Point(60, 4);
			this.comboBoxEditPageSize.Name = "comboBoxEditPageSize";
			this.comboBoxEditPageSize.Properties.Appearance.Options.UseTextOptions = true;
			this.comboBoxEditPageSize.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.comboBoxEditPageSize.Properties.AutoHeight = false;
			this.comboBoxEditPageSize.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.comboBoxEditPageSize.Properties.DisplayFormat.FormatString = "d";
			this.comboBoxEditPageSize.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.comboBoxEditPageSize.Properties.EditFormat.FormatString = "d";
			this.comboBoxEditPageSize.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.comboBoxEditPageSize.Properties.EditValueChangedDelay = 1;
			this.comboBoxEditPageSize.Properties.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "5000"});
			this.comboBoxEditPageSize.Size = new System.Drawing.Size(49, 21);
			this.comboBoxEditPageSize.TabIndex = 0;
			// 
			// labelControl1
			// 
			this.labelControl1.Location = new System.Drawing.Point(3, 5);
			this.labelControl1.Name = "labelControl1";
			this.labelControl1.Size = new System.Drawing.Size(48, 14);
			this.labelControl1.TabIndex = 17;
			this.labelControl1.Text = "每页条数";
			// 
			// Btn_End
			// 
			this.Btn_End.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.Btn_End.Location = new System.Drawing.Point(398, 4);
			this.Btn_End.Name = "Btn_End";
			this.Btn_End.Size = new System.Drawing.Size(55, 20);
			this.Btn_End.TabIndex = 6;
			this.Btn_End.Text = "尾页";
			// 
			// Btn_Next
			// 
			this.Btn_Next.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.Btn_Next.Location = new System.Drawing.Point(339, 4);
			this.Btn_Next.Name = "Btn_Next";
			this.Btn_Next.Size = new System.Drawing.Size(55, 20);
			this.Btn_Next.TabIndex = 5;
			this.Btn_Next.Text = "下一页";
			// 
			// Btn_Prev
			// 
			this.Btn_Prev.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.Btn_Prev.Location = new System.Drawing.Point(280, 4);
			this.Btn_Prev.Name = "Btn_Prev";
			this.Btn_Prev.Size = new System.Drawing.Size(55, 20);
			this.Btn_Prev.TabIndex = 4;
			this.Btn_Prev.Text = "上一页";
			// 
			// Btn_First
			// 
			this.Btn_First.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
			this.Btn_First.Location = new System.Drawing.Point(221, 4);
			this.Btn_First.Name = "Btn_First";
			this.Btn_First.Size = new System.Drawing.Size(55, 20);
			this.Btn_First.TabIndex = 3;
			this.Btn_First.Text = "首页";
			// 
			// PagingControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.panelControl1);
			this.Controls.Add(this.lbl_pageInfo);
			this.Name = "PagingControl";
			this.Size = new System.Drawing.Size(633, 27);
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.panelControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.textEditToPage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.comboBoxEditPageSize.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_First;
        private DevExpress.XtraEditors.SimpleButton Btn_End;
        private DevExpress.XtraEditors.SimpleButton Btn_Next;
        private DevExpress.XtraEditors.SimpleButton Btn_Prev;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditPageSize;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditToPage;
        private DevExpress.XtraEditors.LabelControl lbl_pageInfo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton Btn_toPage;
    }
}
