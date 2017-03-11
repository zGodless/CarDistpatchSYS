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
    public partial class FormEditDepartment : FormBase
    {
        #region 初始化
        public FormEditDepartment()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += FormEditDepartment_Load;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
            textDepartmentName.EditValueChanged += textDepartmentName_EditValueChanged;
        }

        void textDepartmentName_EditValueChanged(object sender, EventArgs e)
        {
            textDepartmentCode.EditValue = ChineseUtil.ToPyLetters(textDepartmentName.Text.Trim());
        }

        void FormEditDepartment_Load(object sender, EventArgs e)
        {
            cLInChargeID.BindList();
            clParentID.BindList();
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

        public Department curData = new Department();

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
            if (textDepartmentName.EditValue == null)
            {
                MessageBox.Show("请输入部门名称");
                return;
            }
            Department model = new Department

            {
                DepartmentName = textDepartmentName.EditValue.ToString(),
                DepartmentCode = textDepartmentCode.EditValue.ToString(),
                EmployeeCount = ValueConvert.ToNullableInt32(textEmployeeCount.EditValue),
                InChargeID = ValueConvert.ToNullableInt32(cLInChargeID.EditValue),
                ParentID = ValueConvert.ToNullableInt32(clParentID.EditValue),
                Note = memoNote.Text.Trim(),
                OperateID = Program.CurrentEmployee.EmployeeID,
                OperateTime = DateTime.Now
            };
            bool result = false;
            if (FormState == DS.MSClient.FormState.Modify)
            {
                model.DepartmentID = curData.DepartmentID;
                result = new DepartmentDao().Update(model);
            }
            else
            {
                model.DepartmentID = new CommonDAO().GetIntUniqueNumber("t_department");
                result = new DepartmentDao().Add(model);
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
            textDepartmentName.EditValue = ValueConvert.ToString(curData.DepartmentName);
            textDepartmentCode.EditValue = ValueConvert.ToString(curData.DepartmentCode);
            textEmployeeCount.EditValue = ValueConvert.ToString(curData.EmployeeCount);

            cLInChargeID.EditValue = ValueConvert.ToNullableInt32(curData.InChargeID);
            clParentID.EditValue = ValueConvert.ToNullableInt32(curData.ParentID);

            memoNote.EditValue = ValueConvert.ToString(curData.Note);
        }
        #endregion
    }
}
