using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraReports;

namespace DS.MSClient.UICommon.PrintReport
{
	public interface IPrintReport : IReport
	{

		/// <summary>
		/// 填充数据
		/// </summary>
		void FillData();
	}
}
