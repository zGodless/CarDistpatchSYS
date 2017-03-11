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
    /// 作用：数据访问类:ProcessDefinitionDao
    /// 作者：cxp
    /// 代码生成日期：2016-05-03
    /// 最后修改人：cxp
    /// 最后修改日期：2016-05-03
    /// 说明：
    /// </summary>
    public class ProcessDefinitionDao : DaoBase
    {
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist(int DefinitionID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Process.ProcessDefinition.Exist");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@DefinitionID", DefinitionID));

            return Exists(strSql.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ProcessDefinition model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Process.ProcessDefinition.Add");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@DefinitionID", model.DefinitionID));
            parameters.Add(new QfParameter("@Array", model.Array));
            parameters.Add(new QfParameter("@CreateID", model.CreateID));
            parameters.Add(new QfParameter("@CreateTime", model.CreateTime));
            parameters.Add(new QfParameter("@DefinitionName", model.DefinitionName));
            parameters.Add(new QfParameter("@DefinitionType", model.DefinitionType));
            parameters.Add(new QfParameter("@DefinitionCode", model.DefinitionCode));
            parameters.Add(new QfParameter("@NodeID", model.NodeID));
            parameters.Add(new QfParameter("@Status", model.Status));
            parameters.Add(new QfParameter("@TVersion", model.TVersion));
            parameters.Add(new QfParameter("@UseTime", model.UseTime));
            parameters.Add(new QfParameter("@OldID", model.OldID));

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
        public bool Update(ProcessDefinition model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Process.ProcessDefinition.Update");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@DefinitionID", model.DefinitionID));
            parameters.Add(new QfParameter("@Array", model.Array));
            parameters.Add(new QfParameter("@CreateID", model.CreateID));
            parameters.Add(new QfParameter("@CreateTime", model.CreateTime));
            parameters.Add(new QfParameter("@DefinitionName", model.DefinitionName));
            parameters.Add(new QfParameter("@DefinitionType", model.DefinitionType));
            parameters.Add(new QfParameter("@DefinitionCode", model.DefinitionCode));
            parameters.Add(new QfParameter("@NodeID", model.NodeID));
            parameters.Add(new QfParameter("@Status", model.Status));
            parameters.Add(new QfParameter("@TVersion", model.TVersion));
            parameters.Add(new QfParameter("@UseTime", model.UseTime));
            parameters.Add(new QfParameter("@OldID", model.OldID));

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
        public bool Delete(int DefinitionID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Process.ProcessDefinition.Delete");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@DefinitionID", DefinitionID));

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
        public ProcessDefinition GetModel(int DefinitionID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Process.ProcessDefinition.GetModel");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@DefinitionID", DefinitionID));

            var model = new ProcessDefinition();
            var ds = Query(strSql.ToString(), parameters.ToArray());

            return ModelConvert.ToModel<ProcessDefinition>(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ProcessDefinition> GetList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:Process.ProcessDefinition.GetList");

            try
            {
                return QueryGetList<ProcessDefinition>(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

