using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting.Native;

namespace DS.MSClient.UICommon
{
	/// <summary>
	/// DEV表格控件排序帮助类
	/// 作者：Noly Oh
	/// 日期：2015-06-10
	/// </summary>
	public class DevGridSortHelper
	{
		/// <summary>
		/// 表格控件
		/// </summary>
		private readonly GridControl _gridControl;

		/// <summary>
		/// 表格视图
		/// </summary>
		private readonly GridView _gridView;

		/// <summary>
		/// 鼠标位置点
		/// </summary>
		private Point? _gvMousePoint = null;

		/// <summary>
		/// 数据重绑定委托
		/// </summary>
		public delegate void DataRebindDelegate();

		/// <summary>
		/// 数据重绑定触发器
		/// </summary>
		public DataRebindDelegate DataRebindTrigger { get; set; }

		/// <summary>
		/// 排序表别名
		/// </summary>
		public string SortTableAliasName { get; private set; }

		/// <summary>
		/// 排序字段名
		/// </summary>
		public string SortFieldName { get; private set; }

		/// <summary>
		/// 排序顺序
		/// </summary>
		public string SortOrder { get; private set; }

		/// <summary>
		/// 构造表格排序帮助类
		/// </summary>
		/// <param name="gridControl">表格控件</param>
		public DevGridSortHelper(GridControl gridControl)
		{
			_gridControl = gridControl;
			_gridView = _gridControl.MainView as GridView;
			SortOrder = SortFieldName = SortTableAliasName = "";
			InitEvent();
		}

		/// <summary>
		/// 初始化事件
		/// </summary>
		private void InitEvent()
		{
			//自定义排序
			_gridView.CustomColumnSort += gvRecRej_CustomColumnSort;
			_gridView.MouseDown += gvRecRej_MouseDown;
			_gridView.MouseUp += gvRecRej_MouseUp;
		}

		/// <summary>
		/// 清除排序
		/// </summary>
		/// <param name="reload">重载数据</param>
		public void ClearSort(bool reload = false)
		{
			SortOrder = SortFieldName = SortTableAliasName = "";
			if (_gridView.SortedColumns.Count == 0) return;
			_gridView.ClearSorting();
			if (reload && DataRebindTrigger != null)
			{
				DataRebindTrigger();
			}
		}

		/// <summary>
		/// 自定义排序
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gvRecRej_CustomColumnSort(object sender, CustomColumnSortEventArgs e)
		{
			if (e.Value1 == e.Value2) return;
			e.Handled = true;
			switch (e.SortOrder)
			{
				case ColumnSortOrder.Ascending:
					e.Result = -1;
					break;
				case ColumnSortOrder.Descending:
					e.Result = 1;
					break;
			}
		}

		/// <summary>
		/// 鼠标按下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gvRecRej_MouseDown(object sender, MouseEventArgs e)
		{
			_gvMousePoint = e.Button != MouseButtons.Left && e.Clicks > 1 ? (Point?) null : e.Location;
		}

		/// <summary>
		/// 鼠标放开
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gvRecRej_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left && e.Clicks > 1) return;
			if (_gvMousePoint != e.Location) return;
			_gvMousePoint = null;
			var hitInfo = _gridView.CalcHitInfo(e.X, e.Y);
			var column = hitInfo.Column;
			if (!hitInfo.InColumn || column.FieldName == "Choose") return;
			if (column.OptionsColumn.AllowSort == DefaultBoolean.False) return;
			_gridControl.DataSource = null;
			var sortOrder = column.SortOrder != ColumnSortOrder.Ascending
				? ColumnSortOrder.Ascending
				: ColumnSortOrder.Descending;
			_gridView.ClearSorting();
			column.SortOrder = sortOrder;
			SortTableAliasName = (string)column.Tag;
			SortFieldName = column.FieldName;
			SortOrder = sortOrder == ColumnSortOrder.Ascending
				? "asc"
				: "desc";
			if (DataRebindTrigger != null)
			{
				DataRebindTrigger();
			}
		}
	}
}
