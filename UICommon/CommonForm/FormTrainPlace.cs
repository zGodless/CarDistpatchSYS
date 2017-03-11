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
    public partial class FormTrainPlace : FormBase
    {
        #region 初始化
          public FormTrainPlace()
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
            Load += FormTrainPlace_Load;

            this.gv_TrainPlace.RowClick += gv_TrainPlace_RowClick;
            this.txt_TrainPlaceName.EditValueChanged += txt_EditValueChanged;
            this.txt_TrainPlaceCode.EditValueChanged += txt_EditValueChanged;
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
        private TrainPlace _TrainPlace = null;
        private List<TrainPlace> _listCopy = null;
        private List<TrainPlace> _list = new List<TrainPlace>();
        #endregion

        #region 方法
        void gv_TrainPlace_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (formState == FormState.New)
            {
                this.gv_TrainPlace.DeleteRow(_list.Count-1);
                this._list.Remove(_TrainPlace);
            }
            formState = FormState.Modify;
            _TrainPlace = this.gv_TrainPlace.GetFocusedRow() as TrainPlace;
            if (_TrainPlace == null) return;
            switch (e.Clicks)
            {
                case 1:
                    BindText(_TrainPlace);
                    break;
            }
        }
        /// <summary>
        /// 绑定文本
        /// </summary>
        private void BindText(TrainPlace model)
        {
            txt_TrainPlaceCode.EditValue = model.TrainPlaceCode;
            txt_TrainPlaceName.EditValue = model.TrainPlaceName;
            txt_MnemonicCode.EditValue = model.MnemonicCode;
            txt_Note.EditValue = model.Note;
        }
        private void BindData()
        {
            _list = new TrainPlaceDAO().GetList();
            this.gc_TrainPlace.DataSource = _list;
            this.gc_TrainPlace.RefreshDataSource();
            _listCopy = new List<TrainPlace>();
            _listCopy.AddRange(_list.Select(item => (TrainPlace)item.Copy()));
            if (_list.Count > 0)
            {
                BindText(_list[0]);
                _TrainPlace = _list[0];
            }
            isinit = true;
        }
        void Add()
        {
            this.formState=FormState.New;
            _TrainPlace = new TrainPlace();
            _list.Add(_TrainPlace);
            this.gc_TrainPlace.RefreshDataSource();
            this.gv_TrainPlace.FocusedRowHandle = _list.Count - 1;
            BindText(_TrainPlace);
        }
        void Delete()
        {
            if(formState!=FormState.Modify)
                return;
            if (new TrainPlaceDAO().Delete(_TrainPlace.TrainPlaceID))
            {
                _list.Remove(_TrainPlace);
                _listCopy.Remove(_TrainPlace);
                this.gc_TrainPlace.RefreshDataSource();
            }
        }
        #endregion

        #region 事件

        /// <summary>
        /// 窗体加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormTrainPlace_Load(object sender, EventArgs e)
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
            txt_MnemonicCode.EditValue = ChineseUtil.ToPyLetters(txt_TrainPlaceName.Text.Trim());
            _TrainPlace.OperateStatus = OperateStatus.Modify;
            TextEdit _edit = sender as TextEdit;
            if (_edit.Name == "txt_TrainPlaceCode")
            {
                _TrainPlace.TrainPlaceCode = txt_TrainPlaceCode.Text;
            }
            else if (_edit.Name == "txt_TrainPlaceName")
            {
                _TrainPlace.TrainPlaceName = txt_TrainPlaceName.Text;
            }
            else if (_edit.Name == "txt_Note")
            {
                _TrainPlace.Note = txt_Note.Text;
            }
            _TrainPlace.MnemonicCode = txt_MnemonicCode.Text;
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
                _list = new List<TrainPlace>();
                _list.AddRange(_listCopy.Select(item => (TrainPlace)item.Copy()));
                this.gc_TrainPlace.DataSource = _list;
                this.gc_TrainPlace.RefreshDataSource();
            }
            else if (e.Item == this.Btn_Apply)
            {
                if(formState == FormState.New)
                {
                    _TrainPlace.TrainPlaceID = new CommonDAO().GetIntUniqueNumber("t_apply_place");
                    // _TrainPlace.OperateID = Program.CurrentEmployee.EmployeeID;
                    _TrainPlace.OperateTime = DateTime.Now;
                    if (new TrainPlaceDAO().Add(_TrainPlace))
                    {
                        _listCopy.Add((TrainPlace)_TrainPlace.Copy());
                        formState = FormState.Normal;
                        this.gc_TrainPlace.RefreshDataSource();
                    }
                    else
                    {
                        MsgBox.ShowWarn(_TrainPlace.TrainPlaceName + "添加失败");
                    }
                }
                else
                {
                    bool result = true;
                    _list.ForEach(m =>
                    {
                        if (m.OperateStatus == OperateStatus.Modify)
                        {
                            if (!new TrainPlaceDAO().Exist(m))
                            {
                                if (new TrainPlaceDAO().Update(m))
                                {
                                    m.OperateStatus = OperateStatus.Normal;
                                }
                                else
                                {
                                    MsgBox.ShowWarn(m.TrainPlaceName + "更新失败");
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
                    this.gc_TrainPlace.RefreshDataSource();
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