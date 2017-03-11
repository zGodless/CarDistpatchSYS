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
    public partial class FormSchool : FormBase
    {
        #region 初始化
          public FormSchool()
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
            Load += FormSchool_Load;

            this.gv_School.RowClick += gv_School_RowClick;
            this.txt_SchoolName.EditValueChanged += txt_EditValueChanged;
            this.txt_SchoolCode.EditValueChanged += txt_EditValueChanged;
            this.txt_Note.EditValueChanged += txt_EditValueChanged;

            //任务栏
            Btn_NewAdd.ItemClick += Btn_ItemClick;
            Btn_Del.ItemClick += Btn_ItemClick;
            Btn_Cancel.ItemClick += Btn_ItemClick;
            Btn_Apply.ItemClick += Btn_ItemClick;
            Btn_Refresh.ItemClick += Btn_ItemClick;

        }




        #endregion

        #region 属性

        private bool isinit = false;
        private School _School = null;
        private List<School> _listCopy = null;
        private List<School> _list = new List<School>();
        #endregion

        #region 方法
        void gv_School_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (formState == FormState.New)
            {
                this.gv_School.DeleteRow(_list.Count-1);
                this._list.Remove(_School);
            }
            formState = FormState.Modify;
            _School = this.gv_School.GetFocusedRow() as School;
            if (_School == null) return;
            switch (e.Clicks)
            {
                case 1:
                    BindText(_School);
                    break;
            }
        }
        /// <summary>
        /// 绑定文本
        /// </summary>
        private void BindText(School model)
        {
            txt_SchoolCode.EditValue = model.SchoolCode;
            txt_SchoolName.EditValue = model.SchoolName;
            txt_MnemonicCode.EditValue = model.MnemonicCode;
            txt_Note.EditValue = model.Note;
        }
        private void BindData()
        {
            _list = new SchoolDao().GetAllList();
            this.gc_School.DataSource = _list;
            this.gc_School.RefreshDataSource();
            _listCopy = new List<School>();
            _listCopy.AddRange(_list.Select(item => (School)item.Copy()));
            if (_list.Count > 0)
            {
                BindText(_list[0]);
                _School = _list[0];
            }
            isinit = true;
        }
        void Add()
        {
            this.formState=FormState.New;
            _School = new School();
            _list.Add(_School);
            this.gc_School.RefreshDataSource();
            this.gv_School.FocusedRowHandle = _list.Count - 1;
            BindText(_School);
        }
        void Delete()
        {
            if(formState!=FormState.Modify)
                return;
            if (new SchoolDao().Delete(_School.SchoolID))
            {
                _list.Remove(_School);
                _listCopy.Remove(_School);
                this.gc_School.RefreshDataSource();
            }
        }
        #endregion

        #region 事件

        /// <summary>
        /// 窗体加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormSchool_Load(object sender, EventArgs e)
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
            txt_MnemonicCode.EditValue = ChineseUtil.ToPyLetters(txt_SchoolName.Text.Trim());
            _School.OperateStatus = OperateStatus.Modify;
            TextEdit _edit = sender as TextEdit;
            if (_edit.Name == "txt_SchoolCode")
            {
                _School.SchoolCode = txt_SchoolCode.Text;
            }
            else if (_edit.Name == "txt_SchoolName")
            {
                _School.SchoolName = txt_SchoolName.Text;
            }
            else if (_edit.Name == "txt_Note")
            {
                _School.Note = txt_Note.Text;
            }
            _School.MnemonicCode = txt_MnemonicCode.Text;
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
                _list = new List<School>();
                _list.AddRange(_listCopy.Select(item => (School)item.Copy()));
                this.gc_School.DataSource = _list;
                this.gc_School.RefreshDataSource();
            }
            else if (e.Item == this.Btn_Apply)
            {
                if(formState == FormState.New)
                {
                    _School.SchoolID = new CommonDAO().GetIntUniqueNumber("t_school");
                    // _School.OperateID = Program.CurrentEmployee.EmployeeID;
                    _School.OperateTime = DateTime.Now;
                    if (new SchoolDao().Add(_School))
                    {
                        _listCopy.Add((School)_School.Copy());
                        formState = FormState.Normal;
                        this.gc_School.RefreshDataSource();
                    }
                    else
                    {
                        MsgBox.ShowWarn(_School.SchoolName + "添加失败");
                    }
                }
                else
                {
                    bool result = true;
                    _list.ForEach(m =>
                    {
                        if (m.OperateStatus == OperateStatus.Modify)
                        {
                            if (!new SchoolDao().Exists(m))
                            {
                                if (new SchoolDao().Update(m))
                                {
                                    m.OperateStatus = OperateStatus.Normal;
                                }
                                else
                                {
                                    MsgBox.ShowWarn(m.SchoolName + "更新失败");
                                    result = false;
                                    return;
                                }
                            }
                            else
                            {
                                MsgBox.ShowWarn("编号已存在");
                                result = false;
                                return;
                            }
                        }
                    });
                    if(result)
                    {
                        MsgBox.ShowInfo("更新成功");
                    }
                    this.gc_School.RefreshDataSource();
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