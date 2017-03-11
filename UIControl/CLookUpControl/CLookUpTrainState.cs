using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DS.MSClient.UIControl;
using DS.MSClient.UICommon;
using DS.Model;

namespace DS.MSClient.UIControl
{
    [ToolboxItem(true)]
    public partial class CLookUpTrainState : CSmartLookUpEditBase
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            EditValueChanged += cLookUp_EditValueChanged;
			//Properties.Buttons.Clear();
			//Properties.Buttons.AddRange(new[]
			//{
			//	new EditorButton(ButtonPredefines.Combo) {IsDefaultButton = true},
			//	new EditorButton(ButtonPredefines.Redo, "刷新") {IsDefaultButton = false}
			//});
            if (Properties.Columns.Count == 0)
            {
                Properties.Columns.AddRange(new[]
				{
					new LookUpColumnInfo("StateNames", "培训状态")
				});
            }
            Properties.CharacterCasing = CharacterCasing.Upper;
            Properties.NullText = string.Empty;
            Properties.NullValuePrompt = string.Empty;
            Properties.NullValuePromptShowForEmptyValue = true;
            Properties.PopupSizeable = true;
            Properties.ShowFooter = true;
            Properties.ShowHeader = true;
            Refresh(true);
        }

        #region 属性

        public List<TrainState> ListIsValid { get; set; }
        public TrainState selSource { get; set; }
        public string Types = "";

        #endregion

        #region Method

        protected override void OnRefreshButtonClick()
        {
            BindList(false);
        }
        protected override void OnNewButtonClick()
        {
            MsgBox.ShowWarn("我是触发了");
        }

        #region 绑定下拉框

        /// <summary>
        ///     绑定下拉控件数据集
        /// </summary>
        public void BindList(bool getFromCache = true)
        {
            ListIsValid = CreateSource();

            Properties.DataSource = ListIsValid;
            Properties.DisplayMember = "StateNames";
            Properties.ValueMember = "Codes";
            Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            Properties.SearchMode = SearchMode.AutoFilter;
            Properties.CaseSensitiveSearch = true;
            Properties.AutoSearchColumnIndex = 2;
        }

        private List<TrainState> CreateSource()
        {
            List<TrainState> lists = new List<TrainState>();

            TrainState os12 = new TrainState();
            os12.Codes = "";
            os12.StateNames = "";
            lists.Add(os12);

            TrainState os1 = new TrainState();
            os1.Codes = "10";
            os1.StateNames = "资料受理";
            lists.Add(os1);

            TrainState os2 = new TrainState();
            os2.Codes = "36";
            os2.StateNames = "预报班";
            lists.Add(os2);

            TrainState os3 = new TrainState();
            os3.Codes = "40";
            os3.StateNames = "报班中";
            lists.Add(os3);

            TrainState os4 = new TrainState();
            os4.Codes = "50";
            os4.StateNames = "科一培训";
            lists.Add(os4);

            TrainState os5 = new TrainState();
            os5.Codes = "60";
            os5.StateNames = "科二培训";
            lists.Add(os5);

            TrainState os6 = new TrainState();
            os6.Codes = "70";
            os6.StateNames = "科三培训";
            lists.Add(os6);

            TrainState os7 = new TrainState();
            os7.Codes = "74";
            os7.StateNames = "科四培训";
            lists.Add(os7);

            TrainState os8 = new TrainState();
            os8.Codes = "80";
            os8.StateNames = "毕业归档";
            lists.Add(os8);

            TrainState os9 = new TrainState();
            os9.Codes = "88";
            os9.StateNames = "退学处理中";
            lists.Add(os9);

            TrainState os10 = new TrainState();
            os10.Codes = "90";
            os10.StateNames = "退学归档";
            lists.Add(os10);

            TrainState os11 = new TrainState();
            os11.Codes = "100";
            os11.StateNames = "复训";
            lists.Add(os11);

            return lists;
        }

        /// <summary>
        ///     值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cLookUp_EditValueChanged(object sender, EventArgs e)
        {
            if (ListIsValid == null) return;
            selSource = EditValue == null
                    ? null
                    : ListIsValid.Find(model => model.Codes == EditValue);
        }
        #endregion

        #endregion

    }
}
