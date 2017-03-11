using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DS.MSClient.UICommon;
using DS.MSClient.UICommon.CustomClass;
using DS.MSClient.UIControl;

namespace DS.MSClient.UIModule
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

		#region 检查权限

		/// <summary>
		///     检查权限
		/// </summary>
		/// <param name="EmployeeId">员工id</param>
		/// <param name="RightId">权限id</param>
		/// <returns></returns>
		public bool CheckPopdom(int EmployeeId, string RightId)
		{
			try
			{
				if (Program._employeeroleRight.Exists(m => m.RightID == RightId))
				{
					if (Program._employeeRight.Exists(m => m.Status == false && m.RightID == RightId))
					{
						return false;
					}
					return true;
				}
				if (Program._employeeRight.Exists(m => m.Status && m.RightID == RightId))
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				//日志记录
				return false;
			}
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
			this.ZoomOutFontSize();
		}

		#endregion

		#region 方法(线程操作)

		/// <summary>
		///     线程执行函数委托
		/// </summary>
		protected delegate void ThreadExcuteMethod();

		/// <summary>
		///     线程执行方法，不等待线程结束，线程结束后以非线程方式执行后续方法
		/// </summary>
		/// <param name="method">线程方法</param>
		/// <param name="nextMethod">后续非线程方法</param>
		/// <param name="showWaitLayer">是否显示等待层</param>
		/// <param name="control">需要遮罩的控件或窗体</param>
		/// <returns></returns>
		protected void ThreadExcuteNoLock(ThreadExcuteMethod method, ThreadExcuteMethod nextMethod = null,
			bool showWaitLayer = false, Control control = null)
		{
			TranslucentHelper tl = null;
			if (showWaitLayer)
			{
				if (control == null) control = this;
				tl = TranslucentHelper.GenerateAndShowTranslucentLayer(control, 127, true);
			}
			//定义线程，使用匿名Lambda匿名委托
			var thread = new Thread(() =>
			{
				try
				{
					//调用方法
					method();
				}
				catch (Exception ex)
				{
					//将线程异常信息放至父线程
					MsgBox.ShowError(ex);
				}
				finally
				{
					if (showWaitLayer && tl != null) tl.HideTranslucentLayer();
					if (nextMethod != null)
					{
						var invorker = new MethodInvoker(nextMethod);
						BeginInvoke(invorker);
					}
				}
			});
			//启动线程
			thread.Start();
			thread.IsBackground = true;
		}

		/// <summary>
		///     线程执行方法，不锁定事件，显示遮罩层
		/// </summary>
		/// <param name="method">线程方法</param>
		/// <param name="control">需要遮罩的控件或窗体</param>
		/// <param name="showError">是否显示错误信息</param>
		/// <returns></returns>
		protected bool ThreadExcute(ThreadExcuteMethod method, Control control = null, bool showError = true)
		{
			if (control == null) control = this;
			//线程异常信息
			Exception threadException = null;
			var tl = TranslucentHelper.GenerateAndShowTranslucentLayer(control, 127, true);
			//使用变量同步
			var isEnd = false;
			//定义线程，使用匿名Lambda匿名委托
			var thread = new Thread(() =>
			{
				try
				{
					//调用方法
					method();
				}
				catch (Exception ex)
				{
					//将线程异常信息放至父线程
					threadException = ex;
				}
				finally
				{
					//设置同步变量为终止状态
					isEnd = true;
				}
			});
			//启动线程
			thread.Start();
			thread.IsBackground = true;
			//主线程须等待子线程执行完毕后才能继续执行
			while (!isEnd)
			{
				Application.DoEvents();
			}
			tl.HideTranslucentLayer();
			if (threadException != null)
			{
				if (showError) MsgBox.ShowError(threadException);
				threadException = null;
				return false;
			}
			return true;
		}

		/// <summary>
		///     线程执行方法，不锁定事件，不显示遮罩层
		/// </summary>
		/// <param name="method">线程方法</param>
		/// <param name="showError">是否显示错误信息</param>
		/// <returns></returns>
		protected bool ThreadExcuteNoShade(ThreadExcuteMethod method, bool showError = true)
		{
			//线程异常信息
			Exception threadException = null;
			//使用变量同步
			var isEnd = false;
			//定义线程，使用匿名Lambda匿名委托
			var thread = new Thread(() =>
			{
				try
				{
					//调用方法
					method();
				}
				catch (Exception ex)
				{
					//将线程异常信息放至父线程
					threadException = ex;
				}
				finally
				{
					//设置同步变量为终止状态
					isEnd = true;
				}
			});
			//启动线程
			thread.Start();
			thread.IsBackground = true;
			//主线程须等待子线程执行完毕后才能继续执行
			while (!isEnd)
			{
				Application.DoEvents();
			}
			if (threadException != null)
			{
				if (showError) MsgBox.ShowError(threadException);
				threadException = null;
				return false;
			}
			return true;
		}

		/// <summary>
		///     线程执行方法，不做保护，不暂停主线程
		/// </summary>
		/// <param name="method">方法委托</param>
		/// <returns></returns>
		protected Thread ExcuteThread(ThreadExcuteMethod method)
		{
			var thread = new Thread(new ThreadStart(method));
			thread.Start();
			return thread;
		}

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