using System;
using System.Collections.Generic;
using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DS.MSClient;
using DS.Model;
using DS.MSClient.UICommon;

namespace HBClient
{
	public class MemberGridCreator : BaseGridCreator
	{
		private BackgroundWorker _currentWorker;
		//缓存的数据
        public readonly List<Student> DataList = new List<Student>();
		//过滤栏编辑控件
		private readonly RepositoryItemTextEdit _filterTextEdit;
		//当前数据控件
		private readonly GridControl _grid;

		/// <summary>
		///     构造函数
		/// </summary>
		public MemberGridCreator(GridControl gridctl)
		{
			_grid = gridctl;
			_filterTextEdit = new RepositoryItemTextEdit();
			((GridView) _grid.MainView).CustomRowCellEdit += GridCreator_CustomRowCellEdit;
			_filterTextEdit.EditValueChanged += filterTextEdit_EditValueChanged;
			((GridView) _grid.MainView).ColumnFilterChanged += GridCreator_ColumnFilterChanged;

			((GridView) _grid.MainView).CustomDrawCell += GridCreator_CustomDrawCell;
			//grid开始排序
			((GridView) _grid.MainView).StartSorting += GridCreator_StartSorting;
			//grid停止排序
			((GridView) _grid.MainView).EndSorting += GridCreator_EndSorting;
			_grid.DataSource = DataList;
		}

		/// <summary>
		///     获取前两页数据
		/// </summary>
		public void PrepareData()
		{
			DataList.Clear();
			PageNum = 0;
			PageSize = PageSize*2;
			GetData();
			PageSize = PageSize/2;
			if (PageSize < RowCount)
			{
				PageNum += 1;
			}
		}

		/// <summary>
		///     实时的加载数据函数
		/// </summary>
		/// <returns></returns>
		public void GetData()
		{
			try
			{
				IsUpdatingData = true;
                var data = GetDataEvent.Invoke(SearchFilter, PageSize, PageNum) as List<Student>;
				if (data != null) DataList.AddRange(data);
				if (_currentWorker == null) //防止数据导出时，界面字段有排序，频繁绘制grid时数据源变化引起空异常
				{
					_grid.RefreshDataSource();
				}
			}
			catch (Exception ex)
			{
				MsgBox.ShowError(ex);
			}
			finally
			{
				IsUpdatingData = false;
			}
		}

		/// <summary>
		///     为导出excel数据获取数据
		/// </summary>
		public void GetDataForExportExcel(BackgroundWorker worker, DoWorkEventArgs e)
		{
			_currentWorker = worker;
			IsGetExcelData = true;
			while (DataList.Count < RowCount)
			{
				worker.ReportProgress(DataList.Count); //返回进度条进度
				if (worker.CancellationPending)
				{
					e.Cancel = true;
					break;
				}
				PageNum++;
				GetData();
			}
			IsGetExcelData = false;
		}

		/// <summary>
		///     grid下拉事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GridCreator_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
		{
			try
			{
				if (IsGetExcelData || IsUpdatingData || IsGridSorting || _grid.MainView.RowCount > e.RowHandle + 1 ||
				    DataList.Count >= RowCount)
				{
					return;
				}

				PageNum++;
				GetData();
			}
			catch (Exception ee)
			{
				MsgBox.ShowError(ee);
			}
		}

		/// <summary>
		///     grid开始排序
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GridCreator_StartSorting(object sender, EventArgs e)
		{
			IsGridSorting = true;
		}

		/// <summary>
		///     grid停止排序
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GridCreator_EndSorting(object sender, EventArgs e)
		{
			if (!IsGetExcelData)
			{
				IsGridSorting = false;
			}
		}

		/// <summary>
		///     过滤行初始化编辑控件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GridCreator_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
		{
			if (e.RowHandle == GridControl.AutoFilterRowHandle)
				e.RepositoryItem = _filterTextEdit;
		}

		/// <summary>
		///     过滤条件变化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void filterTextEdit_EditValueChanged(object sender, EventArgs e)
		{
			IsFilterUpdate = true;
		}

		/// <summary>
		///     girdview过滤条件变化，禁用过滤
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GridCreator_ColumnFilterChanged(object sender, EventArgs e)
		{
			IsFilterUpdate = true;
			((GridView) _grid.MainView).ActiveFilterEnabled = false;
		}
	}
}