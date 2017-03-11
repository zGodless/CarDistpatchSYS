using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace DS.MSClient.UICommon.CommonForm
{
    public partial class FormPreviewPicture : FormBase
    {
        #region 初始化
        public FormPreviewPicture()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            this.Load += FormPreviewPicture_Load;
        }

        void FormPreviewPicture_Load(object sender, EventArgs e)
        {
            if (this.showType == "preview")//预览图片
            {
                var url = this.picturePreviewURL ?? "";
                _imgurl = Path.Combine(Application.StartupPath, "Temp", "CarCondition", url.Replace("/", @"\") + @"\" + pictureID + "_L." + pictureSuffix);
                var path1 = Path.GetDirectoryName(_imgurl);
                if (path1 != null && !Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                DownImage(Program.FilesWebServiceUrl + "/" + url.Replace(@"\", "/") + "/" + pictureID + "_L." + pictureSuffix, _imgurl, _web);
                try
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile(_imgurl);
                    System.Drawing.Image bmp = new System.Drawing.Bitmap(img);
                    img.Dispose();
                    pictureEdit1.Image = bmp;
                }
                catch
                {
                    // ignored
                }
            }
        }
        #endregion

        #region 属性
        public string picturePreviewURL = null;
        public string pictureName = null;
        public string pictureSuffix = null;
        public int pictureID ;
        public string showType = null;
        private readonly WebClient _web = new WebClient();
        private string _imgurl = "";

        #endregion

        /// <summary>
        ///     下载图片
        /// </summary>
        /// <param name="url">Url地址</param>
        /// <param name="path">保存路径</param>
        /// <param name="web"></param>
        public void DownImage(string url, string path, WebClient web)
        {
            try
            {
                web.DownloadFile(url, path);
            }
            catch
            {
                // ignored
            }
        }
    }
}
