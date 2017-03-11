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
    /// 学时状态
    /// </summary>
    [ToolboxItem(true)]
    public class CLookComboSchoolState : CSmartLookUpEditBase
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
            arList.Add(new DictionaryEntry("NotUpStandard", "学时未达标"));
            arList.Add(new DictionaryEntry("UpStandardUnAudit", "学时已达标"));
            arList.Add(new DictionaryEntry("StudentSign", "学员已签字"));

            arList.Add(new DictionaryEntry("CoachSign", "教练已签字"));
            arList.Add(new DictionaryEntry("SchoolSign", "学校已签章"));
            arList.Add(new DictionaryEntry("Upload", "学校已上报"));


            arList.Add(new DictionaryEntry("TMAudit", "运管已核审"));
            arList.Add(new DictionaryEntry("PassAudit", "运管已签章"));

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
