using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DS.Data;
using DS.Model;

namespace DS.MSClient.UICommon
{
    public partial class FormSelectStudent : FormBase
    {
        public FormSelectStudent()
        {
            InitializeComponent();
            this.Init();
        }
        #region 初始化
        void Init()
        {
            this.cLookUpStudent.BindList();
            this.simpleButton_no.Click += simpleButton_no_Click;
            this.simpleButton_yes.Click += simpleButton_no_Click;
        }
        #endregion
        #region 属性
        public int studid = 0;
        #endregion
        #region 事件
        void simpleButton_no_Click(object sender, EventArgs e)
        {
            if(sender==simpleButton_no)
            {
                this.Close();
            }
            else if(sender==simpleButton_yes)
            {
                studid = Convert.ToInt32(cLookUpStudent.EditValue);
                if (studid == 0)
                {
                    MsgBox.ShowInfo("请选择一个学员进行关联");
                }
                this.DialogResult = DialogResult.Yes;
            }
        }
        #endregion
    }
}
