using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using DevExpress.XtraTab.Registrator;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DS.Data;
using DS.Model;
using DS.MSClient.Properties;
using DS.MSClient.UICommon;
using DS.MSClient.UIControl;
using DS.MSClient.UIModule;
using NoHeaderXtraTabControl;
using QuickFrame.Common.Converter;
using QuickFrame.ClientConnector;
using QuickFrame.Model;

namespace DS.MSClient.UIGeneric
{
	public partial class FormMain : FormBase
	{
		#region 初始化

		public FormMain()
		{
			InitializeComponent();
			AddNoHeaderXtraTabControlPaintStyle();
			InitEvent();
		}

		/// <summary>
		///     添加无头标签tab控件的样式
		/// </summary>
		private void AddNoHeaderXtraTabControlPaintStyle()
		{
			PaintStyleCollection.DefaultPaintStyles.Add(new MyRegistrator());
			tabcPages.PaintStyleName = @"MyStyle";
		}

		private void InitEvent()
		{
			Shown += FormMain_Shown;
			FormClosing += FormMain_FormClosing;
			FormClosed += FormMain_FormClosed;
			//窗体尺寸拉伸，必须检查是否非最大化，非最大化时需要设置MDI容器内边距大于0方便用户拉伸无边框窗体
			Resize += FormMain_Resize;

			lblBtnExit.Click += lblBtnClose_Click;
			lblBtnMax.Click += lblBtnMax_Click;
			lblBtnMin.Click += lblBtnMin_Click;
			picLogo.MouseDown += FormMain_MouseDown;
			panelTopRight.MouseDown += FormMain_MouseDown;
			panelTopCenter.MouseDown += FormMain_MouseDown;
			lblTitle.MouseDown += FormMain_MouseDown;

			picLogo.MouseMove += FormMain_MouseMove;
			panelTopCenter.MouseMove += FormMain_MouseMove;
			panelTopRight.MouseMove += FormMain_MouseMove;
			lblTitle.MouseMove += FormMain_MouseMove;

			picLogo.DoubleClick += FormMain_DoubleClick;
			panelTopRight.DoubleClick += FormMain_DoubleClick;
			panelTopCenter.DoubleClick += FormMain_DoubleClick;
			lblTitle.DoubleClick += FormMain_DoubleClick;
            this.Btn_Wechat.ItemClick += Btn_Wechat_ItemClick;

			//切换
			tabcMain.SelectedPageChanged += tabcMain_SelectedPageChanged;
			//导航收缩/伸展
			tabcMain.CustomHeaderButtonClick += tabcMain_CustomHeaderButtonClick;

			//tab页数量变化
			tabcPages.ControlAdded += tabcPages_ControlAdded;
			tabcPages.ControlRemoved += tabcPages_ControlAdded;
			tabcPages.SelectedPageChanged += tabcPages_SelectedPageChanged;

			//动态加载业务系统菜单
			navBusiness.ActiveGroupChanged += navBusiness_ActiveGroupChanged;

			//tab导航按键            
			picBtnDialog.Click += picBtn_Click;
			picBtnNext.Click += picBtn_Click;
			picBtnPrev.Click += picBtn_Click;
			picBtnClose.Click += picBtn_Click;
			picBtnHome.Click += picBtn_Click;
			picBtnHistory.Click += picBtn_Click;
			picBtnCloseAll.Click += picBtn_Click;

			btnChangePassword.ItemClick += btnChangePassword_ItemClick;
			btnResetGridStyle.ItemClick += btnResetGridStyle_ItemClick;

			treeHistory.Click += treeList_history_Click;
			tluHistoryTreeList.Click += treeList_history_Click; //导航栏上面的工作列表 

			//改变尺寸
			lblSizeDrag.MouseDown += lblSizeDrag_MouseDown;
			lblSizeDrag.MouseMove += lblSizeDrag_MouseMove;
			lblSizeDrag.MouseUp += lblSizeDrag_MouseUp;
		}


		#endregion

		#region 属性

		private string _mainTitle;

		private bool _bStartMove; //开始拖动窗体
		private bool _isInit; //是否初始化
		private bool _isBussiness; //业务模块是否初始化
		private List<CustomStrNode> _nodeBussiness;
		protected new NavBarGroupControlContainer Container;
		private TreeList _menuTree;

		private bool _inChangeSize;
		private Point _changeSizeBaseLoc;
		private Size _changeSizeBaseSize;
		private Point _normalLocation;

		#endregion

		#region 事件

        void Btn_Wechat_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var _list = new StudentDAO().GetUnionList();
                foreach (var m in _list)
                {
                    var paramList = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("WechatOpenID", m.WechatOpenID)
                                };
                    QfJsonResult _sResult = Program.ApiConnector.Post<QfJsonResult>("Api", "Student",
                        "GetStudentUnionID",
                        paramList);
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

		#region 窗体

