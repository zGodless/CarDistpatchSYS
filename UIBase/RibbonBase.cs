using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DS.MSClient.UICommon;
using DS.MSClient.UIControl;

namespace DS.MSClient.UIBase
{
	public partial class RibbonBase : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		#region 初始化

		public RibbonBase()
		{
			InitializeComponent();
		}

		#endregion

		#region 方法(线程操作)

		/// <summary>
		/// 线程执行函数委托
		/// </summary>
		protected delegate void ThreadExcuteMethod();

		/// <summary>
		/// 线程执行方法，不等待线程结束，线程结束后以非线程方式执行后续方法
		/// </summary>
		/// <param name="method">线程方法</param>
		/// <param name="nextMethod">后续非线程方法</param>
		/// <returns></returns>
		protected void ThreadExcuteNoLock(ThreadExcuteMethod method, ThreadExcuteMethod nextMethod = null)
		{
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
		/// 线程执行方法，不锁定事件
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
		/// 线程执行方法，不做保护，不暂停主线程
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

		#region 方法(窗口操作)

		/// <summary>
		/// 查找窗口
		/// </summary>
		/// <param name="uniqueId">唯一ID</param>
		public static Form FindForm(string uniqueId)
		{
			var formList = Application.OpenForms.Cast<Form>().Where(form => form.Tag != null && form.Tag.ToString() == uniqueId).ToList();
			return formList.Any() ? formList[0] : null;
		}

		#endregion
	}
}