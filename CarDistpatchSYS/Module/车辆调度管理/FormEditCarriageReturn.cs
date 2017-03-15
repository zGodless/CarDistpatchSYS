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
    public partial class FormEditCarriageReturn : FormBase
    {
        #region 初始化
        public FormEditCarriageReturn()
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
            else
            {
                if (curData != null)
                {
                    BindDate();
                }
            }
        }



        #endregion


        #region 属性

        public CarriageReturn curData = new CarriageReturn();

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
                MessageBox.Show("请输入登记人！");
                return;
            }
            if (cLCarID.EditValue == null)
            {
                MessageBox.Show("请选择车辆！");
                return;
            }
            if (dateReturnDate.EditValue == null)
            {
                MessageBox.Show("请输入回车日期！");
                return;
            }
            CarriageReturn model = new CarriageReturn

            {
                EmployeeID = ValueConvert.ToInt32(cLookEmployee.EditValue),
                CarID = ValueConvert.ToInt32(cLCarID.EditValue),
                ReturnDate = ValueConvert.ToDateTime(dateReturnDate.EditValue),
                Note = memoDispatchReason.Text,
                OperatorID = Program.CurrentEmployee.EmployeeID,
                OperateTime = DateTime.Now
            };
            bool result = false;
            if (FormState == DS.MSClient.FormState.Modify)
            {
                model.ReturnID = curData.ReturnID;
                model.DispatchID = curData.DispatchID;
                result = new CarriageReturnDao().Update(model);
            }
            else
            {
                model.ReturnID = new CommonDAO().GetIntUniqueNumber("t_carriage_return");
                model.DispatchID = curData.DispatchID;
                result = new CarriageReturnDao().Add(model);
            }
            if (result)
            {
                new CarDispatchDao().UpdateReturnDate(model);
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
            dateReturnDate.EditValue = curData.ReturnDate;
            memoDispatchReason.EditValue = curData.Note;
        }
        #endregion
    }
}
