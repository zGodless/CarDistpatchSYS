using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;
using QuickFrame.UI.Common.Search;

namespace DS.MSClient.UICommon
{
    ///<summary> 
    ///模块编号： 
    ///作用：公共Grid查询窗体
    ///作者：phq
    ///编写日期：2015-6-9
    ///</summary> 
    public partial class FormSearchCondition : FormBase
    {
        /// <summary>
        /// 
        /// </summary>
        public FormSearchCondition()
        {
            InitializeComponent();
        }

        #region 属性
  

        #endregion

        public  DevExpress.XtraGrid.Views.Grid.GridView gv_current = null;
        /// <summary>
        /// 查询条件对象列表
        /// </summary>
        public List<Condition> CondtionList = new List<Condition>();

        /// <summary>
        /// 加载条件查询页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSearchCondition_Load(object sender, EventArgs e)
        {
            try
            {
                if (gv_current != null)
                {
                    this.BindConditionGrid();
                }
            }
            catch (Exception ee)
            {
               // Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 确定按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                this.CondtionList.Clear();
                for (int i = 0; i < this.dt_MyDataSet.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dt_MyDataSet.Rows[i]["Choose"]))
                    {
                        SearchValueType t = new SearchValueType();
                        t = SearchValueType.String;
                        if (dt_MyDataSet.Rows[i]["Type"].ToString() == typeof(Decimal).Name)
                        {
                            t = SearchValueType.Number;
                        }
                        if (dt_MyDataSet.Rows[i]["Type"].ToString() == typeof(String).Name)
                        {
                            t = SearchValueType.String;
                        }
                        if (dt_MyDataSet.Rows[i]["Type"].ToString() == typeof(DateTime).Name)
                        {
                            t = SearchValueType.Date;
                        }
                        if (dt_MyDataSet.Rows[i]["Type"].ToString() == typeof(Object).Name)
                        {
                            t = SearchValueType.String;
                        }
                        Condition cond = new Condition(dt_MyDataSet.Rows[i]["ColumnFiledName"].ToString(),
                                                      dt_MyDataSet.Rows[i]["ColumnName"].ToString(),
                                                      dt_MyDataSet.Rows[i]["ValueDisplay"].ToString(), t); 
                           
                        cond.Operator = ToSqlString(dt_MyDataSet.Rows[i]["Operater"].ToString());
                        CondtionList.Add(cond);
                    }
                }
                 
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
               // Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 将中文的符号转换为sqlstring
        /// </summary>
        /// <param name="oldstring">旧string</param>
        /// <returns>新string </returns>
        private string ToSqlString(string oldstring)
        {
            switch (oldstring)
            {
                case "等于":
                    return "=";
                case "近似等于":
                    return "Like";
                case "大于":
                    return ">";
                case "小于":
                    return "<";
                case "大于等于":
                    return ">=";
                case "小于等于":
                    return "<=";
                case "不等于":
                    return "<>";
                default:
                    return "=";
            }
        }

        /// <summary>
        /// 查询表格
        /// </summary>
        private void BindConditionGrid()
        {
            this.dt_MyDataSet.Rows.Clear();
            for (int i = 0; i < gv_current.Columns.Count; i++)
            {
                if (gv_current.Columns[i].UnboundType != DevExpress.Data.UnboundColumnType.Bound)
                {
                    DataRow dr = this.dt_MyDataSet.NewRow();
                    dr["Choose"] = false;
                    dr["ValueDisplay"] = "";
                    dr["TextDisplay"] = "";
                    dr["Type"] = gv_current.Columns[i].UnboundType.ToString();
                    dr["Operater"] = "等于";
                 
                    dr["ColumnName"] = gv_current.Columns[i].Caption;
                    dr["ColumnFiledName"] = gv_current.Columns[i].FieldName;
                    if (dr["ColumnName"] != null && dr["ColumnName"].ToString() != "") 
                    {
                        if (dr["ColumnName"].ToString().Contains("编号") )
                        {
                            dr["Operater"] = "近似等于";
                        }
                    }

                    if (gv_current.Columns[i].Tag != null)
                    {
                        if (gv_current.Columns[i].Tag.ToString() == "Pickstatus")
                        {
                            dr["ButtonEdit"] = gv_current.Columns[i].Tag.ToString();
                        }
                        else
                        {
                            dr["ButtonEdit"] = gv_current.Columns[i].Tag.ToString();
                        }
                    }
                    if (dr["Type"].ToString() == typeof(DateTime).Name)
                    {
                            dr["Operater"] = "大于等于";
                            DataRow dr1 = this.dt_MyDataSet.NewRow();
                            dr1["Choose"] = false;
                            dr1["ValueDisplay"] = "";
                            dr1["TextDisplay"] = "";
                            dr1["Type"] = gv_current.Columns[i].UnboundType.ToString();
                            dr1["Operater"] = "小于等于";
                            dr1["ColumnName"] = gv_current.Columns[i].Caption;
                            dr1["ColumnFiledName"] = gv_current.Columns[i].FieldName;
                            dt_MyDataSet.Rows.Add(dr);
                            dt_MyDataSet.Rows.Add(dr1);
                        
                    }
                    else if (dr["Type"].ToString() == typeof(Object).Name)
                    {
                        dr["ButtonEdit"] = gv_current.Columns[i].FieldName;
                        dt_MyDataSet.Rows.Add(dr);
                    }
                    else
                    {
                        dt_MyDataSet.Rows.Add(dr);
                    }
                }
                              
            }
            this.gc_Condition.RefreshDataSource();
        }

