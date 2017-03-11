using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DS.MSClient
{
	/// <summary>
	///     导出数据（excel）悬浮窗体
	/// </summary>
	public partial class FormExportData : XtraForm
	{
		#region 初始化

		public FormExportData(BackgroundWorker bw)
		{
			_bw = bw;
			InitializeComponent();
			InitEvent();
			Init();
		}

		/// <summary>
		///     初始化事件
		/// </summary>
		private void InitEvent()
		{
			//窗体加载
			Load += FormExportData_Load;

			//鼠标点下
			MouseDown += FormExportData_MouseDown;
			lbl_msg.MouseDown += FormExportData_MouseDown;
			progressBarControl1.MouseDown += FormExportData_MouseDown;
			//鼠标移动
			MouseMove += FormExportData_MouseMove;
			lbl_msg.MouseMove += FormExportData_MouseMove;
			progressBarControl1.MouseMove += FormExportData_MouseMove;
			//鼠标弹起
			MouseUp += FormExportData_MouseUp;
			lbl_msg.MouseUp += FormExportData_MouseUp;
			progressBarControl1.MouseUp += FormExportData_MouseUp;
			//取消下载
			btn_cancelDownLoad.Click += btn_cancelDownLoad_Click;
			// 窗体将要关闭
			FormClosing += FormExportData_FormClosing;
			//窗体关闭
			FormClosed += FormExportData_FormClosed;
			//进度条变化
			progressBarControl1.EditValueChanged += progressBarControl1_EditValueChanged;
		}

		private void Init()
		{
			BackColor = Color.WhiteSmoke;
			Opacity = 0.65;
			TopMost = true;
		}

		#endregion

		#region 属性

		private bool _formMove; //窗体是否移动
		private Point _formPoint; //记录窗体的位置
		private readonly BackgroundWorker _bw;
		public int TotalRowCount; //总记录数
		private string _loadedRowCount = "0"; //已下载记录数

		#endregion

		#region 事件

		private void FormExportData_Load(object sender, EventArgs e)
		{
			//设置悬浮窗体的透明度、初始位置及开启显示下载完成数
			Left = Screen.PrimaryScreen.WorkingArea.Width - 400;
			Top = 80;
			lbl_process.Text = _loadedRowCount + @"/" + TotalRowCount;
			Refresh();
			Application.DoEvents();
		}

		/// <summary>
		///     鼠标点下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormExportData_MouseDown(object sender, MouseEventArgs e)
		{
			_formPoint = new Point();
			//控制是否窗体可以随鼠标移动
			if (e.Button != MouseButtons.Left) return;
			Cursor.Current = Cursors.Hand;
			var xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
			var yOffset = -e.Y - SystemInformation.FrameBorderSize.Height;
			_formPoint = new Point(xOffset, yOffset);
			_formMove = true; //开始移动
		}

		/// <summary>
		///     鼠标移动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormExportData_MouseMove(object sender, MouseEventArgs e)
		{
			//窗体随鼠标移动
			if (!_formMove) return;
			var mousePos = MousePosition;
			mousePos.Offset(_formPoint.X, _formPoint.Y);
			Location = mousePos;
		}

		/// <summary>
		///     鼠标弹起
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormExportData_MouseUp(object sender, MouseEventArgs e)
		{
			//释放的是鼠标左键
			if (e.Button != MouseButtons.Left) return;
			Cursor.Current = Cursors.Default;
			_formMove = false; //停止移动
		}

		/// <summary>
		///     取消下载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_cancelDownLoad_Click(object sender, EventArgs e)
		{
			_bw.WorkerSupportsCancellation = true;
			_bw.CancelAsync(); //取消异步线程处理
			Close();
		}

		/// <summary>
		///     窗体关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormExportData_FormClosed(object sender, FormClosedEventArgs e)
		{
			Dispose();
		}


		/// <summary>
		///     窗体关闭前
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormExportData_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		/// <summary>
		///     进度条变化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void progressBarControl1_EditValueChanged(object sender, EventArgs e)
		{
			_loadedRowCount = progressBarControl1.EditValue != null ? progressBarControl1.EditValue.ToString() : "0";
			lbl_process.Text = _loadedRowCount + @"/" + TotalRowCount;
		}

		#endregion
	}
}