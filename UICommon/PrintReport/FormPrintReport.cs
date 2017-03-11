using System;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace DS.MSClient.UICommon.PrintReport
{
	public partial class FormPrintReport : FormBase
	{
		#region 初始化

		/// <summary>
		/// 构造打印报表窗体
		/// </summary>
		public FormPrintReport()
		{
			InitializeComponent();
			InitEvent();
		}

		/// <summary>
		/// 构造打印报表窗体
		/// </summary>
		public FormPrintReport(IPrintReport report, string moduleName, string formTitle = "")
			: this()
		{
			Report = report;
			ModuleName = moduleName;
			if (!string.IsNullOrEmpty(formTitle)) Text = formTitle;
		}

		/// <summary>
		/// 初始化事件
		/// </summary>
		private void InitEvent()
		{
			Shown += FormPrintDirectRecive_Shown;
		}

		#endregion

		#region 属性

		public IPrintReport Report { get; set; }

		public string ModuleName { get; set; }

		public sealed override string Text
		{
			get { return base.Text; }
			set { base.Text = value; }
		}

		#endregion

		#region 方法

		/// <summary>
		/// 加载报表
		/// </summary>
		private void LoadReport()
		{
			//icboTitle.EditValue = Report.DefaultTitle;
			Report.FillData();
			Invalidate();
			Update();
			printSystem.ClearContent();
			printControl.PrintingSystem = (PrintingSystemBase)Report.PrintingSystem;
			((XtraReport)Report).PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, CommandVisibility.None);
			Report.CreateDocument();
		}

        #endregion

        #region 事件

		/// <summary>
		/// 窗口显示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void FormPrintDirectRecive_Shown(object sender, EventArgs e)
		{
			LoadReport();
		}

        #endregion
	}
}
