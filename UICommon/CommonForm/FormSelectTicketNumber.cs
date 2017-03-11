using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;

namespace DS.MSClient.UICommon
{
    /// <summary>
    /// 生成卡券
    /// </summary>
    public partial class FormSelectTicketNumber : FormBase
    {
        public FormSelectTicketNumber()
        {
            InitializeComponent();
            this.Init();

        }
        #region  初始化
        void Init()
        {

            this.Load += FormSelectTicketNumber_Load;
            this.simpleButton_yes.Click += simpleButton_yes_Click;
            this.simpleButton_no.Click += simpleButton_yes_Click;

        }
        #endregion
        #region 属性
        public int number = 0;
        public string note = "";
        #endregion

        #region 事件
        void simpleButton_yes_Click(object sender, EventArgs e)
        {


            if (sender == simpleButton_yes)
            {
                note = this.txt_Note.Text;
                number = Convert.ToInt32(txt_number.Text);
                if (number == 0)
                {
                    MsgBox.ShowInfo("请选择生成卡券数量");
                    return;
                }
                this.DialogResult = DialogResult.Yes;
            }
            else if (sender == simpleButton_no)
            {
                this.Close();
            }
        }
        void FormSelectTicketNumber_Load(object sender, EventArgs e)
        {
        }
        #endregion


    }
}
