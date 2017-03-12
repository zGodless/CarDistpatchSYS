using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CarDistpatchSYS;
using QuickFrame.Model;
using QuickFrame.Common.Exception;
using QuickFrame.Common.Converter;
using DS.Common.Exception;


namespace DS.Data
{
	/// <summary>
	/// 模块：数据访问
    /// 作用：数据访问类:DepartmentDao
    /// 作者：zyl
    /// 代码生成日期：2017-03-07
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-07
    /// 说明：
	/// </summary>
	public class DepartmentDao
	{


        /// <summary>
        /// 简单查询
        /// </summary>
        /// <param name="sql"></param>
        public List<Department> QueryGetList(string sql)
        {
            try
            {
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<Department> _list = ModelConvert.ToList<Department>(dt);
                return _list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="sql"></param>
        public Department GetModel(int DepartmentID)
        {
            try
            {
                string sql = string.Format("select * from t_department where DepartmentID = {0} limit 1", DepartmentID);
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                Department model = ModelConvert.ToModel<Department>(dt);
                return model;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="sql"></param>
        public bool Add(Department model)
        {
            try
            {
                var parameters = new List<QfParameter>();
                parameters.Add(new QfParameter("DepartmentID", model.DepartmentID));
                parameters.Add(new QfParameter("DepartmentCode", string.Format(@"'{0}'", model.DepartmentCode)));
                parameters.Add(new QfParameter("DepartmentName", string.Format(@"'{0}'", model.DepartmentName)));
                parameters.Add(new QfParameter("ParentID", model.ParentID));
                parameters.Add(new QfParameter("InChargeID", model.InChargeID));
                parameters.Add(new QfParameter("EmployeeCount", model.EmployeeCount));
                parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
                parameters.Add(new QfParameter("OperateID", model.OperateID));
                parameters.Add(new QfParameter("OperateTime", string.Format(@"'{0}'", model.OperateTime)));
                            string colStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.ParameterName));
                string atColStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.Value));
                string sql = string.Format("insert into t_department({0}) values ({1})", colStr, atColStr);
                int row = MysqlHelper.ExecuteNonQuery(sql);
                return row == 1;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="sql"></param>
        public bool Delete(Department model)
        {
            try
            {
                string sql = string.Format("delete from t_department where DepartmentID = {0}", model.DepartmentID);
                int row = MysqlHelper.ExecuteNonQuery(sql);
                return row == 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="sql"></param>
        public bool Update(Department model)
        {
            try
            {
                var parameters = new List<QfParameter>();
                parameters.Add(new QfParameter("DepartmentID", model.DepartmentID));
                parameters.Add(new QfParameter("DepartmentCode", string.Format(@"'{0}'", model.DepartmentCode)));
                parameters.Add(new QfParameter("DepartmentName", string.Format(@"'{0}'", model.DepartmentName)));
                parameters.Add(new QfParameter("ParentID", model.ParentID));
                parameters.Add(new QfParameter("InChargeID", model.InChargeID));
                parameters.Add(new QfParameter("EmployeeCount", model.EmployeeCount));
                parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
                parameters.Add(new QfParameter("OperateID", model.OperateID));
                parameters.Add(new QfParameter("OperateTime", string.Format(@"'{0}'", model.OperateTime)));
                string setStr = "";
                foreach (var item in parameters)
                {
                    if (item.Value != null && ValueConvert.ToString(item.Value) != "''")
                    {
                        setStr += string.Format(" {0} = {1},", item.ParameterName, item.Value);
                    }
                }
                setStr = setStr.Substring(0, setStr.LastIndexOf(","));
                string sql = string.Format("update t_department set {0} where DepartmentID = {1}", setStr,  model.DepartmentID);
                int row = MysqlHelper.ExecuteNonQuery(sql);
                return row == 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sql"></param>
        public List<Department> GetList()
        {
            try
            {
                string sql = string.Format(@"select a.*, b.DepartmentName ParentName, c.EmployeeName InChargeName
                                                 from t_department a 
                                                left join t_department b on a.ParentID = b.DepartmentID
                                                left join t_employee c on a.InChargeID = c.EmployeeID");
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<Department> _list = ModelConvert.ToList<Department>(dt);
                return _list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

