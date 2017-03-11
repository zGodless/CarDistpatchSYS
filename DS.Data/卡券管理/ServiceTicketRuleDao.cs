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
    /// 作用：数据访问类:ServiceTicketRuleDao
    /// 作者：cxl
    /// 代码生成日期：2015-11-20
    /// 最后修改人：NOLY
    /// 最后修改日期：2015-11-20
    /// 说明：
    /// </summary>
    public class ServiceTicketRuleDao : DaoBase
    {
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist(int ServiceID, int TicketRuleID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.ServiceTicketRule.Exist");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ServiceID", ServiceID));
            parameters.Add(new QfParameter("@TicketRuleID", TicketRuleID));

            return Exists(strSql.ToString(), parameters.ToArray());
        }
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist_ID( int TicketRuleID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.ServiceTicketRule.Exist_ID");
            var parameters = new List<QfParameter>();
      
            parameters.Add(new QfParameter("@TicketRuleID", TicketRuleID));

            return Exists(strSql.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ServiceTicketRule model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.ServiceTicketRule.Add");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ServiceID", model.ServiceID));
            parameters.Add(new QfParameter("@TicketRuleID", model.TicketRuleID));
            parameters.Add(new QfParameter("@Count", model.Count));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));

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
        public bool Update(ServiceTicketRule model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.ServiceTicketRule.Update");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ServiceID", model.ServiceID));
            parameters.Add(new QfParameter("@TicketRuleID", model.TicketRuleID));
            parameters.Add(new QfParameter("@Count", model.Count));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));

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
        public bool Delete(int ServiceID, int TicketRuleID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.ServiceTicketRule.Delete");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ServiceID", ServiceID));
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
        public ServiceTicketRule GetModel(int ServiceID, int TicketRuleID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.ServiceTicketRule.GetModel");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ServiceID", ServiceID));
            parameters.Add(new QfParameter("@TicketRuleID", TicketRuleID));

            var model = new ServiceTicketRule();
            var ds = Query(strSql.ToString(), parameters.ToArray());

            return ModelConvert.ToModel<ServiceTicketRule>(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ServiceTicketRule> GetList(int ServiceID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.ServiceTicketRule.GetList");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ServiceID", ServiceID));
            try
            {
                return QueryGetList<ServiceTicketRule>(strSql.ToString(), parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ServiceTicketRule> GetList_ServiceID(int ServiceID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.ServiceTicketRule.GetList_ServiceID");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ServiceID", ServiceID));
            try
            {
                return QueryGetList<ServiceTicketRule>(strSql.ToString(),parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

