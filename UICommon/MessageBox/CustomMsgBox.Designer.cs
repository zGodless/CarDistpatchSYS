namespace DS.MSClient.UICommon.MessageBox
{
	partial class CustomMsgBox
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

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMsgBox));
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.linkLabel_details = new System.Windows.Forms.LinkLabel();
			this.btn_close = new DevExpress.XtraEditors.SimpleButton();
			this.panelControl_details = new DevExpress.XtraEditors.PanelControl();
			this.memoEdit_details = new DevExpress.XtraEditors.MemoEdit();
			this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
			this.btn_ZoomIn = new System.Windows.Forms.PictureBox();
			this.btn_ZoomOut = new System.Windows.Forms.PictureBox();
			this.btn_copy = new DevExpress.XtraEditors.SimpleButton();
			this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
			this.lbl_msg = new DevExpress.XtraEditors.LabelControl();
			this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl_details)).BeginInit();
			this.panelControl_details.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_details.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
			this.panelControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.btn_ZoomIn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_ZoomOut)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
			this.panelControl4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
			this.panelControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.linkLabel_details);
			this.panelControl1.Controls.Add(this.btn_close);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl1.Location = new System.Drawing.Point(2, 90);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(530, 36);
			this.panelControl1.TabIndex = 4;
			// 
			// linkLabel_details
			// 
			this.linkLabel_details.AutoSize = true;
			this.linkLabel_details.Location = new System.Drawing.Point(27, 13);
			this.linkLabel_details.Name = "linkLabel_details";
			this.linkLabel_details.Size = new System.Drawing.Size(67, 14);
			this.linkLabel_details.TabIndex = 1;
			this.linkLabel_details.TabStop = true;
			this.linkLabel_details.Text = "详细信息...";
			// 
			// btn_close
			// 
			this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_close.Location = new System.Drawing.Point(443, 6);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new System.Drawing.Size(75, 23);
			this.btn_close.TabIndex = 0;
			this.btn_close.Text = "确定";
			// 
			// panelControl_details
			// 
			this.panelControl_details.Controls.Add(this.memoEdit_details);
			this.panelControl_details.Controls.Add(this.panelControl3);
			this.panelControl_details.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl_details.Location = new System.Drawing.Point(0, 128);
			this.panelControl_details.Name = "panelControl_details";
			this.panelControl_details.Size = new System.Drawing.Size(534, 250);
			this.panelControl_details.TabIndex = 5;
			// 
			// memoEdit_details
			// 
			this.memoEdit_details.Dock = System.Windows.Forms.DockStyle.Fill;
			this.memoEdit_details.Location = new System.Drawing.Point(2, 2);
			this.memoEdit_details.Name = "memoEdit_details";
			this.memoEdit_details.Properties.ReadOnly = true;
			this.memoEdit_details.Size = new System.Drawing.Size(530, 210);
			this.memoEdit_details.TabIndex = 0;
			this.memoEdit_details.UseOptimizedRendering = true;
			// 
			// panelControl3
			// 
			this.panelControl3.Controls.Add(this.btn_ZoomIn);
			this.panelControl3.Controls.Add(this.btn_ZoomOut);
			this.panelControl3.Controls.Add(this.btn_copy);
			this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl3.Location = new System.Drawing.Point(2, 212);
			this.panelControl3.Name = "panelControl3";
			this.panelControl3.Size = new System.Drawing.Size(530, 36);
			this.panelControl3.TabIndex = 1;
			// 
			// btn_ZoomIn
			// 
			this.btn_ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btn_ZoomIn.Image")));
			this.btn_ZoomIn.Location = new System.Drawing.Point(12, 4);
			this.btn_ZoomIn.Name = "btn_ZoomIn";
			this.btn_ZoomIn.Size = new System.Drawing.Size(32, 32);
			this.btn_ZoomIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.btn_ZoomIn.TabIndex = 2;
			this.btn_ZoomIn.TabStop = false;
			// 
			// btn_ZoomOut
			// 
			this.btn_ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btn_ZoomOut.Image")));
			this.btn_ZoomOut.Location = new System.Drawing.Point(45, 4);
			this.btn_ZoomOut.Name = "btn_ZoomOut";
			this.btn_ZoomOut.Size = new System.Drawing.Size(32, 32);
			this.btn_ZoomOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.btn_ZoomOut.TabIndex = 1;
			this.btn_ZoomOut.TabStop = false;
			// 
			// btn_copy
			// 
			this.btn_copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_copy.Location = new System.Drawing.Point(445, 6);
			this.btn_copy.Name = "btn_copy";
			this.btn_copy.Size = new System.Drawing.Size(75, 23);
			this.btn_copy.TabIndex = 0;
			this.btn_copy.Text = "复制";
			// 
			// panelControl4
			// 
			this.panelControl4.Controls.Add(this.panelControl2);
			this.panelControl4.Controls.Add(this.panelControl1);
			this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl4.Location = new System.Drawing.Point(0, 0);
			this.panelControl4.Name = "panelControl4";
			this.panelControl4.Size = new System.Drawing.Size(534, 128);
			this.panelControl4.TabIndex = 6;
			// 
			// lbl_msg
			// 
			this.lbl_msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_msg.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.lbl_msg.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.lbl_msg.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.lbl_msg.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
			this.lbl_msg.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.lbl_msg.Location = new System.Drawing.Point(69, 0);
			this.lbl_msg.MinimumSize = new System.Drawing.Size(120, 87);
			this.lbl_msg.Name = "lbl_msg";
			this.lbl_msg.Padding = new System.Windows.Forms.Padding(10);
			this.lbl_msg.Size = new System.Drawing.Size(461, 88);
			this.lbl_msg.TabIndex = 0;
			this.lbl_msg.Text = "  未定义的错误";
			// 
			// panelControl2
			// 
			this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
			this.panelControl2.Controls.Add(this.lbl_msg);
			this.panelControl2.Controls.Add(this.pictureBox1);
			this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelControl2.Location = new System.Drawing.Point(2, 2);
			this.panelControl2.MinimumSize = new System.Drawing.Size(72, 87);
			this.panelControl2.Name = "panelControl2";
			this.panelControl2.Size = new System.Drawing.Size(530, 88);
			this.panelControl2.TabIndex = 1;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 13);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(51, 39);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// CustomMsgBox
			// 
			this.ClientSize = new System.Drawing.Size(534, 378);
			this.Controls.Add(this.panelControl_details);
			this.Controls.Add(this.panelControl4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(290, 165);
			this.Name = "CustomMsgBox";
			this.Text = "错误报告";
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.panelControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl_details)).EndInit();
			this.panelControl_details.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.memoEdit_details.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
			this.panelControl3.ResumeLayout(false);
			this.panelControl3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.btn_ZoomIn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.btn_ZoomOut)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
			this.panelControl4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
			this.panelControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.PanelControl panelControl1;
		private System.Windows.Forms.LinkLabel linkLabel_details;
		private DevExpress.XtraEditors.SimpleButton btn_close;
		private DevExpress.XtraEditors.PanelControl panelControl_details;
		private DevExpress.XtraEditors.MemoEdit memoEdit_details;
		private DevExpress.XtraEditors.PanelControl panelControl3;
		private System.Windows.Forms.PictureBox btn_ZoomIn;
		private System.Windows.Forms.PictureBox btn_ZoomOut;
		private DevExpress.XtraEditors.SimpleButton btn_copy;
		private DevExpress.XtraEditors.PanelControl panelControl4;
		private DevExpress.XtraEditors.LabelControl lbl_msg;
		private DevExpress.XtraEditors.PanelControl panelControl2;
		private System.Windows.Forms.PictureBox pictureBox1;

	}
}
