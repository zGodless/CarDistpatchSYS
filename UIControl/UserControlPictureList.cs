using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DS.MSClient.Properties;
using DS.MSClient.UICommon;
using DS.MSClient.UICommon.CommonForm;
using QuickFrame.Common.Converter;


namespace DS.MSClient.UIControl
{
    public partial class UserControlPictureList : UserControl
    {
        #region 初始化
        public UserControlPictureList()
        {
            InitializeComponent();
            InitEvent();
        }
        /// <summary>
        /// 初始化事件
        /// </summary>
        private void InitEvent()
        {
            //单击图片
          //  this.rItem_picture.Click += this.rItem_picture_Click;
            //选择图片发生变化
            this.gv_picture.FocusedRowChanged += this.gv_picture_FocusedRowChanged;
            //双击图片
            this.rItem_picture.DoubleClick += this.rItem_picture_DoubleClick;
        }
        private static Exception _e = null;

        /// <summary>
        /// 线程中的Exception
        /// </summary>
        public static Exception ThreadException
        {
            get { return _e; }
            set
            {
                _e = value;
            }
        }

        #endregion

        #region 属性
        public string pictureType = null;//图片类型
        /// <summary>
        /// 图片存放路径名称，如：PathUtil.STYLE_PICTURE_PATH，即"stylePicture";
        /// </summary>
        public string picturePath = "";
        private int? currentPictureID = null;//当前图片ID
        private string currentPictureName = "";//图片名称
        private string currentSuffix = "";//后缀
        public DataTable currentPicture_DataTable = null;//当前图片列表对应datatable



        #endregion

        #region 方法
        void ThreadLoadData(ThreadStart method)
        {
            //线程加载数据
            Thread td = new Thread(method);
            td.Start();
           // Program.Form_Progress.ShowDialog();
            if (ThreadException != null)
            {
                MsgBox.ShowError(ThreadException);
                ThreadException = null;
            }
            else
            {
                this.gc_picture.DataSource = this.currentPicture_DataTable;
                this.gc_picture.RefreshDataSource();
            }
        }



