using System.ComponentModel;
using DevExpress.XtraEditors;

namespace DS.MSClient.UIBase
{
	public partial class DialogBase : FormBase
	{
		#region 初始化

		/// <summary>
		/// 基本对话框
		/// </summary>
		public DialogBase()
		{
			InitializeComponent();
		}

		#endregion

		#region 属性

		[Category("按钮")]
		[Description("确定按钮")]
		public SimpleButton ButtonOK
		{
			get { return btnOK; }
		}

		[Category("按钮")]
		[Description("取消按钮")]
		public SimpleButton ButtonCancel
		{
			get { return btnCancel; }
		}

		#endregion
	}
}