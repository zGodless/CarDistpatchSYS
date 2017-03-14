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
    /// 作用：数据访问类:CarriageReturnDao
    /// 作者：zyl
    /// 代码生成日期：2017-03-14
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-14
    /// 说明：t_carriage_return
	/// </summary>
	public class CarriageReturnDao
	{


        /// <summary>
        /// 简单查询
        /// </summary>
        /// <param name="sql"></param>
        public List<CarriageReturn> QueryGetList(string sql)
        {
            try
            {
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarriageReturn> _list = ModelConvert.ToList<CarriageReturn>(dt);
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
        public CarriageReturn GetModel(int ReturnID)
        {
            try
            {
                string sql = string.Format("select * from t_carriage_return where ReturnID = {0} limit 1", ReturnID);
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                CarriageReturn model = ModelConvert.ToModel<CarriageReturn>(dt);
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
        public bool Add(CarriageReturn model)
        {
            try
            {
                var parameters = new List<QfParameter>();
			parameters.Add(new QfParameter("ReturnID", model.ReturnID));
            parameters.Add(new QfParameter("DispatchID", model.DispatchID));
            parameters.Add(new QfParameter("CarID", model.CarID));
            parameters.Add(new QfParameter("ReturnDate", string.Format(@"'{0}'", model.ReturnDate)));
            parameters.Add(new QfParameter("EmployeeID", model.EmployeeID));
            parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
            parameters.Add(new QfParameter("OperatorID", model.OperatorID));
            parameters.Add(new QfParameter("OperateTime", string.Format(@"'{0}'", model.OperateTime)));
                            string colStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.ParameterName));
                string atColStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.Value));
                string sql = string.Format("insert into t_carriage_return({0}) values ({1})", colStr, atColStr);
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
        public bool Delete(CarriageReturn model)
        {
            try
            {
                string sql = string.Format("delete from t_carriage_return where ReturnID = {0}", model.ReturnID);
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
        public bool Update(CarriageReturn model)
        {
            try
            {
                var parameters = new List<QfParameter>();
			parameters.Add(new QfParameter("ReturnID", model.ReturnID));
            parameters.Add(new QfParameter("DispatchID", model.DispatchID));
            parameters.Add(new QfParameter("CarID", model.CarID));
            parameters.Add(new QfParameter("ReturnDate", string.Format(@"'{0}'", model.ReturnDate)));
            parameters.Add(new QfParameter("EmployeeID", model.EmployeeID));
            parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
            parameters.Add(new QfParameter("OperatorID", model.OperatorID));
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
                string sql = string.Format("update t_carriage_return set {0} where ReturnID = {1}", setStr,  model.ReturnID);
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
        public List<CarriageReturn> GetList()
        {
            try
            {
                string sql = string.Format("select * from t_carriage_return");
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarriageReturn> _list = ModelConvert.ToList<CarriageReturn>(dt);
                return _list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
   
	}
}

