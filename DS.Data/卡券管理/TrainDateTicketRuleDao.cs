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
    /// 作用：数据访问类:TraindateTicketRuleDao
    /// 作者：cxp
    /// 代码生成日期：2015-12-15
    /// 最后修改人：cxp
    /// 最后修改日期：2015-12-15
    /// 说明：
    /// </summary>
    public class TraindateTicketRuleDao : DaoBase
    {
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist(int TrainDateID, int TicketRuleID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TraindateTicketRule.Exist");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TrainDateID", TrainDateID));
            parameters.Add(new QfParameter("@TicketRuleID", TicketRuleID));

            return Exists(strSql.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TraindateTicketRule model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TraindateTicketRule.Add");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TrainDateID", model.TrainDateID));
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
        public bool Update(TraindateTicketRule model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TraindateTicketRule.Update");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TrainDateID", model.TrainDateID));
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
        public bool Delete(int TrainDateID, int TicketRuleID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TraindateTicketRule.Delete");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TrainDateID", TrainDateID));
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
        public TraindateTicketRule GetModel(int TrainDateID, int TicketRuleID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TraindateTicketRule.GetModel");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TrainDateID", TrainDateID));
            parameters.Add(new QfParameter("@TicketRuleID", TicketRuleID));

            var model = new TraindateTicketRule();
            var ds = Query(strSql.ToString(), parameters.ToArray());

            return ModelConvert.ToModel<TraindateTicketRule>(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TraindateTicketRule> GetList(int TrainDateID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TraindateTicketRule.GetList");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TrainDateID", TrainDateID));
            try
            {
                return QueryGetList<TraindateTicketRule>(strSql.ToString(), parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

