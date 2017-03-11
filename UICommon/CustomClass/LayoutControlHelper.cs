using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DS.MSClient.UICommon
{
    public class LayoutControlHelper
    {
        /// <summary>
        /// 注册layoutcontrol容器内控件值修改事件,辅助检查是否变更了控件值
        /// </summary>
        /// <param name="layoutControl"></param>
        public static void RegisterModifiedEvent(DevExpress.XtraLayout.LayoutControl layoutControl)
        {
            try
            {
                foreach (Control control in layoutControl.Controls)
                {
                    if (control is BaseEdit)
                    {
                        ((BaseEdit)control).Modified += control_Modified;
                    }
                }
            }
            catch  
            {
                 
            }
        }

        /// <summary>
        /// 控件值被修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void control_Modified(object sender, EventArgs e)
        {
            try
            {
                BaseEdit baseEdit = sender as BaseEdit;
                baseEdit.Parent.Tag = 1; //父容器layout设置tag值1，表示容器内控件值改变
            }
            catch
            {

            }
        }
    }
}
