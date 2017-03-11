namespace DS.MSClient
{
	partial class FormBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 是否启用 Show 方法的 CenterParent 功能
		/// </summary>
		protected bool alwaysCanCenterParent = true;

		/// <summary>
		/// 初始化时是否最大化
		/// </summary>
		protected bool initMaxize = false;

		/// <summary>
		/// 窗体操作状态
		/// </summary>
		protected FormState formState = FormState.Normal;

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
			this.SuspendLayout();
			// 
			// FormBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(784, 561);
			this.LookAndFeel.SkinName = "Office 2010 Silver";
			this.Name = "FormBase";
			this.Text = "基本窗体";
			this.ResumeLayout(false);

		}

		#endregion
	}
}