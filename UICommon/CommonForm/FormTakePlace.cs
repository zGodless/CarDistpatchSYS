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
    public partial class FormTakePlace : FormBase
    {
        #region 初始化
          public FormTakePlace()
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
            Load += FormTakePlace_Load;

            this.gv_TakePlace.RowClick += gv_TakePlace_RowClick;
            this.txt_TakePlaceName.EditValueChanged += txt_EditValueChanged;
            this.txt_TakePlaceCode.EditValueChanged += txt_EditValueChanged;
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
        private TakePlace _TakePlace = null;
        private List<TakePlace> _listCopy = null;
        private List<TakePlace> _list = new List<TakePlace>();
        #endregion

        #region 方法
        void gv_TakePlace_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (formState == FormState.New)
            {
                this.gv_TakePlace.DeleteRow(_list.Count-1);
                this._list.Remove(_TakePlace);
            }
            formState = FormState.Modify;
            _TakePlace = this.gv_TakePlace.GetFocusedRow() as TakePlace;
            if (_TakePlace == null) return;
            switch (e.Clicks)
            {
                case 1:
                    BindText(_TakePlace);
                    break;
            }
        }
        /// <summary>
        /// 绑定文本
        /// </summary>
        private void BindText(TakePlace model)
        {
            txt_TakePlaceCode.EditValue = model.TakePlaceCode;
            txt_TakePlaceName.EditValue = model.TakePlaceName;
            txt_MnemonicCode.EditValue = model.MnemonicCode;
            txt_Note.EditValue = model.Note;
        }
        private void BindData()
        {
            _list = new TakePlaceDAO().GetList();
            this.gc_TakePlace.DataSource = _list;
            this.gc_TakePlace.RefreshDataSource();
            _listCopy = new List<TakePlace>();
            _listCopy.AddRange(_list.Select(item => (TakePlace)item.Copy()));
            if (_list.Count > 0)
            {
                BindText(_list[0]);
                _TakePlace = _list[0];
            }
            isinit = true;
        }
        void Add()
        {
            this.formState=FormState.New;
            _TakePlace = new TakePlace();
            _list.Add(_TakePlace);
            this.gc_TakePlace.RefreshDataSource();
            this.gv_TakePlace.FocusedRowHandle = _list.Count - 1;
            BindText(_TakePlace);
        }
        void Delete()
        {
            if(formState!=FormState.Modify)
                return;
            if (new TakePlaceDAO().Delete(_TakePlace.TakePlaceID))
            {
                _list.Remove(_TakePlace);
                _listCopy.Remove(_TakePlace);
                this.gc_TakePlace.RefreshDataSource();
            }
        }
        #endregion

        #region 事件

        /// <summary>
        /// 窗体加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormTakePlace_Load(object sender, EventArgs e)
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
            txt_MnemonicCode.EditValue = ChineseUtil.ToPyLetters(txt_TakePlaceName.Text.Trim());
            _TakePlace.OperateStatus = OperateStatus.Modify;
            TextEdit _edit = sender as TextEdit;
            if (_edit.Name == "txt_TakePlaceCode")
            {
                _TakePlace.TakePlaceCode = txt_TakePlaceCode.Text;
            }
            else if (_edit.Name == "txt_TakePlaceName")
            {
                _TakePlace.TakePlaceName = txt_TakePlaceName.Text;
            }
            else if (_edit.Name == "txt_Note")
            {
                _TakePlace.Note = txt_Note.Text;
            }
            _TakePlace.MnemonicCode = txt_MnemonicCode.Text;
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
                _list = new List<TakePlace>();
                _list.AddRange(_listCopy.Select(item => (TakePlace)item.Copy()));
                this.gc_TakePlace.DataSource = _list;
                this.gc_TakePlace.RefreshDataSource();
            }
            else if (e.Item == this.Btn_Apply)
            {
                if(formState == FormState.New)
                {
                    _TakePlace.TakePlaceID = new CommonDAO().GetIntUniqueNumber("t_apply_place");
                    // _TakePlace.OperateID = Program.CurrentEmployee.EmployeeID;
                    _TakePlace.OperateTime = DateTime.Now;
                    if (new TakePlaceDAO().Add(_TakePlace))
                    {
                        _listCopy.Add((TakePlace)_TakePlace.Copy());
                        formState = FormState.Normal;
                        this.gc_TakePlace.RefreshDataSource();
                    }
                    else
                    {
                        MsgBox.ShowWarn(_TakePlace.TakePlaceName + "添加失败");
                    }
                }
                else
                {
                    bool result = true;
                    _list.ForEach(m =>
                    {
                        if (m.OperateStatus == OperateStatus.Modify)
                        {
                            if (!new TakePlaceDAO().Exist(m))
                            {
                                if (new TakePlaceDAO().Update(m))
                                {
                                    m.OperateStatus = OperateStatus.Normal;
                                }
                                else
                                {
                                    MsgBox.ShowWarn(m.TakePlaceName + "更新失败");
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
                    this.gc_TakePlace.RefreshDataSource();
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