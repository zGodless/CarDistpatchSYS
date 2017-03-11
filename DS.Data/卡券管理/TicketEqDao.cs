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
    /// 作用：数据访问类:TicketEqDao
    /// 作者：cxl
    /// 代码生成日期：2015-11-19
    /// 最后修改人：cxl
    /// 最后修改日期：2015-11-19
    /// 说明：
    /// </summary>
    public class TicketEqDao : DaoBase
    {
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist(string SN)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketEq.Exist");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@SN", SN));

            return Exists(strSql.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(TicketEq model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketEq.Add");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@SN", model.SN));
            parameters.Add(new QfParameter("@TicketID", model.TicketID));
            parameters.Add(new QfParameter("@ChangeType", model.ChangeType));
            parameters.Add(new QfParameter("@RefCode", model.RefCode));
            parameters.Add(new QfParameter("@RefCodeType", model.RefCodeType));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@Note", model.Note));

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
        public bool Update(TicketEq model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketEq.Update");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@SN", model.SN));
            parameters.Add(new QfParameter("@TicketID", model.TicketID));
            parameters.Add(new QfParameter("@ChangeType", model.ChangeType));
            parameters.Add(new QfParameter("@RefCode", model.RefCode));
            parameters.Add(new QfParameter("@RefCodeType", model.RefCodeType));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@Note", model.Note));

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
        public bool Delete(string SN)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketEq.Delete");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@SN", SN));

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
        public TicketEq GetModel(string SN)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketEq.GetModel");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@SN", SN));

            var model = new TicketEq();
            var ds = Query(strSql.ToString(), parameters.ToArray());

            return ModelConvert.ToModel<TicketEq>(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<TicketEq> GetList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.TicketEq.GetList");

            try
            {
                return QueryGetList<TicketEq>(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

