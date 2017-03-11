using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CarDistpatchSYS;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace CarDistpatchSYS
{
	/// <summary>
	/// 基本页面控件
	/// </summary>
	[ToolboxItem(false)]
	public partial class BaseUserControl : XtraUserControl
	{
		#region 初始化

		public BaseUserControl()
		{
			InitializeComponent();
			InitEvent();
		}

		private void InitEvent()
		{
			Load += BaseUserControl_Load;
		}

		#endregion


		#region 属性

		/// <summary>
		///     线程中的Exception
		/// </summary>
		public static Exception ThreadException { get; set; }

		/// <summary>
		///     获取或设置窗体操作状态
		/// </summary>
		[Category("外观")]
		[Description("窗体操作状态")]
		public FormState FormState
		{
			get { return formState; }
			set { formState = value; }
		}

		private string _text;

		/// <summary>
		///		获取或设置页面标题
		/// </summary>
		[Bindable(true)]
		[Browsable(true)]
		[Description("设置页面标题")]
		[DXDescription(@"设置页面标题")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public override string Text
		{
			get { return _text; }
			set
			{
				_text = value ?? "";
				OnPageTitleChanged(new PageTitleChangedArgs(_text));
			}
		}

		#endregion

		#region 事件声明

		/// <summary>
		/// 页面首次显示时发生
		/// </summary>
		public event EventHandler Shown;

		public event PageTitleChangedEventHandler PageTitleChanged;

		#endregion

		#region 事件

		void BaseUserControl_Load(object sender, EventArgs e)
		{
			if (DesignMode) return;
		}

		#endregion

		#region 方法(线程操作)

		/// <summary>
		///     线程执行函数委托
		/// </summary>
		protected delegate void ThreadExcuteMethod();


		#endregion

		#region 方法

		public virtual void OnShown()
		{
			var handler = Shown;
			if (handler != null) handler(this, EventArgs.Empty);
		}

		protected virtual void OnPageTitleChanged(PageTitleChangedArgs e)
		{
			var handler = PageTitleChanged;
			if (handler != null) handler(this, e);
		}

		#endregion
	}

	#region 窗体操作状态

	/// <summary>
	///     窗体操作状态枚举
	/// </summary>
	public enum FormState
	{
		/// <summary>
		///     正常
		/// </summary>
		Normal,

		/// <summary>
		///     新增
		/// </summary>
		New,

		/// <summary>
		///     修改
		/// </summary>
		Modify,

		/// <summary>
		///     复制
		/// </summary>
		Copy,

		/// <summary>
		///     只读(打开)
		/// </summary>
		ReadOnly
	}

	#endregion

	#region 存储过程保存状态

	/// <summary>
	///     存储过程保存状态
	/// </summary>
	public enum SaveState
	{
		/// <summary>
		///     新建保存
		/// </summary>
		Save_New,

		/// <summary>
		///     修改保存
		/// </summary>
		Save_Edit,

		/// <summary>
		///     不能保存
		/// </summary>
		Save_ReadOnly
	}

	#endregion

	#region 事件参数/委托

	/// <summary>
	/// 页面标题被改变事件参数
	/// </summary>
	public class PageTitleChangedArgs
	{
		public PageTitleChangedArgs(string newTitle)
		{
			NewTitle = newTitle;
		}

		/// <summary>
		/// 新的标题
		/// </summary>
		public string NewTitle { get; private set; }
	}

	/// <summary>
	/// 页面标题被改变事件处理器
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void PageTitleChangedEventHandler(object sender, PageTitleChangedArgs e);

	#endregion
}