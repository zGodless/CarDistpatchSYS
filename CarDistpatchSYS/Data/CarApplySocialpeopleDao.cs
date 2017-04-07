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
    /// 作用：数据访问类:CarApplySocialpeopleDao
    /// 作者：zyl
    /// 代码生成日期：2017-04-08
    /// 最后修改人：zyl
    /// 最后修改日期：2017-04-08
    /// 说明：
    /// </summary>
    public class CarApplySocialpeopleDao
    {


        /// <summary>
        /// 简单查询
        /// </summary>
        /// <param name="sql"></param>
        public List<CarApplySocialpeople> QueryGetList(string sql)
        {
            try
            {
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarApplySocialpeople> _list = ModelConvert.ToList<CarApplySocialpeople>(dt);
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
        public CarApplySocialpeople GetModel(int SocialPeopleID)
        {
            try
            {
                string sql = string.Format("select * from t_car_apply_socialpeople where SocialPeopleID = {0} limit 1", SocialPeopleID);
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                CarApplySocialpeople model = ModelConvert.ToModel<CarApplySocialpeople>(dt);
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
        public bool Add(CarApplySocialpeople model)
        {
            try
            {
                var parameters = new List<QfParameter>();
                parameters.Add(new QfParameter("SocialPeopleID", model.SocialPeopleID));
                parameters.Add(new QfParameter("ApplyID", model.ApplyID));
                parameters.Add(new QfParameter("Name", string.Format(@"'{0}'", model.Name)));
                parameters.Add(new QfParameter("IdentityNo", string.Format(@"'{0}'", model.IdentityNo)));
                parameters.Add(new QfParameter("DriverLicense", string.Format(@"'{0}'", model.DriverLicense)));
                parameters.Add(new QfParameter("DriverLicenseType", string.Format(@"'{0}'", model.DriverLicenseType)));
                parameters.Add(new QfParameter("FileNumber", string.Format(@"'{0}'", model.FileNumber)));
                string colStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.ParameterName));
                string atColStr = string.Join(",", parameters.FindAll(m => ValueConvert.ToString(m.Value) != null && ValueConvert.ToString(m.Value) != "''").Select(n => n.Value));
                string sql = string.Format("insert into t_car_apply_socialpeople({0}) values ({1})", colStr, atColStr);
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
        public bool Delete(CarApplySocialpeople model)
        {
            try
            {
                string sql = string.Format("delete from t_car_apply_socialpeople where SocialPeopleID = {0}", model.SocialPeopleID);
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
        public bool Update(CarApplySocialpeople model)
        {
            try
            {
                var parameters = new List<QfParameter>();
                parameters.Add(new QfParameter("SocialPeopleID", model.SocialPeopleID));
                parameters.Add(new QfParameter("ApplyID", model.ApplyID));
                parameters.Add(new QfParameter("Name", string.Format(@"'{0}'", model.Name)));
                parameters.Add(new QfParameter("IdentityNo", string.Format(@"'{0}'", model.IdentityNo)));
                parameters.Add(new QfParameter("DriverLicense", string.Format(@"'{0}'", model.DriverLicense)));
                parameters.Add(new QfParameter("DriverLicenseType", string.Format(@"'{0}'", model.DriverLicenseType)));
                parameters.Add(new QfParameter("FileNumber", string.Format(@"'{0}'", model.FileNumber)));
                string setStr = "";
                foreach (var item in parameters)
                {
                    if (item.Value != null && ValueConvert.ToString(item.Value) != "''")
                    {
                        setStr += string.Format(" {0} = {1},", item.ParameterName, item.Value);
                    }
                }
                setStr = setStr.Substring(0, setStr.LastIndexOf(","));
                string sql = string.Format("update t_car_apply_socialpeople set {0} where SocialPeopleID = {1}", setStr, model.SocialPeopleID);
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
        public List<CarApplySocialpeople> GetList()
        {
            try
            {
                string sql = string.Format("select * from t_car_apply_socialpeople");
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarApplySocialpeople> _list = ModelConvert.ToList<CarApplySocialpeople>(dt);
                return _list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        /// <param name="sql"></param>
        public CarApplySocialpeople GetModelByID(int id)
        {
            try
            {
                string sql = string.Format("select * from t_car_apply_socialpeople where ApplyID = {0}", id);
                DataTable dt = MysqlHelper.ExecuteDataTable(sql);
                List<CarApplySocialpeople> _list = ModelConvert.ToList<CarApplySocialpeople>(dt);
                return _list.Count == 0 ? null : _list[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

    }
}

