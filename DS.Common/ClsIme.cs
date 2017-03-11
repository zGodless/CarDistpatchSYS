using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DS.Common
{
    /// <summary>
    /// 将输入法全角转换为半角
    /// </summary>
    public class ClsIme
    {
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hwnd);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetOpenStatus(IntPtr himc);
        [DllImport("imm32.dll")]
        public static extern bool ImmSetOpenStatus(IntPtr himc, bool b);
        [DllImport("imm32.dll")]
        public static extern bool ImmGetConversionStatus(IntPtr himc, ref int lpdw, ref int lpdw2);
        [DllImport("imm32.dll")]
        public static extern int ImmSimulateHotKey(IntPtr hwnd, int lngHotkey);
        public const int IME_CMODE_FULLSHAPE = 0x8;
        public const int IME_CHOTKEY_SHAPE_TOGGLE = 0x11;

        /// <summary>
        /// 重载SetIme，传入Form
        /// </summary>
        /// <param name="frm"></param>
        public static void SetIme(Form frm)
        {
            frm.Paint += new PaintEventHandler(frm_Paint);
            ChangeAllControl(frm);
        }
        /// <summary>
        /// 重载SetIme，传入Control
        /// </summary>
        /// <param name="ctl"></param>
        public static void SetIme(Control ctl)
        {
            ChangeAllControl(ctl);
        }
        /// <summary>
        /// 重载SetIme，传入对象句柄
        /// </summary>
        /// <param name="Handel"></param>
        public static void SetIme(IntPtr Handel)
        {
            ChangeControlIme(Handel);
        }
        /// <summary>
        /// 在控件的的Enter事件中触发来调整输入法状态
        /// </summary>
        /// <param name="ctl"></param>
        private static void ChangeAllControl(Control ctl)
        {
            ctl.Enter += new EventHandler(ctl_Enter);
            foreach (Control ctlChild in ctl.Controls)
            {
                ChangeAllControl(ctlChild);
            }
        }
        private static void frm_Paint(object sender, PaintEventArgs e)
        {
            ChangeControlIme(sender);
        }
        private static void ctl_Enter(object sender, EventArgs e)
        {
            ChangeControlIme(sender);
        }
        private static void ChangeControlIme(object sender)
        {
            var ctl = (Control)sender;
            ChangeControlIme(ctl.Handle);
        }

        /// <summary>
        /// 检查输入法的全角半角状态
        /// </summary>
        /// <param name="h"></param>
        private static void ChangeControlIme(IntPtr h)
        {
            var HIme = ImmGetContext(h);
            if (ImmGetOpenStatus(HIme))
            {
                var iMode = 0;
                var iSentence = 0;
                var bSuccess = ImmGetConversionStatus(HIme, ref iMode, ref iSentence);
                if (bSuccess)
                {
                    if ((iMode & IME_CMODE_FULLSHAPE) > 0)
                    {
                        ImmSimulateHotKey(h, IME_CHOTKEY_SHAPE_TOGGLE);
                    }
                }
            }
        }
    }
}
