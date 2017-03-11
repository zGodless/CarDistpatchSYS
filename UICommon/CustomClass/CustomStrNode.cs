using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.XtraTreeList;
using NoHeaderXtraTabControl;

namespace DS.MSClient.UICommon
{
    [Serializable]
    public class CustomStrNode : EntityBase
    {
        private string fid;
        private string name;
        private string type;
        private string formname;
        private string formtext;
        private string formtag;
        private bool formissaved=true;
        private int formrecordid;

       
        private int array;

        private string pid;

        /// <summary>
        /// 节点编号
        /// </summary>
        public string Fid
        {
            get { return fid; }
            set { fid = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type
        {
			get { return type; }
			set { type = value; }
        }
        /// <summary>
        /// 窗体名称
        /// </summary>
        public string formText
        {
            get { return formtext; }
            set { formtext = value; }
        }
        /// <summary>
        /// 窗体类名称
        /// </summary>
        public string formName
        {
            get { return formname; }
            set { formname = value; }
        }
        /// <summary>
        /// 窗体是否已经保存
        /// </summary>
        public bool formIsSaved
        {
            get { return formissaved; }
            set { formissaved = value; }
        }
        /// <summary>
        /// 窗体当前编辑记录的id
        /// </summary>
        public int formRecordID
        {
            get { return formrecordid; }
            set { formrecordid = value; }
        }
        /// <summary>
        /// 窗体标签
        /// </summary>
        public string formTag
        {
            get { return formtag; }
            set { formtag = value; }
        }
        /// <summary>
        /// 节点排序
        /// </summary>
        public int Array
        {
            get { return array; }
            set { array = value; }
        }
        /// <summary>
        /// 父id
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        public bool isForm{ set; get; }//是否编辑窗体
        public string guid { set; get; } //窗体编号

        public DateTime OpenTime { set; get; } 
    }
}
