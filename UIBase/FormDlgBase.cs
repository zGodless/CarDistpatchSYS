using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DS.MSClient
{
    public partial class FormDlgBase : FormBase
    {
        #region 初始化

        /// <summary>
        /// 基本对话框
        /// </summary>
        public FormDlgBase()
        {
            InitializeComponent();

        }

        #endregion

        #region 属性

        [Category("按钮")]
        [Description("确定按钮")]
        public SimpleButton ButtonOK
        {
            get { return btnOK; }
        }

        [Category("按钮")]
        [Description("取消按钮")]
        public SimpleButton ButtonCancel
        {
            get { return btnCancel; }
        }

        #endregion
    }
}