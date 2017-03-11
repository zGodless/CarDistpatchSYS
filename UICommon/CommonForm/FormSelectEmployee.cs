using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DS.Data;
using DS.Model;

namespace DS.MSClient.UICommon
{
    public partial class FormSelectEmployee : FormDlgBase
    {

        #region 初始化
        public FormSelectEmployee()
        {
            InitializeComponent();
            InitEvent();
        }
        private void InitEvent()
        {
            //加载数据
            this.Load += FormEmployee_Load;
            this.btnOK.Click += btnOK_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.gv_Employee.RowClick += gv_Employee_RowClick;
        }


        #endregion
        #region 属性

        public List<Employee> _List=new List<Employee>();
        public List<Employee> _DelList=new List<Employee>();

        public List<EmployeeRole> empList = new List<EmployeeRole>();//权限用到
        public int _SchoolID = 0;
        public List<Employee> _Employee = new List<Employee>();
        public int isShow = 0;
        #endregion

        #region 事件

        void gv_Employee_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (this.gv_Employee.FocusedColumn == Column_Choose)
            {
                var detail = this.gv_Employee.GetFocusedRow() as Employee;
                if (detail == null) return;
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        this.gc_Employee.RefreshDataSource();
                        break;
                }
            }
            else
            {
                if (this.gv_Employee.FocusedColumn == Column_IsMain)
                {
                    var detail = this.gv_Employee.GetFocusedRow() as Employee;
                    if (detail == null) return;
                    switch (e.Clicks)
                    {
                        case 1:
                            detail.IsMain = !detail.IsMain;
                            this.gc_Employee.RefreshDataSource();
                            break;
                    }
                }
            }
        }

        void FormEmployee_Load(object sender, EventArgs e)
        {
            if (ThreadExcute(BindData))
            {
                if (_List.Count > 0 && _Employee.Count > 0)
                {
                    foreach (var data in _Employee)
                    {
                        _List.Find(m => m.EmployeeID == data.EmployeeID).IsMain = data.IsMain;
                        _List.Find(m => m.EmployeeID == data.EmployeeID).Choose = true;
                    }
                }
                if (_DelList.Count > 0 && _List.Count > 0)
                {
                    foreach (var data in _DelList)
                    {
                        _List.Remove(_List.Find(m => m.EmployeeID == data.EmployeeID));
                    }
                }
                if (empList.Count > 0 && _List.Count > 0)
                {
                    foreach (var data in empList)
                    {
                        _List.Remove(_List.Find(m => m.EmployeeID == data.EmployeeID));
                    }
                }
                this.gc_Employee.DataSource = _List;
                this.gc_Employee.RefreshDataSource();
            }
        }


        void btnOK_Click(object sender, EventArgs e)
        {
            _Employee.Clear();
            foreach (Employee pro in this._List)
            {
                if (pro.Choose)
                {
                    _Employee.Add(pro);                    
                }
            }
            if (_Employee.Count == 0)
            {
                MsgBox.ShowInfo("请选中数据行");
                return;
            }
            else
            {
                this.DialogResult=DialogResult.OK;
            }
        }


        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;;
        }
        #endregion


        #region 方法
        private void BindData()
        {
            _List = new EmployeeDao().GetListBySchool(_SchoolID);
            if(isShow==1)
            {
                _List = new EmployeeDao().GetList();
            }
        }
        #endregion
    }
}