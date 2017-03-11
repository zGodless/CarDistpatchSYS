using DS.Common.Exception;
using DS.Model;
using QuickFrame.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DS.Data
{
    public class CheckDAO : DaoBase
    {
        /// <summary>
        ///  获取
        /// </summary>
        /// <param name="para"></param>
        /// <param name="outPara"></param>
        /// <returns></returns>
        public List<CheckQuery> query_Check2(Check_Para _para)
        {
            string procedureName = "p_query_check2";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("iTrainPlaceID", new QfParameter("iTrainPlaceID", _para.iTrainPlaceID));
            parms.Add("iSchoolID", new QfParameter("iSchoolID", _para.iSchoolID));
            parms.Add("iGroupID", new QfParameter("iGroupID", _para.iGroupID));
            parms.Add("iStudentState", new QfParameter("iStudentState", _para.iStudentState));

            try
            {
                List<CheckQuery> _list = new List<CheckQuery>();
                _list = RunProcedureGetList<CheckQuery>(procedureName, ref parms);
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
        public List<CheckQuery> query_Check(Check_Para _para)
        {
            string procedureName = "p_query_check";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("iTrainPlaceID", new QfParameter("iTrainPlaceID", _para.iTrainPlaceID));
            parms.Add("iSchoolID", new QfParameter("iSchoolID", _para.iSchoolID));
            parms.Add("iGroupID", new QfParameter("iGroupID", _para.iGroupID));
            parms.Add("iStudentState", new QfParameter("iStudentState", _para.iStudentState));

            try
            {
                List<CheckQuery> _list = new List<CheckQuery>();
                _list = RunProcedureGetList<CheckQuery>(procedureName, ref parms);
                return _list;
            }
            catch (Exception ex)
            {
                throw new DsException("获取科二统计失败！", ex);
            }
        }
    }
}
