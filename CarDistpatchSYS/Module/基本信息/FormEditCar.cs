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
    public partial class FormEditCar : FormBase
    {
        #region 初始化
        public FormEditCar()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += FormEditCar_Load;
            btnOK.Click += btnOK_Click;
            btnCancel.Click += btnCancel_Click;
        }


        #endregion


        #region 属性

        public Car curCar = new Car();

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
            if (textCarNo.EditValue == null)
            {
                MessageBox.Show("请输入车牌号");
                return;
            }
            Car model = new Car
            {
                CarNo = textCarNo.Text.Trim(),
                CarModel = textCarModel.Text.Trim(),
                CurrentKil = ValueConvert.ToNullableDecimal(textCurrentKil.EditValue),
                DepartmentID = ValueConvert.ToNullableInt32(clDepartmentID.EditValue),
                BuyTime = ValueConvert.ToNullableDateTime(dateBuyTime.EditValue),
                LicenseCode = textLicenseCode.Text.Trim(),
                LicenseExpireDate = ValueConvert.ToNullableDateTime(dateLicenseExpireDate.EditValue),
                EmployeeID = ValueConvert.ToNullableInt32(cLookEmployeeID.EditValue),
                OwnerID = ValueConvert.ToNullableInt32(cLookOwnerID.EditValue),
                EngineNumber = textEngineNumber.Text.Trim(),
                ChassisNumber = textChassisNumber. Text.Trim(),
                YearCheckExpDate = ValueConvert.ToNullableDateTime(dateYearCheckExpDate.EditValue),
                OilExpenses = ValueConvert.ToNullableDecimal(textOilExpenses.EditValue),
                Note = memoNote.EditValue.ToString(),
                OperateID = Program.CurrentEmployee.EmployeeID,
                OperateTime = DateTime.Now
            };
            if (!string.IsNullOrEmpty(comStatus.SelectedIndex.ToString()))
            {
                model.Status = comStatus.SelectedIndex + 1;
            }
            bool result = false;
            if (FormState == DS.MSClient.FormState.Modify)
            {
                model.CarID = curCar.CarID;
                result = new CarDao().Update(model);
            }
            else
            {
                model.CarID = new CommonDAO().GetIntUniqueNumber("t_car");
                result = new CarDao().Add(model);
            }
            if (result)
            {
                MessageBox.Show("保存成功");
                this.DialogResult = DialogResult.OK;
            }
        }


        void FormEditCar_Load(object sender, EventArgs e)
        {
            cLookEmployeeID.BindList();
            cLookOwnerID.BindList();
            clDepartmentID.BindList();
            if (FormState == DS.MSClient.FormState.Modify) //编辑
            {
                if (curCar == null)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    BindDate();
                    textCarNo.Properties.ReadOnly = true;
                }
            }
            else
            {

            }
        }

        #endregion

        #region 方法

        private void BindDate()
        {
            textCarNo.EditValue = ValueConvert.ToString(curCar.CarNo);
            textCarModel.EditValue = ValueConvert.ToString(curCar.CarModel);
            textChassisNumber.EditValue = ValueConvert.ToString(curCar.ChassisNumber);
            textCurrentKil.EditValue = ValueConvert.ToString(curCar.CurrentKil);
            textEngineNumber.EditValue = ValueConvert.ToString(curCar.EngineNumber);
            textLicenseCode.EditValue = ValueConvert.ToString(curCar.LicenseCode);
            textMaintenanceExp.EditValue = ValueConvert.ToString(curCar.MaintenanceExp);
            textRepairExpenses.EditValue = ValueConvert.ToString(curCar.RepairExpenses);
            textOilExpenses.EditValue = ValueConvert.ToString(curCar.OilExpenses);

            dateBuyTime.EditValue = ValueConvert.ToNullableDateTime(curCar.BuyTime);
            dateLicenseExpireDate.EditValue = ValueConvert.ToNullableDateTime(curCar.LicenseExpireDate);
            dateYearCheckExpDate.EditValue = ValueConvert.ToNullableDateTime(curCar.YearCheckExpDate);

            cLookEmployeeID.EditValue = ValueConvert.ToNullableInt32(curCar.EmployeeID);
            cLookOwnerID.EditValue = ValueConvert.ToNullableInt32(curCar.OwnerID);
            clDepartmentID.EditValue = ValueConvert.ToNullableInt32(curCar.DepartmentID);

            if (curCar.Status != null)
            {
                comStatus.SelectedIndex = ValueConvert.ToInt32(curCar.Status.Value) - 1;
            }
            memoNote.EditValue = ValueConvert.ToString(curCar.Note);
        }
        #endregion
    }
}
