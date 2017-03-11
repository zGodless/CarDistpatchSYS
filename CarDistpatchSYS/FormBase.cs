using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CarDistpatchSYS;
using DevExpress.Utils.Drawing.Helpers;
using DS.MSClient.UIControl;
using DevExpress.XtraEditors;

namespace DS.MSClient
{
	public partial class FormBase : XtraForm
	{
		#region 初始化

		/// <summary>
		/// 基本窗体
		/// </summary>
		public FormBase()
		{
			InitializeComponent();
			InitEvent();
			StartPosition = FormStartPosition.CenterParent;
		}

		/// <summary>
		/// 初始化事件
		/// </summary>
		private void InitEvent()
		{
			//初始化
			Load += FormBase_Load;
		}

		#endregion

		#region 属性
        /// <summary>
        /// 线程中的Exception
        /// </summary>
        public static Exception ThreadException { get; set; }
		/// <summary>
		/// 获取或设置是否启用 Show 方法的 CenterParent 功能
		/// </summary>
		[CategoryAttribute("外观")]
		[DescriptionAttribute("是否启用 Show 方法的 CenterParent 功能")]
		public bool AlwaysCanCenterParent
		{
			get { return alwaysCanCenterParent; }
			set { alwaysCanCenterParent = value; }
		}

		/// <summary>
		/// 获取或设置初始化时是否最大化
		/// </summary>
		[CategoryAttribute("外观")]
		[DescriptionAttribute("初始化时是否最大化")]
		public bool InitMaxize
		{
			get { return initMaxize; }
			set { initMaxize = value; }
		}

		/// <summary>
		/// 获取或设置窗体操作状态
		/// </summary>
		[CategoryAttribute("外观")]
		[DescriptionAttribute("窗体操作状态")]
		public FormState FormState
		{
			get { return formState; }
			set { formState = value; }
		}

		private bool _isDialog = false;
		private DialogResult _dialogResult = DialogResult.None;

		/// <summary>
		/// 对话框返回值
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DialogResult DialogResult
		{
			get { return _dialogResult; }
			set
			{
				_dialogResult = value;
				if (_isDialog) Close();
			}
		}

		#endregion


		#region 方法(显示操作)

		/// <summary>
		/// 向用户显示具有指定所有者的窗体
		/// </summary>
		/// <param name="owner">所有者</param>
		/// <param name="disableOwner">是否禁用所有者</param>
		public void Show(IWin32Window owner, bool disableOwner)
		{
			Show(owner);
			FormClosedEventHandler closedEvent = (s, e) =>
			{
				if (disableOwner && Owner != null) Owner.Enabled = true;
			};
			if (disableOwner && Owner != null) Owner.Enabled = false;
			FormClosed += closedEvent;
		}

		/// <summary>
		/// 将窗体显示为具有指定所有者的模式对话框
		/// (本方法不锁定上级窗体线程)
		/// </summary>
		/// <param name="owner">所有者</param>
		public new DialogResult ShowDialog(IWin32Window owner)
		{
			return ShowDialog(owner as Control);
		}

		/// <summary>
		/// 将窗体显示为具有指定所有者的模式对话框
		/// (本方法不锁定上级窗体线程)
		/// </summary>
		/// <param name="owner">所有者</param>
		public DialogResult ShowDialog(Control owner)
		{
			FormBase parent = null;
			if (owner is BaseUserControl)
			{
				var parentForm = owner.Parent;
				while (!(parentForm is FormBase))
				{
					if (parentForm == null) break;
					parentForm = parentForm.Parent;
				}
				if (parentForm != null)
				{
					parent = parentForm as FormBase;
				}
			}
			else
			{
				var parentForm = owner as FormBase;
				if (parentForm != null)
				{
					parent = parentForm;
				}
			}
			if (parent == null)
			{
				throw new Exception("传入所有者对象无效！");
			}
			Owner = parent;
			var isClosed = false;
			FormClosedEventHandler closedEvent = (s, e) =>
			{
				isClosed = true;
			};
			FormClosed += closedEvent;
			_isDialog = true;
			Show();
			owner.Enabled = false;
			NativeMethods.SetWindowPos(parent.Handle, Handle, 0, 0, 0, 0, 0x0001 | 0x0002);
			while (!isClosed)
			{
				Application.DoEvents();
			}
			_isDialog = false;
			owner.Enabled = true;
			parent.Activate();
			NativeMethods.SetWindowPos(parent.Handle, new IntPtr(0), 0, 0, 0, 0, 0x0001 | 0x0002 | 0x0040);
			FormClosed -= closedEvent;
			return DialogResult;
		}

		/// <summary>
		/// 显示在父窗体中央
		/// </summary>
		private void ShowInCenterParent()
		{
			if (!DesignMode && alwaysCanCenterParent)
			{
				if (Owner == null) return;

				//使CenterParent在Show下也生效
				if (StartPosition == FormStartPosition.CenterParent && !Modal)
				{
					Location = new Point(Owner.Width / 2 - this.Width / 2 + Owner.Location.X, Owner.Height / 2 - Height / 2 + Owner.Location.Y);
				}
			}
		}

		#endregion

		#region 方法

		#endregion

		#region 事件

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormBase_Load(object sender, EventArgs e)
		{
			ShowInCenterParent();
			if (DesignMode) return;
		}

		#endregion
        /// <summary>
        /// 重载，防止加载mdi子窗体时闪现标题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
				if (!DesignMode) cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        /// <summary>
        /// 防止打开多个窗体
        /// </summary>
        /// <param name="p_ChildrenFormText"></param>
        /// <returns></returns>
        public bool ShowChildrenForm(string childrenFormName)
        {
            int i;
            //依次检测当前窗体的子窗体
            for (i = 0; i < this.MdiChildren.Length; i++)
            {
                //判断当前子窗体的Text属性值是否与传入的字符串值相同
                if (this.MdiChildren[i].Name == childrenFormName)
                {
                    //如果值相同则表示此子窗体为想要调用的子窗体，激活此子窗体并返回true值
                    this.MdiChildren[i].Activate();
                    return true;
                }
            }
            //如果没有相同的值则表示要调用的子窗体还没有被打开，返回false值
            return false;
        }
	}

	/// <summary>
	/// 窗体操作状态枚举
	/// </summary>
	public enum FormState
	{
		/// <summary>
		/// 正常
		/// </summary>
		Normal,

		/// <summary>
		/// 新增
		/// </summary>
		New,

		/// <summary>
		/// 修改
		/// </summary>
		Modify,

		/// <summary>
		/// 复制
		/// </summary>
		Copy
	}
}