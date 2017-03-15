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
    public partial class FormSelectDispath : FormBase
    {
        #region 初始化
        public FormSelectDispath()
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
            gvDispath.RowClick += gvDispath_RowClick;
        }

        void gvDispath_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            var detail = gvDispath.GetFocusedRow() as CarDispatch;
            if (detail == null)
            {
                return;
            }
            if (this.gvDispath.FocusedColumn == Column_choose)
            {
                switch (e.Clicks)
                {
                    case 1:
                        _list.ForEach(m => { m.Choose = false; });
                        _list[gvDispath.FocusedRowHandle].Choose = !_list[gvDispath.FocusedRowHandle].Choose;
                        gcDispath.DataSource = _list;
                        gcDispath.RefreshDataSource();
                        break;
                }
            }
        }


        void FormEditDispathApply_Load(object sender, EventArgs e)
        {
            if (state != null)
            {
                _list = new CarDispatchDao().GetListByState(ValueConvert.ToInt32(state));
                gcDispath.DataSource = _list;
                gcDispath.RefreshDataSource();
            }
        }



        #endregion


        #region 属性

        private List<CarDispatch> _list = new List<CarDispatch>();
        public List<CarDispatch> SelectList = new List<CarDispatch>();
        public int? state;

        /// <summary>
        ///     刷新事件委托
        /// </summary>
        /// <param name="list"></param>
        public delegate void DisplayUpdate(CarDispatch model);

        /// <summary>
        ///     刷新事件
        /// </summary>
        public event DisplayUpdate ShowUpdate;


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
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnOK_Click(object sender, EventArgs e)
        {
            SelectList = _list.FindAll(m => m.Choose);
            if (SelectList.Count == 0)
            {
                DialogResult = DialogResult.No;
                return;
            }
            ShowUpdate(SelectList[0]);
            DialogResult = DialogResult.OK;
        }



        #endregion

        #region 方法

        #endregion
    }
}
