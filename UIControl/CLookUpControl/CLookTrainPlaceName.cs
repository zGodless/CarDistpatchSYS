using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DS.MSClient.UICommon;
using DevExpress.XtraEditors.Repository;
using DS.MSClient.UIControl;
using DS.Model;
using DS.Data;

namespace DS.MSClient.UIControl
{
     [ToolboxItem(true)]
    public partial class CLookTrainPlaceName:DevExpress.XtraEditors.ComboBoxEdit
    {
         public CLookTrainPlaceName()
        {
            InitializeComponent();
        }

         public CLookTrainPlaceName(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

         public List<TrainPlace> ListIsValid = null;

        public void BindList(bool getFromCache = true)
        {
            if (getFromCache)
            {
                ListIsValid = (List<TrainPlace>)ClientCache.GetAuto("TrainPlace", () => new TrainPlaceDAO().GetList());
            }
            else
            {
                ListIsValid = (List<TrainPlace>)ClientCache.GetUpdate("TrainPlace", () => new TrainPlaceDAO().GetList());
            }
            foreach (TrainPlace item in ListIsValid)
            {
                Properties.Items.Add(item.TrainPlaceName);
            }
        } 

    }
}
