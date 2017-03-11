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
    public partial class FormDuty : FormBase
    {
        #region 初始化
        public FormDuty()
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
            Load += FormDuty_Load;

            this.gv_Duty.RowClick += gv_Duty_RowClick;
            this.txt_DutyName.EditValueChanged += txt_EditValueChanged;
            this.txt_DutyCode.EditValueChanged += txt_EditValueChanged;
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
        private Duty _Duty = null;
         private List<Duty> _listCopy  = null;
        private List<Duty> _list = new List<Duty>();
        #endregion

        #region 方法
        void gv_Duty_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (formState == FormState.New)
            {
                this.gv_Duty.DeleteRow(_list.Count-1);
                this._list.Remove(_Duty);
            }
            formState = FormState.Modify;
            _Duty = this.gv_Duty.GetFocusedRow() as Duty;
            if (_Duty == null) return;
            switch (e.Clicks)
            {
                case 1:
                    BindText(_Duty);
                    break;
            }
        }
        /// <summary>
        /// 绑定文本
        /// </summary>
        private void BindText(Duty model)
        {
            txt_DutyCode.EditValue = model.DutyCode;
            txt_DutyName.EditValue = model.DutyName;
            txt_MnemonicCode.EditValue = model.MnemonicCode;
            txt_Note.EditValue = model.Note;
        }
        private void BindData()
        {
            _list = new DutyDao().GetList();
            this.gc_Duty.DataSource = _list;
            this.gc_Duty.RefreshDataSource();
            _listCopy=new List<Duty>();
            _listCopy.AddRange(_list.Select(item => (Duty)item.Copy()));
            if (_list.Count > 0)
            {
                BindText(_list[0]);
                _Duty = _list[0];
            }
            isinit = true;
        }
        void Add()
        {
            this.formState=FormState.New;
            _Duty = new Duty();
            _list.Add(_Duty);
            this.gc_Duty.RefreshDataSource();
            this.gv_Duty.FocusedRowHandle = _list.Count - 1;
            BindText(_Duty);
        }
        void Delete()
        {
            if(formState!=FormState.Modify)
                return;
            if (new DutyDao().Delete(_Duty.DutyID))
            {
                _list.Remove(_Duty);
                _listCopy.Remove(_Duty);
                this.gc_Duty.RefreshDataSource();
            }
        }
        #endregion

        #region 事件

        /// <summary>
        /// 窗体加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormDuty_Load(object sender, EventArgs e)
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
            txt_MnemonicCode.EditValue = ChineseUtil.ToPyLetters(txt_DutyName.Text.Trim());
            _Duty.OperateStatus = OperateStatus.Modify;
            TextEdit _edit = sender as TextEdit;
            if (_edit.Name == "txt_DutyCode")
            {
                _Duty.DutyCode = txt_DutyCode.Text;
            }
            else if (_edit.Name == "txt_DutyName")
            {
                _Duty.DutyName = txt_DutyName.Text;
            }
            else if (_edit.Name == "txt_Note")
            {
                _Duty.Note = txt_Note.Text;
            }
            _Duty.MnemonicCode = txt_MnemonicCode.Text;
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
                _list = new List<Duty>();
                _list.AddRange(_listCopy.Select(item => (Duty)item.Copy()));
                this.gc_Duty.DataSource = _list;
                this.gc_Duty.RefreshDataSource();
            }
            else if (e.Item == this.Btn_Apply)
            {
                if(formState == FormState.New)
                {
                    _Duty.DutyID = new CommonDAO().GetIntUniqueNumber("t_duty");
                   // _Duty.OperateID = Program.CurrentEmployee.EmployeeID;
                    _Duty.OperateTime = DateTime.Now;
                    if (new DutyDao().Add(_Duty))
                    {
                        _listCopy.Add((Duty)_Duty.Copy());
                        formState = FormState.Normal;
                        this.gc_Duty.RefreshDataSource();
                    }
                    else
                    {
                        MsgBox.ShowWarn(_Duty.DutyName + "添加失败");
                    }
                }
                else
                {
                    bool result = true;
                    _list.ForEach(m =>
                    {
                        if (m.OperateStatus == OperateStatus.Modify)
                        {
                            if (!new DutyDao().Exists(m))
                            {
                                if (new DutyDao().Update(m))
                                {
                                    m.OperateStatus = OperateStatus.Normal;
                                }
                                else
                                {
                                    MsgBox.ShowWarn(m.DutyName + "更新失败");
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
                    this.gc_Duty.RefreshDataSource();
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