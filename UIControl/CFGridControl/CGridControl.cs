using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DS.MSClient.Controls;
using DS.MSClient.Properties;
using QuickFrame.Common.Configuration;

namespace DS.MSClient.UIControl
{
	/// <summary>
	///     自定义GridControl控件
	///     1、增加加载、保存grid样式方法
	/// </summary>
	[DesignerCategory("")]
	[ToolboxItem(true)]
	public class CGridControl : GridControl
	{
		public CGridControl() : base() { }
		/// <summary>
		///     显示自定义显示行高按钮
		/// </summary>
		[Browsable(true)]
		[Description("显示grid左侧底部行高切换按钮(包括插入、追加、删除和取消)"), Category("自定义属性"), DefaultValue("true")]
		public bool ShowCustomRowHeightButton
		{
			get { return _showCustomRowHeightButton; }
			set { _showCustomRowHeightButton = value; }
		}


		/// <summary>
		///     显示立即下载菜单项
		/// </summary>
		[Browsable(true)]
		[Description("显示立即下载菜单项"), Category("自定义属性"), DefaultValue("true")]
		public bool ShowImmediatelyDownLoadMenu
		{
			get { return _showImmediatelyDownLoadMenu; }
			set { _showImmediatelyDownLoadMenu = value; }
		}

		protected override void RegisterAvailableViewsCore(InfoCollection collection)
		{
			base.RegisterAvailableViewsCore(collection);
			collection.Add(new CGridViewInfoRegistrator());
		}

		#region 自定义按钮、菜单相关属性设置、方法

		private NavigatorCustomButton _btnInsert;
		private NavigatorCustomButton _btnAdd;
		private NavigatorCustomButton _btnDelete;
		private NavigatorCustomButton _btnCancel;
		private NavigatorCustomButton _btnRowHeight;


		private bool _showCustomRowHeightButton = true;
		private bool _showCustomHeaderMenu = true;
		private bool _showImmediatelyDownLoadMenu = true;

		/// <summary>
		///     显示自定义栏左上头部菜单
		/// </summary>
		[Browsable(true)]
		[Description("显示自定义左侧头部菜单"), Category("自定义属性"), DefaultValue("false")]
		public bool ShowCustomHeaderMenu
		{
			get { return _showCustomHeaderMenu; }
			set { _showCustomHeaderMenu = value; }
		}

		/// <summary>
		///     显示自定义导航栏按钮
		/// </summary>
		[Browsable(true)]
		[Description("显示grid左侧底部自定义导航按钮(包括插入、追加、删除和取消)"), Category("自定义属性"), DefaultValue("false")]
		public bool ShowCustomNavigationButtons { get; set; }

		/// <summary>
		///     设置自定义grid数据导航按钮是否可用
		/// </summary>
		/// <param name="insertButtonEnabled">插入按钮是否可用</param>
		/// <param name="addButtonEnabled">追加按钮是否可用</param>
		/// <param name="deleteButtonEnabled">删除按钮是否可用</param>
		/// <param name="cancelButtonEnabled">取消按钮是否可用</param>
		public void SetCustomNavicationButtonEnabled(bool insertButtonEnabled, bool addButtonEnabled, bool deleteButtonEnabled,
			bool cancelButtonEnabled)
		{
			if (_btnInsert != null) _btnInsert.Enabled = insertButtonEnabled;
			if (_btnAdd != null) _btnAdd.Enabled = addButtonEnabled;
			if (_btnDelete != null) _btnDelete.Enabled = deleteButtonEnabled;
			if (_btnCancel != null) _btnCancel.Enabled = cancelButtonEnabled;
		}

		/// <summary>
		///     设置自定义grid数据导航插入和追加按钮是否可用
		/// </summary>
		/// <param name="enabled"></param>
		public void SetCustomNavicationInsert_AddButtonEnabled(bool enabled)
		{
			if (_btnInsert != null) _btnInsert.Enabled = enabled;
			if (_btnAdd != null) _btnAdd.Enabled = enabled;
		}

		/// <summary>
		///     设置自定义grid数据导航取消按钮是否可用
		/// </summary>
		/// <param name="enabled"></param>
		public void SetCustomNavicationCancelButtonEnabled(bool enabled)
		{
			if (_btnCancel != null) _btnCancel.Enabled = enabled;
		}

