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
    /// 作用：数据访问类:CarDispatchApplyDao
    /// 作者：zyl
    /// 代码生成日期：2017-03-14
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-14
    /// 说明：t_car_dispatch_apply
	/// </summary>
	public class CarDispatchApplyDao
	{


        /// <summary>
        /// 简单查询
        /// </summary>
        /// <param name="sql"></param>
        public List<CarDispatchApply> QueryGetList(string sql)
        {
            try
            {
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarDispatchApply> _list = ModelConvert.ToList<CarDispatchApply>(dt);
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
        public CarDispatchApply GetModel(int ApplyID)
        {
            try
            {
                string sql = string.Format("select * from t_car_dispatch_apply where ApplyID = {0} limit 1", ApplyID);
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                CarDispatchApply model = ModelConvert.ToModel<CarDispatchApply>(dt);
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
        public bool Add(CarDispatchApply model)
        {
            try
            {
                var parameters = new List<QfParameter>();
                parameters.Add(new QfParameter("ApplyID", model.ApplyID));
                parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
                parameters.Add(new QfParameter("OperatorID", model.OperatorID));
                parameters.Add(new QfParameter("OperateTime", string.Format(@"'{0}'", model.OperateTime)));
                parameters.Add(new QfParameter("ApplyMode", string.Format(@"'{0}'", model.ApplyMode)));
                parameters.Add(new QfParameter("IsDriver", model.IsDriver));
                parameters.Add(new QfParameter("CarModel", string.Format(@"'{0}'", model.CarModel)));
                parameters.Add(new QfParameter("DriverName", string.Format(@"'{0}'", model.DriverName)));
                parameters.Add(new QfParameter("DriverLicense", string.Format(@"'{0}'", model.DriverLicense)));
                parameters.Add(new QfParameter("DispatchID", model.DispatchID));
                parameters.Add(new QfParameter("EmployeeID", model.EmployeeID));
                parameters.Add(new QfParameter("ApplyDate", string.Format(@"'{0}'", model.ApplyDate)));
                parameters.Add(new QfParameter("CarID", model.CarID));
                parameters.Add(new QfParameter("DispatchReason", string.Format(@"'{0}'", model.DispatchReason)));
                parameters.Add(new QfParameter("PlaceBackDate", string.Format(@"'{0}'", model.PlaceBackDate)));
                parameters.Add(new QfParameter("CarBackDate", string.Format(@"'{0}'", model.CarBackDate)));
                parameters.Add(new QfParameter("Status", model.Status));
                            string colStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.ParameterName));
                string atColStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.Value));
                string sql = string.Format("insert into t_car_dispatch_apply({0}) values ({1})", colStr, atColStr);
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
        public bool Delete(CarDispatchApply model)
        {
            try
            {
                string sql = string.Format("delete from t_car_dispatch_apply where ApplyID = {0}", model.ApplyID);
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
        public bool Update(CarDispatchApply model)
        {
            try
            {
                var parameters = new List<QfParameter>();
                parameters.Add(new QfParameter("ApplyID", model.ApplyID));
                parameters.Add(new QfParameter("DispatchID", model.DispatchID));
                parameters.Add(new QfParameter("EmployeeID", model.EmployeeID));
                parameters.Add(new QfParameter("ApplyDate", string.Format(@"'{0}'", model.ApplyDate)));
                parameters.Add(new QfParameter("CarID", model.CarID));
                parameters.Add(new QfParameter("DispatchReason", string.Format(@"'{0}'", model.DispatchReason)));
                parameters.Add(new QfParameter("PlaceBackDate", string.Format(@"'{0}'", model.PlaceBackDate)));
                parameters.Add(new QfParameter("CarBackDate", string.Format(@"'{0}'", model.CarBackDate)));
                parameters.Add(new QfParameter("Status", model.Status));
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
                string sql = string.Format("update t_car_dispatch_apply set {0} where ApplyID = {1}", setStr,  model.ApplyID);
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
        public List<CarDispatchApply> GetList()
        {
            try
            {
                string sql = string.Format(@"select a.*, b.EmployeeName, c.CarNo, d.EmployeeName OperatorName from t_car_dispatch_apply a 
                                                left join t_employee b on a.EmployeeID = b.EmployeeID
                                                left join t_car c on a.CarID = c.CarID 
                                                left join t_employee d on a.OperatorID = d.EmployeeID");
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarDispatchApply> _list = ModelConvert.ToList<CarDispatchApply>(dt);
                return _list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary  >
        /// 获得数据列表
        /// </summary>
        /// <param name="sql"></param>
        public List<CarDispatchApply> GetNotAuditList()
        {
            try
            {
                string sql = string.Format(@"select a.*, b.EmployeeName, c.CarNo, d.EmployeeName OperatorName from t_car_dispatch_apply a 
                                                left join t_employee b on a.EmployeeID = b.EmployeeID
                                                left join t_car c on a.CarID = c.CarID 
                                                left join t_employee d on a.OperatorID = d.EmployeeID
                                                where a.Status = 1");
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarDispatchApply> _list = ModelConvert.ToList<CarDispatchApply>(dt);
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

