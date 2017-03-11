using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DS.Common;


namespace DS.MSClient
{
    public partial class FormColumnConfig : FormBlankBase
    {
        ///<summary> 
        ///模块编号：CF0006
        ///作用：公共列配置
        ///作者：phq
        ///编写日期： 
        ///</summary> 
        public FormColumnConfig()
        {
            InitializeComponent();
            InitEvent();
        }

        #region 属性
        /// <summary>
        /// 传入需要配置的列信息
        /// </summary>
        public DevExpress.XtraGrid.Views.Grid.GridView gv_current = null;
        public string defaultLayoutXMLName = "";//默认grid样式名称
        public List<Column> list_column = new List<Column>();
        private Column CurrentColumn = null;//当前行
        #endregion

        #region 事件
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitEvent()
        {
            this.Load += new System.EventHandler(this.FormColumnConfig_Load);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);//取消
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);//确定
            this.btnUp.Click += new System.EventHandler(this.btnDownAndUp_Click);//上
            this.btnDown.Click += new System.EventHandler(this.btnDownAndUp_Click);//下
            this.btnRestoreViewLayout.Click+=btnRestoreViewLayout_Click;//恢复gridview默认样式
            this.ckb_ChooseAll.CheckedChanged += new System.EventHandler(this.ckb_ChooseAll_CheckedChanged);//全选
            this.gv_ColumnConfig.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_ColumnConfig_FocusedRowChanged);//grid选择某行
            //勾选选择列
            this.gv_ColumnConfig.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv_ColumnConfig_CellValueChanging);
        }
        /// <summary>
        /// 绑定列信息
        /// </summary>
        private void BindColumn()
        {
            try
            {
                if (gv_current != null)
                {
                    this.list_column.Clear();
                    for (int i = 0; i < gv_current.Columns.Count; i++)
                    {
                        if (gv_current.Columns[i].Tag == null&&gv_current.Columns[i].FieldName!="Choose")
                        {
                            Column column = new Column();
                            column.Visible = gv_current.Columns[i].Visible;
                            column.ColumnEditName = gv_current.Columns[i].Caption;
                            column.VisibleIndex = gv_current.Columns[i].VisibleIndex;
                            if (gv_current.Columns[i].Fixed == FixedStyle.Left)
                            {
                                column.FixedStyle = "left";
                            }
                            else if (gv_current.Columns[i].Fixed == FixedStyle.Right)
                            {
                                column.FixedStyle = "right";
                            }

                            this.list_column.Add(column);
                        }
                    }
                    list_column.Sort(CompareVisibleIndex);
                    for (int i = 0; i < list_column.Count; i++)
                    {
                        list_column[i].ColumnIndex = i + 1;
                    }
                    this.gc_ColumnConfig.DataSource = list_column;
                    this.gc_ColumnConfig.RefreshDataSource();
                }
            }
            catch
            {

            }

        }

        /// <summary>
        /// 加载条件查询页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormColumnConfig_Load(object sender, EventArgs e)
        {
            try
            {
                this.btnRestoreViewLayout.ImageList = DS.MSClient.Controls.StaticImageList.Instance.ImageList_global;
                this.btnRestoreViewLayout.ImageIndex = 6;
                if (gv_current != null)
                {
                    int x = Cursor.Position.X;
                    int y = Cursor.Position.Y;
                    if (this.Height <y)
                    {
                        y = y - this.Height;
                    }
                   
                    this.Location = new Point(x, y);
                    this.BindColumn();
                }
                
            }
            catch
            {

            }
        }
        #endregion
        #region 方法
        /// <summary>
        /// 比较显示索引大小，用于排序
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        private int CompareVisibleIndex(Column X, Column Y)
        {
            if (X != null && Y != null)
            {
                return X.VisibleIndex.CompareTo(Y.VisibleIndex);
            }
            else
            {
                if (X == null && Y == null)
                    return 0;
                else if (X == null && Y != null)
                    return -1;
                else
                    return 1;
            }
        }
        #endregion
        #region 事件
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        /// <summary>
        /// 确定保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int visibleIndex = 1;//列的可见索引,除去选择列是0，从1开始
                for (int i = 0; i < list_column.Count; i++)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn gc in this.gv_current.Columns)
                    {
                        if (gc.Caption.Equals(list_column[i].ColumnEditName))
                        {
                            gc.Visible = list_column[i].Visible;
                            if (gc.Visible)
                            {
                                gc.VisibleIndex = visibleIndex;
                                visibleIndex++;
                            }
                            break;
                        }

                    }
                }
                this.gv_current.RefreshData();
                visibleIndex = 1;
                //因为第一遍的排序还可能有问题，重复再排一遍，可提高排序的准确性
                for (int i = 0; i < list_column.Count; i++)
                {
                    foreach (DevExpress.XtraGrid.Columns.GridColumn gc in this.gv_current.Columns)
                    {
                        if (gc.Caption.Equals(list_column[i].ColumnEditName))
                        {
                            gc.Visible = list_column[i].Visible;
                            if (gc.Visible)
                            {
                                gc.VisibleIndex = visibleIndex;
                                visibleIndex++;
                            }
                            break;
                        }

                    }
                }

                this.gv_current.RefreshData();
                Application.DoEvents();
                this.DialogResult = DialogResult.OK;
            }
            catch
            {

            }
        }

        /// <summary>
        /// 上下移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownAndUp_Click(object sender, EventArgs e)
        {
            try
            {
                CurrentColumn = this.list_column[gv_ColumnConfig.GetFocusedDataSourceRowIndex()];
                if (CurrentColumn != null)
                {
                    bool flag = false;
                    int tempColumnIndex = CurrentColumn.ColumnIndex;
                    if (sender == this.btnUp && tempColumnIndex > 1)//上移增加了判断冻结列的情况,冻结列只能在自己的范围内移动
                    {
                        if (tempColumnIndex >= 2 && this.list_column[tempColumnIndex - 1].FixedStyle == "right" && string.IsNullOrEmpty(this.list_column[tempColumnIndex - 2].FixedStyle))//从冻结列往非冻结列下移动是禁止的
                        {
                            return;//从右侧冻结到左侧
                        }
                        if (tempColumnIndex >= 2 && string.IsNullOrEmpty(this.list_column[tempColumnIndex - 1].FixedStyle) && this.list_column[tempColumnIndex - 2].FixedStyle == "left")//从冻结列往非冻结列下移动是禁止的
                        {
                            return;//从右侧非冻结到左侧冻结列
                        }
                        this.list_column.Remove(this.CurrentColumn);
                        this.list_column[tempColumnIndex - 2].ColumnIndex = tempColumnIndex;
                        this.CurrentColumn.ColumnIndex = this.CurrentColumn.ColumnIndex - 1;
                        this.list_column.Insert(this.CurrentColumn.ColumnIndex - 1, this.CurrentColumn);
                        this.gv_ColumnConfig.FocusedRowHandle--;

                        flag = true;
                    }
                    if (sender == this.btnDown && tempColumnIndex < this.list_column.Count)//下移动，增加了判断冻结列的情况,冻结列只能在自己的范围内移动
                    {
                        if (this.list_column[tempColumnIndex - 1].FixedStyle == "left" && string.IsNullOrEmpty(this.list_column[tempColumnIndex].FixedStyle))//从冻结列往非冻结列下移动是禁止的
                        {
                            return;//从左侧冻结到右侧
                        }
                        if (string.IsNullOrEmpty(this.list_column[tempColumnIndex - 1].FixedStyle) && this.list_column[tempColumnIndex].FixedStyle == "right")//从冻结列往非冻结列下移动是禁止的
                        {
                            return;//从左侧非冻结到右侧冻结列
                        }
                        this.list_column.Remove(this.CurrentColumn);
                        this.list_column[tempColumnIndex - 1].ColumnIndex = tempColumnIndex;
                        this.CurrentColumn.ColumnIndex = this.CurrentColumn.ColumnIndex + 1;
                        this.list_column.Insert(this.CurrentColumn.ColumnIndex - 1, this.CurrentColumn);
                        this.gv_ColumnConfig.FocusedRowHandle++;
                        flag = true;
                    }
                    if (flag)
                    {
                        this.gc_ColumnConfig.RefreshDataSource();
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 恢复gridview默认样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestoreViewLayout_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.defaultLayoutXMLName) || !System.IO.File.Exists(defaultLayoutXMLName))
                {
                    DS.MSClient.UICommon.MsgBox.ShowInfo("未找到默认配置");
                    return; 
                }
                gv_current.RestoreLayoutFromXml(defaultLayoutXMLName, DevExpress.Utils.OptionsLayoutBase.FullLayout);//重新加载
                this.BindColumn();
                gv_current.FixedLineWidth = 2;
                //gv_current.Appearance.FixedLine.BackColor = Color.PaleVioletRed;
            }
            catch
            {
            }
        }
        private void ckb_ChooseAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Column c in list_column)
                {
                    c.Visible = this.ckb_ChooseAll.Checked;
                }
                this.gc_ColumnConfig.RefreshDataSource();
            }
            catch
            {

            }
        }
        /// <summary>
        /// grid选择某行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_ColumnConfig_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                CurrentColumn = this.list_column[gv_ColumnConfig.GetFocusedDataSourceRowIndex()];
            }
            catch
            {

            }
        }
        /// <summary>
        /// 点击grid选择列，进行勾选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_ColumnConfig_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0 && e.Column.FieldName == "Choose")
                {
                    this.list_column[this.gv_ColumnConfig.GetFocusedDataSourceRowIndex()].Visible = Convert.ToBoolean(e.Value);
                }
            }
            catch (Exception ee)
            {

            }
        }
        #endregion

    }
}