		/// <summary>
		///     窗体加载
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void FormMain_Shown(object sender, EventArgs e)
		{
			try
			{
				//读取开发完成情况
				var ats = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (ats.Any())
				{
					var at = ats[0] as AssemblyTitleAttribute;
					if (at == null) return;
					_mainTitle = at.Title;
				}
				ShowTitle();
				Text = bsiVersion.Caption = string.Format(@"康达驾校管理系统 v{0}", Program.CurrentAssemblyFileVersion); //系统版本
				bsiUserInfo.Caption = Program.CurrentEmployee.EmployeeName + @"(" + Program.CurrentEmployee.EmployeeCode + @")";
				SetTabNavPicVisible(true);
				GenerateMainMenu();
				_isBussiness = true;
				//DeleteStyle();
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		/// 窗体关闭前
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (MessageBox.Show(@"您确定要退出系统吗?", @"提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
				{
					e.Cancel = true;
					return;
				}
				//清除已经打开编辑或查看的模块，临时表
				foreach (var node in Program.ArrHistoryNode)
				{
					if (node.Array == 3 && node.formRecordID != -1)
					{
						FormPageOperation.ClearUserTempData(node.guid, node.formName, node.formRecordID); //清除临时表数据
					}
				}
				CheckUpdateSoftware(); //检查是否有升级程序更新
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     窗体关闭后
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				Application.Exit();
			}
			catch (Exception ex)
			{
				MsgBox.ShowError(ex);
			}
		}

		/// <summary>
		///     窗体尺寸伸缩,，必须检查是否非最大化，非最大化时需要设置MDI容器内边距大于0方便用户拉伸无边框窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMain_Resize(object sender, EventArgs e)
		{
			try
			{
				if (_isInit)
				{
					if (Width < Screen.PrimaryScreen.WorkingArea.Width && Height < Screen.PrimaryScreen.WorkingArea.Height) //普通拉伸模式
					{
						Padding = new Padding(1); //设置MDI容器的内边距，用于无边框窗体在非最大化的时候方便拉伸
					}
					else //最大化
					{
						Padding = new Padding(0); //设置MDI容器的内边距0
					}
				}
			}
			catch
			{
				// ignored
			}
		}

		#endregion

		#region 导航栏

		private void navBusiness_ActiveGroupChanged(object sender, NavBarGroupEventArgs e)
		{
			var groupControl2 = ((NavBarControl)sender).ActiveGroup;
			var items = MainMenu.GetLevelItemsByOrder(2, ValueConvert.ToString(groupControl2.Tag));
			_nodeBussiness = new List<CustomStrNode>();
			if (items != null)
			{
				Container = new NavBarGroupControlContainer();
				_menuTree = new TreeList();
				_menuTree.CustomDrawNodeCell += treeList_CustomDrawNodeCell;
				_menuTree.FocusedNodeChanged += treeList_FocusedNodeChanged;
				_menuTree.Click += treeList_Click;
				_menuTree.CustomDrawNodeImages += treeList_CustomDrawNodeImages;
				var column = new TreeListColumn();
				_menuTree.Columns.AddRange(new[] { column });
				_menuTree.Dock = DockStyle.Fill;
				_menuTree.Location = new Point(0, 0);
				_menuTree.Name = "treeList_normalMenu";
				_menuTree.OptionsView.ShowColumns = false;
				_menuTree.OptionsView.ShowHorzLines = false;
				_menuTree.OptionsView.ShowIndicator = false;
				_menuTree.OptionsView.ShowVertLines = false;
				_menuTree.RowHeight = 25;
				_menuTree.SelectImageList = ilBusiness;
				_menuTree.Size = new Size(188, 405);
				_menuTree.TabIndex = 1;
				_menuTree.TreeLevelWidth = 15;
				_menuTree.TreeLineStyle = LineStyle.None;
				// 
				// column
				// 
				column.Caption = @"名称";
				column.FieldName = "formText";
				column.MinWidth = 69;
				column.Name = "column";
				column.OptionsColumn.AllowEdit = false;
				column.OptionsColumn.AllowMove = false;
				column.Visible = true;
				column.VisibleIndex = 0;
				column.ImageIndex = 16;
				foreach (var item in items)
				{
					if (!UIRight.CheckRightByID(item.Order) && Program.CurrentEmployee.EmployeeCode != "admin")
					{
						continue;
					}
					var node = new CustomStrNode
					{
						Fid = item.Level + "_" + item.Order,
						Pid = "-1",
						formName = item.MdiName,
						formText = item.Text,
						formTag = item.Order,
						Array = item.Level
					};
					_nodeBussiness.Add(node);
					var childitems = MainMenu.GetLevelItemsByOrder(3, item.Order);
					if (childitems != null)
					{
						foreach (var childitem in childitems)
						{
							if (!UIRight.CheckRightByID(childitem.Order) && Program.CurrentEmployee.EmployeeCode != "admin")
							{
								continue;
							}
							var childnode = new CustomStrNode
							{
								Fid = childitem.Level + "_" + "_" + childitem.Order,
								Pid = item.Level + "_" + item.Order,
								formName = childitem.MdiName,
								formText = childitem.Text,
								isForm = false
							};
							if (Program.HtTreeListHistory.ContainsKey(childnode.Fid + "列表"))
							{
								var historynode = Program.ArrHistoryNode.Find(m => m.formName == childnode.formName && m.formText == "列表");
								childnode.guid = historynode != null ? historynode.guid : Guid.NewGuid().ToString();
							}
							else
							{
								childnode.guid = Guid.NewGuid().ToString();
							}
							childnode.formTag = childitem.Order;
							childnode.Array = childitem.Level;
							_nodeBussiness.Add(childnode);
						}
					}
				}
				_menuTree.DataSource = _nodeBussiness;
				_menuTree.KeyFieldName = "Fid";
				_menuTree.ParentFieldName = "Pid";
				_menuTree.Dock = DockStyle.Fill;
				navBusiness.Controls.Add(Container);
				//添加子节点到控件下
				Container.Controls.Add(_menuTree);
				//设置高度
				Container.Height = ((TreeList)Container.Controls[0]).Nodes.Count * 23;
				e.Group.ControlContainer = Container;
				//展开所有节点
				_menuTree.ExpandAll();
			}
		}

		private void treeList_CustomDrawNodeImages(object sender, CustomDrawNodeImagesEventArgs e)
		{
			if (e.Node.Level == 0) //默认只有一级菜单项才有图标
				e.SelectImageIndex = 16; // e.Node.Level + 1; // e.SelectImageIndex为图片在ImageList中的index
			else
				e.SelectImageIndex = -1;
		}

		private void treeList_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
		{
			try
			{
				// Create brushes for cells.
				Brush backBrush, foreBrush;
				var treeList = sender as TreeList;
				if (treeList != null && e.Node != treeList.FocusedNode) //不是焦点节点
				{
					// backBrush = new LinearGradientBrush(e.Bounds, Color.PapayaWhip, Color.PeachPuff, LinearGradientMode.ForwardDiagonal);
					backBrush = new LinearGradientBrush(e.Bounds, Color.White, Color.White, LinearGradientMode.ForwardDiagonal);
					foreBrush = Brushes.Black; //字体颜色
				}
				else
				{
					backBrush = Brushes.WhiteSmoke;
					foreBrush = new SolidBrush(Color.DarkBlue);
				}
				// Fill the background.
				e.Graphics.FillRectangle(backBrush, e.Bounds);
				// Paint the node value.
				e.Graphics.DrawString(e.CellText, e.Appearance.Font, foreBrush, e.Bounds,
					e.Appearance.GetStringFormat());

				// Prohibit default painting.
				e.Handled = true;
			}
			catch
			{
				// ignored
			}
		}

		private void treeList_history_Click(object sender, EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				var tree = sender as TreeList;
				if (tree == null) return;
				var node = tree.GetDataRecordByNode(tree.FocusedNode) as CustomStrNode;
				if (node == null || node.Array <= 2) return;
				var hisnode = node.isForm ? Program.ArrHistoryNode.Find(m => m.guid == node.guid) : Program.ArrHistoryNode.Find(m => m.guid == node.guid);
				//判断打开窗体中是否存在改列表，有则定位至该窗体
				if (hisnode != null)
				{
					ActivatePage(hisnode, false); //激活页面，但是点击工作列表不更新当前工作列表的排序，否则用户会觉得怪异
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

		private void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				lock (Program.HtTreeListHistory.SyncRoot)
				{
					var tree = sender as TreeList;
					CheckBindMainTreeData(tree);
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
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeList_Click(object sender, EventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				lock (Program.HtTreeListHistory.SyncRoot)
				{
					var tree = sender as TreeList;
					CheckBindMainTreeData(tree);
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
		///     伸缩面板
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabcMain_CustomHeaderButtonClick(object sender, CustomHeaderButtonEventArgs e)
		{
			if (e.Button.Tag.ToString() == "shrink") //收缩
			{
				// MessageBox.Show("收缩");
				e.Button.Tag = "extand";
				e.Button.Image = Resources.move_right;
				tabcMain.Width = 27;
			}
			else //extand 伸展
			{
				//MessageBox.Show("伸展");
				e.Button.Tag = "shrink";
				e.Button.Image = Resources.move_left;
				tabcMain.Width = 215;
			}
		}

		/// <summary>
		///     切换
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabcMain_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
		{
			tabcMain.CustomHeaderButtons[0].Visible = true;
			tabcMain.Dock = DockStyle.Left; //左侧菜单面板区域收缩到左侧
			tabcPages.Visible = true; //右侧主界面可见，紧挨左侧菜单面板
			tabcPages.BringToFront();
			tabcPages.Dock = DockStyle.Fill;

			tabcMain.Width = 215;
			tabcMain.CustomHeaderButtons[0].Tag = "shrink";
			tabcMain.CustomHeaderButtons[0].Image = Resources.move_left;
			tluHistoryTreeList.RefreshDataSource();
			treeHistory.RefreshDataSource();

			if (e.Page == tabBusiness && !_isBussiness)
			{
				GenerateMainMenu();
				_isBussiness = true;
			}
			else if (e.Page == tabUser)
			{
				RefreshHistoryTreeList();
			}
			SetTabNavPicVisible(true);
		}

		#endregion

		#region 标签页

		private void tabcPages_ControlAdded(object sender, ControlEventArgs e)
		{
			try
			{
				ShowTitle(tabcPages.SelectedTabPage.Text);
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     切换
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabcPages_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
		{
            ShowTitle(tabcPages.SelectedTabPage != null ? tabcPages.SelectedTabPage.Text : null);
            FormPageOperation.FormSetMin();
		}

		#endregion

		#region 功能按钮

		/// <summary>
		///     tab导航
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void picBtn_Click(object sender, EventArgs e)
		{
			if (sender == picBtnNext) //下一页
			{
				if (tabcPages.SelectedTabPageIndex < tabcPages.TabPages.Count - 1)
				{
					tabcPages.SelectedTabPageIndex = tabcPages.SelectedTabPageIndex + 1;
				}
			}
			else if (sender == picBtnPrev) //上一页
			{
				if (tabcPages.SelectedTabPageIndex > 0)
				{
					tabcPages.SelectedTabPageIndex = tabcPages.SelectedTabPageIndex - 1;
				}
			}
			else if (sender == picBtnDialog) //拖出窗体
			{
				if (tabcPages.SelectedTabPage != null && tabcPages.SelectedTabPageIndex != 0) //除了主页，都可以拖出来
				{
					var form = new FormLoad
					{
						WindowState = FormWindowState.Normal,
						tabc_Main = tabcPages,
						RefreshHistoryTreeList = RefreshHistoryTreeList,
						Tag = tabcPages.SelectedTabPage.Tag,
						Text = tabcPages.SelectedTabPage.Text
					};
					//刷新工作列表 

					form.Controls.Add(tabcPages.SelectedTabPage.Controls[0]);
					var currentSelectIndex = tabcPages.SelectedTabPageIndex;
					tabcPages.TabPages.Remove(tabcPages.SelectedTabPage); //移除tabcontrol中显示页面 
					tabcPages.SelectedTabPageIndex = currentSelectIndex - 1;
					form.TopMost = true;
					form.Show();
				}
			}
			else if (sender == picBtnClose) //关闭
			{
				if (tabcPages.SelectedTabPage != null && tabcPages.SelectedTabPageIndex != 0)
				{
					var currentSelectIndex = tabcPages.SelectedTabPageIndex;
					if (tabcPages.SelectedTabPage.Tag != null)
					{
						//移除工作列表节点
						var node = Program.ArrHistoryNode.Find(m => m.guid == tabcPages.SelectedTabPage.Tag.ToString() && m.Array == 3);
                        if (node != null)
                        {
                            if (!node.formIsSaved)
                            {
                                if (MsgBox.ShowYesNo("确定取消编辑，退出吗?") != DialogResult.Yes)
                                {
                                    return;
                                }
                            }
                            if (node.formRecordID != -1)
                            {
                                FormPageOperation.ClearUserTempData(node.guid, node.formName, node.formRecordID); //清除临时表数据
                            }

                            if (!node.isForm && Program.HtTreeListHistory.ContainsKey(node.Pid + "列表")) //如果不是编辑窗口,移除防止重复添加列表的key
                            {
                                Program.HtTreeListHistory.Remove(node.Pid + "列表");
                            }
                            Program.ArrHistoryNode.Remove(node);
                            //判断是否需要移除父节点
                            var parentnode = Program.ArrHistoryNode.FindAll(m => m.Pid == node.Pid);
                            if (!parentnode.Any())
                            {
                                Program.ArrHistoryNode.RemoveAll(m => m.Fid == node.Pid);
                            }
                            treeHistory.RefreshDataSource();
                            treeHistory.Refresh();
                        }
					}
					var selectedTabPage = tabcPages.SelectedTabPage;
					tabcPages.TabPages.Remove(tabcPages.SelectedTabPage);
					if (selectedTabPage != null)
					{
						foreach (Control tempCtrl in selectedTabPage.Controls)
						{
							if (tempCtrl is GridControl) //移除grid，触发保存grid布局样式事件(此处去掉，grid样式将不能保存)
							{
								selectedTabPage.Controls.Remove(tempCtrl);
							}
						}
						selectedTabPage.Dispose();
					}

					if (currentSelectIndex <= tabcPages.TabPages.Count - 1)
					{
						tabcPages.SelectedTabPageIndex = currentSelectIndex;
					}
					else
					{
						tabcPages.SelectedTabPageIndex = currentSelectIndex - 1;
					}
				}
				RefreshHistoryTreeList();
			}
			else if (sender == picBtnCloseAll) //关闭全部，只留主页
			{
                object homePage = this.tabcPages.TabPages[0];//保留首页
                for (int i = this.tabcPages.TabPages.Count - 1; i > 0; i--)//遍历在容器内的窗体
                {
                    if (this.tabcPages.TabPages[i].Tag != null)//可以移除
                    {
                        FormPageOperation.FormFindMin(ValueConvert.ToString(this.tabcPages.TabPages[i].Tag));
                        //移除工作列表节点
                        var node = Program.ArrHistoryNode.Find(m => m.guid == ValueConvert.ToString(this.tabcPages.TabPages[i].Tag) && m.Array == 3);
                        if (node != null && node.formRecordID != -1)
                        {
                            FormPageOperation.ClearUserTempData(node.guid, node.formName, node.formRecordID);//清除临时表数据
                        }
                        if (node != null)
                        {
                            if (Program.HtTreeListHistory != null)
                            {
                                if (Program.HtTreeListHistory != null)
                                {
                                    if (!node.isForm && Program.HtTreeListHistory.ContainsKey(node.Pid + "列表"))//如果不是编辑窗口,移除防止重复添加列表的key
                                    {
                                        Program.HtTreeListHistory.Remove(node.Pid + "列表");
                                    }
                                }
                                Program.ArrHistoryNode.Remove(node);
                                //判断是否需要移除父节点
                                var parentnode = Program.ArrHistoryNode.FindAll(m => m.Pid == node.Pid);
                                if (parentnode == null || parentnode.Count() == 0)
                                {
                                    var _node = Program.ArrHistoryNode.Find(m => m.Fid == node.Pid);
                                    Program.ArrHistoryNode.Remove(_node);
                                }
                            }
                        }
                    }
                }
                //此种方式是防止工作列表清除的不够干净,并触发保存grid布局样式事件
                for (int i = this.tabcPages.TabPages.Count - 1; i > 0; i--)//遍历在容器内的窗体
                {
                    foreach (Control tempCtrl in this.tabcPages.TabPages[i].Controls)
                    {
                        if (tempCtrl is DevExpress.XtraGrid.GridControl)//移除grid，触发保存grid布局样式事件(此处去掉，grid样式将不能保存)
                        {
                            this.tabcPages.TabPages[i].Controls.Remove(tempCtrl);
                        }
                    }
                    this.tabcPages.TabPages[i].Dispose();
                }


                this.tabcPages.TabPages.Clear();
                this.tabcPages.TabPages.Add((MyXtraTabPage)homePage);
                this.tabcPages.Refresh();

                this.RefreshHistoryTreeList();
                this.tluHistory.ClosePopup();
			}
			else if (sender == picBtnHome) //主页 
			{
				tabcPages.SelectedTabPageIndex = 0;
			}
			else if (sender == picBtnHistory) //工作列表
			{
				tluHistory.Properties.TreeList.ExpandToLevel(1);
				tluHistory.ShowPopup(); //展开列表
			}
		}

		private void btnChangePassword_ItemClick(object sender, ItemClickEventArgs e)
		{
			var form = new DialogEditPassword();
			form.ShowDialog(this);
		}

		private void btnResetGridStyle_ItemClick(object sender, ItemClickEventArgs e)
		{
			DeleteStyle();
		}

		#endregion

		#region 右侧按钮

		private void lblBtnMin_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void lblBtnMax_Click(object sender, EventArgs e)
		{
			WindowStateMaximized();
		}


		private void lblBtnClose_Click(object sender, EventArgs e)
		{
			//退出系统 
			Close();
		}

		#endregion

		#region 无标题窗体拖动

		//窗体移动属性
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		//发送消息
		[DllImport("user32.dll")]
		public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

		//属性
		// ReSharper disable once InconsistentNaming
		public const int WM_SYSCOMMAND = 0x0112;
		// ReSharper disable once InconsistentNaming
		public const int SC_MOVE = 0xF010;
		// ReSharper disable once InconsistentNaming
		public const int HTCAPTION = 0x0002;

		/// <summary>
		///     窗体移动事件
		/// </summary>
		private void FormMain_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) //只有左键才能移动
			{
				_bStartMove = true;
			}
		}

		private void FormMain_MouseMove(object sender, MouseEventArgs e)
		{
			if (_bStartMove)
			{
				ReleaseCapture(); //捕获鼠标
				//发送消息
				SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
			}
		}

		#endregion

		#region 双击最大化

		private void FormMain_DoubleClick(object sender, EventArgs e)
		{
			_bStartMove = false;
			WindowStateMaximized();
		}

		#endregion

		#region 右下角拖拽改变大小

		void lblSizeDrag_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			_inChangeSize = true;
			_changeSizeBaseLoc = MousePosition;
			_changeSizeBaseSize = Size;
		}

		void lblSizeDrag_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left || !_inChangeSize) return;
			Width = _changeSizeBaseSize.Width + (MousePosition.X - _changeSizeBaseLoc.X);
			Height = _changeSizeBaseSize.Height + (MousePosition.Y - _changeSizeBaseLoc.Y);
		}

		void lblSizeDrag_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			_inChangeSize = false;
		}

		#endregion

		#endregion

		#region 方法

		#region 改变窗体大小+自定义窗体边框

		// ReSharper disable once InconsistentNaming
		private const int Guying_HTLEFT = 10;
		// ReSharper disable once InconsistentNaming
		private const int Guying_HTRIGHT = 11;
		// ReSharper disable once InconsistentNaming
		private const int Guying_HTTOP = 12;
		// ReSharper disable once InconsistentNaming
		private const int Guying_HTTOPLEFT = 13;
		// ReSharper disable once InconsistentNaming
		private const int Guying_HTTOPRIGHT = 14;
		// ReSharper disable once InconsistentNaming
		private const int Guying_HTBOTTOM = 15;
		// ReSharper disable once InconsistentNaming
		private const int Guying_HTBOTTOMLEFT = 0x10;
		// ReSharper disable once InconsistentNaming
		private const int Guying_HTBOTTOMRIGHT = 17;

		/// <summary>
		///     改变无边框窗体的大小,在MDI窗体容器中，内边距必须大于0才能拉伸边框
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref Message m)
		{
			try
			{
				switch (m.Msg)
				{
					case 0x0084:
						base.WndProc(ref m);
						var vPoint = new Point((int)m.LParam & 0xFFFF,
							(int)m.LParam >> 16 & 0xFFFF);
						vPoint = PointToClient(vPoint);
						if (vPoint.X <= 5)
						{
							if (vPoint.Y <= 5)
								m.Result = (IntPtr)Guying_HTTOPLEFT;
							else if (vPoint.Y >= ClientSize.Height - 5)
								m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
							else
								m.Result = (IntPtr)Guying_HTLEFT;
						}
						else if (vPoint.X >= ClientSize.Width - 5)
						{
							if (vPoint.Y <= 5)
								m.Result = (IntPtr)Guying_HTTOPRIGHT;
							else if (vPoint.Y >= ClientSize.Height - 5)
								m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
							else
								m.Result = (IntPtr)Guying_HTRIGHT;
						}
						else if (vPoint.Y <= 5)
							m.Result = (IntPtr)Guying_HTTOP;
						else if (vPoint.Y >= ClientSize.Height - 5)
							m.Result = (IntPtr)Guying_HTBOTTOM;
						break;
					case 0x0201:
						//鼠标左键按下的消息   
						m.Msg = 0x00A1; //更改消息为非客户区按下鼠标   
						m.LParam = IntPtr.Zero; //默认值   
						m.WParam = new IntPtr(2); //鼠标放在标题栏内   
						base.WndProc(ref m);
						break;
					default:
						base.WndProc(ref m);
						break;
				}
			}
			catch
			{
				// ignored
			}
		}

		#endregion

		/// <summary>
		///     初始化
		/// </summary>
		public void Init()
		{
			var screenArea = Screen.GetWorkingArea(this);
			MaximumSize = screenArea.Size; //防止遮住任务栏 
			MinimumSize = new Size(500, 400); //最小尺寸
			_normalLocation = new Point((screenArea.Width - Width) / 2, (screenArea.Height - Height) / 2);
			WindowState = FormWindowState.Maximized;

			//xtraTabControl_all.CustomHeaderButtons[0].Visible = false; //面板伸缩按钮不可见
			//tabc_Main.Visible = false; //右侧主界面暂时不可见
			//xtraTabControl_all.Dock = DockStyle.Fill; //左侧菜单面板区域全屏
			//右侧主页背景图片
			//picHomeBg.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "workplace.png");
			//System.AppDomain.CurrentDomain.BaseDirectory + "\\Images\\workplace.png";

			SetTabNavPicVisible(false); //默认不可见,加载了别的页面的时候可见
			_isInit = true;
			Program.TreeListHistory = treeHistory;
			Program.TabcMain = tabcPages;
		}

		/// <summary>
		///     设置tab页导航图片可见
		/// </summary>
		/// <param name="flag"></param>
		private void SetTabNavPicVisible(bool flag)
		{
			picBtnPrev.Visible = flag;
			picBtnNext.Visible = flag;
			picBtnDialog.Visible = flag;
			picBtnClose.Visible = flag;
			picBtnHome.Visible = flag;
			picBtnHistory.Visible = flag;
			picBtnCloseAll.Visible = flag;
			picSplit1.Visible = flag; //分隔符
			picSplic.Visible = flag;
		}

		/// <summary>
		///     生成业务系统主菜单
		/// </summary>
		private void GenerateMainMenu()
		{
			var groupItems = MainMenu.GetLevelItemsByOrder(1);
			foreach (var groupItem in groupItems)
			{
				if (!UIRight.CheckRightByID(groupItem.Order) && Program.CurrentEmployee.EmployeeCode != "admin")
				{
					continue;
				}
				var navGroup = new NavBarGroup(groupItem.Text)
				{
					Tag = groupItem.Order,
					SmallImageIndex = groupItem.ImageIndex,
					LargeImageIndex = groupItem.ImageIndex
				};
				if (groupItem.HeadImage != null)
				{
					navGroup.LargeImage = groupItem.HeadImage;
					navGroup.SmallImage = groupItem.HeadImage;
				}
				navGroup.Expanded = false;
				navBusiness.Groups.Add(navGroup);
			}
			navBusiness.SelectedLink = null;
		}

		/// <summary>
		///     绑定主业务菜单点击数据
		/// </summary>
		/// <param name="tree"></param>
		private void BindMainTreeData(TreeList tree)
		{
			var node = tree.GetDataRecordByNode(tree.FocusedNode) as CustomStrNode;
			if (node != null)
			{
				node.OpenTime = DateTime.Now;
				//节点大于2级进行详细菜单
				if (node.Array > 2)
				{
					var hisnode = node.isForm
						? Program.ArrHistoryNode.Find(m => m.guid == node.guid)
						: Program.ArrHistoryNode.Find(m => m.guid == node.guid);
					//判断打开窗体中是否存在改列表，有则定位至该窗体
					if (hisnode != null)
					{
						ActivatePage(hisnode); //激活页面
					}
					else
					{
						if (!node.isForm)
						{
							node.OpenTime = DateTime.Now; //更新时间
							//自定义的tab页面
							var page = new MyXtraTabPage();
						    page.HidePageHeader = false;
							var assembly = Assembly.GetExecutingAssembly();
							var control = (BaseUserControl) assembly.CreateInstance("DS.MSClient.UIModule." + node.formName);
							if (control == null) return;
							control.Dock = DockStyle.Fill;
							control.Tag = node.guid;
							//control.treeList_history = this.treeList_history;
							page.Text = node.formText;
							page.Tag = node.guid;
							//control.tabc_Main = this.tabc_Main;
							page.Controls.Add(control);
							tabcPages.TabPages.Add(page);
							tabcPages.SelectedTabPage = page;
							var dnode = (CustomStrNode) node.Copy();
							if (Program.ArrHistoryNode.Find(m => m.Fid == node.Fid) != null)
							{
								dnode.formText = "列表";
								dnode.Array = 3;
								dnode.Fid = Guid.NewGuid().ToString();
								dnode.OpenTime = DateTime.Now;
								dnode.Pid = node.Fid;

								Program.ArrHistoryNode.Insert(0, dnode); //改插入首位 
							}
							else
							{
								dnode.Array = 2;
								Program.ArrHistoryNode.Add(dnode);
								var copynode = (CustomStrNode) node.Copy();
								copynode.formText = "列表";
								copynode.Array = 3;
								copynode.OpenTime = DateTime.Now;
								copynode.Fid = Guid.NewGuid().ToString();
								copynode.Pid = dnode.Fid;
								var key = copynode.Pid + "列表";
								if (!Program.HtTreeListHistory.ContainsKey(key))
								{
									Program.HtTreeListHistory.Add(key, key); //用于判断是否重复加载
								}

								Program.ArrHistoryNode.Insert(0, copynode); //改插入首位
							}
							UpdateTreeNodeOpentime(node);
							RefreshHistoryTreeList();
						}
					}
				}
			}
		}

		/// <summary>
		///     检查是否可以触发树形菜单事件
		/// </summary>
		/// <param name="tree"></param>
		private void CheckBindMainTreeData(TreeList tree)
		{
			var node = tree.GetDataRecordByNode(tree.FocusedNode) as CustomStrNode;
			if (node != null)
			{
				if (!node.isForm)
				{
					if (!Program.HtTreeListHistory.ContainsKey(node.Fid + "列表"))
					{
						Program.HtTreeListHistory.Add(node.Fid + "列表", node.Pid + "列表");
						BindMainTreeData(tree);
					}
					else
					{
						var hisnode = Program.ArrHistoryNode.Find(m => m.guid == node.guid);
						if (hisnode != null)
						{
							ActivatePage(hisnode); //激活页面
						}
					}
				}
				else
				{
					BindMainTreeData(tree);
				}
			}
		}

		/// <summary>
		///     激活页面
		/// </summary>
		/// <param name="hisnode"></param>
		/// <param name="updateSortOrder">是否更新排序</param>
		private void ActivatePage(CustomStrNode hisnode, bool updateSortOrder = true)
		{
			var isFound = false; //在tabcontrol页面当中是否找到，如果没有找到再去找被最小化的拉出去的窗体了
			foreach (MyXtraTabPage page in tabcPages.TabPages)
			{
				if (page.Tag != null)
				{
					if (page.Tag.ToString() == hisnode.guid)
					{
						tabcPages.SelectedTabPage = page;
						isFound = true;
						break;
					}
				}
			}
			if (!isFound) //如果没有找到再去找被最小化的拉出去的窗体了
			{
				if (Program.HtMinimizeForm.Contains(hisnode.guid))
				{
					var form = (FormLoad) Program.HtMinimizeForm[hisnode.guid];
					form.WindowState = FormWindowState.Normal;
					form.StartPosition = FormStartPosition.CenterScreen;

					form.Activate();
				}
			}
			if (updateSortOrder)
			{
				UpdateTreeNodeOpentime(hisnode);
			}
			RefreshHistoryTreeList(); //刷新历史工作列表
		}

		/// <summary>
		///     更新节点打开时间
		/// </summary>
		/// <param name="hisnode"></param>
		private static void UpdateTreeNodeOpentime(CustomStrNode hisnode)
		{
			foreach (var cs in Program.ArrHistoryNode) //更新节点时间
			{
				if (cs.Fid == hisnode.Pid)
				{
					cs.OpenTime = DateTime.Now;
				}
			}
			hisnode.OpenTime = DateTime.Now; //更新最新的点击时间，否则排序无效
		}

		/// <summary>
		///     刷新历史工作列表
		/// </summary>
		private void RefreshHistoryTreeList()
		{
			treeHistory.Nodes.Clear();

			treeHistory.KeyFieldName = "Fid";
			treeHistory.ParentFieldName = "Pid";
			treeHistory.DataSource = null;
			treeHistory.DataSource = Program.ArrHistoryNode;
			treeHistory.RefreshDataSource();
			treeHistory.Refresh();
			treeHistory.ExpandToLevel(1);
			treeHistory.Columns["OpenTime"].SortOrder = SortOrder.Descending;

			tluHistory.Properties.TreeList.KeyFieldName = "Fid";
			tluHistory.Properties.TreeList.ParentFieldName = "Pid";
			tluHistory.Properties.DataSource = Program.ArrHistoryNode;
			tluHistory.Properties.ValueMember = "Fid";
			tluHistory.Properties.DisplayMember = "formText";
			tluHistory.Properties.TreeList.DataSource = null;
			tluHistory.Properties.TreeList.DataSource = Program.ArrHistoryNode;
			tluHistory.Properties.TreeList.RefreshDataSource();
			tluHistory.Properties.TreeList.Refresh();
			tluHistory.Properties.TreeList.ExpandToLevel(1);

			tluHistory.Properties.TreeList.Columns["OpenTime"].SortOrder = SortOrder.Descending;
			tluHistoryTreeList.RefreshDataSource();
		}

		/// <summary>
		///     窗体最大化
		/// </summary>
		private void WindowStateMaximized()
		{
			if (WindowState == FormWindowState.Maximized)
			{
				WindowState = FormWindowState.Normal;
				Location = _normalLocation;
				//var screenArea = Screen.GetWorkingArea(this);
				//var width1 = screenArea.Width; //屏幕宽度 
				//var height1 = screenArea.Height; //屏幕高度

				//Location = new Point((width1 - Width)/2, (height1 - Height)/2);
			}
			else
			{
				_normalLocation = Location;
				var screenArea = Screen.GetWorkingArea(this);
				MaximumSize = screenArea.Size; //防止遮住任务栏 
				WindowState = FormWindowState.Maximized;
			}
		}

		/// <summary>
		///     读取开发完成情况
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public string ReadWorkLogString(string path)
		{
			var sb = new StringBuilder();
			try
			{
				var sr = new StreamReader(path, Encoding.Default);
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					sb.Append(line + "\r\n");
				}
			}
			catch
			{
				// ignored
			}
			return sb.ToString();
		}

		/// <summary>
		///     检查升级程序是否需要更新strPath: ForUpdate
		/// </summary>
		private void CheckUpdateSoftware()
		{
			try
			{
				var updatePath = "ForUpdate";
				var appPath = AppDomain.CurrentDomain.BaseDirectory;
				var strPath = Path.Combine(appPath, updatePath);

				if (Directory.Exists(strPath))
				{
					MovetoFile(strPath, appPath); //剪切升级程序到当前目录
					Directory.Delete(strPath, true);
				}
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     移动文件;
		/// </summary>
		/// <param name="sourcePath"></param>
		/// <param name="objPath"></param>
		private void MovetoFile(string sourcePath, string objPath)
		{
			if (!Directory.Exists(objPath))
			{
				Directory.CreateDirectory(objPath);
			}
			var files = Directory.GetFiles(sourcePath);
			if (files.Length == 0) return;

			foreach (string file in files)
			{
				var childfile = file.Split('\\');
				File.Copy(file, Path.Combine(objPath, childfile[childfile.Length - 1]), true);
			}
			var dirs = Directory.GetDirectories(sourcePath);
			foreach (string dir in dirs)
			{
				var childdir = dir.Split('\\');
				MovetoFile(dir, Path.Combine(objPath, childdir[childdir.Length - 1]));
			}
		}

		/// <summary>
		/// 删除样式
		/// </summary>
		private void DeleteStyle()
		{
			//删除grid样式，避免开发测试不错来新添加列、移除列或其他的功能不正常。
			var strPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Style", Program.CurrentEmployee.EmployeeCode);
			if (Directory.Exists(strPath))
			{
				Directory.Delete(strPath, true);
			}
		}

		/// <summary>
		/// 显示标题
		/// </summary>
		/// <param name="pageTitle">页面标题</param>
		private void ShowTitle(string pageTitle = null)
		{
			pageTitle = (pageTitle ?? string.Empty).Trim();
			lblTitle.Text = pageTitle == string.Empty ? _mainTitle : string.Format("{0} - {1}", pageTitle, _mainTitle);
		}

		#endregion
	}
}