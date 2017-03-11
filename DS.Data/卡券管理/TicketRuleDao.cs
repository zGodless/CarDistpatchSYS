using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using DS.Model;
using QuickFrame.Model;
using QuickFrame.Common.Exception;
using QuickFrame.Common.Converter;
using DS.Common.Exception;

namespace DS.Data
{
    /// <summary>
    /// 模块：数据访问
    /// 作用：数据访问类:TicketRuleDao
    /// 作者：cxl
    /// 代码生成日期：2015-11-16
    /// 最后修改人：cxl
    /// 最后修改日期：2015-11-16
    /// 说明：
    /// </summary>
    public class TicketRuleDao : DaoBase
    {
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist(string TicketRuleCode)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketRule.Exist");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TicketRuleCode", TicketRuleCode));

            return Exists(strSql.ToString(), parameters.ToArray());
        }
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist(TicketRule model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketRule.Exist");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TicketRuleID", model.TicketRuleID));
            parameters.Add(new QfParameter("@TicketRuleCode", model.TicketRuleCode));

            return Exists(strSql.ToString(), parameters.ToArray());
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TicketRule model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketRule.Add");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TicketRuleID", model.TicketRuleID));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@Note", model.Note));
            parameters.Add(new QfParameter("@TicketRuleCode", model.TicketRuleCode));
            parameters.Add(new QfParameter("@TicketType", model.TicketType));
            parameters.Add(new QfParameter("@StartDate", model.StartDate));
            parameters.Add(new QfParameter("@ExpireDate", model.ExpireDate));
            parameters.Add(new QfParameter("@Amount", model.Amount));
            parameters.Add(new QfParameter("@Time", model.Time));
            parameters.Add(new QfParameter("@CommodityIDStr", model.CommodityIDStr));
            parameters.Add(new QfParameter("@CommodityNameStr", model.CommodityNameStr));

            try
            {
                var rows = ExecuteSql(strSql.ToString(), parameters.ToArray());
                return rows > 0;
            }
            catch (QfException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TicketRule model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketRule.Update");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TicketRuleID", model.TicketRuleID));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@Note", model.Note));
            parameters.Add(new QfParameter("@TicketRuleCode", model.TicketRuleCode));
            parameters.Add(new QfParameter("@TicketType", model.TicketType));
            parameters.Add(new QfParameter("@StartDate", model.StartDate));
            parameters.Add(new QfParameter("@ExpireDate", model.ExpireDate));
            parameters.Add(new QfParameter("@Amount", model.Amount));
            parameters.Add(new QfParameter("@Time", model.Time));
            parameters.Add(new QfParameter("@CommodityIDStr", model.CommodityIDStr));
            parameters.Add(new QfParameter("@CommodityNameStr", model.CommodityNameStr));

            try
            {
                var rows = ExecuteSql(strSql.ToString(), parameters.ToArray());
                return rows > 0;
            }
            catch (QfException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int TicketRuleID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketRule.Delete");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TicketRuleID", TicketRuleID));

            try
            {
                var rows = ExecuteSql(strSql.ToString(), parameters.ToArray());
                return rows > 0;
            }
            catch (QfException ex)
            {
                if (ex.Message.Contains("foreign key constraint failed"))
                    throw new DsException("该条目下有数据，无法直接删除", ex);
                else
                    throw ex;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TicketRule GetModel(int TicketRuleID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketRule.GetModel");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TicketRuleID", TicketRuleID));

            var model = new TicketRule();
            var ds = Query(strSql.ToString(), parameters.ToArray());

            return ModelConvert.ToModel<TicketRule>(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TicketRule> GetList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketRule.GetList");

            try
            {
                return QueryGetList<TicketRule>(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  获取
        /// </summary>
        /// <param name="para"></param>
        /// <param name="outPara"></param>
        /// <returns></returns>
        public List<TicketRule> Query(QueryProcedurePara para, out int TotalCount)
        {
            const string procedureName = "p_query_ticket_rule";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("iPageIndex", new QfParameter("iPageIndex", para.P_PageIndex));
            parms.Add("iPageSize", new QfParameter("iPageSize", para.P_PageSize));
            parms.Add("vWhere", new QfParameter("vWhere", para.P_Where));
            parms.Add("vOrderBy", new QfParameter("vOrderBy", para.P_OrderBy));
            parms.Add("iTotalCount", new QfParameter("iTotalCount", para.P_TotalCount));
            parms["iTotalCount"].Direction = ParameterDirection.Output;
            try
            {
                List<TicketRule> _list = new List<TicketRule>();
                _list = RunProcedureGetList<TicketRule>(procedureName, ref parms);
                TotalCount = ValueConvert.ToInt32(parms["iTotalCount"].Value);
                return _list;
            }
            catch (Exception ex)
            {
                throw new DsException("获取预约大类列表失败！", ex);
            }
        }
    }
}

