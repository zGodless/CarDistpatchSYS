using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS.MSClient.UIControl
{
    interface ICGridLayout
    {
        /// <summary>
        /// 加载和保存grid样式
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="moduleName"></param>
        /// <param name="layoutXMLName"></param>
        void LoadGridLayout(string employeeCode, string moduleName, string layoutXMLName);
    }
}
