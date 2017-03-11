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
    /// 提现
    /// </summary>
    public partial class FormEditWithDrawal : FormBase
    {
        public FormEditWithDrawal()
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
            if (txt_CashAmount.Text == "")
            {

                MsgBox.ShowInfo("可提现金额不为空");
                return;
            }
            int itype = 2;
            int? Amount = ValueConvert.ToNullableInt32(this.txt_CashAmount.Text);
            string note = txt_Note.Text;
            string StudentIDstr = StuCurrent.StudentID.ToString();
            bool result = new AccountDao().query(StudentIDstr, Amount, itype, note, Program.CurrentEmployee.EmployeeID, DateTime.Now);
            if (result)
            {
                MsgBox.ShowInfo("提现成功！");
                this.Close();

                //this.AccCurrent = new AccountDao().GetModel_StudentID(this.StuCurrent.StudentID);
                //Lab_Amount.Text = AccCurrent.CashAmount.ToString() ;

            }
            else
            { MsgBox.ShowInfo("提现失败，账户余额足！"); 
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
                this.AccCurrent.AccountCode = "C" + AccCurrent.AccountID;
                AccCurrent.OperateID = Program.CurrentEmployee.EmployeeID;
                AccCurrent.OperateTime = DateTime.Now;
                bool result1 = new AccountDao().Add(AccCurrent);



            }


            this.AccCurrent = new AccountDao().GetModel_StudentID(this.StuCurrent.StudentID);

            this.txt_studentname.Text = StuCurrent.StudentName;
            this.txt_AccountCode.Text = this.AccCurrent.AccountCode;
            Lab_Amount.Text = AccCurrent.CashAmount.ToString();


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
