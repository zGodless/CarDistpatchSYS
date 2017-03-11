using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DS.MSClient.UICommon.MessageBox
{
    public partial class MsgBoxShowTip : Form
    {
        public MsgBoxShowTip()
        {
            InitializeComponent();
            InitEvent();
            Init();
        }
        private void InitEvent()
        {
            Load += MsgBoxShowTip_Load;
            BtnOK.Click += BtnOK_Click;
        }

        void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception)
            {
            }
        }

        private void Init()
        {

        }

        void MsgBoxShowTip_Load(object sender, EventArgs e)
        {
            ShowText();
        }

        public string tipStr = "";
        public string memoStr = "";

        private void ShowText()
        {
            if (!string.IsNullOrEmpty(tipStr))
            {
                labelControl1.Text = tipStr;
            }
            if (!string.IsNullOrEmpty(memoStr))
            {
                memoEdit1.Text = memoStr;
            }
        }
    }
}
