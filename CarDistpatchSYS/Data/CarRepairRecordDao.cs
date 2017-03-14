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
    /// 作用：数据访问类:CarRepairRecordDao
    /// 作者：zyl
    /// 代码生成日期：2017-03-14
    /// 最后修改人：zyl
    /// 最后修改日期：2017-03-14
    /// 说明：t_car_repair_record
	/// </summary>
	public class CarRepairRecordDao
	{


        /// <summary>
        /// 简单查询
        /// </summary>
        /// <param name="sql"></param>
        public List<CarRepairRecord> QueryGetList(string sql)
        {
            try
            {
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarRepairRecord> _list = ModelConvert.ToList<CarRepairRecord>(dt);
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
        public CarRepairRecord GetModel(int RepairID)
        {
            try
            {
                string sql = string.Format("select * from t_car_repair_record where RepairID = {0} limit 1", RepairID);
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                CarRepairRecord model = ModelConvert.ToModel<CarRepairRecord>(dt);
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
        public bool Add(CarRepairRecord model)
        {
            try
            {
                var parameters = new List<QfParameter>();
			parameters.Add(new QfParameter("CarID", model.CarID));
            parameters.Add(new QfParameter("RepairID", model.RepairID));
            parameters.Add(new QfParameter("RepairPlace", string.Format(@"'{0}'", model.RepairPlace)));
            parameters.Add(new QfParameter("RepairDate", string.Format(@"'{0}'", model.RepairDate)));
            parameters.Add(new QfParameter("ItemStr", string.Format(@"'{0}'", model.ItemStr)));
            parameters.Add(new QfParameter("RepairKil", model.RepairKil));
            parameters.Add(new QfParameter("Result", string.Format(@"'{0}'", model.Result)));
            parameters.Add(new QfParameter("PartsCost", model.PartsCost));
            parameters.Add(new QfParameter("CreatID", model.CreatID));
            parameters.Add(new QfParameter("Note", string.Format(@"'{0}'", model.Note)));
            parameters.Add(new QfParameter("OperateID", model.OperateID));
            parameters.Add(new QfParameter("OperateTime", string.Format(@"'{0}'", model.OperateTime)));
                            string colStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.ParameterName));
                string atColStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.Value));
                string sql = string.Format("insert into t_car_repair_record({0}) values ({1})", colStr, atColStr);
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
        public bool Delete(CarRepairRecord model)
        {
            try
            {
                string sql = string.Format("delete from t_car_repair_record where RepairID = {0}", model.RepairID);
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
        public bool Update(CarRepairRecord model)
        {
            try
            {
                var parameters = new List<QfParameter>();
			parameters.Add(new QfParameter("CarID", model.CarID));
            parameters.Add(new QfParameter("RepairID", model.RepairID));
            parameters.Add(new QfParameter("RepairPlace", string.Format(@"'{0}'", model.RepairPlace)));
            parameters.Add(new QfParameter("RepairDate", string.Format(@"'{0}'", model.RepairDate)));
            parameters.Add(new QfParameter("ItemStr", string.Format(@"'{0}'", model.ItemStr)));
            parameters.Add(new QfParameter("RepairKil", model.RepairKil));
            parameters.Add(new QfParameter("Result", string.Format(@"'{0}'", model.Result)));
            parameters.Add(new QfParameter("PartsCost", model.PartsCost));
            parameters.Add(new QfParameter("CreatID", model.CreatID));
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
                string sql = string.Format("update t_car_repair_record set {0} where RepairID = {1}", setStr,  model.RepairID);
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
        public List<CarRepairRecord> GetList()
        {
            try
            {
                string sql = string.Format("select * from t_car_repair_record");
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarRepairRecord> _list = ModelConvert.ToList<CarRepairRecord>(dt);
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

