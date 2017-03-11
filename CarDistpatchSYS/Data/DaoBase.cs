using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using QuickFrame.ClientConnector;
using QuickFrame.Common;
using QuickFrame.Common.Converter;
using QuickFrame.Model;
using CarDistpatchSYS;
using MySql.Data.MySqlClient;

namespace CarDistpatchSYS
{
    class DaoBase : MysqlHelper
    {
        /// <summary>
        ///     数据库帮助类
        /// </summary>
        public static MysqlHelper Connector;

        public DaoBase()
        {
            if (Connector == null)
            {
                Connector = new MysqlHelper();
            }
        }
    }
}
