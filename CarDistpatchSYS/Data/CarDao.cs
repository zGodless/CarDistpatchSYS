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
using MySql.Data.MySqlClient;


namespace DS.Data
{
    /// <summary>
    /// 模块：数据访问
    /// 作用：数据访问类:CarDao
    /// 作者：zyl
    /// 代码生成日期：2017-03-06
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-06
    /// 说明：
    /// </summary>
    public class CarDao
    {


        /// <summary>
        /// 简单查询
        /// </summary>
        /// <param name="sql"></param>
        public List<Car> QueryGetList(string sql)
        {
            try
            {
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<Car> _list = ModelConvert.ToList<Car>(dt);
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
        public Car GetModel(int CarID)
        {
            try
            {
                string sql = string.Format("select * from t_car where CarID = {0} limit 1", CarID);
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                Car model = ModelConvert.ToModel<Car>(dt);
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
        public bool Add(Car model)
        {
            try
            {
                var parameters = new List<QfParameter>();
                parameters.Add(new QfParameter("CarID", model.CarID));
                parameters.Add(new QfParameter("EmployeeID", model.EmployeeID));
                parameters.Add(new QfParameter("Brand", string.Format(@"'{0}'", model.Brand)));
                parameters.Add(new QfParameter("OwnerID", model.OwnerID));
                parameters.Add(new QfParameter("FuelType", string.Format(@"'{0}'", model.FuelType)));
                parameters.Add(new QfParameter("EngineNumber", string.Format(@"'{0}'", model.EngineNumber)));
                parameters.Add(new QfParameter("ChassisNumber", string.Format(@"'{0}'", model.ChassisNumber)));
                parameters.Add(new QfParameter("YearCheckExpDate", string.Format(@"'{0}'", model.YearCheckExpDate)));
                parameters.Add(new QfParameter("CurrentKil", model.CurrentKil));
                parameters.Add(new QfParameter("RepairExpenses", model.RepairExpenses));
                parameters.Add(new QfParameter("MaintenanceExp", model.MaintenanceExp));
                parameters.Add(new QfParameter("CarModel", string.Format(@"'{0}'", model.CarModel)));
                parameters.Add(new QfParameter("OilExpenses", model.OilExpenses));
                parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
                parameters.Add(new QfParameter("OperateID", model.OperateID));
                parameters.Add(new QfParameter("OperateTime", string.Format(@"'{0}'", model.OperateTime)));
                parameters.Add(new QfParameter("CarNo", string.Format(@"'{0}'", model.CarNo)));
                parameters.Add(new QfParameter("DepartmentID", model.DepartmentID));
                parameters.Add(new QfParameter("Status", model.Status));
                parameters.Add(new QfParameter("ServiceTime", string.Format(@"'{0}'", model.ServiceTime)));
                parameters.Add(new QfParameter("BuyTime", string.Format(@"'{0}'", model.BuyTime)));
                parameters.Add(new QfParameter("LicenseCode", string.Format(@"'{0}'", model.LicenseCode)));
                parameters.Add(new QfParameter("LicenseExpireDate", string.Format(@"'{0}'", model.LicenseExpireDate)));
                string colStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.ParameterName));
                string atColStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.Value));
                string sql = string.Format("insert into t_car({0}) values ({1})", colStr, atColStr);
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
        public bool Delete(Car model)
        {
            try
            {
                string sql = string.Format("delete from t_car where CarID = {0}", model.CarID);
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
        public bool Update(Car model)
        {
            try
            {
                var parameters = new List<QfParameter>();
                parameters.Add(new QfParameter("CarID", model.CarID));
                parameters.Add(new QfParameter("EmployeeID", model.EmployeeID));
                parameters.Add(new QfParameter("Brand", string.Format(@"'{0}'", model.Brand)));
                parameters.Add(new QfParameter("OwnerID", model.OwnerID));
                parameters.Add(new QfParameter("FuelType", string.Format(@"'{0}'", model.FuelType)));
                parameters.Add(new QfParameter("EngineNumber", string.Format(@"'{0}'", model.EngineNumber)));
                parameters.Add(new QfParameter("ChassisNumber", string.Format(@"'{0}'", model.ChassisNumber)));
                parameters.Add(new QfParameter("YearCheckExpDate", string.Format(@"'{0}'", model.YearCheckExpDate)));
                parameters.Add(new QfParameter("CurrentKil", model.CurrentKil));
                parameters.Add(new QfParameter("RepairExpenses", model.RepairExpenses));
                parameters.Add(new QfParameter("MaintenanceExp", model.MaintenanceExp));
                parameters.Add(new QfParameter("CarModel", string.Format(@"'{0}'", model.CarModel)));
                parameters.Add(new QfParameter("OilExpenses", model.OilExpenses));
                parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
                parameters.Add(new QfParameter("OperateID", model.OperateID));
                parameters.Add(new QfParameter("OperateTime", string.Format(@"'{0}'", model.OperateTime)));
                parameters.Add(new QfParameter("CarNo", string.Format(@"'{0}'", model.CarNo)));
                parameters.Add(new QfParameter("DepartmentID", model.DepartmentID));
                parameters.Add(new QfParameter("Status", model.Status));
                parameters.Add(new QfParameter("ServiceTime", string.Format(@"'{0}'", model.ServiceTime)));
                parameters.Add(new QfParameter("BuyTime", string.Format(@"'{0}'", model.BuyTime)));
                parameters.Add(new QfParameter("LicenseCode", string.Format(@"'{0}'", model.LicenseCode)));
                parameters.Add(new QfParameter("LicenseExpireDate", string.Format(@"'{0}'", model.LicenseExpireDate)));
                string setStr = "";
                foreach (var item in parameters)
                {
                    if (item.Value != null && ValueConvert.ToString(item.Value) != "''")
                    {
                        setStr += string.Format(" {0} = {1},", item.ParameterName, item.Value);
                    }
                }
                setStr = setStr.Substring(0, setStr.LastIndexOf(","));
                string sql = string.Format("update t_car set {0} where CarID = {1}", setStr,  model.CarID);
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
        public List<Car> GetList()
        {
            try
            {
                string sql = string.Format(@"select a.*, b.EmployeeName, c.DepartmentName, d.EmployeeName OwnerName
                     from t_car a 
                    left join t_employee b on a.EmployeeID = b.EmployeeID 
                    left join t_department c on a.DepartmentID = c.DepartmentID 
                    left join t_employee d on a.OwnerID = d.EmployeeID ");
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<Car> _list = ModelConvert.ToList<Car>(dt);
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

