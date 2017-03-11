using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DS.MSClient.UICommon
{
    public partial class FormStudentOrSchool : FormDlgBase
    {
        public FormStudentOrSchool()
        {
            InitializeComponent();
            this.Init();
        }
        void Init()
        {
            this.btnOK.Click += btnOK_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnOK_Click(object sender, EventArgs e)
        {   
            this.DialogResult = DialogResult.Yes;
        }
    }
}