		/// <summary>
		///     设置自定义grid数据导航删除按钮是否可用
		/// </summary>
		/// <param name="enabled"></param>
		public void SetCustomNavicationDeleteButtonEnabled(bool enabled)
		{
			if (_btnDelete != null) _btnDelete.Enabled = enabled;
		}

		#endregion

		#region 加载和保存界面grid风格

		/// <summary>
		///     打开后立即下载
		/// </summary>
		public bool ImmediatelyDownLoad { get; set; }

		private bool _stylesave; //是否已经保存界风格
		private string _strPath = string.Empty; //路径
		private readonly string _stylePath = "Style"; //style路径
		private string _moduleName = string.Empty; //模块名称
		private string _layoutXmlName = string.Empty; //布局xml文件名称
		private string _rowNumberName = string.Empty; //用于保存行号状态
		private string _immediatelyDownloadName = string.Empty; //用于保存立即下载状态

		private int _totalRecordCount; //当前数据集记录数,用于判断是否启用列排序的数据库查询
		private int _pageSize = 100; //当前页面的分页记录数

		//----高级菜单相关
		protected PopupMenu PopupMenuMain;
		protected BarManager BarManagerMain;
		private BarButtonItem _pbarbtnColumnConfig;
		private BarButtonItem _pbarbtnAdvanceSearch;
		private BarButtonItem _pbarbtnRowHeight;
		private BarCheckItem _pbarbtnRowNumber; //行号
		private BarCheckItem _pbarbtnImmediatelyDownload; //打开后立即下载数据
		private ItemClickEventHandler _advanceSearchItemClick;

		public delegate void DelegateCustomMethod(); //自定义方法

		public delegate int DelegateCustomGetMethod(); //自定义方法

		public delegate void DelegateCustomCallMethod(string operateType); //自定义方法

		//公共变量,存放要拖拽的对象
		private GridHitInfo _downHitInfo;
		private DXMouseEventArgs _oldargs;

		/// <summary>
		///     高级查询方法
		/// </summary>
		public DelegateCustomMethod AdvanceSearchMethod { get; set; }

		/// <summary>
		///     分页字段排序查询方法
		/// </summary>
		public DelegateCustomMethod PageSortOrderSearchMethod { get; set; }

		/// <summary>
		///     获取每页条数方法
		/// </summary>
		public DelegateCustomGetMethod GetPageSizeMethod { get; set; }

		/// <summary>
		///     获取总记录数方法
		/// </summary>
		public DelegateCustomGetMethod GetTotalRecordCountMethod { get; set; }

		/// <summary>
		///     调用自定义grid导航按钮（插入、追加、删除、取消）点击事件,对应参数:insert,add,delete,cancel
		/// </summary>
		public DelegateCustomCallMethod CallCustomNavicationButtonClick { get; set; }

		/// <summary>
		///     加载和保存界面grid风格
		///     1、包含菜单项：高级查询、列配置、行号、行高
		///     2、包含高级查询
		/// </summary>
		/// <param name="barManager">barManager</param>
		/// <param name="moduleName">模块名称</param>
		/// <param name="advanceSearchItemClick">高级查询按钮事件</param>
		public void LoadGridLayout(BarManager barManager, string moduleName, ItemClickEventHandler advanceSearchItemClick)
		{
			RegisterAdvanceSearch(advanceSearchItemClick);
			LoadGridLayout(barManager, moduleName);
		}

		/// <summary>
		///     加载和保存界面grid风格
		///     1、包含菜单项：高级查询、列配置、行号、行高
		///     2、包含高级查询
		///     3、包含分页字段排序查询方法
		/// </summary>
		/// <param name="barManager">barManager</param>
		/// <param name="moduleName">模块名称</param>
		/// <param name="advanceSearchMethod"></param>
		/// <param name="pageSortOrderSearchMethod">分页字段排序查询委托事件</param>
		/// <param name="getPageSizeMethod">每页记录数委托事件</param>
		/// <param name="getTotalRecordCountMethod">总记录数委托事件</param>
		public void LoadGridLayout(BarManager barManager, string moduleName, DelegateCustomMethod advanceSearchMethod,
			DelegateCustomMethod pageSortOrderSearchMethod, DelegateCustomGetMethod getPageSizeMethod,
			DelegateCustomGetMethod getTotalRecordCountMethod)
		{
			GetPageSizeMethod = getPageSizeMethod;
			GetTotalRecordCountMethod = getTotalRecordCountMethod;
			_pageSize = GetPageSizeMethod();
			RegisterAdvanceSearch(advanceSearchMethod, pageSortOrderSearchMethod);
			LoadGridLayout(barManager, moduleName);
		}

