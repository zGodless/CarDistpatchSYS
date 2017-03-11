using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using CrmClient.UIControl;
using DS.MSClient.UIControl;
using DS.MSClient.UICommon;
using System.Collections;
using DS.Model;
using QuickFrame.Common.Converter;


namespace DS.MSClient.UIControl
{
    /// <summary>
    /// 商品属性类别
    /// </summary>
    [ToolboxItem(true)]
    public class CLookComboStudentState : CSmartLookUpEditBase
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
			//Properties.Buttons.Clear();
			//Properties.Buttons.AddRange(new[]
			//{
			//	new EditorButton(ButtonPredefines.Combo) {IsDefaultButton = true},
			//	new EditorButton(ButtonPredefines.Redo, "刷新") {IsDefaultButton = false}
			//});
            EditValueChanged += cLookUp_EditValueChanged;
            if (Properties.Columns.Count == 0)
            {
                Properties.Columns.AddRange(new[]
				{
                    new LookUpColumnInfo("Value", "状态")

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


        #endregion

        #region Method

        private StudentState Currentduty = null;

        List<StudentState> arList = new List<StudentState>();
        protected override void OnRefreshButtonClick()
        {
            Bind(false);
        }
        protected override void OnNewButtonClick()
        {
            MsgBox.ShowWarn("我是触发了");
        }

        #region 绑定下拉框

        /// <summary>
        ///     绑定下拉控件数据集
        /// </summary>
        public void Bind(bool getFromCache = true)
        {
            StudentState model = new StudentState();
            model.Key = 10;
            model.Value = "资料受理";
            arList.Add(model);

            model = new StudentState();
            model.Key = 36;
            model.Value = "预报班";
            arList.Add(model);

            model = new StudentState();
            model.Key = 40;
            model.Value = "报班中";
            arList.Add(model);

            model = new StudentState();
            model.Key = 50;
            model.Value = "科一培训";
            arList.Add(model);

            model = new StudentState();
            model.Key = 60;
            model.Value = "科二培训";
            arList.Add(model);

            model = new StudentState();
            model.Key = 70;
            model.Value = "科三培训";
            arList.Add(model);

            model = new StudentState();
            model.Key = 74;
            model.Value = "科四培训";
            arList.Add(model);

            model = new StudentState();
            model.Key = 80;
            model.Value = "毕业归档";
            arList.Add(model);

            model = new StudentState();
            model.Key = 88;
            model.Value = "退学处理中";
            arList.Add(model);

            model = new StudentState();
            model.Key = 90;
            model.Value = "退学归档";
            arList.Add(model);

            model = new StudentState();
            model.Key = 100;
            model.Value = "复训";
            arList.Add(model);


            this.Properties.DisplayMember = "Value";
            this.Properties.ValueMember = "Key";
            Properties.ShowFooter = false;
            Properties.ShowHeader = false;
            this.Properties.DataSource = arList;
        }

        #endregion
        /// <summary>
        ///     值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cLookUp_EditValueChanged(object sender, EventArgs e)
        {
            if (arList == null) return;
            Currentduty = EditValue == null
                ? null
                : arList.Find(model => model.Key == ValueConvert.ToInt32(EditValue));
        }
        #endregion
    }
}
