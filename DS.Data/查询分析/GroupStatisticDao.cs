using DS.Model;
using QuickFrame.Common.Converter;
using QuickFrame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DS.Data
{
    /// <summary>
    /// 模块：数据访问
    /// 作用：数据访问类:GroupStatisticDao
    /// 作者：NOLY
    /// 代码生成日期：2016-04-20
    /// 最后修改人：LB
    /// 最后修改日期：2016-04-20
    /// 说明：
    /// </summary>
    public class GroupStatisticDao : DaoBase
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GroupStatistic> GetGroupByDateSchoolTrainPlace(DateTime _beginDate, DateTime _endDate, int SchoolID, int TrainPlaceID, int GroupID)
        {
            var strSql = new StringBuilder();
            if (GroupID!=0)
            {
                strSql.Append(@"REPOS:Query.Query.GetGroupByDateGroup");
            }
            else
            {
                if(SchoolID!=0&&TrainPlaceID!=0)
                {
                    strSql.Append(@"REPOS:Query.Query.GetGroupByDateSchoolTrainPlace");
                }
                else
                {
                    if(SchoolID != 0)
                    {
                        strSql.Append(@"REPOS:Query.Query.GetGroupByDateSchool");
                    }
                    if (TrainPlaceID != 0)
                    {
                        strSql.Append(@"REPOS:Query.Query.GetGroupByDateTrainPlace");
                    }

                }
            }
            if(strSql.Length==0)
            {
                strSql.Append(@"REPOS:Query.Query.GetGroupByDate");
            }
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StartDate", _beginDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@EndDate", _endDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@SchoolID", SchoolID));
            parameters.Add(new QfParameter("@TrainPlaceID", TrainPlaceID));
            parameters.Add(new QfParameter("@GroupID", GroupID));
            try
            {
                return QueryGetList<GroupStatistic>(strSql.ToString(),parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GroupStatistic> GetCarByDateGroup(DateTime _beginDate, DateTime _endDate, int GroupID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Query.Query.GetCarByDateGroup");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StartDate", _beginDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@EndDate", _endDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@GroupID", GroupID));
            try
            {
                return QueryGetList<GroupStatistic>(strSql.ToString(), parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取车辆开放数
        /// </summary>
        public int GetAllowNum(DateTime _beginDate, DateTime _endDate, int CarID, int GroupID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Query.Query.GetAllowNum");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StartDate", _beginDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@EndDate", _endDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@GroupID", GroupID));
            parameters.Add(new QfParameter("@CarID", CarID));
            return ValueConvert.ToInt32(GetSingle(strSql.ToString(), parameters.ToArray()));
        }

        /// <summary>
        /// 获取车辆暂停数
        /// </summary>
        public int GetStopNum(DateTime _beginDate, DateTime _endDate, int CarID, int GroupID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Query.Query.GetStopNum");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StartDate", _beginDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@EndDate", _endDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@GroupID", GroupID));
            parameters.Add(new QfParameter("@CarID", CarID));
            return ValueConvert.ToInt32(GetSingle(strSql.ToString(), parameters.ToArray()));
        }

        /// <summary>
        /// 获取车辆预约数
        /// </summary>
        public int GetAppointNum(DateTime _beginDate, DateTime _endDate, int CarID, int GroupID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Query.Query.GetAppointNum");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StartDate", _beginDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@EndDate", _endDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@GroupID", GroupID));
            parameters.Add(new QfParameter("@CarID", CarID));
            return ValueConvert.ToInt32(GetSingle(strSql.ToString(), parameters.ToArray()));
        }

        /// <summary>
        /// 获取车辆取消数
        /// </summary>
        public int GetCancelNum(DateTime _beginDate, DateTime _endDate, int CarID, int GroupID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Query.Query.GetCancelNum");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StartDate", _beginDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@EndDate", _endDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@GroupID", GroupID));
            parameters.Add(new QfParameter("@CarID", CarID));
            return ValueConvert.ToInt32(GetSingle(strSql.ToString(), parameters.ToArray()));
        }

        /// <summary>
        /// 获取分队预约数
        /// </summary>
        public int GetAppointNumGroup(DateTime _beginDate, DateTime _endDate, int GroupID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Query.Query.GetAppointNumGroup");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StartDate", _beginDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@EndDate", _endDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@GroupID", GroupID));
            return ValueConvert.ToInt32(GetSingle(strSql.ToString(), parameters.ToArray()));
        }

        /// <summary>
        /// 获取分队暂停数
        /// </summary>
        public int GetStopNumGroup(DateTime _beginDate, DateTime _endDate, int GroupID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Query.Query.GetStopNumGroup");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StartDate", _beginDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@EndDate", _endDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@GroupID", GroupID));
            return ValueConvert.ToInt32(GetSingle(strSql.ToString(), parameters.ToArray()));
        }

        /// <summary>
        /// 获取分队开放数
        /// </summary>
        public int GetAllowNumGroup(DateTime _beginDate, DateTime _endDate, int GroupID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Query.Query.GetAllowNumGroup");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StartDate", _beginDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@EndDate", _endDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@GroupID", GroupID));
            return ValueConvert.ToInt32(GetSingle(strSql.ToString(), parameters.ToArray()));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<GroupStatistic> GetAppointByExamState(DateTime _beginDate, DateTime _endDate, int GroupID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Query.Query.GetAppointByExamState");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StartDate", _beginDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@EndDate", _endDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@GroupID", GroupID));
            try
            {
                return QueryGetList<GroupStatistic>(strSql.ToString(),parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取分队总赴约数
        /// </summary>
        public int GetAptSum(DateTime _beginDate, DateTime _endDate, int GroupID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Query.Query.GetAptSum");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StartDate", _beginDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@EndDate", _endDate.ToString("yyyy-MM-dd")));
            parameters.Add(new QfParameter("@GroupID", GroupID));
            return ValueConvert.ToInt32(GetSingle(strSql.ToString(), parameters.ToArray()));
        }
    }
}