		/// <summary>
		///     加载和保存界面grid风格
		///     1、包含菜单项：高级查询、列配置、行号、行高
		///     2、包含分页字段排序查询方法(不包含高级查询)
		/// </summary>
		/// <param name="barManager">barManager</param>
		/// <param name="moduleName">模块名称</param>
		/// <param name="pageSortOrderSearchMethod">分页字段排序查询委托事件</param>
		/// <param name="getPageSizeMethod">每页记录数</param>
		/// <param name="getTotalRecordCountMethod">总记录数</param>
		public void LoadGridLayout(BarManager barManager, string moduleName, DelegateCustomMethod pageSortOrderSearchMethod,
			DelegateCustomGetMethod getPageSizeMethod, DelegateCustomGetMethod getTotalRecordCountMethod)
		{
			GetPageSizeMethod = getPageSizeMethod;
			GetTotalRecordCountMethod = getTotalRecordCountMethod;
			RegisterAdvanceSearch(null, pageSortOrderSearchMethod);
			LoadGridLayout(barManager, moduleName);
		}

		/// <summary>
		///     加载和保存界面grid风格
		///     1、包含菜单项：高级查询、列配置、行号、行高
		///     2、包含高级查询方法
		/// </summary>
		/// <param name="barManager">barManager</param>
		/// <param name="moduleName">模块名称</param>
		/// <param name="advanceSearchMethod">高级查询委托事件</param>
		public void LoadGridLayout(BarManager barManager, string moduleName, DelegateCustomMethod advanceSearchMethod)
		{
			RegisterAdvanceSearch(advanceSearchMethod, null);
			LoadGridLayout(barManager, moduleName);
		}

