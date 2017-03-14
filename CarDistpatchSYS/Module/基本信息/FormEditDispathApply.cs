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
using QuickFrame.Common.Text;

namespace CarDistpatchSYS
{
    public partial class FormEditDispathApply : FormBase
    {
        #region 初始化
        public FormEditDispathApply()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
        }



        #endregion


        #region 属性

        public CarDispatchApply curData = new CarDispatchApply();

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
        }



        #endregion

        #region 方法

        private void BindDate()
        {
        }
        #endregion
    }
}
