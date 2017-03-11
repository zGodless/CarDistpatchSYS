using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DS.Common;
using DS.MSClient.UICommon;
using DevExpress.XtraTreeList.Nodes;
using DS.Data;
using System.Collections;
using NoHeaderXtraTabControl;
using DS.Model;
using DevExpress.XtraGrid.Columns;
using System.Threading.Tasks;

namespace DS.MSClient.UICommon
{
    public partial class FormSelectRole : FormDlgBase
    {

        #region 初始化
        public FormSelectRole()
        {
            InitializeComponent();
            InitEvent();
        }
        void InitEvent()
        {
            Load += FormSelectRole_Load;
            this.pagingControl1.PagingEvent += pagingControl_pagingEvents;
            this.gv_Role.RowClick += gv_Role_RowClick;
            this.btn_AllSelect.Click += btn_AllSelect_Click;
            this.btnCancel.Click += btnCancel_Click;
            this.btnOK.Click += btnOK_Click;
        }





        void FormSelectRole_Load(object sender, EventArgs e)
        {
            sql = " 1=1 ";
            GetSearchFilter(this.sql);
            BindData(_para);

        }
        #endregion
        #region 属性
        private List<Role> _list = new List<Role>();
        private List<Role> _chooseList = new List<Role>();
        //当前页
        public int curPage = 1;
        //分页数
        public int pageSize = 100;
        //总行数
        private int allCount = 0;
        private QueryProcedurePara _para = null;
        private string sql = "";
        public string StrRoleID = "";
        public string StrRoleName = "";
        #endregion
        #region 事件
        void btnOK_Click(object sender, EventArgs e)
        {
            var ChoostList= _list.FindAll(m => m.Choose == true);
            StrRoleID = string.Join(",",ChoostList.Select(m=>m.RoleID));
            StrRoleName = string.Join(",", ChoostList.Select(m => m.RoleName));
            this.DialogResult = DialogResult.OK;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        void btn_AllSelect_Click(object sender, EventArgs e)
        {

            if (_list.Count == 0) return;
            if (btn_AllSelect.Text == "全选")
            {
                foreach (var com in _list)
                {
                    com.Choose = true;

                }
                btn_AllSelect.Text = "全清";
            }
            else
            {
                foreach (var com in _list)
                {
                    com.Choose = false;

                }
                btn_AllSelect.Text = "全选";
            }


            gc_Role.RefreshDataSource();
        }

        void gv_Role_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var detail = this.gv_Role.GetFocusedRow() as Role;
            if (detail == null) return;
            if (gv_Role.FocusedColumn == gridColumn_Choose)
            {
                switch (e.Clicks)
                {
                    case 1:
                        detail.Choose = !detail.Choose;
                        gc_Role.RefreshDataSource();
                        break;
                }


            }
        }
        void pagingControl_pagingEvents(int curPage, int pageSize)
        {
            this.curPage = curPage;
            this.pageSize = pageSize;
            this.GetSearchFilter(this.sql);
            this.BindData(this._para);
        }
        #endregion
        #region 方法
        private void GetSearchFilter(string sql)
        {
            _para = new QueryProcedurePara();
            _para.P_Where = sql;
            _para.P_PageSize = pageSize;
            if (curPage == 0)
            {
                curPage = 1;
            }
            _para.P_PageIndex = curPage;
            string _orderBy = "Array";//默认排序字段
            foreach (GridColumn col in this.gv_Role.Columns)
            {
                if (col.FieldName != "Choose" && col.SortOrder != DevExpress.Data.ColumnSortOrder.None)//判断是否有排序，如果有，加上列排序信息
                {
                    string sortOrder = col.SortOrder.ToString() == "Descending" ? "desc" : "asc";//升序、降序
                    _orderBy = "a." + col.FieldName + " " + sortOrder;//注意：此处需要根据字段所属表进行必要的替换对应的字段、表别名等。
                    break;
                }
            }

            _para.P_OrderBy = _orderBy;
        }
        private void BindData(QueryProcedurePara para)
        {
            allCount = 0;
            bool result = ThreadExcute(() =>
            {
                _list = new RoleDao().Query(para, out allCount);
            });
            if (result)
            {
                this.gc_Role.DataSource = _list;
                this.gc_Role.RefreshDataSource();
                if (allCount == 0)
                {
                    curPage = 0;
                }
                pagingControl1.RefreshPager(pageSize, allCount, curPage);
            }
        }
        #endregion

    }
}
