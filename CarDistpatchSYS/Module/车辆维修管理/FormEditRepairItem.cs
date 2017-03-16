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
    public partial class FormEditRepairItem : FormBase
    {
        #region 初始化
        public FormEditRepairItem()
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

        public CarRepairItem curData = new CarRepairItem();

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
            if (textRepairName.EditValue == null)
            {
                MessageBox.Show("请输入维修项名称");
                return;
            }
            CarRepairItem model = new CarRepairItem

            {
                RepairName = textRepairName.EditValue.ToString(),
                Note = memoNote.Text.Trim(),
                OperateID = Program.CurrentEmployee.EmployeeID,
                OperateTime = DateTime.Now
            };
            bool result = false;
            if (FormState == DS.MSClient.FormState.Modify)
            {
                model.ItemID = curData.ItemID;
                result = new CarRepairItemDao().Update(model);
            }
            else
            {
                model.ItemID = new CommonDAO().GetIntUniqueNumber("t_car_repair_item");
                result = new CarRepairItemDao().Add(model);
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
            textRepairName.EditValue = ValueConvert.ToString(curData.RepairName);

            memoNote.EditValue = ValueConvert.ToString(curData.Note);
        }
        #endregion
    }
}