        /// <summary>
        /// 绑定图片数据
        /// </summary>
        public void BindData(object list_picture)
        {
            if (list_picture == null)//如果传入数据为空，则清空列表
            {
                this.gc_picture.DataSource = null;
                this.gc_picture.RefreshDataSource();
                return;
            }

            GetDataSource(list_picture);
            if (this.currentPicture_DataTable != null)
            {
                this.gc_picture.DataSource = this.currentPicture_DataTable;
                this.gc_picture.RefreshDataSource();
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="sqlString"></param>
        public void GetDataSource(object list_picture)
        {
            try
            {
                this.currentPicture_DataTable = new DataTable();
                currentPicture_DataTable.Columns.Add("PictureID", System.Type.GetType("System.String"));
                currentPicture_DataTable.Columns.Add("PictureName", System.Type.GetType("System.String"));
                currentPicture_DataTable.Columns.Add("PicturePath", System.Type.GetType("System.String"));
                currentPicture_DataTable.Columns.Add("PictureSuffix", System.Type.GetType("System.String"));
                currentPicture_DataTable.Columns.Add("Type", System.Type.GetType("System.String"));
                currentPicture_DataTable.Columns.Add("Img", System.Type.GetType("System.Byte[]"));
                WebClient client = new WebClient();
                if (pictureType == "OutLook" || pictureType == "Inside" || pictureType == "Other")
                {
                    List<CommonPicture> list_SaleStylePicture = (List<CommonPicture>)list_picture;
                    foreach (CommonPicture s in list_SaleStylePicture)
                    {
                        var url = s.PicturePath ?? "";
                        string urlString = Program.FilesWebServiceUrl + "/" + url.Replace(@"\", "/");//文件上传到目标服务器上的url
                        string pictureNameExt = s.PictureSuffix;//文件扩展名
                        string imgUrl = urlString + "/" + s.PictureID + "_M." + pictureNameExt;//完整地址
                        try
                        {
                            Stream stream = client.OpenRead(imgUrl);
                            StreamReader reader = new StreamReader(stream);
                            Image img = Image.FromStream(stream);
                            MemoryStream ms = new MemoryStream();
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            DataRow dr = currentPicture_DataTable.NewRow();
                            dr["Type"] = s.Type;
                            dr["PictureID"] = s.PictureID;
                            dr["PictureName"] = s.PictureName;
                            dr["PicturePath"] = s.PicturePath;
                            dr["PictureSuffix"] = s.PictureSuffix;
                            dr["Img"] = ms.ToArray();
                            ms.Close();
                            ms.Dispose();
                            currentPicture_DataTable.Rows.Add(dr);
                        }
                        catch (Exception)//有可能数据库转移的时候，图片没有移过来即图片不存在，不抛异常
                        {
                            DataRow dr = currentPicture_DataTable.NewRow();
                            dr["PictureName"] = s.PictureName;
                            dr["PicturePath"] = s.PicturePath;
                            dr["PictureSuffix"] = s.PictureSuffix;
                            dr["Type"] = s.Type;
                            dr["Img"] = null;
                            //currentPicture_DataTable.Rows.Add(dr);
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                ThreadException = e;
            }
            finally
            {
               // Program.Form_Progress.NeedClose = true;
            }
        }
        /// <summary>
        /// 获取图片预览网址
        /// </summary>
        /// <returns></returns>
        public string GetPicturePreviewURL()
        {
            if (this.currentPictureID == null)
            {
                throw new Exception("请选中图片!");
            }
            string pictureURL = Program.FilesWebServiceUrl + "/" + this.picturePath + "/" + this.currentPictureID.ToString() + "." + currentSuffix;
            return pictureURL;
        }
        /// <summary>
        /// 获取图片原图下载网址
        /// </summary>
        /// <returns></returns>
        public string GetPictureDownloadURL()
        {
            if (this.currentPictureID == null)
            {
                throw new Exception("请选中图片!");
            }
            string pictureURL = Program.FilesWebServiceUrl + "/" + this.picturePath + "/" + this.currentPictureID.ToString() + "." + currentSuffix;
            return pictureURL;
        }
        /// <summary>
        /// 获取图片名称
        /// </summary>
        /// <returns></returns>
        public string GetPictureName()
        {
            if (this.currentPictureID == null)
            {
                throw new Exception("请选中图片!");
            }
            return this.currentPictureName;
        }
        /// <summary>
        /// 获取图片后缀
        /// </summary>
        /// <returns></returns>
        public string GetPictureSuffix()
        {
            if (this.currentPictureID == null)
            {
                throw new Exception("请选中图片!");
            }
            return currentSuffix;
        }
        /// <summary>
        /// 获取图片ID
        /// </summary>
        /// <returns></returns>
        public int GetPictureID()
        {
            int focusedRowIndex = this.gv_picture.GetFocusedDataSourceRowIndex();
            if (focusedRowIndex < 0)
            {
                throw new Exception("请选中图片!");
            }

            DataRow dr = this.currentPicture_DataTable.Rows[focusedRowIndex];
            this.currentPictureID = Convert.ToInt32(dr["PictureID"]);
            this.currentPictureName = dr["PictureName"].ToString();
            return this.currentPictureID.Value;
        }

        public CommonPicture GetFocusedRow()
        {
            int focusedRowIndex = this.gv_picture.GetFocusedDataSourceRowIndex();
            if (focusedRowIndex < 0)
            {
                throw new Exception("请选中图片!");
            }
            CommonPicture model = new CommonPicture();
            model.PictureID = ValueConvert.ToInt32(this.currentPicture_DataTable.Rows[focusedRowIndex]["PictureID"]);
            model.PictureName = ValueConvert.ToString(this.currentPicture_DataTable.Rows[focusedRowIndex]["PictureName"]);
            model.PictureSuffix = ValueConvert.ToString(this.currentPicture_DataTable.Rows[focusedRowIndex]["PictureSuffix"]);
            model.PicturePath = ValueConvert.ToString(this.currentPicture_DataTable.Rows[focusedRowIndex]["PicturePath"]);
            model.Type = ValueConvert.ToString(this.currentPicture_DataTable.Rows[focusedRowIndex]["Type"]);
            return model;
        }
        /// <summary>
        /// 设置图片名称
        /// </summary>
        /// <param name="pictureName"></param>
        public void SetPictureNameAndNote(string pictureName)
        {
            int focusedRowIndex = this.gv_picture.GetFocusedDataSourceRowIndex();
            this.currentPicture_DataTable.Rows[focusedRowIndex]["PictureName"] = pictureName;
            this.gv_picture.RefreshData();
        }
        /// <summary>
        /// 设置焦点
        /// </summary>
        /// <param name="pictureName"></param>
        public void SetFoucsedPictureIndex(int index)
        {
            this.gv_picture.FocusedRowHandle = index;
            this.gv_picture.RefreshData();
        }
        /// <summary>
        /// 移除当前焦点图片
        /// </summary>
        /// <returns></returns>
        public bool RemoveFocusedPicture()
        {
            int focusedRowIndex = this.gv_picture.GetFocusedDataSourceRowIndex();
            if (focusedRowIndex >= 0)
            {
                this.currentPicture_DataTable.Rows.RemoveAt(focusedRowIndex);
                this.gv_picture.RefreshData();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 得到当前焦点下标
        /// </summary>
        /// <returns></returns>
        public int GetCurrentFocusIndex()
        {
            if (gv_picture.RowCount > 0)
            {
                return gv_picture.GetFocusedDataSourceRowIndex();
            }
            return 0;
        }
        /// <summary>
        /// 刷新数据源
        /// </summary>
        public void RefreshDataSource()
        {
            gc_picture.RefreshDataSource();
        }
        /// <summary>
        /// 下移
        /// </summary>
        public void MoveDown()
        {
            int index = GetCurrentFocusIndex();
            if (index + 1 == currentPicture_DataTable.Rows.Count || gv_picture.RowCount == 0)
            {
                return;
            }
            gv_picture.BeginUpdate();
            DataRow currentDr = currentPicture_DataTable.NewRow();
            currentDr.ItemArray = currentPicture_DataTable.Rows[index].ItemArray;

            currentPicture_DataTable.Rows.RemoveAt(index);
            currentPicture_DataTable.Rows.InsertAt(currentDr, index + 1);
            gv_picture.FocusedRowHandle = index + 1;
            gv_picture.EndUpdate();
            RefreshDataSource();
        }
        /// <summary>
        /// 上移
        /// </summary>
        public void MoveUp()
        {
            int index = GetCurrentFocusIndex();
            if (index == 0)
            {
                return;
            }

            DataRow beforeDr = currentPicture_DataTable.NewRow();
            beforeDr.ItemArray = currentPicture_DataTable.Rows[index].ItemArray;


            currentPicture_DataTable.Rows.RemoveAt(index);
            currentPicture_DataTable.Rows.InsertAt(beforeDr, index - 1);
            gv_picture.FocusedRowHandle = index - 1;

            RefreshDataSource();
        }
        #endregion



        #region 事件
        /// <summary>
        /// 双击显示图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rItem_picture_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FormPreviewPicture form = new FormPreviewPicture();
                form.picturePreviewURL = this.picturePath;
                form.pictureName = this.GetPictureName();
                form.pictureSuffix = this.GetPictureSuffix();
                form.pictureID = this.GetPictureID();
                form.showType = "preview";
                form.ShowDialog();
            }
            catch (Exception ee)
            {
                MsgBox.ShowError(ee);
            }
        }
        /// <summary>
        /// 选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_picture_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (e.FocusedRowHandle >= 0)
                {
                    DataRow dr = this.currentPicture_DataTable.Rows[this.gv_picture.GetFocusedDataSourceRowIndex()];
                    this.currentPictureID = Convert.ToInt32(dr["PictureID"]);
                    this.currentPictureName = dr["PictureName"].ToString();
                    this.currentSuffix = dr["PictureSuffix"].ToString();
                    this.picturePath = dr["PicturePath"].ToString();
                    this.pictureType = dr["Type"].ToString();
                }
                else
                {
                    this.currentPictureID = null;
                    this.currentPictureName = "";
                    this.currentSuffix = "";
                    this.picturePath = "";
                    this.pictureType = "";
                }
            }
            catch (Exception ee)
            {
                MsgBox.ShowError(ee);
            }
        }
        /// <summary>
        /// 单击图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rItem_picture_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gv_picture.GetFocusedDataSourceRowIndex() >= 0)
                {
                    DataRow dr = this.currentPicture_DataTable.Rows[this.gv_picture.GetFocusedDataSourceRowIndex()];
                    if (dr["Type"].ToString() != "")
                    {
                        this.toolTipController1.ShowHint(dr["Type"].ToString(), Cursor.Position);
                    }
                }
            }
            catch (Exception ee)
            {
                
            }
        }
        #endregion 
    }
}
