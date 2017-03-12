using QuickFrame.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DevExpress.XtraEditors.Controls;
using DS.Model;
using QuickFrame.Common;

namespace CarDistpatchSYS
{
    /// <summary>
    ///     公用库访问类
    /// </summary>
    public class CommonDAO 
    {
        /// <summary>
        ///     获取主键
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public int GetIntUniqueNumber(string name)
        {
            try
            {
                string sql = string.Format("select f_get_uniquenumber('{0}');", name);
                int result = Convert.ToInt32(MysqlHelper.ExecuteScalar(sql));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CheckRight(int employeeID)
        {

        }
    }
}