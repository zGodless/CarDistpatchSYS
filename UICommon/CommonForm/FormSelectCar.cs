using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSpreadsheet;
using DS.Model;
using DS.Data;

namespace DS.MSClient.UICommon.CommonForm
{
    public partial class FormSelectCar : FormDlgBase
    {
        #region 初始化
        public FormSelectCar()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            this.Load += FormSelectCar_Load;
            this.gv_Car.RowClick += gv_Car_RowClick;
            this.chkCheckAll.Click += chkCheckAll_Click;
            this.gvSelect.RowClick += gvSelect_RowClick;
            this.btnSelAdd.Click += btnSelAdd_Click;
             this.btnOK.Click += this.btnOK_Click;
             this.btnCancel.Click += this.btnCancel_Click;
//             this.gvGroup.CustomDrawCell += this.gvGroup_CustomDrawCell;
//             this.gvSelect.CustomDrawRowIndicator += this.gvSelect_CustomDrawRowIndicator;
//             this.gvSelect.CustomDrawCell += this.gvGroup_CustomDrawCell;
             this.btnSelRemove.Click += this.btnSelRemove_Click;
             this.btnSelClear.Click += this.btnSelClear_Click;
        }


        #endregion

        #region 属性
        private List<Car> _cars;

        public List<Car> Selectedcars { get; set; }

        public List<Car> Existscars { get; set; }
        private List<Car> Cars
        {
            get
            {
                return _cars.FindAll(m => !m.IsSelected);
            }
        }

        #endregion

        #region 事件
        void FormSelectCar_Load(object sender, EventArgs e)
        {
            _cars = new CarDAO().GetList();

            if (Existscars != null && Existscars.Any())
            {
                _cars.RemoveAll(m => Existscars.Exists(n => m.CarID == n.CarID));
            }
            gc_Car.DataSource = Cars;
            gc_Car.RefreshDataSource();

            Selectedcars = new DetailList<Car>();
            gcSelect.DataSource = Selectedcars;
            gcSelect.RefreshDataSource();
        }

        private void chkCheckAll_Click(object sender, EventArgs e)
        {
            chkCheckAll.Checked = !chkCheckAll.Checked;
            Cars.ForEach(m => m.Choose = chkCheckAll.Checked);
            gc_Car.RefreshDataSource();
        }

        private void gv_Car_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var row = gv_Car.GetRow(e.RowHandle) as Car;
            if (row == null || e.HitInfo.Column == null) return;
            switch (e.Clicks)
            {
                case 1:
                    if (e.HitInfo.Column.FieldName != "Choose") break;
                    row.Choose = !row.Choose;
                    gc_Car.RefreshDataSource();
                    var selCount = _cars.FindAll(m => m.Choose).Count;
                    if (_cars.Count == selCount)
                    {
                        chkCheckAll.CheckState = CheckState.Checked;
                    }
                    else if (_cars.Count > selCount && selCount > 0)
                    {
                        chkCheckAll.CheckState = CheckState.Indeterminate;
                    }
                    else
                    {
                        chkCheckAll.CheckState = CheckState.Unchecked;
                    }
                    break;
                case 2:
                    int TopIndex = gv_Car.TopRowIndex;
                    row.Choose = false;
                    row.IsSelected = true;
                    Selectedcars.Add(row);
                    gc_Car.DataSource = Cars;
                    gc_Car.RefreshDataSource();
                    gv_Car.TopRowIndex = TopIndex;
                    gcSelect.RefreshDataSource();
                    break;
            }
        }

        private void gvSelect_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var row = gvSelect.GetRow(e.RowHandle) as Car;
            if (row == null || e.HitInfo.Column == null) return;
            switch (e.Clicks)
            {
                case 1:
                    if (e.HitInfo.Column.FieldName != "Choose") break;
                    row.Choose = !row.Choose;
                    gcSelect.RefreshDataSource();
                    break;
                case 2:
                    row.Choose = false;
                    row.IsSelected = false;
                    Selectedcars.Remove(row);
                    gc_Car.DataSource = Cars;
                    gc_Car.RefreshDataSource();
                    gcSelect.RefreshDataSource();
                    break;
            }
        }

        private void btnSelAdd_Click(object sender, EventArgs e)
        {
            var cars = Cars.FindAll(m => m.Choose);
            foreach (Car car in cars)
            {
                car.Choose = false;
                car.IsSelected = true;
            }
            gc_Car.DataSource = Cars;
            Selectedcars.AddRange(cars);
            gc_Car.RefreshDataSource();
            gcSelect.RefreshDataSource();
        }

        private void btnSelRemove_Click(object sender, EventArgs e)
        {
            var cars = Selectedcars.FindAll(m => m.Choose);
            foreach (Car car in cars)
            {
                car.Choose = false;
                car.IsSelected = false;
                Selectedcars.Remove(car);
            }
            gc_Car.DataSource = Cars;
            gc_Car.RefreshDataSource();
            gcSelect.RefreshDataSource();
        }

        private void btnSelClear_Click(object sender, EventArgs e)
        {
            foreach (Car car in Selectedcars)
            {
                car.Choose = false;
                car.IsSelected = false;
            }
            Selectedcars.Clear();
            gc_Car.DataSource = Cars;
            gc_Car.RefreshDataSource();
            gcSelect.RefreshDataSource();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Selectedcars.Any())
            {
                foreach (var item in Cars.FindAll(m => m.Choose))
                {
                    Selectedcars.Add(item);
                }
            }
            if (!Selectedcars.Any())
            {
                MsgBox.ShowInfo("请至少选择一辆车");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion
    }
}
