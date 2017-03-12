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

namespace CarDistpatchSYS
{
    public partial class FormEditEmployee : FormBase
    {
        #region 初始化
        public FormEditEmployee()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += FormEditEmployee_Load;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }

        void FormEditEmployee_Load(object sender, EventArgs e)
        {
            clDepartmentID.BindList();
            if (FormState == DS.MSClient.FormState.Modify) //编辑
            {
                if (curData == null)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    BindDate();
                }
            }
        }


        #endregion


        #region 属性

        public Employee curData = new Employee();

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
            if (textEmployeeName.EditValue == null)
            {
                MessageBox.Show("请输入姓名");
                return;
            }
            if (textEmployeeCode.EditValue == null)
            {
                MessageBox.Show("请输入工号");
                return;
            }
            Employee model = new Employee
            {
                EmployeeCode = textEmployeeCode.Text.Trim(),
                EmployeeName = ValueConvert.ToString(textEmployeeName.EditValue),
                DepartmentID = ValueConvert.ToNullableInt32(clDepartmentID.EditValue),
                Email = textEmail.Text.Trim(),
                IdentityNo = textIdentityNo.Text.Trim(),
                DimissionDate = ValueConvert.ToNullableDateTime(dateDimissionDate.EditValue),
                QQ = ValueConvert.ToString(textQQ.EditValue),
                EntryDate = ValueConvert.ToNullableDateTime(dateEntryDate.EditValue),
                Sex = comSex.Text.Trim(),
                Birthday = ValueConvert.ToNullableDateTime(dateBirthday.EditValue),
                Degree = comDegree.Text.Trim(),
                Cellphone = ValueConvert.ToString(textCellphone.EditValue),
                Note = ValueConvert.ToString(memoNote.EditValue),
                OperateID = Program.CurrentEmployee.EmployeeID,
                OperateTime = DateTime.Now
            };
            if (!string.IsNullOrEmpty(comStatus.SelectedIndex.ToString()))
            {
                model.Status = comStatus.SelectedIndex;
            }
            bool result = false;
            if (FormState == DS.MSClient.FormState.Modify)
            {
                model.EmployeeID = curData.EmployeeID;
                result = new EmployeeDao().Update(model);
            }
            else
            {
                model.EmployeeID = new CommonDAO().GetIntUniqueNumber("t_employee");
                result = new EmployeeDao().Add(model);
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
            textEmployeeCode.EditValue = ValueConvert.ToString(curData.EmployeeCode);
            textEmployeeName.EditValue = ValueConvert.ToString(curData.EmployeeName);
            textIdentityNo.EditValue = ValueConvert.ToString(curData.IdentityNo);
            textAddress.EditValue = ValueConvert.ToString(curData.Address);
            textEmail.EditValue = ValueConvert.ToString(curData.Email);
            textQQ.EditValue = ValueConvert.ToString(curData.QQ);
            textCellphone.EditValue = ValueConvert.ToString(curData.Cellphone);
            comSex.EditValue = curData.Sex == "男" ? 0 : 1;
            comDegree.EditValue = curData.Degree;

            dateBirthday.EditValue = ValueConvert.ToNullableDateTime(curData.Birthday);
            dateEntryDate.EditValue = ValueConvert.ToNullableDateTime(curData.EntryDate);
            dateDimissionDate.EditValue = ValueConvert.ToNullableDateTime(curData.DimissionDate);

            clDepartmentID.EditValue = ValueConvert.ToNullableInt32(curData.DepartmentID);

            if (curData.Status != null)
            {
                comStatus.SelectedIndex = ValueConvert.ToInt32(curData.Status.Value);
            }
            memoNote.EditValue = ValueConvert.ToString(curData.Note);
        }
        #endregion
    }
}
