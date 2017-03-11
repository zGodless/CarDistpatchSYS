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
    /// 作用：数据访问类:AccountSeqDao
    /// 作者：cxl
    /// 代码生成日期：2015-12-01
    /// 最后修改人：cxl
    /// 最后修改日期：2015-12-01
    /// 说明：
    /// </summary>
    public class AccountSeqDao : DaoBase
    {
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist(string SN)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.AccountSeq.Exist");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@SN", SN));

            return Exists(strSql.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(AccountSeq model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.AccountSeq.Add");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@SN", model.SN));
            parameters.Add(new QfParameter("@FreezeUncashAmount", model.FreezeUncashAmount));
            parameters.Add(new QfParameter("@RefSN", model.RefSN));
            parameters.Add(new QfParameter("@RefFreezeSN", model.RefFreezeSN));
            parameters.Add(new QfParameter("@RefCode", model.RefCode));
            parameters.Add(new QfParameter("@RefCodeType", model.RefCodeType));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@Note", model.Note));
            parameters.Add(new QfParameter("@WorkDate", model.WorkDate));
            parameters.Add(new QfParameter("@AccountID", model.AccountID));
            parameters.Add(new QfParameter("@SeqFlag", model.SeqFlag));
            parameters.Add(new QfParameter("@ChangeType", model.ChangeType));
            parameters.Add(new QfParameter("@PreAmount", model.PreAmount));
            parameters.Add(new QfParameter("@Amount", model.Amount));
            parameters.Add(new QfParameter("@CashAmount", model.CashAmount));
            parameters.Add(new QfParameter("@UncashAmount", model.UncashAmount));
            parameters.Add(new QfParameter("@FreezeCashAmount", model.FreezeCashAmount));

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
        public bool Update(AccountSeq model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.AccountSeq.Update");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@SN", model.SN));
            parameters.Add(new QfParameter("@FreezeUncashAmount", model.FreezeUncashAmount));
            parameters.Add(new QfParameter("@RefSN", model.RefSN));
            parameters.Add(new QfParameter("@RefFreezeSN", model.RefFreezeSN));
            parameters.Add(new QfParameter("@RefCode", model.RefCode));
            parameters.Add(new QfParameter("@RefCodeType", model.RefCodeType));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@Note", model.Note));
            parameters.Add(new QfParameter("@WorkDate", model.WorkDate));
            parameters.Add(new QfParameter("@AccountID", model.AccountID));
            parameters.Add(new QfParameter("@SeqFlag", model.SeqFlag));
            parameters.Add(new QfParameter("@ChangeType", model.ChangeType));
            parameters.Add(new QfParameter("@PreAmount", model.PreAmount));
            parameters.Add(new QfParameter("@Amount", model.Amount));
            parameters.Add(new QfParameter("@CashAmount", model.CashAmount));
            parameters.Add(new QfParameter("@UncashAmount", model.UncashAmount));
            parameters.Add(new QfParameter("@FreezeCashAmount", model.FreezeCashAmount));

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
            strSql.Append(@"REPOS:Ticket.AccountSeq.Delete");
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
        public AccountSeq GetModel(string SN)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.AccountSeq.GetModel");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@SN", SN));

            var model = new AccountSeq();
            var ds = Query(strSql.ToString(), parameters.ToArray());

            return ModelConvert.ToModel<AccountSeq>(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<AccountSeq> GetList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.AccountSeq.GetList");

            try
            {
                return QueryGetList<AccountSeq>(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

