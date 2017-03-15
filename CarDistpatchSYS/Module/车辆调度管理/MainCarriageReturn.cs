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
    public partial class MainCarriageReturn : BaseUserControl
    {
        #region 初始化
        public MainCarriageReturn()
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

            gvReturn.RowClick += gvCar_RowClick;
        }

        void MainCarApply_Load(object sender, EventArgs e)
        {
            cLCar.BindList();
            cLEmployeeID.BindList();
            _list = new CarriageReturnDao().GetList();
            if (_list.Count > 0)
            {
                gcReturn.DataSource = _list;
                gcReturn.RefreshDataSource();
            }
        }

        void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPageOperation.RemoveTabPage(this);
        }

        void gvCar_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var detail = gvReturn.GetFocusedRow() as CarriageReturn;
            if (detail == null)
            {
                return;
            }
            if (this.gvReturn.FocusedColumn == Column_choose)
            {
                switch (e.Clicks)
                {
                    case 1:
                        _list[gvReturn.FocusedRowHandle].Choose = !detail.Choose;
                        gcReturn.DataSource = _list;
                        gcReturn.RefreshDataSource();
                        break;
                }
            }
        }

        #endregion


        #region 属性

        private List<CarriageReturn> _list = new List<CarriageReturn>();
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
                new CarriageReturnDao().Delete(detail);
                _list.Remove(detail);
            }
            gcReturn.DataSource = _list;
            gcReturn.RefreshDataSource();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var detail = gvReturn.GetFocusedRow() as CarriageReturn;
            if (detail == null)
            {
                return;
            }
            FormEditCarriageReturn form = new FormEditCarriageReturn();
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
            if (dateReturnBegin.EditValue != null && dateReturnEnd.EditValue == null)
            {
                sql += string.Format(" and a.ReturnDate >= '{0}'", ValueConvert.ToDateTime(dateReturnBegin.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateReturnEnd.EditValue == null && dateReturnEnd.EditValue != null)
            {
                sql += string.Format(" and a.ReturnDate <= '{0}'", ValueConvert.ToDateTime(dateReturnEnd.EditValue).ToString("yyyy-MM-dd"));
            }
            if (dateReturnEnd.EditValue != null && dateReturnEnd.EditValue != null)
            {
                sql += string.Format(" and a.ReturnDate between '{0}' and '{1}'", ValueConvert.ToDateTime(dateReturnBegin.EditValue).ToString("yyyy-MM-dd"), ValueConvert.ToDateTime(dateReturnEnd.EditValue).ToString("yyyy-MM-dd"));
            }

            string _sql = string.Format(@"select a.*, b.EmployeeName, c.CarNo, d.EmployeeName OperatorName from t_carriage_return a 
                                                left join t_employee b on a.EmployeeID = b.EmployeeID
                                                left join t_car c on a.CarID = c.CarID 
                                                left join t_employee d on a.OperatorID = d.EmployeeID
                                                where {0}", sql);
            _list = new CarriageReturnDao().QueryGetList(_sql);

            gcReturn.DataSource = _list;
            gcReturn.RefreshDataSource();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormSelectDispath form = new FormSelectDispath();
            form.state = 3;
            form.ShowUpdate += form_ShowUpdate;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                FormEditCarriageReturn formout = new FormEditCarriageReturn();
                formout.FormState = DS.MSClient.FormState.New;
                formout.curData = new CarriageReturn()
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
