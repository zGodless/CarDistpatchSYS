using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DS.Common;
using DS.Model;
using DS.Data;
using DS.MSClient;
using QuickFrame.Common.Converter;


namespace DS.MSClient.UICommon
{
    /// <summary>
    /// 个人充值
    /// </summary>
    public partial class FormEditTopUp : FormBase
    {
        public FormEditTopUp()
        {
            InitializeComponent();
            this.Init();
        }
        #region
        void Init()
        {
            Load += FormEditTopUp_Load;
            this.simpleButton_no.Click += simpleButton_no_Click;
            this.simpleButton_yes.Click += simpleButton_yes_Click;
        }

        void simpleButton_yes_Click(object sender, EventArgs e)
        {
            int itype = 0;
            if (txt_CashAmount.Text == "")
            {

                MsgBox.ShowInfo("充值金额不为空");
                return;
            }
            if (this.checkEdit_ISUse.Checked)
            {
                itype = 1;
            }
            else
            {
                itype = 0;
            }
            int? Amount=ValueConvert.ToNullableInt32(this.txt_CashAmount.Text);
            string note= txt_Note.Text;
            string StudentIDstr = StuCurrent.StudentID.ToString();
            bool result = new AccountDao().query(StudentIDstr, Amount, itype, note, Program.CurrentEmployee.EmployeeID, DateTime.Now);
            if(result)
            {
                MsgBox.ShowInfo("充值成功"); 
                    this.Close();
                
            }
            else
            { MsgBox.ShowInfo("充值失败");
            this.Close();
            }
         
           
        }

        void simpleButton_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void FormEditTopUp_Load(object sender, EventArgs e)
        {
            bool result = new AccountDao().Exist_StudentID(this.StuCurrent.StudentID);

            if (result == false)
            {
                this.AccCurrent.AccountID = new CommonDAO().GetIntUniqueNumber("t_account");
                this.AccCurrent.StudentID = StuCurrent.StudentID;
                this.AccCurrent.AccountCode = new CommonDAO().GetRunning_Number("ZH");
                AccCurrent.OperateID = Program.CurrentEmployee.EmployeeID;
                AccCurrent.OperateTime = DateTime.Now;
                bool result1 = new AccountDao().Add(AccCurrent);

        

            }


            this.AccCurrent = new AccountDao().GetModel_StudentID(this.StuCurrent.StudentID);

            this.txt_studentname.Text = StuCurrent.StudentName;
            this.txt_AccountCode.Text = this.AccCurrent.AccountCode;

        }
        #endregion
        #region 属性
        public Student StuCurrent = new Student();
        public Account AccCurrent = new Account();
        public AccountSeq SeqCurrent = new AccountSeq();
        #endregion
        #region
        #endregion
        #region
        #endregion

    }
}
