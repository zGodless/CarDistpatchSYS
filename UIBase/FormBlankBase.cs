using System;
using DevExpress.XtraEditors;
using DS.MSClient.Properties;

namespace DS.MSClient
{
	/// <summary>
	///     空白窗体基类
	/// </summary>
	public partial class FormBlankBase : XtraForm
	{
		#region 事件

		private void FormBlankBase_Load(object sender, EventArgs e)
		{
			Icon = Resources.驾校图标;
		}

		#endregion

		#region 初始化

		public FormBlankBase()
		{
			InitializeComponent();
			InitEvent();
		}

		private void InitEvent()
		{
			Load += FormBlankBase_Load;
		}

		#endregion
	}
}