		/// <summary>
		///     加载和保存界面grid风格
		///     1、包含菜单项：列配置、行号、行高，无高级查询选项
		///     2、不包含分页字段排序查询
		/// </summary>
		/// <param name="barManager">barManager</param>
		/// <param name="moduleName">模块名称</param>
		public void LoadGridLayout(BarManager barManager, string moduleName)
		{
			try
			{
				_moduleName = moduleName;
				_layoutXmlName = MainView.Name + ".xml"; // layoutXMLName;
				_strPath = AppDomain.CurrentDomain.BaseDirectory + _stylePath + "\\" + Program.CurrentEmployee.EmployeeCode;
				_rowNumberName = Program.CurrentEmployee.EmployeeCode + "_" + moduleName + "_" + _layoutXmlName;
				_immediatelyDownloadName = Program.CurrentEmployee.EmployeeCode + "_" + moduleName + "_" + _layoutXmlName;
				//加载界面grid风格
				if (LayOutIsAlive(@"\" + moduleName + "\\" + _layoutXmlName)) //如果有grid样式，则加载
				{
					MainView.RestoreLayoutFromXml(_strPath + @"\" + moduleName + "\\" + _layoutXmlName, OptionsLayoutBase.FullLayout);
					//取出所有gridview样式信息
				}
				else if (!LayOutIsAlive(@"\" + moduleName + "\\" + "Default_" + _layoutXmlName)) //保存默认gridview样式，用于还原
				{
					try
					{
						if (!Directory.Exists(_strPath + @"\" + _moduleName))
						{
							Directory.CreateDirectory(_strPath + @"\" + _moduleName);
						}
						MainView.SaveLayoutToXml(_strPath + @"\" + _moduleName + "\\Default_" + _layoutXmlName,
							OptionsLayoutBase.FullLayout); //保存所有信息
					}
					catch
					{
						// ignored
					}
				}

				//注册离开界面保存grid风格事件，行号状态
				ControlRemoved += gc_ControlRemoved;
				LoadGridHeaderMenu(barManager);

				if (ShowCustomNavigationButtons || ShowCustomRowHeightButton)
				{
					var imageList1 = new ImageList {ImageSize = new Size(36, 16)};

					imageList1.Images.Add(Resources.grid_insert);
					imageList1.Images.Add(Resources.grid_add);
					imageList1.Images.Add(Resources.grid_delete);
					imageList1.Images.Add(Resources.grid_cancel);
					imageList1.Images.Add(Resources.grid_rowHeight);
					UseEmbeddedNavigator = true;
					EmbeddedNavigator.Buttons.ImageList = imageList1;
					//禁用自带按钮
					EmbeddedNavigator.Buttons.Append.Visible = false; //新增
					EmbeddedNavigator.Buttons.CancelEdit.Visible = false; //取消编辑
					EmbeddedNavigator.Buttons.EndEdit.Visible = false; //结束编辑
					EmbeddedNavigator.Buttons.Prev.Visible = false; //上一条
					EmbeddedNavigator.Buttons.PrevPage.Visible = false; //上一页
					EmbeddedNavigator.Buttons.Next.Visible = false; //下一条
					EmbeddedNavigator.Buttons.NextPage.Visible = false; //下一页
					EmbeddedNavigator.Buttons.First.Visible = false; //第一条
					EmbeddedNavigator.Buttons.Last.Visible = false; //最后一条
					EmbeddedNavigator.Buttons.Edit.Visible = false; //编辑
					EmbeddedNavigator.Buttons.Remove.Visible = false; //删除
					EmbeddedNavigator.TextLocation = NavigatorButtonsTextLocation.End;
					EmbeddedNavigator.Text = string.Empty;
					EmbeddedNavigator.TextStringFormat = string.Empty;
					EmbeddedNavigator.ButtonClick += gridControl_EmbeddedNavigator_ButtonClick;
				}
				if (ShowCustomNavigationButtons)
				{
					_btnInsert = new NavigatorCustomButton();
					_btnInsert = EmbeddedNavigator.Buttons.CustomButtons.Add();
					_btnInsert.Tag = "insert";
					//btn_insert.Hint = "插入";
					_btnInsert.ImageIndex = 0;

					_btnAdd = new NavigatorCustomButton();
					_btnAdd = EmbeddedNavigator.Buttons.CustomButtons.Add();
					_btnAdd.Tag = "add";
					// btn_add.Hint = "追加";
					_btnAdd.ImageIndex = 1;

					_btnDelete = new NavigatorCustomButton();
					_btnDelete = EmbeddedNavigator.Buttons.CustomButtons.Add();
					_btnDelete.Tag = "delete";
					//btn_delete.Hint = "删除";
					_btnDelete.ImageIndex = 2;

					_btnCancel = new NavigatorCustomButton();
					_btnCancel = EmbeddedNavigator.Buttons.CustomButtons.Add();
					_btnCancel.Tag = "cancel";
					//btn_cancel.Hint = "取消";
					_btnCancel.ImageIndex = 3;
				}
				if (ShowCustomRowHeightButton)
				{
					var btnRowHeight = EmbeddedNavigator.Buttons.CustomButtons.Add();
					btnRowHeight.Tag = "rowHeight";
					// btnRowHeight.Hint = "行高";
					btnRowHeight.ImageIndex = 4;
				}
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		/// 保存样式
		/// </summary>
		public void SaveStyle()
		{
			try
			{
				if (!_stylesave)
				{
					if (!Directory.Exists(_strPath + @"\" + _moduleName))
					{
						Directory.CreateDirectory(_strPath + @"\" + _moduleName);
					}
					MainView.SaveLayoutToXml(_strPath + @"\" + _moduleName + "\\" + _layoutXmlName, OptionsLayoutBase.FullLayout);
					//保存所有信息
					//保存行号状态 
					Ini.WriteItem("GridRowNumber", _rowNumberName, _pbarbtnRowNumber.Checked.ToString());
					//保存是否立即下载状态
					Ini.WriteItem("ImmediatelyDownload", _immediatelyDownloadName, _pbarbtnImmediatelyDownload.Checked.ToString());
					_stylesave = true;
				}
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     grid按钮click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridControl_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
		{
			try
			{
				var button = e.Button as NavigatorCustomButton;
				if (button == null) return;
				var btn = button;
				if (btn.Tag != null)
				{
					if (btn.Tag.ToString() == "rowHeight")
					{
						var gridView = MainView as GridView;
						if (gridView == null) return;
						gridView.RowHeight = gridView.RowHeight == -1 ? 35 : -1;
					}
					else
					{
						if (CallCustomNavicationButtonClick != null)
						{
							CallCustomNavicationButtonClick(btn.Tag.ToString());
						}
					}
				}
				e.Handled = true;
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     判断对应风格文件是否存在
		/// </summary>
		/// <param name="layOutName"></param>
		private bool LayOutIsAlive(string layOutName)
		{
			var strPath = _strPath;
			if (!Directory.Exists(strPath))
			{
				Directory.CreateDirectory(strPath);
			}
			//配置文件的完整路径
			strPath += @"\" + layOutName;

			if (File.Exists(strPath))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		///     保存界面风格
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gc_ControlRemoved(object sender, ControlEventArgs e)
		{
			SaveStyle();
		}

		#endregion

		#region 加载grid头部左侧菜单

		/// <summary>
		///     注册高级查询按钮事件
		/// </summary>
		/// <param name="itemClick"></param>
		private void RegisterAdvanceSearch(ItemClickEventHandler itemClick)
		{
			_advanceSearchItemClick = itemClick;
		}

		/// <summary>
		///     注册高级查询按钮事件
		/// </summary>
		/// <param name="advanceSearchMethod"></param>
		/// <param name="pageSortOrderSearchMethod"></param>
		private void RegisterAdvanceSearch(DelegateCustomMethod advanceSearchMethod,
			DelegateCustomMethod pageSortOrderSearchMethod)
		{
			AdvanceSearchMethod = advanceSearchMethod;
			PageSortOrderSearchMethod = pageSortOrderSearchMethod;

			CloseLocalSort();
		}

		private void CloseLocalSort()
		{
			var gv = Views[0] as GridView;
			if (gv == null) return;
			foreach (GridColumn column in gv.Columns)
			{
				if (column.SortMode != ColumnSortMode.Custom) column.SortMode = ColumnSortMode.Custom;
			}
			gv.CustomColumnSort += (s, e) =>
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
			};
		}

		/// <summary>
		///     加载头部左侧菜单
		/// </summary>
		private void LoadGridHeaderMenu(BarManager barManager)
		{
			if (!ShowCustomHeaderMenu) return;
			BarManagerMain = barManager;
			var gridView = MainView as GridView;
			if (gridView == null) return;
			gridView.FixedLineWidth = 2;
			//gridView.Appearance.FixedLine.BackColor = Color.PaleVioletRed;


			gridView.CustomDrawRowIndicator += gridView_CustomDrawRowIndicator;
			gridView.Click += gridView_Click; //单击gridview
			gridView.DragObjectStart += gridView_DragObjectStart; //开始拖拽grid列头,用于处理拖拽动态生成冻结列
			gridView.DragObjectDrop += gridView_DragObjectDrop; //停止拖拽grid列头，用于处理拖拽动态生成冻结列
			gridView.MouseDown += gridView_MouseDown;
			//初始化菜单 
			PopupMenuMain = new PopupMenu();
			_pbarbtnColumnConfig = new BarButtonItem
			{
				Caption = @"列数",
				Id = 0,
				Name = "pbarbtn_ColumnConfig"
			};

			_pbarbtnAdvanceSearch = new BarButtonItem
			{
				Caption = @"高级查询",
				Id = 2,
				Name = "pbarbtn_AdvanceSearch",
				Visibility = _advanceSearchItemClick == null && AdvanceSearchMethod == null
					? BarItemVisibility.Never
					: BarItemVisibility.Always
			};

			_pbarbtnRowNumber = new BarCheckItem
			{
				Caption = @"行号",
				Id = 3,
				Name = "pbarbtn_RowHeight"
			};


			_pbarbtnRowHeight = new BarButtonItem
			{
				Caption = @"行高",
				Id = 4,
				Name = "pbarbtn_RowHeight"
			};

			_pbarbtnImmediatelyDownload = new BarCheckItem
			{
				Caption = @"打开后立即下载",
				Id = 5,
				Name = "pbarbtn_ImmediatelyDownload",
				Visibility = ShowImmediatelyDownLoadMenu
					? BarItemVisibility.Always
					: BarItemVisibility.Never
			};

			_pbarbtnColumnConfig.ItemClick += pbarbtn_ItemClick;
			_pbarbtnAdvanceSearch.ItemClick += pbarbtn_ItemClick;
			_pbarbtnRowHeight.ItemClick += pbarbtn_ItemClick;
			_pbarbtnRowNumber.ItemClick += pbarbtn_ItemClick;
			_pbarbtnImmediatelyDownload.ItemClick += pbarbtn_ItemClick;

			PopupMenuMain.LinksPersistInfo.AddRange(new[]
			{
				new LinkPersistInfo(_pbarbtnAdvanceSearch),
				new LinkPersistInfo(_pbarbtnColumnConfig, true),
				new LinkPersistInfo(_pbarbtnRowNumber),
				new LinkPersistInfo(_pbarbtnRowHeight),
				new LinkPersistInfo(_pbarbtnImmediatelyDownload, true)
			});
			PopupMenuMain.Manager = BarManagerMain;
			PopupMenuMain.Name = "popupMenu_Main";
			//加载行号
			var rowNumberChecked = Ini.ReadItem("GridRowNumber", _rowNumberName);
			_pbarbtnRowNumber.Checked = !string.IsNullOrEmpty(rowNumberChecked) && Convert.ToBoolean(rowNumberChecked);
			gridView.IndicatorWidth = _pbarbtnRowNumber.Checked ? 35 : 20; //行号列宽
			//打开后是否立即下载
			var immediatelyDownload = Ini.ReadItem("ImmediatelyDownload", _immediatelyDownloadName);
			_pbarbtnImmediatelyDownload.Checked = !string.IsNullOrEmpty(immediatelyDownload) && Convert.ToBoolean(immediatelyDownload);
			ImmediatelyDownLoad = _pbarbtnImmediatelyDownload.Checked;
		}

		//鼠标按下事件
		private void gridView_MouseDown(object sender, MouseEventArgs e)
		{
			var view = sender as GridView;
			if (view == null) return;
			_downHitInfo = null;
			var hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
			if (ModifierKeys != Keys.None) return;
			if (e.Button == MouseButtons.Left && hitInfo.InColumnPanel)
			{
				_downHitInfo = hitInfo;
				_oldargs = e as DXMouseEventArgs;
			}
		}

		/// <summary>
		///     绘制RowIndicator,添加查询按钮、立即下载按钮图片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
		{
			try
			{
				if (e.Info.IsRowIndicator) //如果是RowIndicator列
				{
					if (e.RowHandle >= 0 && _pbarbtnRowNumber.Checked) //行号
					{
						e.Info.DisplayText = (e.RowHandle + 1).ToString();
					}
					//else if (e.RowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)//如果是过滤栏
					//{

					//    e.Info.ImageIndex = -1;
					//    e.Painter.DrawObject(e.Info);
					//    Rectangle r = e.Bounds;
					//    r.Inflate(-1, -1);
					//    int x = r.X + (r.Width - 16) / 2;//imageList1.ImageSize.Width=16
					//    int y = r.Y + (r.Height - 16) / 2;
					//    e.Graphics.DrawImageUnscaled(Client.Controls.StaticImageList.Instance.ImageList_global.Images[1], x, y);//立即下载按钮图片

					//    e.Handled = true;

					//}
				}
				else //标题栏最左边的RowIndicator列
				{
					e.Info.ImageIndex = -1;
					e.Painter.DrawObject(e.Info);
					var r = e.Bounds;
					r.Inflate(-1, -1);
					var x = r.X + (r.Width - 16)/2;

					var y = r.Y + (r.Height - 16)/2;
					e.Graphics.DrawImageUnscaled(StaticImageList.Instance.ImageList_global.Images[19], x, y); //RowIndicator列头部查询按钮图片
					e.Handled = true;
				}
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     单击gridview，弹出菜单
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView_Click(object sender, EventArgs e)
		{
			try
			{
				var gridView = sender as GridView;
				if (gridView == null) return;
				Cursor.Current = Cursors.WaitCursor;
				var args = e as DXMouseEventArgs;
				if (args == null) return;
				var hitInfo = gridView.CalcHitInfo(args.Location);
				if (hitInfo != null)
				{
					if (!hitInfo.InGroupPanel)
					{
						if (!hitInfo.InColumn) //点击放大镜图标，调出菜单
						{
							if (hitInfo.HitTest.ToString() == "ColumnButton")
							{
								PopupMenuMain.ShowPopup(Cursor.Position);
								//this.popupMenu_Main.ShowPopup(this.barManager_Main, Cursor.Position); //调出菜单 
							}
						}
						else if (hitInfo.InColumn) //封装排序
						{
							if (hitInfo.HitTest.ToString() == "Column" && hitInfo.Column != null)
							{
								if (PageSortOrderSearchMethod == null || GetPageSizeMethod == null || GetTotalRecordCountMethod == null)
									return; //未传入分页字段排序查询方法
								_totalRecordCount = GetTotalRecordCountMethod();
								if (gridView.DataRowCount == 0 || _totalRecordCount == 0) return; //如果没有记录数，则不需要排序

								_pageSize = GetPageSizeMethod();
								//if (_pageSize >= _totalRecordCount) return; //如果总记录数小于每页记录数，则只需要本地排序记录，没有必要到数据库查询
								if (hitInfo.Column.FieldName == "Choose") return; //选择列排除      
								var order = hitInfo.Column.SortOrder; //记住排序

								if (_downHitInfo != null)
								{
									if (_downHitInfo.Column.FieldName != hitInfo.Column.FieldName) //如果列进行扩大，鼠标按下时候的列信息和鼠标释放的列信息不同进行处理
									{
										return;
									}
									else
									{
										if (_oldargs != null)
										{
											if (args.Location.Y - _oldargs.Location.Y > 0.1) //如果列进行缩小，鼠标按下时候的列信息相同利用不同的鼠标位置处理
											{
												return;
											}
											else
											{
												if (args.Location.X != _oldargs.Location.X)
												{
													return;
												}
											}
										}
									}
								}

								//排序取反
								if (order == ColumnSortOrder.None)
								{
									order = ColumnSortOrder.Ascending;
								}
								else if (order == ColumnSortOrder.Ascending)
								{
									order = ColumnSortOrder.Descending;
								}
								else if (order == ColumnSortOrder.Descending)
								{
									order = ColumnSortOrder.Ascending;
								}
								foreach (GridColumn col in gridView.Columns)
								{
									col.SortOrder = ColumnSortOrder.None; //清除所有列的排序 
								}
								hitInfo.Column.SortOrder = order; //设置当前点击列排序
								PageSortOrderSearchMethod(); //调用分页字段排序查询                            
							}
						}
					}
				}
			}
			catch
			{
				// ignored
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}


		/// <summary>
		///     菜单单击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pbarbtn_ItemClick(object sender, ItemClickEventArgs e)
		{
			try
			{
				if (e.Item == _pbarbtnAdvanceSearch) //高级查询
				{
					if (_advanceSearchItemClick != null)
					{
						_advanceSearchItemClick(sender, e);
					}
					else
					{
						AdvanceSearchMethod();
					}
				}
				else if (e.Item == _pbarbtnColumnConfig) //列配置
				{
					var gridView = MainView as GridView;
					var form = new FormColumnConfig
					{
						gv_current = gridView,
						defaultLayoutXMLName = _strPath + "\\" + _moduleName + "\\Default_" + _layoutXmlName
					};
					if (form.ShowDialog(this) == DialogResult.OK)
					{
						Application.DoEvents();
					}
				}
				else if (e.Item == _pbarbtnRowNumber) //行号
				{
					var gridView = MainView as GridView;
					if (gridView == null) return;
					gridView.IndicatorWidth = _pbarbtnRowNumber.Checked ? 35 : 20;
				}
				else if (e.Item == _pbarbtnRowHeight) //行高
				{
					var gridView = MainView as GridView;
					if (gridView == null) return;
					gridView.RowHeight = gridView.RowHeight == -1 ? 35 : -1;
				}
				else if (e.Item == _pbarbtnImmediatelyDownload) //打开后立即下载
				{
					ImmediatelyDownLoad = _pbarbtnImmediatelyDownload.Checked;
				}
			}
			catch
			{
				// ignored
			}
		}

		#endregion

		#region 冻结左侧列，拖拽动态生成冻结列

		//用于记录冻结列原来的显示位置
		private readonly SortedList _htIndex = new SortedList(new MySort());

		public CGridControl(NavigatorCustomButton btnRowHeight)
		{
			_btnRowHeight = btnRowHeight;
			ShowCustomNavigationButtons = false;
		}

		/// <summary>
		///     拖拽列头时，保存冻结列信息，以便拖拽后进行还原和更新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView_DragObjectStart(object sender, DragObjectStartEventArgs e)
		{
			try
			{
				var gridView = sender as GridView;
				if (gridView == null) return;
				gridView.BeginUpdate();
				lock (_htIndex.SyncRoot) //记录原来的冻结情况
				{
					_htIndex.Clear();
					for (var i = gridView.VisibleColumns.Count - 1; i >= 0; i--)
					{
						if (gridView.VisibleColumns[i].Fixed == FixedStyle.Left)
						{
							_htIndex.Add(gridView.VisibleColumns[i].FieldName, gridView.VisibleColumns[i].VisibleIndex);
							gridView.VisibleColumns[i].Fixed = FixedStyle.None;
						}
					}
				}
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     拖拽列头停止时，进行拖拽后进行还原和更新
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridView_DragObjectDrop(object sender, DragObjectDropEventArgs e)
		{
			GridView gridView = null;
			try
			{
				gridView = sender as GridView;
				if (gridView == null) return;
				var currentColumn = e.DragObject as GridColumn;
				var index = e.DropInfo.Index; //-1：表示没有变化，-100表示脱出控件外，看不见了
				if (index == -1 || index == -100 || _htIndex.Count == 0) //count=0，说明没有冻结列，就不需要处理了
				{
					lock (_htIndex.SyncRoot)
					{
						foreach (DictionaryEntry de in _htIndex)
						{
							foreach (GridColumn col in gridView.VisibleColumns)
							{
								if (de.Key.ToString() == col.FieldName)
								{
									col.Fixed = FixedStyle.Left;
									col.VisibleIndex = Convert.ToInt32(_htIndex[col.FieldName]);
									break;
								}
							}
						}
					}
				}
				else if (e.DropInfo.Index > _htIndex.Count - 1) //被拉动的列，目的的在冻结列的右侧范围（不属于冻结列）
				{
					//这种情况需要判断并排除已冻结列被拉出去的情况
					lock (_htIndex.SyncRoot)
					{
						foreach (DictionaryEntry de in _htIndex)
						{
							foreach (GridColumn col in gridView.VisibleColumns)
							{
								if (de.Key.ToString() == col.FieldName)
								{
									if (currentColumn != null && col.FieldName == currentColumn.FieldName)
									{
										col.Fixed = FixedStyle.None; //被拉出冻结列的情况
										break;
									}
									col.Fixed = FixedStyle.Left;
									col.VisibleIndex = Convert.ToInt32(_htIndex[col.FieldName]);
									break;
								}
							}
						}
					}
				}
				else //需要重新安排冻结顺序
				{
					//先定义两个一维数组，分别用来存储Key和Value
					var keyArray = new string[_htIndex.Count];
					var valueArray = new int[_htIndex.Count];
					//将HashTable中的Key和Value分别赋给上面两个数组  

					_htIndex.Keys.CopyTo(keyArray, 0);
					_htIndex.Values.CopyTo(valueArray, 0);
					Array.Sort(valueArray, keyArray); //按值排序

					var listKey = new List<string>(keyArray);
					if (currentColumn != null) listKey.Insert(e.DropInfo.Index, currentColumn.FieldName); //插入当前冻结位置，取代原来的冻结列位置

					foreach (string t in listKey)
					{
						for (var i = 0; i < gridView.VisibleColumns.Count; i++)
						{
							if (gridView.VisibleColumns[i].Fixed == FixedStyle.Left) continue; //已经冻结则不处理
							if (gridView.VisibleColumns[i].FieldName == t)
							{
								gridView.VisibleColumns[i].Fixed = FixedStyle.Left; //按照新的顺序设置冻结列即可  
								break;
							}
						}
					}
				}
			}
			catch
			{
				// ignored
			}
			finally
			{
				if (gridView != null) gridView.EndUpdate();
			}
		}

		#endregion
	}

	/// <summary>
	///     排序类
	/// </summary>
	internal class MySort : IComparer
	{
		public int Compare(object x, object y)
		{
			return -1;
		}
	}
}