using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DS.MSClient.UICommon.MessageBox
{
	public partial class CustomMsgBox : XtraForm
	{
		#region 初始化

		/// <summary>
		///     构造函数
		/// </summary>
		public CustomMsgBox()
		{
			InitializeComponent();
			InitEvent();
			Init();
		}

		private void InitEvent()
		{
			//点击链接：详细信息
			linkLabel_details.LinkClicked += linkLabel_details_LinkClicked;
			//窗体加载
			Shown += FormCustomMessage_Load;
			//关闭窗体
			btn_close.Click += btn_close_Click;
			//复制详细信息
			btn_copy.Click += btn_copy_Click;
			//关闭窗体，释放
			FormClosed += FormCustomMessage_FormClosed;
			//界面放大缩小  
			btn_ZoomOut.Click += btn_ZoomIn_Click;
			btn_ZoomIn.Click += btn_ZoomIn_Click;
			//鼠标进入、退出（放大缩小按钮）
			btn_ZoomOut.MouseMove += btn_ZoomIn_MouseMove;
			btn_ZoomIn.MouseMove += btn_ZoomIn_MouseMove;
			btn_ZoomOut.MouseLeave += btn_ZoomIn_MouseLeave;
			btn_ZoomIn.MouseLeave += btn_ZoomIn_MouseLeave;
		}

		private void Init()
		{
			panelControl_details.Visible = false; //初始化不显示详细信息面板
			Height = panelControl_details.Visible ? 450 : 165;
		}

		#endregion

		#region 属性

		private static readonly string logBasePath = AppDomain.CurrentDomain.BaseDirectory + "Log"; //错误日志文件夹
		private static readonly string logPicBasePath = AppDomain.CurrentDomain.BaseDirectory + "Log\\Pic"; //错误日志截图文件夹
		private static readonly string logCatalogPath = logBasePath + "\\Catalog.log"; //错误日志目录路径
		public Exception currentException = null; //原错误消息异常
		private Bitmap image; //屏幕截图
		private string logContentPath = string.Empty; //错误日志详细内容文件路径
		public string msg = string.Empty; //传入的经过处理的错误消息

		/// <summary>
		///     错误日志详细内容文件路径
		/// </summary>
		public string LogContentPath
		{
			get { return logBasePath + "\\" + logContentPath + ".log"; //按传入的名称拼接路径（按月份存放）
			}
			set { logContentPath = value; }
		}

		#endregion

		#region 方法

		[DllImport("kernel32")]
		public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		/// <summary>
		///     写入ini文件
		/// </summary>
		/// <param name="server"></param>
		/// <param name="uid"></param>
		/// <param name="pwd"></param>
		/// <param name="database"></param>
		private void WriteIni(string session, string key, string keyValue, string path)
		{
			WritePrivateProfileString(session, key, keyValue, path);
		}

		/// <summary>
		///     写入文件
		/// </summary>
		/// <param name="str"></param>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static bool SaveStringToFile(string str, string fileName, bool isAppend)
		{
			try
			{
				if (!File.Exists(fileName))
				{
					File.Create(fileName).Close();
				}
				var sw = new StreamWriter(fileName, isAppend, Encoding.GetEncoding("gb2312"));
				sw.WriteLine(str);
				sw.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		///     截图
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		public void Snap(int x, int y, int width, int height)
		{
			try
			{
				image = new Bitmap(width, height);
				Graphics g = Graphics.FromImage(image);
				g.CopyFromScreen(x, y, 0, 0, new Size(width, height));
			}
			catch
			{
			}
		}

		#endregion

		#region 事件

		/// <summary>
		///     点击链接：详细信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void linkLabel_details_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				panelControl_details.Visible = !panelControl_details.Visible;
				Height = panelControl_details.Visible ? 450 : 165;
				Refresh();
				Application.DoEvents();
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		///     窗体加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormCustomMessage_Load(object sender, EventArgs e)
		{
			try
			{
				msg = msg.Replace("<br/>", "\r\n");
				if (msg.Length <= 26) //根据消息内容长度，调整消息窗口宽度
				{
					Width = 290;
				}
				else
				{
					Width = 320;
				}

				lbl_msg.Text = msg;


				if (currentException.StackTrace == null)
				{
					memoEdit_details.Text = currentException.Message;
				}
				else //显示跟踪具体位置,便于开发人员跟踪bug问题
				{
					if (currentException.InnerException == null)
					{
						memoEdit_details.Text = currentException.Message + "\r\n" + currentException.StackTrace;
					}
					else
					{
						memoEdit_details.Text = currentException.Message + "\r\n" + currentException.InnerException;
					}
				}
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		///     关闭窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_close_Click(object sender, EventArgs e)
		{
			try
			{
				Close();
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		///     复制详细信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_copy_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetDataObject(memoEdit_details.Text);
			}
			catch (Exception)
			{
				MsgBox.ShowInfo("内存不足，复制失败!");
			}
		}

		/// <summary>
		///     关闭窗体，释放
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormCustomMessage_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				//记录错误日志信息
				if (!Directory.Exists(logBasePath)) //如果当前存放错误日志目录不存在，则创建
				{
					Directory.CreateDirectory(logBasePath);
				}
				if (!Directory.Exists(logPicBasePath)) //如果当前存放错误日志截图目录不存在，则创建
				{
					Directory.CreateDirectory(logPicBasePath);
				}
				DateTime dt = DateTime.Now;
				string key = dt.ToString();

				string session = dt.Date.ToString("yyyy-MM-dd");
				string logCatelog = "[" + key + "]" + msg.Replace("\r", "").Replace("\n", ""); //日志目录
				string logContent = memoEdit_details.Text.Replace("\r", "").Replace("\n", ""); //日志内容，详细                 
				SaveStringToFile(logCatelog, logCatalogPath, true);
				LogContentPath = dt.ToString("yyyy-MM"); //日志内容文件以月份为单位，每个月的日志放到一个文件当中
				WriteIni(session, key, logContent, LogContentPath);
				//记录当时界面截图
                Snap(0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
				if (image != null)
				{
					string imageFileName = logPicBasePath + "\\" + dt.ToString("yyyy_MM_dd HH_mm_ss") + ".png";
					image.Save(imageFileName, ImageFormat.Png); //以当前时间为图片名称
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (image != null)
				{
					image.Dispose();
				}
				Dispose();
			}
		}

		/// <summary>
		///     放大缩小
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_ZoomIn_Click(object sender, EventArgs e)
		{
			try
			{
				int width = 0;
				if (sender == btn_ZoomIn) //缩小
				{
					width = -200;
				}
				else if (sender == btn_ZoomOut) //放大
				{
					width = 200;
				}
				Width += width;
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		///     鼠标进入
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_ZoomIn_MouseMove(object sender, MouseEventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.Hand;
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		///     鼠标退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_ZoomIn_MouseLeave(object sender, EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.Default;
			}
			catch (Exception)
			{
			}
		}

		#endregion
	}
}