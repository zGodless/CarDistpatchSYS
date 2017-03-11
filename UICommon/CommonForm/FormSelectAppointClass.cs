using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DS.Data;
using DS.Model;

namespace DS.MSClient.UICommon.CommonForm
{
	public partial class FormSelectAppointClass : FormDlgBase
	{
		#region 初始化

		public FormSelectAppointClass()
		{
			InitializeComponent();
			InitEvent();
		}

		private void InitEvent()
		{
			Load += FormSelectAppointClass_Load;
			Closed += FormSelectAppointClass_Closed;
			gvAppointClass.RowClick += gvAppointClass_RowClick;

			ButtonOK.Click += ButtonOK_Click;
			ButtonCancel.Click += ButtonCancel_Click;
		}

		#endregion

		#region 属性

		public List<AppointClass> DataList { get; set; }

		public List<int> FilterList { get; set; }

		public List<AppointClass> SeletedList { get; set; }

		private List<AppointClass> ShowList
		{
			get
			{
				if (DataList == null) return null;
				return FilterList == null
					? DataList
					: DataList.FindAll(m => !FilterList.Exists(n => n == m.AppointClassID));
			}
		}

		#endregion

		#region 方法

		#endregion

		#region 事件

		void FormSelectAppointClass_Load(object sender, EventArgs e)
		{
			DataList = new AppointClassDao().GetList();
			gcAppointClass.DataSource = ShowList;
			gcAppointClass.RefreshDataSource();
		}

		void FormSelectAppointClass_Closed(object sender, EventArgs e)
		{
			if (DialogResult != DialogResult.OK)
			{
				DialogResult = DialogResult.Cancel;
			}
		}

		void gvAppointClass_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
		{
			if (e.HitInfo.Column != null && e.HitInfo.Column.VisibleIndex == 0) return;
			gvAppointClass.InvertRowSelection(e.RowHandle);
		}

		void ButtonOK_Click(object sender, EventArgs e)
		{
			if (gvAppointClass.SelectedRowsCount == 0)
			{
				MsgBox.ShowInfo("请勾选预约大类");
				return;
			}
			SeletedList = new List<AppointClass>();
			foreach (var rowHandle in gvAppointClass.GetSelectedRows())
			{
				SeletedList.Add(gvAppointClass.GetRow(rowHandle) as AppointClass);
			}
			DialogResult = DialogResult.OK;
			Close();
		}

		void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion
	}
}
