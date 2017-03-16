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
    /// 作用：数据访问类:CarRepairItemDao
    /// 作者：zyl
    /// 代码生成日期：2017-03-14
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-14
    /// 说明：t_car_repair_item
	/// </summary>
	public class CarRepairItemDao
	{


        /// <summary>
        /// 简单查询
        /// </summary>
        /// <param name="sql"></param>
        public List<CarRepairItem> QueryGetList(string sql)
        {
            try
            {
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarRepairItem> _list = ModelConvert.ToList<CarRepairItem>(dt);
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
        public CarRepairItem GetModel(int ItemID)
        {
            try
            {
                string sql = string.Format("select * from t_car_repair_item where ItemID = {0} limit 1", ItemID);
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                CarRepairItem model = ModelConvert.ToModel<CarRepairItem>(dt);
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
        public bool Add(CarRepairItem model)
        {
            try
            {
                var parameters = new List<QfParameter>();
			parameters.Add(new QfParameter("ItemID", model.ItemID));
            parameters.Add(new QfParameter("RepairName", string.Format(@"'{0}'", model.RepairName)));
            parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
            parameters.Add(new QfParameter("OperateID", model.OperateID));
            parameters.Add(new QfParameter("OperateTime", string.Format(@"'{0}'", model.OperateTime)));
                            string colStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.ParameterName));
                string atColStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.Value));
                string sql = string.Format("insert into t_car_repair_item({0}) values ({1})", colStr, atColStr);
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
        public bool Delete(CarRepairItem model)
        {
            try
            {
                string sql = string.Format("delete from t_car_repair_item where ItemID = {0}", model.ItemID);
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
        public bool Update(CarRepairItem model)
        {
            try
            {
                var parameters = new List<QfParameter>();
			parameters.Add(new QfParameter("ItemID", model.ItemID));
            parameters.Add(new QfParameter("RepairName", string.Format(@"'{0}'", model.RepairName)));
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
                string sql = string.Format("update t_car_repair_item set {0} where ItemID = {1}", setStr,  model.ItemID);
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
        public List<CarRepairItem> GetList()
        {
            try
            {
                string sql = string.Format(@"select a.*, b.EmployeeName from t_car_repair_item a 
                                                left join t_employee b on a.OperateID = b.EmployeeID ");
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarRepairItem> _list = ModelConvert.ToList<CarRepairItem>(dt);
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

