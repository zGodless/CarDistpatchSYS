using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DS.MSClient;
using DS.Model;
using DS.Data;

namespace DS.MSClient.UICommon
{
    public partial class FormEmployee : FormDlgBase
    {
        #region 初始化
        public FormEmployee()
        {
            InitializeComponent();
            InitEvent();

        }
        private void InitEvent()
        {
            //加载数据
            Shown += FormSelectEmployee_Shown;
            this.gv_Employee.RowClick += gv_Employee_RowClick;
            this.Btn_Ok.Click += Btn_Ok_Click;
            this.Btn_Cancel.Click += Btn_Cancel_Click;
        }




        #endregion

        #region 属性
        private List<Employee> _list = null;
        public List<Employee> _selectList = null;
        #endregion

        #region 事件
        void FormSelectEmployee_Shown(object sender, EventArgs e)
        {
            BindData();
        }

        void Btn_Ok_Click(object sender, EventArgs e)
        {
            _selectList = new List<Employee>();
            foreach (var item in _list)
            {
                if (item.Choose)
                {
                    _selectList.Add(item.Copy() as Employee);
                }
            }
            if (_selectList.Count == 0)
            {
                if (this.gv_Employee.GetFocusedDataSourceRowIndex() >= 0)
                {
                    _selectList.Add(gv_Employee.GetFocusedRow() as Employee);
                }
            }
            if (_selectList.Count > 0)
            {
                DialogResult = DialogResult.OK;
            }
        }
        void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void gv_Employee_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_Employee.FocusedColumn == Column_choose)
            {
                var _employee = gv_Employee.GetFocusedRow() as Employee;
                if (_employee == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        _employee.Choose = !_employee.Choose;
                        gc_Employee.RefreshDataSource();
                        break;
                }
            }
        }
        #endregion

        #region 方法
        private void BindData()
        {
            bool result = ThreadExcute(() =>
            {
                _list = new EmployeeDao().GetList();
            });
            if (result)
            {
                this.gc_Employee.DataSource = _list;
                this.gc_Employee.RefreshDataSource();
            }
        }
        #endregion
    }
}