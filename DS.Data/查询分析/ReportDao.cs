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
    public class ReportDao : DaoBase
    {
        
        /// <summary>
        ///  获取
        /// </summary>
        /// <param name="para"></param>
        /// <param name="outPara"></param>
        /// <returns></returns>
        public List<Report> Query2(DateTime beginTime,DateTime endTime)
        {
            const string procedureName = "p_report2";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("dBeginDate", new QfParameter("dBeginDate", beginTime.ToString("yyyy-MM-dd")));
            parms.Add("dEndDate", new QfParameter("dEndDate", endTime.ToString("yyyy-MM-dd")));
            try
            {
                List<Report> _list = new List<Report>();
                _list = RunProcedureGetList<Report>(procedureName, ref parms);
                return _list;
            }
            catch (Exception ex)
            {
                throw new DsException("获取科二统计失败！", ex);
            }
        }

        /// <summary>
        ///  获取
        /// </summary>
        /// <param name="para"></param>
        /// <param name="outPara"></param>
        /// <returns></returns>
        public List<SchoolExamReport> SchoolExamReportQuery(DateTime beginTime, DateTime endTime)
        {
            const string procedureName = "p_schoolexamreport";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("dBeginDate", new QfParameter("dBeginDate", beginTime.ToString("yyyy-MM-dd")));
            parms.Add("dEndDate", new QfParameter("dEndDate", endTime.ToString("yyyy-MM-dd")));
            try
            {
                List<SchoolExamReport> _list = new List<SchoolExamReport>();
                _list = RunProcedureGetList<SchoolExamReport>(procedureName, ref parms);
                return _list;
            }
            catch (Exception ex)
            {
                throw new DsException("获取学校月考试统计失败！", ex);
            }
        }
/// <summary>
        ///  获取
        /// </summary>
        /// <param name="para"></param>
        /// <param name="outPara"></param>
        /// <returns></returns>
        public List<SchoolExamReport> AptExaminationQuery(DateTime beginTime, DateTime endTime)
        {
            const string procedureName = "p_appointmentexamination";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("dBeginDate", new QfParameter("dBeginDate", beginTime.ToString("yyyy-MM-dd")));
            parms.Add("dEndDate", new QfParameter("dEndDate", endTime.ToString("yyyy-MM-dd")));
            try
            {
                List<SchoolExamReport> _list = new List<SchoolExamReport>();
                _list = RunProcedureGetList<SchoolExamReport>(procedureName, ref parms);
                return _list;
            }
            catch (Exception ex)
            {
                throw new DsException("获取自约统计失败！", ex);
            }
        }
        /// <summary>
        ///  获取
        /// </summary>
        /// <param name="para"></param>
        /// <param name="outPara"></param>
        /// <returns></returns>
        public List<Report> Query3(DateTime beginTime, DateTime endTime)
        {
            const string procedureName = "p_report3";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("dBeginDate", new QfParameter("dBeginDate", beginTime.ToString("yyyy-MM-dd")));
            parms.Add("dEndDate", new QfParameter("dEndDate", endTime.ToString("yyyy-MM-dd")));
            try
            {
                List<Report> _list = new List<Report>();
                _list = RunProcedureGetList<Report>(procedureName, ref parms);
                return _list;
            }
            catch (Exception ex)
            {
                throw new DsException("获取科三统计表失败！", ex);
            }
        }
        /// <summary>
        ///  获取
        /// </summary>
        /// <param name="para"></param>
        /// <param name="outPara"></param>
        /// <returns></returns>
        public List<GroupStatistic> GroupStatisticQuery(DateTime beginTime, DateTime endTime)
        {
            const string procedureName = "p_appointmentexamination";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("dBeginDate", new QfParameter("dBeginDate", beginTime.ToString("yyyy-MM-dd")));
            parms.Add("dEndDate", new QfParameter("dEndDate", endTime.ToString("yyyy-MM-dd")));
            try
            {
                List<GroupStatistic> _list = new List<GroupStatistic>();
                _list = RunProcedureGetList<GroupStatistic>(procedureName, ref parms);
                return _list;
            }
            catch (Exception ex)
            {
                throw new DsException("获取车辆分队预约统计失败！", ex);
            }
        }
    }
}
