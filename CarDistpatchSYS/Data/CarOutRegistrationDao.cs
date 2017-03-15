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
    /// 作用：数据访问类:CarOutRegistrationDao
    /// 作者：zyl
    /// 代码生成日期：2017-03-14
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-14
    /// 说明：t_car_out_registration
	/// </summary>
	public class CarOutRegistrationDao
	{


        /// <summary>
        /// 简单查询
        /// </summary>
        /// <param name="sql"></param>
        public List<CarOutRegistration> QueryGetList(string sql)
        {
            try
            {
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarOutRegistration> _list = ModelConvert.ToList<CarOutRegistration>(dt);
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
        public CarOutRegistration GetModel(int RegistraID)
        {
            try
            {
                string sql = string.Format("select * from t_car_out_registration where RegistraID = {0} limit 1", RegistraID);
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                CarOutRegistration model = ModelConvert.ToModel<CarOutRegistration>(dt);
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
        public bool Add(CarOutRegistration model)
        {
            try
            {
                var parameters = new List<QfParameter>();
			parameters.Add(new QfParameter("RegistraID", model.RegistraID));
            parameters.Add(new QfParameter("DispatchID", model.DispatchID));
            parameters.Add(new QfParameter("CarID", model.CarID));
            parameters.Add(new QfParameter("RegistraDate", string.Format(@"'{0}'", model.RegistraDate)));
            parameters.Add(new QfParameter("EmployeeID", model.EmployeeID));
            parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
            parameters.Add(new QfParameter("OperatorID", model.OperatorID));
            parameters.Add(new QfParameter("OperateTime", string.Format(@"'{0}'", model.OperateTime)));
                            string colStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.ParameterName));
                string atColStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.Value));
                string sql = string.Format("insert into t_car_out_registration({0}) values ({1})", colStr, atColStr);
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
        public bool Delete(CarOutRegistration model)
        {
            try
            {
                string sql = string.Format("delete from t_car_out_registration where RegistraID = {0}", model.RegistraID);
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
        public bool Update(CarOutRegistration model)
        {
            try
            {
                var parameters = new List<QfParameter>();
			parameters.Add(new QfParameter("RegistraID", model.RegistraID));
            parameters.Add(new QfParameter("DispatchID", model.DispatchID));
            parameters.Add(new QfParameter("CarID", model.CarID));
            parameters.Add(new QfParameter("RegistraDate", string.Format(@"'{0}'", model.RegistraDate)));
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
                string sql = string.Format("update t_car_out_registration set {0} where RegistraID = {1}", setStr,  model.RegistraID);
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
        public List<CarOutRegistration> GetList()
        {
            try
            {
                string sql = string.Format(@"select a.*, b.EmployeeName, c.CarNo, d.EmployeeName OperatorName from t_car_out_registration a 
                                                left join t_employee b on a.EmployeeID = b.EmployeeID
                                                left join t_car c on a.CarID = c.CarID 
                                                left join t_employee d on a.OperatorID = d.EmployeeID");
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarOutRegistration> _list = ModelConvert.ToList<CarOutRegistration>(dt);
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

