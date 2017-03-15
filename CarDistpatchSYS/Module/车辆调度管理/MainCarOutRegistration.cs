using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DS.Data;
using QuickFrame.Common.Converter;

namespace CarDistpatchSYS
{
    public partial class MainCarOutRegistration : BaseUserControl
    {
        #region 初始化
        public MainCarOutRegistration()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += MainCarApply_Load;
            btnSearch.Click += btnSearch_Click;
            btnAdd.ItemClick += btnAdd_ItemClick;
            btnEdit.ItemClick += btnEdit_ItemClick;
            btnDel.ItemClick += btnDel_ItemClick;
            btnClose.ItemClick +=btnClose_ItemClick;

            gvOut.RowClick += gvCar_RowClick;
        }

        void MainCarApply_Load(object sender, EventArgs e)
        {
            cLCar.BindList();
            cLEmployeeID.BindList();
            _list = new CarOutRegistrationDao().GetList();
            if (_list.Count > 0)
            {
                gcOut.DataSource = _list;
                gcOut.RefreshDataSource();
            }
        }

        void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPageOperation.RemoveTabPage(this);
        }

        void gvCar_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var detail = gvOut.GetFocusedRow() as CarOutRegistration;
            if (detail == null)
            {
                return;
            }
            if (this.gvOut.FocusedColumn == Column_choose)
            {
                switch (e.Clicks)
                {
                    case 1:
                        _list[gvOut.FocusedRowHandle].Choose = !detail.Choose;
                        gcOut.DataSource = _list;
                        gcOut.RefreshDataSource();
                        break;
                }
            }
        }

        #endregion


        #region 属性

        private List<CarOutRegistration> _list = new List<CarOutRegistration>();
        private CarDispatch selectModel = new CarDispatch();
        private string sql;

        #endregion

        #region 事件


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var delList = _list.FindAll(m => m.Choose);
            if (delList.Count <= 0)
            {
                return;
            }
            foreach (var detail in delList)
            {
                new CarOutRegistrationDao().Delete(detail);
                _list.Remove(detail);
            }
            gcOut.DataSource = _list;
            gcOut.RefreshDataSource();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var detail = gvOut.GetFocusedRow() as CarOutRegistration;
            if (detail == null)
            {
                return;
            }
            FormEditOutRegistration form = new FormEditOutRegistration();
            form.curData = detail;
            form.FormState = DS.MSClient.FormState.Modify;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                btnSearch.PerformClick();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnSearch_Click(object sender, EventArgs e)
        {
            sql = " 1 = 1 ";
            if (cLCar.EditValue != null)
            {
                sql += string.Format(" and a.CarID = {0}", ValueConvert.ToInt32(cLCar.EditValue));
            }
            if (cLEmployeeID.EditValue != null)
            {
                sql += string.Format(" and a.EmployeeID = {0}", ValueConvert.ToInt32(cLEmployeeID.EditValue));
            }
            if (dateApplyBegin.EditValue != null && dateApplyEnd.EditValue == null)
            {
                sql += string.Format(" and a.RegistraDate >= '{0}'", ValueConvert.ToDateTime(dateApplyBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateApplyEnd.EditValue == null && dateApplyEnd.EditValue != null)
            {
                sql += string.Format(" and a.RegistraDate <= '{0}'", ValueConvert.ToDateTime(dateApplyEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateApplyEnd.EditValue != null && dateApplyEnd.EditValue != null)
            {
                sql += string.Format(" and a.RegistraDate between '{0}' and '{1}'", ValueConvert.ToDateTime(dateApplyBegin.EditValue).ToString("yyyy-MM-dd"), ValueConvert.ToDateTime(dateApplyEnd.EditValue).ToString("yyyy-MM-dd"));
            }

            string _sql = string.Format(@"select a.*, b.EmployeeName, c.CarNo, d.EmployeeName OperatorName from t_car_out_registration a 
                                                left join t_employee b on a.EmployeeID = b.EmployeeID
                                                left join t_car c on a.CarID = c.CarID 
                                                left join t_employee d on a.OperatorID = d.EmployeeID
                                                where {0}", sql);
            _list = new CarOutRegistrationDao().QueryGetList(_sql);

            gcOut.DataSource = _list;
            gcOut.RefreshDataSource();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormSelectDispath form = new FormSelectDispath();
            form.state = 1;
            form.ShowUpdate += form_ShowUpdate;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                FormEditOutRegistration formout = new FormEditOutRegistration();
                formout.FormState = DS.MSClient.FormState.New;
                formout.curData = new CarOutRegistration()
                {
                    DispatchID = selectModel.DispatchID,
                    CarID = selectModel.CarID
                };
                if (formout.ShowDialog(this) == DialogResult.OK)
                {
                    btnSearch.PerformClick();
                }
            }
        }

        void form_ShowUpdate(CarDispatch model)
        {
            selectModel = model;
        }
        #endregion
    }
}
