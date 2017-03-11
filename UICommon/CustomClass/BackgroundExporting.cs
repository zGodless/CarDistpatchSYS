using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace DS.MSClient.UICommon
{
	public class BackgroundExporting
	{
		public delegate void RunFunction();

		//============================================================================ 
		public delegate void WithFormRunFuction(BackgroundWorker worker, DoWorkEventArgs e);

		private readonly BackgroundWorker _bw;
		private string _fileName = string.Empty;
		private FormExportData _formExportData; //导出数据悬浮窗体
		private readonly RunFunction _thisFunction;
		private readonly WithFormRunFuction _thisWithFormFunction;
		private readonly GridView _exportView;
		private readonly int _loadedRowCount;
		private readonly int _totalRowCount;

		/// <summary>
		///     不带悬浮窗体的数据导出
		/// </summary>
		/// <param name="newFunction"></param>
		/// <param name="gridView"></param>
		/// <param name="totalRowCount"></param>
		/// <param name="loadedRowCount"></param>
		public BackgroundExporting(RunFunction newFunction, GridView gridView, int totalRowCount, int loadedRowCount)
		{
			_totalRowCount = totalRowCount;
			_loadedRowCount = loadedRowCount;
			_exportView = gridView;
			_thisFunction = newFunction;
			_bw = new BackgroundWorker();
			//开始处理
			_bw.DoWork += Bw_DoWork;
			//处理完成
			_bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
		}

		/// <summary>
		///     带悬浮窗体的数据导出
		/// </summary>
		/// <param name="newFunction"></param>
		/// <param name="gridView"></param>
		/// <param name="totalRowCount"></param>
		/// <param name="loadedRowCount"></param>
		public BackgroundExporting(WithFormRunFuction newFunction, GridView gridView, int totalRowCount, int loadedRowCount)
		{
			_totalRowCount = totalRowCount;
			_loadedRowCount = loadedRowCount;
			_exportView = gridView;
			_thisWithFormFunction = newFunction;
			_bw = new BackgroundWorker
			{
				WorkerReportsProgress = true, //允许报告进度
				WorkerSupportsCancellation = true //允许中途取消
			};

			//开始处理
			_bw.DoWork += Bw_DoWork;
			//处理完成
			_bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
			//进度变化
			_bw.ProgressChanged += BW_ProgressChanged;
		}

		/// <summary>
		///     开始下载excel数据
		/// </summary>
		public void Start()
		{
			ExportData();
		}

		/// <summary>
		///     线程完成
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (_formExportData != null) //带悬浮窗体的，在下载结束或发生异常，关闭悬浮窗体
			{
				_formExportData.Close();
			}
			if (e.Error == null && !e.Cancelled) //未发生错误及未取消，则导出excel数据
			{
				_exportView.RefreshData();
				ExportToEx(_fileName);
			}
			else
			{
				_exportView.RefreshData(); //如果取消或出错，则刷新数据，以便下载的数据能显示在grid中
			}
		}

		/// <summary>
		///     线程开始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Bw_DoWork(object sender, DoWorkEventArgs e)
		{
			var worker = sender as BackgroundWorker;
			if (_thisFunction != null) //无悬浮窗体的
				_thisFunction();
			if (_thisWithFormFunction != null) //带有悬浮窗体的
			{
				_thisWithFormFunction(worker, e);
			}
			if (worker == null || worker.CancellationPending)
			{
				e.Cancel = true;
			}
		}

		private void BW_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			_formExportData.progressBarControl1.EditValue = e.ProgressPercentage;
		}

		/// <summary>
		///     导出数据
		/// </summary>
		private void ExportData()
		{
			const string exportFilter = "Microsoft Excel|*.xls|Microsoft Excel|*.xlsx";
			_fileName = ShowSaveFileDialog(exportFilter);
			if (_fileName == string.Empty) return;
			if (_totalRowCount > _loadedRowCount) //如果客户端一下载的数据少于总查询数据行，则还需后台异步线程去下载
			{
				var msg = new StringBuilder();
				msg.Append(string.Format("导出数据总计:{0}条,可能需要很长时间，将转入后台处理!", _totalRowCount));
				msg.Append("\r\n是否继续导出?");
				msg.Append("\r\n\r\n注:数据导出过程请不要关闭本页面，数据导出结束后,将自动");
				msg.Append("\r\n打开导出数据文件，若打开失败，请尝试手工打开文件!");
				if (_totalRowCount > 500 && MsgBox.ShowYesNo(msg.ToString()) != DialogResult.Yes)
				{
					return;
				}
				if (_thisWithFormFunction != null)
				{
					_formExportData = new FormExportData(_bw) {TotalRowCount = _totalRowCount};
					_formExportData.progressBarControl1.Properties.Maximum = _totalRowCount;
					_formExportData.Show();
				}
				_bw.RunWorkerAsync(_totalRowCount); //线程开始,并传入进度条最大值
			}
			else //如果数据已经下载完全，就可以直接导出excel数据了
			{
				ExportToEx(_fileName);
			}
		}

		/// <summary>
		///     显示保存对话框
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		private string ShowSaveFileDialog(string filter)
		{
			var dlg = new SaveFileDialog
			{
				FileName = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + "Book1"),
				Title = @"导出数据 ",
				Filter = filter
			};
			return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : "";
		}

		/// <summary>
		///     导出数据
		/// </summary>
		/// <param name="fileName"></param>
		private void ExportToEx(string fileName)
		{
			try
			{
				var ext = fileName.Substring(fileName.LastIndexOf(".", StringComparison.Ordinal) + 1);
				var currentCursor = Cursor.Current;
				Cursor.Current = Cursors.WaitCursor;
				_exportView.OptionsPrint.AutoWidth = false;
				_exportView.OptionsPrint.PrintDetails = true;
				_exportView.OptionsPrint.PrintFilterInfo = true;
				_exportView.OptionsPrint.PrintFooter = false;
				_exportView.OptionsPrint.PrintHeader = true;
				_exportView.OptionsPrint.PrintHorzLines = true;
				_exportView.OptionsPrint.PrintVertLines = true;
				_exportView.OptionsPrint.ShowPrintExportProgress = true;
				if (ext == "xls") _exportView.ExportToXls(fileName);
				if (ext == "xlsx") _exportView.ExportToXlsx(fileName);
				Cursor.Current = currentCursor;
				OpenFile(fileName);
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     打开文件
		/// </summary>
		/// <param name="fileName"></param>
		private void OpenFile(string fileName)
		{
			try
			{
				var process = new Process
				{
					StartInfo = {FileName = fileName, Verb = "Open", WindowStyle = ProcessWindowStyle.Normal}
				};
				process.Start();
			}
			catch
			{
				MsgBox.ShowWarn("无法打开导出的文件，请尝试手工打开!");
			}
		}
	}
}