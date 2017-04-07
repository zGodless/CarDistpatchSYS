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
using DevExpress.Utils;
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
            radioGroup1.SelectedIndexChanged += radioGroup1_SelectedIndexChanged;
            checkEdit1.Click += checkEdit1_Click;
            checkEdit2.Click += checkEdit2_Click;
            checkEdit3.Click += checkEdit3_Click;
        }

        void checkEdit3_Click(object sender, EventArgs e)
        {
            textEdit1.Properties.ReadOnly = false;
            textEdit2.Properties.ReadOnly = false;
            textEdit3.Properties.ReadOnly = false;
            textEdit4.Properties.ReadOnly = false;
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
        }

        void checkEdit2_Click(object sender, EventArgs e)
        {
            textEdit1.Properties.ReadOnly = true;
            textEdit2.Properties.ReadOnly = true;
            textEdit3.Properties.ReadOnly = true;
            textEdit4.Properties.ReadOnly = true;
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
        }

        void checkEdit1_Click(object sender, EventArgs e)
        {
            textEdit1.Properties.ReadOnly = true;
            textEdit2.Properties.ReadOnly = true;
            textEdit3.Properties.ReadOnly = true;
            textEdit4.Properties.ReadOnly = true;
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";
            textEdit4.Text = "";
        }

        void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
            {
                cLCarNo.Properties.ReadOnly = false;
                comCarModel.Properties.ReadOnly = true;
                comCarModel.Text = "";
            }
            else
            {
                cLCarNo.Properties.ReadOnly = true;
                comCarModel.Properties.ReadOnly = false;
                cLCarNo.Text = "";
            }
        }

        void FormEditDispathApply_Load(object sender, EventArgs e)
        {
            dateApply.Properties.VistaEditTime = DefaultBoolean.True;
            datePlaceBackDate.Properties.VistaEditTime = DefaultBoolean.True;
            cLCarNo.BindList();
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
                cLookEmployee.EditValue = Program.CurrentEmployee.EmployeeID;
                dateOperateTime.EditValue = DateTime.Now;
                radioGroup1.SelectedIndex = 0;

                //驾驶员
                checkEdit1.Checked = true;
                checkEdit2.Checked = false;
                checkEdit3.Checked = false;
                comCarModel.Properties.ReadOnly = true;
                textEdit1.Properties.ReadOnly = true;
                textEdit2.Properties.ReadOnly = true;
                textEdit3.Properties.ReadOnly = true;
                textEdit4.Properties.ReadOnly = true;

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
            if (dateOperateTime.EditValue == null)
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
            if (checkEdit3.Checked)
            {
                if (string.IsNullOrEmpty(textEdit1.Text.Trim()) || string.IsNullOrEmpty(textEdit2.Text.Trim()) ||
                    string.IsNullOrEmpty(textEdit3.Text.Trim()) || string.IsNullOrEmpty(textEdit4.Text.Trim()))
                {
                MessageBox.Show("请完善社会人员信息！");
                return;
                }
            }
            CarDispatchApply model = new CarDispatchApply

            {
                EmployeeID = ValueConvert.ToInt32(cLookEmployee.EditValue),
                CarID = ValueConvert.ToNullableInt32(cLCarNo.EditValue),
                ApplyDate = ValueConvert.ToDateTime(dateApply.EditValue),
                PlaceBackDate = ValueConvert.ToDateTime(datePlaceBackDate.EditValue),
                Status = 1,
                DispatchReason = memoDispatchReason.Text,
                OperatorID = Program.CurrentEmployee.EmployeeID,
                OperateTime = ValueConvert.ToDateTime(dateOperateTime.EditValue)
            };
            if (radioGroup1.SelectedIndex == 0)
            {
                model.ApplyMode = "CP";
                model.CarID = ValueConvert.ToInt32(cLCarNo.EditValue);
            }
            else
            {
                model.ApplyMode = "CX";
                model.CarModel = comCarModel.Text;
            }
            if (checkEdit1.Checked)
            {
                model.IsDriver = 0;
            }
            else if (checkEdit2.Checked)
            {
                model.IsDriver = 1;
            }
            else if (checkEdit3.Checked)
            {
                model.IsDriver = 2;
            }
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
                    CarID = ValueConvert.ToNullableInt32(cLCarNo.EditValue),
                    ApplyDate = ValueConvert.ToDateTime(dateApply.EditValue),
                    PlaceBackDate = ValueConvert.ToDateTime(datePlaceBackDate.EditValue),
                    Status = 0,
                    OperatorID = Program.CurrentEmployee.EmployeeID,
                    OperateTime = ValueConvert.ToDateTime(dateOperateTime.EditValue)
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
                new CarDispatchDao().UpdateApplyDate(model);
                CarApplySocialpeople model1 = new CarApplySocialpeople();
                model1.Name = textEdit1.Text;
                model1.IdentityNo = textEdit2.Text;
                model1.DriverLicense = textEdit3.Text;
                model1.FileNumber = textEdit4.Text;
                new CarApplySocialpeopleDao().Add(model1);
                MessageBox.Show("保存成功");
                this.DialogResult = DialogResult.OK;
            }
        }



        #endregion

        #region 方法

        private void BindDate()
        {
            cLookEmployee.EditValue = curData.EmployeeID;
            cLCarNo.EditValue = curData.CarID;
            dateApply.EditValue = curData.ApplyDate;
            dateOperateTime.EditValue = curData.OperateTime;
            datePlaceBackDate.EditValue = curData.PlaceBackDate;
            memoDispatchReason.EditValue = curData.DispatchReason;
            if (curData.ApplyMode == "CP")
            {
                radioGroup1.SelectedIndex = 0;
                cLCarNo.EditValue = curData.CarNo;
                comCarModel.Properties.ReadOnly = true;
            }
            else
            {
                radioGroup1.SelectedIndex = 1;
                comCarModel.EditValue = curData.CarModel;
                cLCarNo.Properties.ReadOnly = true;
            }
            if (curData.IsDriver == 0 || curData.IsDriver == 1)
            {
                if (curData.IsDriver == 0)
                {
                    checkEdit1.Checked = true;
                    checkEdit2.Checked = false;
                }
                else
                {
                    checkEdit1.Checked = false;
                    checkEdit2.Checked = true;
                }
                checkEdit3.Checked = false;
                textEdit1.Properties.ReadOnly = true;
                textEdit2.Properties.ReadOnly = true;
                textEdit3.Properties.ReadOnly = true;
                textEdit4.Properties.ReadOnly = true;
            }
            else if (curData.IsDriver == 2 )
            {
                checkEdit1.Checked = false;
                checkEdit2.Checked = false;
                checkEdit3.Checked = true;
                textEdit1.Properties.ReadOnly = false;
                textEdit2.Properties.ReadOnly = false;
                textEdit3.Properties.ReadOnly = false;
                textEdit4.Properties.ReadOnly = false;
                CarApplySocialpeople model = new CarApplySocialpeopleDao().GetModelByID(curData.ApplyID);
                if (model != null)
                {
                    textEdit1.EditValue = model.Name;
                    textEdit2.EditValue = model.IdentityNo;
                    textEdit3.EditValue = model.DriverLicense;
                    textEdit4.EditValue = model.FileNumber;
                }
            }
        }
        #endregion
    }
}
