using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DS.Data;
using DS.MSClient;
using QuickFrame.Common.Converter;
using QuickFrame.Common.Crypt;
using QuickFrame.Common.Text;

namespace CarDistpatchSYS
{
    public partial class FormChangePassword : FormBase
    {
        #region 初始化
        public FormChangePassword()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += FormChangePassword_Load;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        void FormChangePassword_Load(object sender, EventArgs e)
        {
            if (curData != null)
            {
                oldPassword = curData.Password;
            }
        }


      

        #endregion


        #region 属性

        public Employee curData = new Employee();
        public string oldPassword;

        #endregion

        #region 事件
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 确认保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(oldPassword))
            {
                if (string.IsNullOrEmpty(ValueConvert.ToString(textOld.EditValue)))
                {
                    MessageBox.Show("请输入原密码");
                    return;
                }
                string old = Salt.Encrypt(ValueConvert.ToString(textOld.EditValue));
                if (old != oldPassword)
                {
                    MessageBox.Show("原密码错误！");
                    return;
                }
                string newPassword1 = ValueConvert.ToString(textNow1.EditValue);
                string newPassword2 = ValueConvert.ToString(textNow2.EditValue);
                if (newPassword1 != newPassword2)
                {
                    MessageBox.Show("两次输入新密码需相同！");
                    return;
                }
                string newPassword = Salt.Encrypt(newPassword1);
                if (new EmployeeDao().ChangePassword(newPassword, curData.EmployeeID))
                {
                    MessageBox.Show("密码修改成功！");
                    this.DialogResult = DialogResult.OK;
                }
            }
        }



        #endregion

        #region 方法

        #endregion
    }
}
