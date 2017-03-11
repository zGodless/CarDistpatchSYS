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
    public partial class FormService : FormBase
    {
        #region 初始化
          public FormService()
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
            Load += FormService_Load;

            this.gv_Service.RowClick += gv_Service_RowClick;
            this.txt_ServiceName.EditValueChanged += txt_EditValueChanged;
            this.txt_ServiceCode.EditValueChanged += txt_EditValueChanged;
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
        private Service _Service = null;
        private List<Service> _listCopy = null;
        private List<Service> _list = new List<Service>();
        #endregion

        #region 方法
        void gv_Service_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (formState == FormState.New)
            {
                this.gv_Service.DeleteRow(_list.Count-1);
                this._list.Remove(_Service);
            }
            formState = FormState.Modify;
            _Service = this.gv_Service.GetFocusedRow() as Service;
            if (_Service == null) return;
            switch (e.Clicks)
            {
                case 1:
                    BindText(_Service);
                    break;
            }
        }
        /// <summary>
        /// 绑定文本
        /// </summary>
        private void BindText(Service model)
        {
            txt_ServiceCode.EditValue = model.ServiceCode;
            txt_ServiceName.EditValue = model.ServiceName;
            txt_MnemonicCode.EditValue = model.MnemonicCode;
            txt_Note.EditValue = model.Note;
        }
        private void BindData()
        {
            _list = new ServiceDao().GetList();
            this.gc_Service.DataSource = _list;
            this.gc_Service.RefreshDataSource();
            _listCopy = new List<Service>();
            _listCopy.AddRange(_list.Select(item => (Service)item.Copy()));
            if (_list.Count > 0)
            {
                BindText(_list[0]);
                _Service = _list[0];
            }
            isinit = true;
        }
        void Add()
        {
            this.formState=FormState.New;
            _Service = new Service();
            _list.Add(_Service);
            this.gc_Service.RefreshDataSource();
            this.gv_Service.FocusedRowHandle = _list.Count - 1;
            BindText(_Service);
        }
        void Delete()
        {
            if(formState!=FormState.Modify)
                return;
            if (new ServiceDao().Delete(_Service.ServiceID))
            {
                _list.Remove(_Service);
                _listCopy.Remove(_Service);
                this.gc_Service.RefreshDataSource();
            }
        }
        #endregion

        #region 事件

        /// <summary>
        /// 窗体加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormService_Load(object sender, EventArgs e)
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
            txt_MnemonicCode.EditValue = ChineseUtil.ToPyLetters(txt_ServiceName.Text.Trim());
            _Service.OperateStatus = OperateStatus.Modify;
            TextEdit _edit = sender as TextEdit;
            if (_edit.Name == "txt_ServiceCode")
            {
                _Service.ServiceCode = txt_ServiceCode.Text;
            }
            else if (_edit.Name == "txt_ServiceName")
            {
                _Service.ServiceName = txt_ServiceName.Text;
            }
            else if (_edit.Name == "txt_Note")
            {
                _Service.Note = txt_Note.Text;
            }
            _Service.MnemonicCode = txt_MnemonicCode.Text;
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
                _list = new List<Service>();
                _list.AddRange(_listCopy.Select(item => (Service)item.Copy()));
                this.gc_Service.DataSource = _list;
                this.gc_Service.RefreshDataSource();
            }
            else if (e.Item == this.Btn_Apply)
            {
                if(formState == FormState.New)
                {
                    _Service.ServiceID = new CommonDAO().GetIntUniqueNumber("t_service");
                    // _Service.OperateID = Program.CurrentEmployee.EmployeeID;
                    _Service.OperateTime = DateTime.Now;
                    if (new ServiceDao().Add(_Service))
                    {
                        _listCopy.Add((Service)_Service.Copy());
                        formState = FormState.Normal;
                        this.gc_Service.RefreshDataSource();
                    }
                    else
                    {
                        MsgBox.ShowWarn(_Service.ServiceName + "添加失败");
                    }
                }
                else
                {
                    bool result = true;
                    _list.ForEach(m =>
                    {
                        if (m.OperateStatus == OperateStatus.Modify)
                        {
                            if (!new ServiceDao().Exist(m.ServiceID,m.ServiceCode))
                            {
                                if (new ServiceDao().Update(m))
                                {
                                    m.OperateStatus = OperateStatus.Normal;
                                }
                                else
                                {
                                    MsgBox.ShowWarn(m.ServiceName + "更新失败");
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
                    this.gc_Service.RefreshDataSource();
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