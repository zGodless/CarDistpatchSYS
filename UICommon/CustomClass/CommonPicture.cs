using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DS.Model.Base;

namespace DS.MSClient.UICommon
{
    public class CommonPicture : ModelBase
    {
        /// <summary>
        /// 图片ID
        /// </summary>
        public int PictureID { get; set; }

        /// <summary>
        /// 图片名
        /// </summary>
        public string PictureName { get; set; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string PicturePath { get; set; }

        /// <summary>
        /// 图片后缀
        /// </summary>
        public string PictureSuffix { get; set; }

        /// <summary>
        /// 图片类型
        /// </summary>
        public string Type { get; set; }

    }

}
