using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.Data.PLinq.Helpers;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ListControls;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace DS.MSClient.UIControl
{

    #region CSmartRepositoryItemLookupEdit

    /// <summary>
    ///     自定义包含联想控件的编辑控件
    /// </summary>
    [ToolboxItem(false)]
    public class CSmartRepositoryItemLookupEdit : RepositoryItemLookUpEdit
	{
		private IContainer components;
        #region Field

        /// <summary>
        ///     自定义控件名称
        /// </summary>
        internal const string CustomEditName = "CSmartRepositoryItemLookupEdit";

        #endregion

        #region Constractor

        /// <summary>
        ///     构造函数
        /// </summary>
        static CSmartRepositoryItemLookupEdit()
        {
            RegisterCustomEdit();
        }

        public CSmartRepositoryItemLookupEdit()
        {
            InitEdit();
            InitEvent();
        }

        public void InitEdit()
        {
            AllowNullInput = DefaultBoolean.True;
            AutoHeight = false;
            ShowFooter = true;
            ShowHeader = true;
            PopupSizeable = true;
            NullText = string.Empty;
            NullValuePrompt = string.Empty;
            NullValuePromptShowForEmptyValue = true;
            CharacterCasing = CharacterCasing.Upper;
            BestFitMode = BestFitMode.BestFitResizePopup;
            SearchMode = SearchMode.AutoFilter;
            CaseSensitiveSearch = true;
            TextEditStyle = TextEditStyles.Standard;
            
        }
        private void InitEvent()
        {
            ButtonClick +=CSmartRepositoryItemLookupEdit_ButtonClick;
        }
        void CSmartRepositoryItemLookupEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (e.Button.Kind == ButtonPredefines.Redo)
                {
                    OnRefreshButtonClick();
                }
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    OnNewButtonClick();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            } 
        }
        /// <summary>
        ///     刷新按钮被单击
        /// </summary>
        protected virtual void OnRefreshButtonClick()
        {
        }
        /// <summary>
        ///     新增按钮被单击
        /// </summary>
        protected virtual void OnNewButtonClick()
        {
        }
        #endregion

        #region Property

        #region EditorTypeName

        /// <summary>
        ///     只读属性，获取编辑控件名称
        /// </summary>
        public override string EditorTypeName
        {
            get { return CustomEditName; }
        }

        #endregion

        #region 自定义数据源适配器

        /// <summary>
        ///     只读属性，获取自定义数据源适配器
        /// </summary>
        internal CSmartLookUpListDataAdapter CustomDataAdapter
        {
            get { return (CSmartLookUpListDataAdapter)DataAdapter; }
        }

        #endregion

        #endregion

        #region Method

        #endregion

        #region RegisterCustomEdit

        /// <summary>
        ///     静态方法，注册自定义控件
        /// </summary>
        public static void RegisterCustomEdit()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(CustomEditName,
                typeof(CSmartLookUpEditBase), typeof(CSmartRepositoryItemLookupEdit),
                typeof(LookUpEditViewInfo), new ButtonEditPainter(), true));
        }

        #endregion

        #region CreateDataAdapter

        /// <summary>
        ///     重写生成数据源适配器，利用自定义的适配器
        /// </summary>
        /// <returns></returns>
        protected override LookUpListDataAdapter CreateDataAdapter()
        {
            return new CSmartLookUpListDataAdapter(this);
        }

        #endregion

        #region 分配属性

        /// <summary>
        ///     分配属性
        /// </summary>
        /// <param name="item"></param>
        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                var source = item as CSmartRepositoryItemLookupEdit;
                if (source == null) return;
            }
            finally
            {
                EndUpdate();
            }
        }

        #endregion

        #region BindList

        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="list">列表</param>
        /// <param name="displayMember">显示成员</param>
        /// <param name="valueMember">值成员</param>
        /// <param name="autoSearchColumnIndex">自动检索列索引</param>
        public void BindList<T>(List<T> list, string displayMember = null, string valueMember = null, int autoSearchColumnIndex = 0)
        {
            BindList(list, null, displayMember, valueMember, autoSearchColumnIndex);
        }

        /// <summary>
        /// 绑定列表，含列数据
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="list">列表</param>
        /// <param name="columns">列数据</param>
        /// <param name="displayMember">显示成员</param>
        /// <param name="valueMember">值成员</param>
        /// <param name="autoSearchColumnIndex">自动检索列索引</param>
        public void BindList<T>(List<T> list, LookUpColumnInfo[] columns, string displayMember = null, string valueMember = null, int autoSearchColumnIndex = 0)
        {
            DataSource = list;
            if (columns != null)
            {
                Columns.AddRange(columns);
            }
            if (!string.IsNullOrEmpty(displayMember))
            {
                DisplayMember = displayMember;
            }
            if (!string.IsNullOrEmpty(valueMember))
            {
                ValueMember = valueMember;
            }
            AutoSearchColumnIndex = autoSearchColumnIndex;
        }

        #endregion

		private void InitializeComponent()
		{
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

    }

    #endregion

    #region CSmartLookUpListDataAdapter

    /// <summary>
    ///     自定义的数据源适配器
    /// </summary>
    public class CSmartLookUpListDataAdapter : LookUpListDataAdapter
    {
        #region Constractor

        /// <summary>
        ///     构造函数
        /// </summary>
        /// <param name="item">下拉编辑控件</param>
        public CSmartLookUpListDataAdapter(RepositoryItemLookUpEdit item)
            : base(item)
        {
        }

        #endregion

        #region Method

        #region 重新生成过虑表达式

        /// <summary>
        ///     重新生成过虑表达式
        /// </summary>
        /// <returns></returns>
        protected override string CreateFilterExpression()
        {
            if (Item.TextEditStyle != TextEditStyles.Standard) return base.CreateFilterExpression();
            var likeClause = "%" + FilterPrefix + "%";
            var bops = (from LookUpColumnInfo column in Item.Columns select new BinaryOperator(column.FieldName, likeClause, BinaryOperatorType.Like)).ToList();
            return new GroupOperator(GroupOperatorType.Or, bops).ToString();
        }

        #endregion

        #endregion

        #region Property

        #endregion
    }

    #endregion

    #region CSmartLookUpEditBase

    /// <summary>
    ///     联想控件的基类，所有的联想控件都应该使用此类或继承此类
    /// </summary>
    [ToolboxItem(false)]
    public class CSmartLookUpEditBase : LookUpEdit
    {

        #region 初始化

        /// <summary>
        ///     构造函数
        /// </summary>
        static CSmartLookUpEditBase()
        {
            CSmartRepositoryItemLookupEdit.RegisterCustomEdit();
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        protected CSmartLookUpEditBase()
        {
            InitializeComponment();
            InitEvent();
        }

        /// <summary>
        ///     初始化自定义组件
        /// </summary>
        private void InitializeComponment()
        {
            Properties.InitEdit();
			_clearButton = new EditorButton(ButtonPredefines.Clear) { IsDefaultButton = false, Visible = false };
            _comboButton = new EditorButton(ButtonPredefines.Combo) { IsDefaultButton = true };
            _refreshButton = new EditorButton(ButtonPredefines.Redo, "刷新") { IsDefaultButton = false, Visible = false };
            _newButton = new EditorButton(ButtonPredefines.Plus, "新增") { IsDefaultButton = false, Visible = false };
            Properties.Buttons.Clear();
            Properties.Buttons.AddRange(new[]
			{
				_clearButton,
				_comboButton,
				_refreshButton,
                _newButton
			});
            MaximumSize = new System.Drawing.Size(0, 20);
        }

        private void InitEvent()
        {
            ButtonClick += CSmartLookUpEditBase_ButtonClick;
			EditValueChanged += CSmartLookUpEditBase_EditValueChanged;
        }

		#endregion

		#region 编辑器类型名

		/// <summary>
		///     只读属性，获取当前编辑控件类型名
		/// </summary>
		public override string EditorTypeName
		{
			get { return CSmartRepositoryItemLookupEdit.CustomEditName; }
		}

		#endregion

        #region 字段

		private EditorButton _clearButton;
        private EditorButton _comboButton;
        private EditorButton _refreshButton;
        private EditorButton _newButton;

	    private bool _showClearButton = false;

        #endregion

        #region 属性

        /// <summary>
        /// 工具提示
        /// </summary>
        [DefaultValue("")]
        [DXCategory(@"ToolTip")]
        [DXDescription(@"工具提示")]
		[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(UITypeEditor))]
        [Localizable(true)]
        public override string ToolTip
        {
            get
            {
                if (Properties.ReadOnly) return "";
                return @"清除选择:[CTRL + 0]";
            }
            set { base.ToolTip = value; }
        }

        /// <summary>
        /// 子控件属性
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [DXCategory("Properties")]
        [DXDescription("子控件属性")]
        [SmartTagSearchNestedProperties]
        public new CSmartRepositoryItemLookupEdit Properties
        {
            get { return base.Properties as CSmartRepositoryItemLookupEdit; }
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
		[DXCategory("Behavior")]
		[DXDescription("是否显示刷新按钮")]
		[DefaultValue(false)]
		public bool RefreshButton
		{
			get
			{
				var button = GetEditorButton(ButtonPredefines.Redo);
				if (button == null) return false;
				return button.Visible;
			}
			set
			{
				var button = GetEditorButton(ButtonPredefines.Redo);
				if (button == null)
				{
					Properties.Buttons.Add(_refreshButton);
					button = _refreshButton;
				}
				button.Visible = value;
			}
		}

        /// <summary>
        /// 新增按钮
        /// </summary>
        [DXCategory("Behavior")]
		[DXDescription("是否显示新增按钮")]
		[DefaultValue(false)]
        public bool NewButton
		{
			get
			{
				var button = GetEditorButton(ButtonPredefines.Plus);
				if (button == null) return false;
				return button.Visible;
			}
			set
			{
				var button = GetEditorButton(ButtonPredefines.Plus);
				//if (button == null)
				//{
				//	Properties.Buttons.Add(_newButton);
				//	button = _newButton;
				//}
				if (button != null) button.Visible = value;
			}
        }
        /// <summary>
        /// 清空按钮
        /// </summary>
        [DXCategory("Behavior")]
		[DXDescription("是否显示清空按钮")]
		[DefaultValue(true)]
        public bool ClearButton
        {
			get
			{
				return _showClearButton;
			}
	        set
			{
				_showClearButton = value;
		        var clearButton = GetEditorButton(ButtonPredefines.Clear);
				if (clearButton == null)
				{
					Properties.Buttons.Insert(0, _clearButton);
					clearButton = _clearButton;
					Properties.ActionButtonIndex = 1;
				}
				if (_showClearButton && EditValue != null)
				{
					clearButton.Visible = true;
				}
				else
				{
					clearButton.Visible = false;
				}
	        }
        }
        #endregion

        #region 方法

	    protected override DXPopupMenu CreateMenu()
	    {
			var menu = base.CreateMenu();
			var dXMenuItemTextEdit = new DXMenuItemCLookUp("clean", "清除(&C)", OnMenuItemClick, null);
			dXMenuItemTextEdit.UpdateElement = new MenuItemUpdateElement(dXMenuItemTextEdit, OnMenuItemUpdate);
			menu.Items.Insert(0, dXMenuItemTextEdit);
			dXMenuItemTextEdit = new DXMenuItemCLookUp("refresh", "刷新(&R)", OnMenuItemClick, null);
			dXMenuItemTextEdit.UpdateElement = new MenuItemUpdateElement(dXMenuItemTextEdit, OnMenuItemUpdate);
			menu.Items.Insert(1, dXMenuItemTextEdit);
			if(menu.Items.Count > 2) menu.Items[2].BeginGroup = true;
		    return menu;
	    }

	    protected EditorButton GetEditorButton(ButtonPredefines buttonKind)
	    {
			foreach (EditorButton button in Properties.Buttons)
			{
				if (button.Kind == buttonKind) return button;
			}
		    return null;
	    }

        protected override void OnCreateControl()
		{
			var buttonList = Properties.Buttons.Cast<EditorButton>().ToList();
			if (!buttonList.Any()
				|| buttonList.Count(m => m.Kind == ButtonPredefines.Clear) > 1
				|| buttonList.Count(m => m.Kind == ButtonPredefines.Combo) > 1
				|| buttonList.Count(m => m.Kind == ButtonPredefines.Redo) > 1
				|| buttonList.Count(m => m.Kind == ButtonPredefines.Plus) > 1)
			{
				Properties.Buttons.Clear();
				Properties.Buttons.AddRange(new[]
		        {
			        _clearButton,
			        _comboButton,
			        _refreshButton,
			        _newButton 
		        });
				Properties.ActionButtonIndex = 1;
			}
	        if (GetEditorButton(ButtonPredefines.Combo) == null)
	        {
		        if (GetEditorButton(ButtonPredefines.Clear) != null)
		        {
			        Properties.Buttons.Insert(1, _comboButton);
			        Properties.ActionButtonIndex = 1;
		        }
		        else
		        {
					Properties.Buttons.Insert(0, _comboButton);
					Properties.ActionButtonIndex = 0;
		        }
	        }
        }

        /// <summary>
        ///     刷新按钮被单击
        /// </summary>
        protected virtual void OnRefreshButtonClick()
        {
        }
        /// <summary>
        ///     清空按钮被单击
        /// </summary>
        protected virtual void OnClearButtonClick()
        {
	        EditValue = null;
        }
        /// <summary>
        ///     新增按钮被单击
        /// </summary>
        protected virtual void OnNewButtonClick()
        {
        }

	    protected virtual void OnMenuItemClick(object sender, EventArgs e)
	    {
		    var sd = sender as DXMenuItem;
			if (sd == null || sd.Tag == null) return;
			switch (sd.Tag.ToString())
			{
				case "clean":
					OnClearButtonClick();
					break;
				case "refresh":
					OnRefreshButtonClick();
					break;
			}
	    }

		protected virtual void OnMenuItemUpdate(DXMenuItem sender, EventArgs e)
		{
			if (sender == null || sender.Tag == null) return;
			switch (sender.Tag.ToString())
			{
				case "clean":
					sender.Enabled = _clearButton.Visible;
					break;
				case "refresh":
					sender.Enabled = true;
					break;
			}
		}

		#region 事件

		/// <summary>
		///     编辑按钮被单击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CSmartLookUpEditBase_ButtonClick(object sender, ButtonPressedEventArgs e)
		{
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				if (e.Button.Kind == ButtonPredefines.Redo)
				{
					OnRefreshButtonClick();
				}
				if (e.Button.Kind == ButtonPredefines.Plus)
				{
					OnNewButtonClick();
				}
				if (e.Button.Kind == ButtonPredefines.Clear)
				{
					OnClearButtonClick();
				}
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		/// <summary>
		///		编辑内容被改变
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CSmartLookUpEditBase_EditValueChanged(object sender, System.EventArgs e)
		{
			if (!_showClearButton) return;
			var clearButton = GetEditorButton(ButtonPredefines.Clear);
			if (EditValue != null)
			{
				clearButton.Visible = true;
			}
			else
			{
				clearButton.Visible = false;
			}
		}

		#endregion

		#region 扩展查找数据源项方法

		/// <summary>
        ///     扩展查找数据源项的方法
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public object FindItemEx(string text)
        {
            if (string.IsNullOrEmpty(text)) return -1;
            if (!Properties.CaseSensitiveSearch) text = text.ToLower();
            for (var i = 0; i < Properties.CustomDataAdapter.ItemCount; i++)
            {
                for (var j = 0; j < Properties.Columns.VisibleCount; j++)
                {
                    var col = Properties.Columns[j];
                    if (!col.Visible) continue;
                    var itemText = Properties.GetDisplayText(Properties.CustomDataAdapter.GetValueAtIndex(col.FieldName, i));
                    if (!Properties.CaseSensitiveSearch) itemText = itemText.ToLower();
                    if (text == itemText) return Properties.CustomDataAdapter.GetKeyValue(i);
                }
            }
            return -1;
        }

        /// <summary>
        ///     扩展查找数据源项的方法[如果可见的只剩下最后一条，默认选中]
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public object FindItemExSelected(string text)
        {
            if (string.IsNullOrEmpty(text)) return -1;
            if (!Properties.CaseSensitiveSearch) text = text.ToLower();
            for (var i = 0; i < Properties.CustomDataAdapter.ItemCount; i++)
            {
                for (var j = 0; j < Properties.Columns.VisibleCount; j++)
                {
                    var col = Properties.Columns[j];
                    if (!col.Visible) continue;
                    if (Properties.Columns.VisibleCount == 1)
                    {
                        return Properties.CustomDataAdapter.GetKeyValue(i);
                    }
                }
            }
            return -1;
        }

		#endregion

		#region 内部类
		protected class DXMenuItemCLookUp : DXMenuItem
		{
			public MenuItemUpdateElement UpdateElement { get; set; }

			public DXMenuItemCLookUp(string tag, string caption, EventHandler click, Image image)
				: base(caption, click, image)
			{
				Tag = tag;
			}
		}

		protected new class MenuItemUpdateElement
		{
			public readonly MenuItemUpdateHandler UpdateMenuItemDelegate;

			public readonly DXMenuItemCLookUp Item;

			public MenuItemUpdateElement(DXMenuItemCLookUp item, MenuItemUpdateHandler updateMenuItemDelegate)
			{
				Item = item;
				UpdateMenuItemDelegate = updateMenuItemDelegate;
			}

			public void DoUpdate()
			{
				if (UpdateMenuItemDelegate != null)
				{
					UpdateMenuItemDelegate.DynamicInvoke(Item, EventArgs.Empty);
				}
			}
		}

		#endregion

        #endregion
    }

    #endregion


    #region CSmartTreeListLookUpEditBase

    /// <summary>
    ///     联想控件的基类，所有的联想控件都应该使用此类或继承此类
    /// </summary>
    [ToolboxItem(false)]
    public class CSmartTreeListLookUpEditBase : TreeListLookUpEdit
    {

        #region Constractor

        /// <summary>
        ///     构造函数
        /// </summary>
        static CSmartTreeListLookUpEditBase()
        {
            CSmartRepositoryItemLookupEdit.RegisterCustomEdit();
        }

        /// <summary>
        ///     构造函数
        /// </summary>
        protected CSmartTreeListLookUpEditBase()
        {
            InitializeComponment();
            InitEvent();
        } 
        /// <summary>
        ///     初始化自定义组件
        /// </summary>
        private void InitializeComponment()
        {  
            _comboButton = new EditorButton(ButtonPredefines.Combo) { IsDefaultButton = true };
            _refreshButton = new EditorButton(ButtonPredefines.Redo, "刷新") { IsDefaultButton = false, Visible = true };
            _newButton = new EditorButton(ButtonPredefines.Plus, "新增") { IsDefaultButton = false, Visible = true };
            Properties.Buttons.Clear();
            Properties.Buttons.AddRange(new[]
			{
				_comboButton,
				_refreshButton,
                _newButton
			});
            MaximumSize = new System.Drawing.Size(0, 20);
        }

        private void InitEvent()
        {
            Properties.TreeList.OptionsView.ShowHorzLines = false;
            Properties.TreeList.OptionsView.ShowVertLines = false;
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
          
            Properties.TreeList.OptionsView.ShowIndentAsRowStyle = true;
            Properties.TreeList.OptionsView.ShowPreview = true;
            
            ButtonClick += CSmartTreeListLookUpEditBase_ButtonClick;
        }

        #endregion

        #region Field/Control

        private EditorButton _comboButton;
        private EditorButton _refreshButton;
        private EditorButton _newButton;

        #endregion

        #region Property

        /// <summary>
        /// 工具提示
        /// </summary>
        //[DefaultValue("")]
        //[DXCategory("ToolTip")]
        //[DXDescription("工具提示")]
        //[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        //[Localizable(true)]
        //public override string ToolTip
        //{
        //    get
        //    {
        //        if (Properties.ReadOnly) return "";
        //        return "清除选择:[CTRL + 0]";
        //    }
        //    set { base.ToolTip = value; }
        //}

       

        /// <summary>
        /// 刷新按钮
        /// </summary>
        [DXCategory("Behavior")]
        [DXDescription("是否显示刷新按钮")]
        public bool RefreshButton
        {
            get { return _refreshButton.Visible; }
            set { _refreshButton.Visible = value; }
        }
        /// <summary>
        /// 新增按钮
        /// </summary>
        [DXCategory("Behavior")]
        [DXDescription("是否显示新增按钮")]
        public bool NewButton
        {
            get { return _newButton.Visible; }
            set { _newButton.Visible = value; }
        }
        #endregion

        #region Method

        protected override void OnCreateControl()
        {
            if (Properties.Buttons.Count == 0)
            {
                Properties.Buttons.AddRange(new[]
				{
					_comboButton,
					_refreshButton,
                    _newButton
				});
            }
        }

        /// <summary>
        ///     编辑按钮被单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CSmartTreeListLookUpEditBase_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (e.Button.Kind == ButtonPredefines.Redo)
                {
                    OnRefreshButtonClick();
                }
                if (e.Button.Kind == ButtonPredefines.Plus)
                {
                    OnNewButtonClick();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            } 
        }

        /// <summary>
        ///     刷新按钮被单击
        /// </summary>
        protected virtual void OnRefreshButtonClick()
        {
        }
        /// <summary>
        ///     新增按钮被单击
        /// </summary>
        protected virtual void OnNewButtonClick()
        {
        }
        
        #region EditorTypeName
 
        #endregion

        #region FindItemEx
 

        

        #endregion

        #endregion
    }

    #endregion



}