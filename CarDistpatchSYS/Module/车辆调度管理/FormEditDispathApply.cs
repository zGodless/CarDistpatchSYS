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
            if (cLookEmployee.EditValue == null)
            {
                MessageBox.Show("请输入申请人！");
                return;
            }
            if (cLCarID.EditValue == null)
            {
                MessageBox.Show("请选择车辆！");
                return;
            }
            if (dateApplyDate.EditValue == null)
            {
                MessageBox.Show("请输入申请日期！");
                return;
            }
            if (datePlaceBackDate.EditValue == null)
            {
                MessageBox.Show("请输入预计回车日期！");
                return;
            }
            if (memoDispatchReason.EditValue == null)
            {
                MessageBox.Show("请输入申请理由！");
                return;
            }
            CarDispatchApply model = new CarDispatchApply

            {
                EmployeeID = ValueConvert.ToInt32(cLookEmployee.EditValue),
                CarID = ValueConvert.ToInt32(cLCarID.EditValue),
                ApplyDate = ValueConvert.ToDateTime(dateApplyDate.EditValue),
                DispatchReason = memoDispatchReason.Text,
                PlaceBackDate = ValueConvert.ToDateTime(datePlaceBackDate.EditValue),
                Status = 1,
                OperatorID = Program.CurrentEmployee.EmployeeID,
                OperateTime = DateTime.Now
            };
            bool result = false;
            if (FormState == DS.MSClient.FormState.Modify)
            {
                model.ApplyID = curData.ApplyID;
                model.DispatchID = curData.DispatchID;
                result = new CarDispatchApplyDao().Update(model);
            }
            else
            {
                CarDispatch modelDis = new CarDispatch
                {
                    DispatchID = new CommonDAO().GetIntUniqueNumber("t_car_dispatch"),
                    EmployeeID = ValueConvert.ToInt32(cLookEmployee.EditValue),
                    DispatchReason = memoDispatchReason.Text,
                    CarID = ValueConvert.ToInt32(cLCarID.EditValue),
                    ApplyDate = ValueConvert.ToDateTime(dateApplyDate.EditValue),
                    PlaceBackDate = ValueConvert.ToDateTime(datePlaceBackDate.EditValue),
                    Status = 0,
                    OperatorID = Program.CurrentEmployee.EmployeeID,
                    OperateTime = DateTime.Now
                };
                if (new CarDispatchDao().Add(modelDis))
                {
                    model.ApplyID = new CommonDAO().GetIntUniqueNumber("t_car_dispatch_apply");
                    model.DispatchID = modelDis.DispatchID;
                    result = new CarDispatchApplyDao().Add(model);
                    
                }
            }
            if (result)
            {
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
