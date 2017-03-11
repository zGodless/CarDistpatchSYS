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
    public partial class MainCar : BaseUserControl
    {
        #region 初始化
        public MainCar()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        ///     初始化事件
        /// </summary>
        private void InitEvent()
        {
            Load += MainCar_Load;
            btnSearch.Click += btnSearch_Click;
            btnAdd.ItemClick += btnAdd_ItemClick;
            btnEdit.ItemClick += btnEdit_ItemClick;
            btnDel.ItemClick += btnDel_ItemClick;
            btnClose.ItemClick +=btnClose_ItemClick;

            gvCar.RowClick += gvCar_RowClick;
        }

        void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormPageOperation.RemoveTabPage(this);
        }

        void gvCar_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var detail = gvCar.GetFocusedRow() as Car;
            if (detail == null)
            {
                return;
            }
            if (this.gvCar.FocusedColumn == Column_choose)
            {
                switch (e.Clicks)
                {
                    case 1:
                        _list[gvCar.FocusedRowHandle].Choose = !detail.Choose;
                        gcCar.DataSource = _list;
                        gcCar.RefreshDataSource();
                        break;
                }
            }
        }

        #endregion


        #region 属性


        private List<Car> _list = new List<Car>();
        private string sql;

        #endregion

        #region 事件

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainCar_Load(object sender, EventArgs e)
        {
            _list = new CarDao().GetList();
            if (_list.Count > 0)
            {
                gcCar.DataSource = _list;
                gcCar.RefreshDataSource();
            }
        }

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
                if (new CarDao().Delete(detail))
                {
                    _list.Remove(detail);
                }
            }
            gcCar.DataSource = _list;
            gcCar.RefreshDataSource();
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var detail = gvCar.GetFocusedRow() as Car;
            if (detail == null)
            {
                return;
            }
            FormEditCar form = new FormEditCar();
            form.curCar = detail;
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
            string carNo = ValueConvert.ToString(textCarNo.EditValue);

            if (!string.IsNullOrEmpty(carNo))
            {
                sql += string.Format(" and CarNo like '%{0}%'", carNo);
            }

            string _sql = string.Format("select * from t_car where {0}", sql);
            _list = new CarDao().QueryGetList(_sql);

            gcCar.DataSource = _list;
            gcCar.RefreshDataSource();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FormEditCar form = new FormEditCar();
            form.curCar = new Car();
            form.FormState = DS.MSClient.FormState.New;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                btnSearch.PerformClick();
            }
        }
        #endregion
    }
}
