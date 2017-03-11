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


namespace DS.MSClient.UIControl
{
    /// <summary>
    /// 考试状态
    /// </summary>
    [ToolboxItem(true)]
    public class CLookComboExamstate : CSmartLookUpEditBase
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
            ArrayList arList = new ArrayList();
            arList.Add(new DictionaryEntry("", ""));
            arList.Add(new DictionaryEntry("50", "未考"));
            arList.Add(new DictionaryEntry("100", "科一正考"));
            arList.Add(new DictionaryEntry("101", "科一补考"));

            arList.Add(new DictionaryEntry("200", "科二正考"));
            arList.Add(new DictionaryEntry("201", "科二补考"));

            arList.Add(new DictionaryEntry("300", "科三正考"));
            arList.Add(new DictionaryEntry("301", "科三补考"));

            arList.Add(new DictionaryEntry("340", "科四正考"));
            arList.Add(new DictionaryEntry("341", "科四补考"));

            arList.Add(new DictionaryEntry("400", "毕业"));
            arList.Add(new DictionaryEntry("500", "退学"));


            this.Properties.DisplayMember = "Value";
            this.Properties.ValueMember = "Key";
            Properties.ShowFooter = false;
            Properties.ShowHeader = false;
            this.Properties.DataSource = arList;
        }

        #endregion

        #endregion
    }
}