        /// <summary>
        /// 选择行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_LoadGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.FocusedRowHandle)];
                string type = dr["Type"].ToString();
                this.comb_Operater.Items.Clear();
                if (dr["Type"].ToString() == typeof(Decimal).Name)
                {
                    this.comb_Operater.Items.AddRange(new object[]
                    {
                        "等于",
                        "大于",
                        "小于",
                        "大于等于",
                        "小于等于",
                        "不等于"
                    });
                    gridCol_Value.ColumnEdit = null;
                }
                else if (dr["Type"].ToString() == typeof(String).Name)
                {
                    this.comb_Operater.Items.AddRange(new object[]
                    {
                        "等于",
                        "近似等于",
                        "大于",
                        "小于",
                        "大于等于",
                        "小于等于",
                        "不等于"
                    });
                    gridCol_Value.ColumnEdit = null;
                }
                else if (dr["Type"].ToString() == typeof(DateTime).Name)
                {
                    this.comb_Operater.Items.AddRange(new object[]
                    {
                        "等于",
                        "大于",
                        "小于",
                        "大于等于",
                        "小于等于",
                        "不等于"
                    });
                     
                    gridCol_Value.ColumnEdit = this.dateEdit_Value;
                    
                 
                }
                else if (dr["Type"].ToString() == typeof(Object).Name)
                {
                    this.comb_Operater.Items.AddRange(new object[]
                    {
                        "等于"
                    });
                    string fieldName = dr["ButtonEdit"].ToString();
                    gridCol_Value.ColumnEdit =gv_current.Columns[fieldName].ColumnEdit;
                }
                else if (dr["Type"].ToString() == typeof(Boolean).Name)
                {
                    this.comb_Operater.Items.AddRange(new object[]
                    {
                        "等于"
                    });
                    gridCol_Value.ColumnEdit = comb_TrueOrFalse;
                }
                if (dr["ButtonEdit"].ToString() != "" && dr["Type"].ToString() != typeof(Object).Name)
                {
                    gridCol_Value.ColumnEdit = this.btnEdit_Value;
                }
                string temp = dr["ButtonEdit"].ToString();
                //增加值为:下拉框的情况
                if (dr["ButtonEdit"].ToString() == "VehicleType")
                {
                    this.gridCol_Value.ColumnEdit = repositoryItemComboBox_VehicleType;
                }
                else if (dr["ButtonEdit"].ToString() == "DutyType")//渣土白班，晚班
                {
                    this.gridCol_Value.ColumnEdit = repositoryItemComboBox_DutyType;
                }
                else if (dr["ButtonEdit"].ToString() == "NJDutyType")//加油上下午
                {
                    this.gridCol_Value.ColumnEdit = repositoryItemComboBox_NJDutyType;
                }
                else if (dr["ButtonEdit"].ToString() == "IsCreatedByPDA")//是否pda创建： "手工单","PDA刷车卡", "PDA手工录入"
                {
                    this.gridCol_Value.ColumnEdit = repositoryItemComboBox_IsCreatedByPDA;
                }
            }
            catch (Exception ee)
            {
               // Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 查询按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Value_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (this.gv_Condition.FocusedRowHandle >= 0)
                {
                   
                    DataRow dr = dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()];

                     // 如果是对象查询：
                   if (dr["ButtonEdit"].ToString().Contains("Driver"))
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(Driver);
                       //form.SearchType_Suffix = dr["ButtonEdit"].ToString();//传入具体查询类型，包括后缀
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    Driver bc = (Driver)form.SearchObject;
                       //    dr["TextDisplay"] = bc.DriverName;
                       //    dr["ValueDisplay"] = bc.DriverID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//查询框中，如果值填入东西，那么这个条件就默认选中。不要用户再去勾选前面的勾勾。
                       //}
                   }
                   // 如果是对象查询：
                   else if (dr["ButtonEdit"].ToString().Contains( "Vehicle"))
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(Vehicle);
                       //form.SearchType_Suffix = dr["ButtonEdit"].ToString();//传入具体查询类型，包括后缀
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    Vehicle bc = (Vehicle)form.SearchObject;
                       //    dr["TextDisplay"] = bc.VehicleNO;
                       //    dr["ValueDisplay"] = bc.VehicleID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//查询框中，如果值填入东西，那么这个条件就默认选中。不要用户再去勾选前面的勾勾。
                       //}
                   }
                   else if (dr["ButtonEdit"].ToString() == "Employee")
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(Employee); 
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    Employee bc = (Employee)form.SearchObject;
                       //    dr["TextDisplay"] = bc.EmployeeName;
                       //    dr["ValueDisplay"] = bc.EmployeeID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//查询框中，如果值填入东西，那么这个条件就默认选中。不要用户再去勾选前面的勾勾。
                       //}
                   }
                   else if (dr["ButtonEdit"].ToString().Contains ("ConstructionSite"))
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(ConstructionSite);
                       //form.SearchType_Suffix = dr["ButtonEdit"].ToString();//传入具体查询类型，包括后缀
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    ConstructionSite bc = (ConstructionSite)form.SearchObject;
                       //    dr["TextDisplay"] = bc.ConstructionName;
                       //    dr["ValueDisplay"] = bc.ConstructionSiteID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//查询框中，如果值填入东西，那么这个条件就默认选中。不要用户再去勾选前面的勾勾。
                       //}
                   }
                   else if (dr["ButtonEdit"].ToString() == "Project")
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(Project);
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    Project bc = (Project)form.SearchObject;
                       //    dr["TextDisplay"] = bc.ProjectName;
                       //    dr["ValueDisplay"] = bc.ProjectID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//查询框中，如果值填入东西，那么这个条件就默认选中。不要用户再去勾选前面的勾勾。
                       //}
                   }
                   else if (dr["ButtonEdit"].ToString().Contains("DataDictionary"))//字典相关
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(DataDictionary);
                       //form.SearchType_Suffix = dr["ButtonEdit"].ToString();//传入具体查询类型，包括后缀
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    DataDictionary bc = (DataDictionary)form.SearchObject;
                       //    dr["TextDisplay"] = bc.DataDictionaryName;
                       //    dr["ValueDisplay"] = bc.DataDictionaryID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//查询框中，如果值填入东西，那么这个条件就默认选中。不要用户再去勾选前面的勾勾。
                       //}
                   }
                   else if (dr["ButtonEdit"].ToString().Contains("Customer"))//客户：甲方单位、外包车队
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(Customer);
                       //form.SearchType_Suffix = dr["ButtonEdit"].ToString();//传入具体查询类型，包括后缀
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    Customer bc = (Customer)form.SearchObject;
                       //    dr["TextDisplay"] = bc.CustomerName;
                       //    dr["ValueDisplay"] = bc.CustomerID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//查询框中，如果值填入东西，那么这个条件就默认选中。不要用户再去勾选前面的勾勾。
                       //}
                   } 
                }
                this.gc_Condition.RefreshDataSource();
                this.gv_Condition.RefreshRow(this.gv_Condition.GetFocusedDataSourceRowIndex());
            }
            catch (Exception ee)
            {
               // Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// 修改值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_Condition_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "TextDisplay") 
                {
                    string temp = e.Value.ToString();
                    if (dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Type"].ToString() == typeof(DateTime).Name)
                    {

                        dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ValueDisplay"] = Convert.ToDateTime(e.Value);
                    }
                    else
                    {
                        if (dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ButtonEdit"].ToString() == "" ||
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ButtonEdit"].ToString() == "VehicleType" ||//自定义下拉框赋值情况要考虑 
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ButtonEdit"].ToString() == "DutyType" ||
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ButtonEdit"].ToString() == "NJDutyType" ||
                             dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ButtonEdit"].ToString() == "IsCreatedByPDA" ||
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Type"].ToString() == typeof(Object).Name)
                        {
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ValueDisplay"] = e.Value;
                        }
                    }
                    if (dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Type"].ToString() == typeof(Boolean).Name)
                    {
                        if (e.Value.ToString() == "是")
                        {
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ValueDisplay"] = "True";  
                        }
                        else
                        {
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ValueDisplay"] = "False"; 
                        }
                    }

                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Choose"] = true;// 查询框中，如果值填入东西，那么这个条件就默认选中。不要用户再去勾选前面的勾勾。
                    }
                    else
                    {
                        dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Choose"] = false;// 查询框中，如果值填入东西，那么这个条件就默认选中。不要用户再去勾选前面的勾勾。
                    }
                }
                if (e.Value.ToString().Trim() != "")
                {

                    if (e.Column.FieldName == "Choose" && (bool)e.Value)
                    {
                        if (dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Type"].ToString() == typeof(DateTime).Name)
                        {
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["TextDisplay"] = DateTime.Now.Date.ToString("yyyy-MM-dd");
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ValueDisplay"] = DateTime.Now.Date.ToString("yyyy-MM-dd");                 
 
                        }
                    }
                    
                }
            }
            catch
            {
               // ignored
            }        


        }
    }
}