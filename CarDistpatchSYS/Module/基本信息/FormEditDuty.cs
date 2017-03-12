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
    public partial class FormEditDuty : FormBase
    {
        #region 初始化
        public FormEditDuty()
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
            textDutyName.EditValueChanged += textDepartmentName_EditValueChanged;
        }

        void textDepartmentName_EditValueChanged(object sender, EventArgs e)
        {
            textMnemonicCode.EditValue = ChineseUtil.ToPyLetters(textDutyName.Text.Trim());
        }

        void FormEditDepartment_Load(object sender, EventArgs e)
        {
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

        public Duty curData = new Duty();

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
            if (textDutyName.EditValue == null)
            {
                MessageBox.Show("请输入部门名称");
                return;
            }
            Duty model = new Duty

            {
                DutyName = textDutyName.EditValue.ToString(),
                DutyCode = textDutyCode.EditValue.ToString(),
                MnemonicCode = ValueConvert.ToString(textMnemonicCode.EditValue),
                Note = memoNote.Text.Trim(),
                OperateID = Program.CurrentEmployee.EmployeeID,
                OperateTime = DateTime.Now
            };
            bool result = false;
            if (FormState == DS.MSClient.FormState.Modify)
            {
                model.DutyID = curData.DutyID;
                result = new DutyDao().Update(model);
            }
            else
            {
                model.DutyID = new CommonDAO().GetIntUniqueNumber("t_duty");
                result = new DutyDao().Add(model);
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
            textDutyName.EditValue = ValueConvert.ToString(curData.DutyName);
            textDutyCode.EditValue = ValueConvert.ToString(curData.DutyCode);
            textMnemonicCode.EditValue = ValueConvert.ToString(curData.MnemonicCode);

            memoNote.EditValue = ValueConvert.ToString(curData.Note);
        }
        #endregion
    }
}
