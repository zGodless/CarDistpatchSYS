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
using DS;


namespace DS.Data
{
    /// <summary>
    /// 模块：数据访问
    /// 作用：数据访问类:AccountDao
    /// 作者：cxl
    /// 代码生成日期：2015-12-01
    /// 最后修改人：cxl
    /// 最后修改日期：2015-12-01
    /// 说明：
    /// </summary>
    public class AccountDao : DaoBase
    {
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist(int AccountID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Account.Exist");
            var parameters = new List<QfParameter>();

            return Exists(strSql.ToString(), parameters.ToArray());
        }
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist_StudentID(int StudentID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Account.Exist_StudentID");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StudentID", StudentID));
            return Exists(strSql.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Account model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Account.Add");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@AccountID", model.AccountID));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@Note", model.Note));
            parameters.Add(new QfParameter("@AccountCode", model.AccountCode));
            parameters.Add(new QfParameter("@StudentID", model.StudentID));
            parameters.Add(new QfParameter("@Amount", model.Amount));
            parameters.Add(new QfParameter("@CashAmount", model.CashAmount));
            parameters.Add(new QfParameter("@UncashAmount", model.UncashAmount));
            parameters.Add(new QfParameter("@FreezeCashAmount", model.FreezeCashAmount));
            parameters.Add(new QfParameter("@FreezeUncashAmount", model.FreezeUncashAmount));
            parameters.Add(new QfParameter("@Status", model.Status));

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
        public bool Update(Account model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Account.Update");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@AccountID", model.AccountID));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@Note", model.Note));
            parameters.Add(new QfParameter("@AccountCode", model.AccountCode));
            parameters.Add(new QfParameter("@StudentID", model.StudentID));
            parameters.Add(new QfParameter("@Amount", model.Amount));
            parameters.Add(new QfParameter("@CashAmount", model.CashAmount));
            parameters.Add(new QfParameter("@UncashAmount", model.UncashAmount));
            parameters.Add(new QfParameter("@FreezeCashAmount", model.FreezeCashAmount));
            parameters.Add(new QfParameter("@FreezeUncashAmount", model.FreezeUncashAmount));
            parameters.Add(new QfParameter("@Status", model.Status));

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
        public bool Delete(int AccountID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Account.Delete");
            var parameters = new List<QfParameter>();

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
        public Account GetModel(int AccountID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Account.GetModel");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@AccountID", AccountID));
            var model = new Account();
            var ds = Query(strSql.ToString(), parameters.ToArray());

            return ModelConvert.ToModel<Account>(ds);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Account GetModel_StudentID(int StudentID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Account.GetModel_StudentID");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@StudentID", StudentID));
            var model = new Account();
            var ds = Query(strSql.ToString(), parameters.ToArray());

            return ModelConvert.ToModel<Account>(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Account> GetList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Ticket.Account.GetList");

            try
            {
                return QueryGetList<Account>(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool query(string StudentID,int? Amount,int Type, string Note,int OperateID,DateTime OperateTime)

        {
            bool result = true;
            const string procedureName = "p_build_Amount";
            var parms = new Dictionary<string, QfParameter>();
            parms.Add("iStudentIDStr", new QfParameter("iStudentIDStr", StudentID));
            parms.Add("dAmount", new QfParameter("dAmount", Amount));
            parms.Add("iType", new QfParameter("iType", Type));
            parms.Add("iNote", new QfParameter("iNote", Note));
            parms.Add("iOperateID", new QfParameter("iOperateID", OperateID));
            parms.Add("dOperateTime", new QfParameter("dOperateTime", OperateTime));
            parms.Add("vReturnValue", new QfParameter("vReturnValue", QfDbType.VarChar, 100));
            parms.Add("iResult", new QfParameter("iResult", QfDbType.BigInt));

            parms["iStudentIDStr"].Direction = ParameterDirection.Input;
            parms["dAmount"].Direction = ParameterDirection.Input;
            parms["iType"].Direction = ParameterDirection.Input;
            parms["iNote"].Direction = ParameterDirection.Input;
            parms["iOperateID"].Direction = ParameterDirection.Input;
            parms["dOperateTime"].Direction = ParameterDirection.Input;
            parms["iResult"].Direction = ParameterDirection.Output;

            parms["vReturnValue"].Direction = ParameterDirection.Output;
            try
            {

                RunProcedure_(procedureName, ref parms);
            
                Account Acc=new Account();
                if (parms["vReturnValue"].Value != null && parms["vReturnValue"].Value != DBNull.Value)
                {
                  string  vReturnValue = ValueConvert.ToString(parms["vReturnValue"].Value);
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

