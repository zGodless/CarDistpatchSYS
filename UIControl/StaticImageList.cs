using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace DS.MSClient.Controls
{
    //use like this.ImageList = StaticImageList.Instance.GlobalImageList 
    //can use designer on this class but wouldn't want to drop it onto a design surface
    [ToolboxItem(false)]
    public partial class StaticImageList : Component
    {
        private ImageList imageList_global;
        public ImageList ImageList_global
        {
            get { return imageList_global; }
            set { imageList_global = value; }
        }
        private IContainer components;
        private static StaticImageList _instance;
        public static StaticImageList Instance
        {
            get
            {
                if (_instance == null) _instance = new StaticImageList();
                return _instance;
            }
        }
        public StaticImageList()
        {
            InitializeComponent();
        }

        public StaticImageList(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
