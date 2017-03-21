using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarDistpatchSYS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MFormMain = new FormMain();
            Application.Run(new FormLogin());
        }

        private static string ConStr = "";
        public static Employee CurrentEmployee = new Employee();
        public static FormMain MFormMain = null;
        public static DevExpress.XtraTab.XtraTabControl TabcMain = null;//主界面工作台
        public static List<CustomStrNode> ArrHistoryNode = new List<CustomStrNode>();
        public static Hashtable HtMinimizeForm = new Hashtable();//用于保存最小化窗口;
    }
}
