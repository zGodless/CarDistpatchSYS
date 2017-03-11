using DS.Common.Exception;
using DS.Model;
using QuickFrame.Common.Converter;
using QuickFrame.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DS.Data
{
    public class K2ReportDao : DaoBase
    {
        
        /// <summary>
        ///  获取
        /// </summary>
        /// <param name="para"></param>
        /// <param name="outPara"></param>
        /// <returns></returns>
        public List<K2Report> Query(DateTime beginTime,DateTime endTime)
        {
            const string procedureName = "p_report2";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("dBeginDate", new QfParameter("dBeginDate", beginTime.ToString("yyyy-MM-dd")));
            parms.Add("dEndDate", new QfParameter("dEndDate", endTime.ToString("yyyy-MM-dd")));
            try
            {
                List<K2Report> _list = new List<K2Report>();
                _list = RunProcedureGetList<K2Report>(procedureName, ref parms);
                return _list;
            }
            catch (Exception ex)
            {
                throw new DsException("获取卡券表失败！", ex);
            }
        }
    }
}
