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
    public partial class FormEditRepair : FormBase
    {
        #region 初始化
        public FormEditRepair()
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
            cLookRepairItem1.BindList();
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

        public CarRepairRecord curData = new CarRepairRecord();

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
                MessageBox.Show("请输入经办人！");
                return;
            }
            if (cLCarID.EditValue == null)
            {
                MessageBox.Show("请选择车辆！");
                return;
            }
            if (dateRepairDate.EditValue == null)
            {
                MessageBox.Show("请输入维修日期！");
                return;
            }
            if (cLookRepairItem1.EditValue == null)
            {
                MessageBox.Show("请选择维修项目！");
                return;
            }

            CarRepairRecord model = new CarRepairRecord

            {
                CreatID = ValueConvert.ToInt32(cLookEmployee.EditValue),
                CarID = ValueConvert.ToInt32(cLCarID.EditValue),
                RepairDate = ValueConvert.ToDateTime(dateRepairDate.EditValue),
                ItemStr = ValueConvert.ToInt32(cLookRepairItem1.EditValue),
                RepairKil = ValueConvert.ToDecimal(textRepairKil.EditValue),
                PartsCost = ValueConvert.ToDecimal(textPartsCost.EditValue),
                RepairPlace = textRepairPlace.Text,
                Note = memoNote.Text,
                OperateID = Program.CurrentEmployee.EmployeeID,
                OperateTime = DateTime.Now
            };
            bool result = false;
            if (FormState == DS.MSClient.FormState.Modify)
            {
                model.RepairID = curData.RepairID;
                result = new CarRepairRecordDao().Update(model);
            }
            else
            {
                model.RepairID = new CommonDAO().GetIntUniqueNumber("t_car_repair_record");
                result = new CarRepairRecordDao().Add(model);
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
            cLookEmployee.EditValue = curData.CreatID;
            cLCarID.EditValue = curData.CarID;
            cLookRepairItem1.EditValue = curData.ItemStr;
            dateRepairDate.EditValue = curData.RepairDate;
            textRepairPlace.EditValue = curData.RepairPlace;
            textPartsCost.EditValue = curData.PartsCost;
            textRepairKil.EditValue = curData.RepairKil;
            comResult.Text = curData.Result;
            memoNote.EditValue = curData.Note;
        }
        #endregion
    }
}
