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
    /// 作用：数据访问类:TicketDao
    /// 作者：cxl
    /// 代码生成日期：2015-11-16
    /// 最后修改人：cxl
    /// 最后修改日期：2015-11-16
    /// 说明：
    /// </summary>
    public class TicketDao : DaoBase
    {
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist(int TicketID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Ticket.Exist");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TicketID", TicketID));

            return Exists(strSql.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Ticket model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Ticket.Add");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TicketID", model.TicketID));
            parameters.Add(new QfParameter("@CommodityIDStr", model.CommodityIDStr));
            parameters.Add(new QfParameter("@CommodityNameStr", model.CommodityNameStr));
            parameters.Add(new QfParameter("@RefCode", model.RefCode));
            parameters.Add(new QfParameter("@RefCodeType", model.RefCodeType));
            parameters.Add(new QfParameter("@State", model.State));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@Note", model.Note));
            parameters.Add(new QfParameter("@TicketCode", model.TicketCode));
            parameters.Add(new QfParameter("@TicketType", model.TicketType));
            parameters.Add(new QfParameter("@StartDate", model.StartDate));
            parameters.Add(new QfParameter("@ExpireDate", model.ExpireDate));
            parameters.Add(new QfParameter("@Amount", model.Amount));
            parameters.Add(new QfParameter("@Time", model.Time));
            parameters.Add(new QfParameter("@StudentID", model.StudentID));
            parameters.Add(new QfParameter("@UsedTime", model.UsedTime));

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
        public bool Update(Ticket model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Ticket.Update");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TicketID", model.TicketID));
            parameters.Add(new QfParameter("@CommodityIDStr", model.CommodityIDStr));
            parameters.Add(new QfParameter("@CommodityNameStr", model.CommodityNameStr));
            parameters.Add(new QfParameter("@RefCode", model.RefCode));
            parameters.Add(new QfParameter("@RefCodeType", model.RefCodeType));
            parameters.Add(new QfParameter("@State", model.State));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@Note", model.Note));
            parameters.Add(new QfParameter("@TicketCode", model.TicketCode));
            parameters.Add(new QfParameter("@TicketType", model.TicketType));
            parameters.Add(new QfParameter("@StartDate", model.StartDate));
            parameters.Add(new QfParameter("@ExpireDate", model.ExpireDate));
            parameters.Add(new QfParameter("@Amount", model.Amount));
            parameters.Add(new QfParameter("@Time", model.Time));
            parameters.Add(new QfParameter("@StudentID", model.StudentID));
            parameters.Add(new QfParameter("@UsedTime", model.UsedTime));

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
        public bool Delete(int TicketID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Ticket.Delete");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TicketID", TicketID));

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
        public Ticket GetModel(int TicketID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Ticket.GetModel");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@TicketID", TicketID));

            var model = new Ticket();
            var ds = Query(strSql.ToString(), parameters.ToArray());

            return ModelConvert.ToModel<Ticket>(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Ticket> GetList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Ticket.GetList");

            try
            {
                return QueryGetList<Ticket>(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Ticket> GetList_ID(int StudentID, string CommodityIDStr)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Ticket.GetList_ID");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StudentID", StudentID));
            parameters.Add(new QfParameter("@CommodityIDStr", CommodityIDStr));
            try
            {
                return QueryGetList<Ticket>(strSql.ToString(), parameters.ToArray());
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
        public List<Ticket> Query(QueryProcedurePara para, out int TotalCount)
        {
            const string procedureName = "p_query_ticket";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("iPageIndex", new QfParameter("iPageIndex", para.P_PageIndex));
            parms.Add("iPageSize", new QfParameter("iPageSize", para.P_PageSize));
            parms.Add("vWhere", new QfParameter("vWhere", para.P_Where));
            parms.Add("vOrderBy", new QfParameter("vOrderBy", para.P_OrderBy));
            parms.Add("iTotalCount", new QfParameter("iTotalCount", para.P_TotalCount));
            parms["iTotalCount"].Direction = ParameterDirection.Output;
            try
            {
                List<Ticket> _list = new List<Ticket>();
                _list = RunProcedureGetList<Ticket>(procedureName, ref parms);
                TotalCount = ValueConvert.ToInt32(parms["iTotalCount"].Value);
                return _list;
            }
            catch (Exception ex)
            {
                throw new DsException("获取卡券表失败！", ex);
            }
        }
        /// <summary>
        /// 批量生成卡券
        /// </summary>
        /// <param name="StudentID"></param>
        /// <param name="Amount"></param>
        /// <param name="iTicketID"></param>
        /// <param name="Note"></param>
        /// <param name="OperateID"></param>
        /// <param name="OperateTime"></param>
        /// <returns></returns>
        public bool Generate_voucher(string StudentID, int Amount, int iTicketID, string Note, int OperateID, DateTime OperateTime)
        {
            bool result = true;
            const string procedureName = "p_build_Ticket_ID";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("iStudentIDStr", new QfParameter("iStudentIDStr", StudentID));
            parms.Add("iNum", new QfParameter("iNum", Amount));
            parms.Add("iTicketID", new QfParameter("iTicketID", iTicketID));
            parms.Add("iNote", new QfParameter("iNote", Note));
            parms.Add("iOperateID", new QfParameter("iOperateID", OperateID));
            parms.Add("dOperateTime", new QfParameter("dOperateTime", OperateTime));
            parms.Add("vReturnValue", new QfParameter("vReturnValue", QfDbType.VarChar, 100));
            parms.Add("iResult", new QfParameter("iResult", QfDbType.BigInt));

            parms["iStudentIDStr"].Direction = ParameterDirection.Input;
            parms["iNum"].Direction = ParameterDirection.Input;
            parms["iTicketID"].Direction = ParameterDirection.Input;
            parms["iNote"].Direction = ParameterDirection.Input;
            parms["iOperateID"].Direction = ParameterDirection.Input;
            parms["dOperateTime"].Direction = ParameterDirection.Input;
            parms["iResult"].Direction = ParameterDirection.Output;

            parms["vReturnValue"].Direction = ParameterDirection.Output;
            try
            {

                RunProcedure_(procedureName, ref parms);

                Account Acc = new Account();
                if (parms["vReturnValue"].Value != null && parms["vReturnValue"].Value != DBNull.Value)
                {
                    string vReturnValue = ValueConvert.ToString(parms["vReturnValue"].Value);
                }
                if (parms["iResult"].Value != null && parms["iResult"].Value != DBNull.Value)
                {
                    int iResult = Convert.ToInt32(parms["iResult"].Value);
                    result = iResult == 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw new DsException("执行存储过程失败！", ex);
            }
            return result;
        }
        /// <summary>
        /// 生成卡券
        /// </summary>
        /// <param name="StudentID"></param>
        /// <param name="Amount"></param>
        /// <param name="iTicketID"></param>
        /// <param name="Note"></param>
        /// <param name="OperateID"></param>
        /// <param name="OperateTime"></param>
        /// <returns></returns>
        public bool Generate(int Amount, int iTicketID, string Note, int OperateID, DateTime OperateTime)
        {
            bool result = true;
            const string procedureName = "p_build_Ticket";
            var parms = new Dictionary<string, QfParameter>();
       
            parms.Add("iNum", new QfParameter("iNum", Amount));
            parms.Add("iTicketID", new QfParameter("iTicketID", iTicketID));
            parms.Add("iNote", new QfParameter("iNote", Note));
            parms.Add("iOperateID", new QfParameter("iOperateID", OperateID));
            parms.Add("dOperateTime", new QfParameter("dOperateTime", OperateTime));
            parms.Add("vReturnValue", new QfParameter("vReturnValue", QfDbType.VarChar, 100));
            parms.Add("iResult", new QfParameter("iResult", QfDbType.BigInt));

       
            parms["iNum"].Direction = ParameterDirection.Input;
            parms["iTicketID"].Direction = ParameterDirection.Input;
            parms["iNote"].Direction = ParameterDirection.Input;
            parms["iOperateID"].Direction = ParameterDirection.Input;
            parms["dOperateTime"].Direction = ParameterDirection.Input;
            parms["iResult"].Direction = ParameterDirection.Output;

            parms["vReturnValue"].Direction = ParameterDirection.Output;
            try
            {

                RunProcedure_(procedureName, ref parms);

                Account Acc = new Account();
                if (parms["vReturnValue"].Value != null && parms["vReturnValue"].Value != DBNull.Value)
                {
                    string vReturnValue = ValueConvert.ToString(parms["vReturnValue"].Value);
                }
                if (parms["iResult"].Value != null && parms["iResult"].Value != DBNull.Value)
                {
                    int iResult = Convert.ToInt32(parms["iResult"].Value);
                    result = iResult == 0 ? true : false;
                }
            }
            catch (Exception ex)
            {
                throw new DsException("执行存储过程失败！", ex);
            }
            return result;
        }
          
    }
}

