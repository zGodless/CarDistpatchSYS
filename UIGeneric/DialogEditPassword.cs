using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DS.Data;
using DS.MSClient.UICommon;
using QuickFrame.Common.Crypt;

namespace DS.MSClient.UIGeneric
{
    public partial class DialogEditPassword : FormDlgBase
	{
		#region 初始化
		public DialogEditPassword()
        {
            InitializeComponent();
            InitEvent();
            Init();
        }
        private void InitEvent()
        {
			ButtonOK.Click += ButtonOK_Click;
			btnCancel.Click += btnCancel_Click;
        }

        private void Init()
        {
        }
        
        #endregion 初始化

        #region 属性

        #endregion 属性

		#region 事件

		private void ButtonOK_Click(object sender, EventArgs e)
		{
			if (CheckPassword())
			{
                string password = Program.CurrentEmployee.Password;
                Program.CurrentEmployee.Password = Salt.Encrypt(txt_NewPassword.Text.Trim());
                if (new EmployeeDao().UpdatePWD(Program.CurrentEmployee))
                {
                    MsgBox.ShowInfo("密码修改成功");
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MsgBox.ShowInfo("密码修改失败");
                }
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        #endregion 事件

        #region 方法
        /// <summary>
        /// 
        /// </summary>
        private bool CheckPassword()
		{
			var password = txt_Password.Text.Trim();
			if (password == "")
			{
				MsgBox.ShowInfo("旧密码不能为空");
				return false;
			}
            var dictpass = new EmployeeDao().GetModel(Program.CurrentEmployee.EmployeeID);
            if (Salt.Encrypt(password).Equals(dictpass.Password))
            {
                if (txt_NewPassword.Text.Trim() == "")
                {
                    MsgBox.ShowInfo("新密码不能为空");
                    return false;
                }
                else if (txt_NewPassword.Text.Trim() != txt_NewPassword2.Text.Trim())
                {
                    MsgBox.ShowInfo("两次输入的密码不相同，请重新输入");
                    return false;
                }
                return true;
            }
            else
            {
                MsgBox.ShowInfo("原密码不正确");
                return false;
            }
            return true;
        }
        #endregion 方法
	}
}
