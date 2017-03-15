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
    public partial class FormEditDispathAudit : FormBase
    {
        #region 初始化
        public FormEditDispathAudit()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += FormEditDispathApply_Load;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        void FormEditDispathApply_Load(object sender, EventArgs e)
        {
            cLCarID.BindList();
            cLookEmployee.BindList();
            if (FormState == DS.MSClient.FormState.Modify) //编辑
            {
                if (curData == null)
                {
                    DialogResult = DialogResult.Cancel;
                }
                else
                {
                    BindDate();
                }
            }
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
            CarDispatchAudit model = new CarDispatchAudit

            {
                AuditID = new CommonDAO().GetIntUniqueNumber("t_car_dispatch_audit"),
                DispatchID = curData.DispatchID,
                EmployeeID = Program.CurrentEmployee.EmployeeID,
                CarID = curData.CarID,
                AuditDate = ValueConvert.ToDateTime(dateApplyDate.EditValue),
                Result = radioGroup1.SelectedIndex == 0 ? "通过" : "退回",
                Note = memoNote.Text,
                OperatorID = Program.CurrentEmployee.EmployeeID,
                OperateTime = DateTime.Now
            };
            bool result = new CarDispatchAuditDao().Add(model);

            if (result)
            {
                //更新状态
                if (model.Result == "通过")
                {
                    new CarDispatchAuditDao().UpdateState(ValueConvert.ToInt32(curData.DispatchID), model.Result);
                    new CarDispatchDao().UpdateAuditDate(model);
                }
                MessageBox.Show("保存成功");
                this.DialogResult = DialogResult.OK;
            }
        }



        #endregion

        #region 方法

        private void BindDate()
        {
            cLookEmployee.EditValue = curData.EmployeeID;
            cLCarID.EditValue = curData.CarID;
            dateApplyDate.EditValue = curData.ApplyDate;
            datePlaceBackDate.EditValue = curData.PlaceBackDate;
            memoDispatchReason.EditValue = curData.DispatchReason;
        }
        #endregion
    }
}
