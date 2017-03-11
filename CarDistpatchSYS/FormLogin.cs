using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using QuickFrame.Common.Converter;
using QuickFrame.DbConnector;
using DS.Data;
using QuickFrame.Model;
using MySql.Data;
using MySql.Data.MySqlClient;
using QuickFrame.Common.Configuration;
using QuickFrame.Common.Crypt;


namespace CarDistpatchSYS
{
    public partial class FormLogin : XtraForm
    {
        #region 初始化
        public FormLogin()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += FormLogin_Load;

            MouseDown += Login_MouseDown;
            //登陆
            BtnLogin.Click += btnLogin_Click;
            //取消，关闭窗体
            BtnClose.Click += btnClose_Click;

            //回车
            textPassWord.KeyPress += txtPassword_KeyPress;
        }
        #endregion


        #region 属性

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        //窗体移动属性
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        //发送消息
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        #endregion

        #region 事件
        void FormLogin_Load(object sender, EventArgs e)
        {
            textUserName.Text = Ini.ReadItem("Login", "UserName");
        }
        /// <summary>
        ///     窗体移动事件
        /// </summary>
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left) //只有左键才能移动
                {
                    ReleaseCapture(); //捕获鼠标
                    //发送消息
                    SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
                }
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        ///     登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var userName = textUserName.Text = textUserName.Text.Trim();
                var password = textPassWord.Text = textPassWord.Text.Trim();
                if (userName == "" || password == "")
                {
                    MessageBox.Show("用户名或密码不能为空！");
                    return;
                }

                var user = new Employee
                {
                    EmployeeCode = userName,
                    Password = Salt.Encrypt(password)
                };
                
                try
                {
                    string sqlLogin = string.Format("select * from t_employee where EmployeeCode like '%{0}%'", ValueConvert.ToString(textUserName.EditValue));
                    List<Employee> _list = new EmployeeDao().QueryGetList(sqlLogin);
                    if (!_list.Any())
                    {
                        MessageBox.Show("用户不存在！");
                        return;
                    }
                    else
                    {
                        Employee model = _list[0];
                        if (model.Password == user.Password) //密码验证正确
                        {
                            Program.CurrentEmployee = model;    //当前用户

                            Ini.WriteItem("Login", "UserName", textUserName.Text.Trim());
                            FormMain form = new FormMain();
                            form.Show();
                        }
                        else
                        {
                            MessageBox.Show("密码错误！");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }  
        }
        /// <summary>
        ///     取消，关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Application.Exit();
        }

        /// <summary>
        ///     回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                btnLogin_Click(sender, e);
            }
        }
        #endregion
    }
}
