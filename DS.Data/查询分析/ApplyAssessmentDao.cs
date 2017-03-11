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
    /// 作用：数据访问类:ApplyAssessmentDao
    /// 作者：NOLY
    /// 代码生成日期：2016-03-30
    /// 最后修改人：NOLY
    /// 最后修改日期：2016-03-30
    /// 说明：
    /// </summary>
    public class ApplyAssessmentDao : DaoBase
    {
        /// <summary>
        /// 是否存在数据
        /// </summary>
        public bool Exist(int ApplyAssessmentID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:ApplyAssessment.ApplyAssessment.Exist");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ApplyAssessmentID", ApplyAssessmentID));

            return Exists(strSql.ToString(), parameters.ToArray());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(ApplyAssessment model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:ApplyAssessment.ApplyAssessment.Add");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ApplyAssessmentID", model.ApplyAssessmentID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@CheckInDate", model.CheckInDate));
            parameters.Add(new QfParameter("@StudentID", model.StudentID));
            parameters.Add(new QfParameter("@SubjectID", model.SubjectID));
            parameters.Add(new QfParameter("@SubjectItemID", model.SubjectItemID));
            parameters.Add(new QfParameter("@CheckEmployeeID", model.CheckEmployeeID));
            parameters.Add(new QfParameter("@Statue", model.Statue));
            parameters.Add(new QfParameter("@Note", model.Note));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));

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
        public bool Update(ApplyAssessment model)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:ApplyAssessment.ApplyAssessment.Update");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ApplyAssessmentID", model.ApplyAssessmentID));
            parameters.Add(new QfParameter("@OperateTime", model.OperateTime));
            parameters.Add(new QfParameter("@CheckInDate", model.CheckInDate));
            parameters.Add(new QfParameter("@StudentID", model.StudentID));
            parameters.Add(new QfParameter("@SubjectID", model.SubjectID));
            parameters.Add(new QfParameter("@SubjectItemID", model.SubjectItemID));
            parameters.Add(new QfParameter("@CheckEmployeeID", model.CheckEmployeeID));
            parameters.Add(new QfParameter("@Statue", model.Statue));
            parameters.Add(new QfParameter("@Note", model.Note));
            parameters.Add(new QfParameter("@OperateID", model.OperateID));

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
        public bool Delete(int ApplyAssessmentID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:ApplyAssessment.ApplyAssessment.Delete");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ApplyAssessmentID", ApplyAssessmentID));

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
        public ApplyAssessment GetModel(int ApplyAssessmentID)
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:ApplyAssessment.ApplyAssessment.GetModel");
            var parameters = new List<QfParameter>();
            parameters.Add(new QfParameter("@ApplyAssessmentID", ApplyAssessmentID));

            var model = new ApplyAssessment();
            var ds = Query(strSql.ToString(), parameters.ToArray());

            return ModelConvert.ToModel<ApplyAssessment>(ds);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ApplyAssessment> GetList()
        {
            var strSql = new StringBuilder();
            strSql.Append(@"REPOS:ApplyAssessment.ApplyAssessment.GetList");

            try
            {
                return QueryGetList<ApplyAssessment>(strSql.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

    }
}

