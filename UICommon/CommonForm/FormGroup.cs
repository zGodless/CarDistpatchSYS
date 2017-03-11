using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DS.MSClient.UICommon;
using DevExpress.XtraEditors;
using DS.MSClient.UICommon.MessageBox;
using DevExpress.Utils.Drawing.Helpers;
using DS.Model;
using DS.Data;
using QuickFrame.Common.Text;

namespace DS.MSClient.UICommon.CommonForm
{
      [ToolboxItem(false)]
    //付款方式
    public partial class FormGroup : FormBase
    {
        #region 初始化
          public FormGroup()
        {
            InitializeComponent();
            InitEvent();
		}

		/// <summary>
		///     初始化事件
		/// </summary>
        private void InitEvent()
        {
            this.barManager1.Images = DS.MSClient.Controls.StaticImageList.Instance.ImageList_global;
            //加载数据
            Load += FormGroup_Load;

            this.gv_Group.RowClick += gv_Group_RowClick;
            this.txt_GroupName.EditValueChanged += txt_EditValueChanged;
            this.cl_School.EditValueChanged += txt_EditValueChanged;
            this.cl_TrainPlace.EditValueChanged += txt_EditValueChanged;
            this.txt_Note.EditValueChanged += txt_EditValueChanged;

            //任务栏
            Btn_NewAdd.ItemClick += Btn_ItemClick;
            Btn_Del.ItemClick += Btn_ItemClick;
            Btn_Cancel.ItemClick += Btn_ItemClick;
            Btn_Apply.ItemClick += Btn_ItemClick;
            Btn_Refresh.ItemClick += Btn_ItemClick;
            cl_School.BindList();
            cl_TrainPlace.BindList();
        }




        #endregion

        #region 属性

        private bool isinit = false;
        private Group _Group = null;
        private List<Group> _listCopy = null;
        private List<Group> _list = new List<Group>();
        #endregion

        #region 方法
        void gv_Group_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (formState == FormState.New)
            {
                this.gv_Group.DeleteRow(_list.Count-1);
                this._list.Remove(_Group);
            }
            formState = FormState.Modify;
            _Group = this.gv_Group.GetFocusedRow() as Group;
            if (_Group == null) return;
            switch (e.Clicks)
            {
                case 1:
                    BindText(_Group);
                    break;
            }
        }
        /// <summary>
        /// 绑定文本
        /// </summary>
        private void BindText(Group model)
        {
            txt_GroupName.EditValue = model.GroupName;
            cl_School.EditValue = model.SchoolID;
            cl_TrainPlace.EditValue = model.TrainPlaceID;
            txt_Note.EditValue = model.Note;
        }
        private void BindData()
        {
            _list = new GroupDao().GetList();
            this.gc_Group.DataSource = _list;
            this.gc_Group.RefreshDataSource();
            _listCopy = new List<Group>();
            _listCopy.AddRange(_list.Select(item => (Group)item.Copy()));
            if (_list.Count > 0)
            {
                BindText(_list[0]);
                _Group = _list[0];
            }
            isinit = true;
        }
        void Add()
        {
            this.formState=FormState.New;
            _Group = new Group();
            _list.Add(_Group);
            this.gc_Group.RefreshDataSource();
            this.gv_Group.FocusedRowHandle = _list.Count - 1;
            BindText(_Group);
        }
        void Delete()
        {
            if(formState!=FormState.Modify)
                return;
            if (new GroupDao().Delete(_Group.GroupID))
            {
                _list.Remove(_Group);
                _listCopy.Remove(_Group);
                this.gc_Group.RefreshDataSource();
            }
        }
        #endregion

        #region 事件

        /// <summary>
        /// 窗体加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormGroup_Load(object sender, EventArgs e)
        {
            BindData();
        }
        /// <summary>
        ///  生成助记码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void txt_EditValueChanged(object sender, EventArgs e)
        {
            if(!isinit)
                return;
            _Group.OperateStatus = OperateStatus.Modify;
        }
        /// <summary>
        /// 工具栏操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Btn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item == this.Btn_NewAdd)
            {
                Add();
            }
            else if (e.Item == this.Btn_Del)
            {
                Delete();
            }
            else if (e.Item == this.Btn_Cancel)
            {
                this.formState = FormState.Normal;
                _list = new List<Group>();
                _list.AddRange(_listCopy.Select(item => (Group)item.Copy()));
                this.gc_Group.DataSource = _list;
                this.gc_Group.RefreshDataSource();
            }
            else if (e.Item == this.Btn_Apply)
            {
                if(formState == FormState.New)
                {
                    _Group.GroupID = new CommonDAO().GetIntUniqueNumber("t_group");
                    // _Group.OperateID = Program.CurrentEmployee.EmployeeID;
                    _Group.OperateTime = DateTime.Now;
                    if (new GroupDao().Add(_Group))
                    {
                        _listCopy.Add((Group)_Group.Copy());
                        formState = FormState.Normal;
                        this.gc_Group.RefreshDataSource();
                    }
                    else
                    {
                        MsgBox.ShowWarn(_Group.GroupName + "添加失败,请先确定是否未有该驾校和场地关联！");
                    }
                }
                else
                {
                    bool result = true;
                    _list.ForEach(m =>
                    {
                        if (m.OperateStatus == OperateStatus.Modify)
                        {
                            if (!new GroupDao().Exist(m))
                            {
                                if (new GroupDao().Update(m))
                                {
                                    m.OperateStatus = OperateStatus.Normal;
                                }
                                else
                                {
                                    MsgBox.ShowWarn(m.GroupName + "更新失败");
                                    result = false;
                                    return;
                                }
                            }
                            else
                            {
                                MsgBox.ShowWarn("名称已存在");
                                result = false;
                                return;
                            }
                        }
                    });
                    if(result)
                    {
                        MsgBox.ShowInfo("更新成功");
                    }
                    this.gc_Group.RefreshDataSource();
                }
            }
            else if (e.Item == this.Btn_Refresh)
            {
                BindData();
            }
        }
        #endregion

    }
}