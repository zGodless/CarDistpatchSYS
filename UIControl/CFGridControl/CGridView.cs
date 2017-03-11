using System;

namespace DS.MSClient.UIControl
{
    [System.ComponentModel.DesignerCategory("")]
	public class CGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        #region 自定义字段
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDatetime1;//日期自定义字段,5个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDatetime2;//日期自定义字段,5个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDatetime3;//日期自定义字段,5个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDatetime4;//日期自定义字段,5个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDatetime5;//日期自定义字段,5个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar1;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar2;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar3;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar4;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar5;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar6;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar7;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar8;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar9;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar10;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar11;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar12;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar13;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar14;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar15;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar16;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar17;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar18;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar19;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldVarchar20;//文本自定义字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal1;//数值自定义字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal2;//数值自定义字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal3;//数值自定义字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal4;//数值自定义字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal5;//数值自定义字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal6;//数值自定义字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal7;//数值自定义字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal8;//数值自定义字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal9;//数值自定义字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_CustomFieldDecimal10;//数值自定义字段,10个

        #endregion
        #region 流动字段
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDatetime1;//日期流动字段,5个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDatetime2;//日期流动字段,5个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDatetime3;//日期流动字段,5个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDatetime4;//日期流动字段,5个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDatetime5;//日期流动字段,5个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar1;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar2;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar3;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar4;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar5;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar6;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar7;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar8;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar9;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar10;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar11;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar12;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar13;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar14;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar15;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar16;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar17;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar18;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar19;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldVarchar20;//文本流动字段 ,20个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal1;//数值流动字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal2;//数值流动字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal3;//数值流动字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal4;//数值流动字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal5;//数值流动字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal6;//数值流动字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal7;//数值流动字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal8;//数值流动字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal9;//数值流动字段,10个
        private DevExpress.XtraGrid.Columns.GridColumn gridCol_FlowFieldDecimal10;//数值流动字段,10个
        #endregion

        public CGridView() : this(null) {}
		public CGridView(DevExpress.XtraGrid.GridControl grid) : base(grid) {
		   
             // 初始化自定义日期列
            InitCustomFieldDatetimeColumn();
            // 初始化自定义文本列
            InitCustomFieldVarcharColumn();
            // 初始化自定义数值列
            InitCustomFieldDecimalColumn();

            // 初始化流动日期列
            InitFlowFieldDatetimeColumn();
            // 初始化流动文本列
            InitFlowFieldVarcharColumn();
            // 初始化流动数值列
            InitFlowFieldDecimalColumn(); 


           //添加自定义列到gridview中
            this.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                //自定义日期字段，5个
            this.gridCol_CustomFieldDatetime1,
            this.gridCol_CustomFieldDatetime2,
            this.gridCol_CustomFieldDatetime3,
            this.gridCol_CustomFieldDatetime4,
            this.gridCol_CustomFieldDatetime5,
            //自定义文本字段，20个
            this.gridCol_CustomFieldVarchar1,
            this.gridCol_CustomFieldVarchar2,
            this.gridCol_CustomFieldVarchar3,
            this.gridCol_CustomFieldVarchar4,
            this.gridCol_CustomFieldVarchar5,
            this.gridCol_CustomFieldVarchar6,
            this.gridCol_CustomFieldVarchar7,
            this.gridCol_CustomFieldVarchar8,
            this.gridCol_CustomFieldVarchar9,
            this.gridCol_CustomFieldVarchar10,
            this.gridCol_CustomFieldVarchar11,
            this.gridCol_CustomFieldVarchar12,
            this.gridCol_CustomFieldVarchar13,
            this.gridCol_CustomFieldVarchar14,
            this.gridCol_CustomFieldVarchar15,
            this.gridCol_CustomFieldVarchar16,
            this.gridCol_CustomFieldVarchar17,
            this.gridCol_CustomFieldVarchar18,
            this.gridCol_CustomFieldVarchar19,
            this.gridCol_CustomFieldVarchar20, 
            //自定义数值字段,10个
            this.gridCol_CustomFieldDecimal1,
            this.gridCol_CustomFieldDecimal2,
            this.gridCol_CustomFieldDecimal3,
            this.gridCol_CustomFieldDecimal4,
            this.gridCol_CustomFieldDecimal5,
            this.gridCol_CustomFieldDecimal6,
            this.gridCol_CustomFieldDecimal7,
            this.gridCol_CustomFieldDecimal8,
            this.gridCol_CustomFieldDecimal9,
            this.gridCol_CustomFieldDecimal10 ,
            //=========流动字段=========
             //流动日期字段，5个
            this.gridCol_FlowFieldDatetime1,
            this.gridCol_FlowFieldDatetime2,
            this.gridCol_FlowFieldDatetime3,
            this.gridCol_FlowFieldDatetime4,
            this.gridCol_FlowFieldDatetime5,
            //流动文本字段，20个
            this.gridCol_FlowFieldVarchar1,
            this.gridCol_FlowFieldVarchar2,
            this.gridCol_FlowFieldVarchar3,
            this.gridCol_FlowFieldVarchar4,
            this.gridCol_FlowFieldVarchar5,
            this.gridCol_FlowFieldVarchar6,
            this.gridCol_FlowFieldVarchar7,
            this.gridCol_FlowFieldVarchar8,
            this.gridCol_FlowFieldVarchar9,
            this.gridCol_FlowFieldVarchar10,
            this.gridCol_FlowFieldVarchar11,
            this.gridCol_FlowFieldVarchar12,
            this.gridCol_FlowFieldVarchar13,
            this.gridCol_FlowFieldVarchar14,
            this.gridCol_FlowFieldVarchar15,
            this.gridCol_FlowFieldVarchar16,
            this.gridCol_FlowFieldVarchar17,
            this.gridCol_FlowFieldVarchar18,
            this.gridCol_FlowFieldVarchar19,
            this.gridCol_FlowFieldVarchar20, 
            //流动数值字段,10个
            this.gridCol_FlowFieldDecimal1,
            this.gridCol_FlowFieldDecimal2,
            this.gridCol_FlowFieldDecimal3,
            this.gridCol_FlowFieldDecimal4,
            this.gridCol_FlowFieldDecimal5,
            this.gridCol_FlowFieldDecimal6,
            this.gridCol_FlowFieldDecimal7,
            this.gridCol_FlowFieldDecimal8,
            this.gridCol_FlowFieldDecimal9,
            this.gridCol_FlowFieldDecimal10  

          
            }); 
		}
        protected override string ViewName { get { return "CGridView"; } }


        public override int FixedLineWidth
        {
            get
            {
                int result = base.FixedLineWidth;
                if (IsColumnPainting)
                    result -= 1;
                return result;
            }
            set
            {
                base.FixedLineWidth = value;
            }
        }

        private bool _IsColumnPainting;
        public bool IsColumnPainting
        {
            get { return _IsColumnPainting; }
            set { _IsColumnPainting = value; }
        }

        #region 自定义列
        /// <summary>
        /// 初始化自定义日期列
        /// </summary>
        private void InitCustomFieldDatetimeColumn()
        {
            // 初始化日期自定义字段，5个
            this.gridCol_CustomFieldDatetime1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDatetime2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDatetime3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDatetime4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDatetime5 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_CustomFieldDatetime1.Name = "gridCol_CustomFieldDatetime1";
            this.gridCol_CustomFieldDatetime1.FieldName = "SelfDatetime1";
            this.gridCol_CustomFieldDatetime1.Caption = "自定义日期1";
            this.gridCol_CustomFieldDatetime1.Visible = false;
            this.gridCol_CustomFieldDatetime1.Tag = "Choose";

            this.gridCol_CustomFieldDatetime2.Name = "gridCol_CustomFieldDatetime2";
            this.gridCol_CustomFieldDatetime2.FieldName = "SelfDatetime2";
            this.gridCol_CustomFieldDatetime2.Caption = "自定义日期2";
            this.gridCol_CustomFieldDatetime2.Visible = false;
            this.gridCol_CustomFieldDatetime2.Tag = "Choose";

            this.gridCol_CustomFieldDatetime3.Name = "gridCol_CustomFieldDatetime3";
            this.gridCol_CustomFieldDatetime3.FieldName = "SelfDatetime3";
            this.gridCol_CustomFieldDatetime3.Caption = "自定义日期3";
            this.gridCol_CustomFieldDatetime3.Visible = false;
            this.gridCol_CustomFieldDatetime3.Tag = "Choose";

            this.gridCol_CustomFieldDatetime4.Name = "gridCol_CustomFieldDatetime4";
            this.gridCol_CustomFieldDatetime4.FieldName = "SelfDatetime4";
            this.gridCol_CustomFieldDatetime4.Caption = "自定义日期4";
            this.gridCol_CustomFieldDatetime4.Visible = false;
            this.gridCol_CustomFieldDatetime4.Tag = "Choose";

            this.gridCol_CustomFieldDatetime5.Name = "gridCol_CustomFieldDatetime5";
            this.gridCol_CustomFieldDatetime5.FieldName = "SelfDatetime5";
            this.gridCol_CustomFieldDatetime5.Caption = "自定义日期5";
            this.gridCol_CustomFieldDatetime5.Visible = false;
            this.gridCol_CustomFieldDatetime5.Tag = "Choose";
        }
        /// <summary>
        /// 初始化自定义文本列
        /// </summary>
        private void InitCustomFieldVarcharColumn()
        { //初始化文本自定义字段，20个
            this.gridCol_CustomFieldVarchar1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldVarchar20 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_CustomFieldVarchar1.Name = "gridCol_CustomFieldVarchar1";
            this.gridCol_CustomFieldVarchar1.FieldName = "SelfVarchar1";
            this.gridCol_CustomFieldVarchar1.Caption = "自定义文本1";
            this.gridCol_CustomFieldVarchar1.Visible = false;
            this.gridCol_CustomFieldVarchar1.Tag = "Choose";

            this.gridCol_CustomFieldVarchar2.Name = "gridCol_CustomFieldVarchar2";
            this.gridCol_CustomFieldVarchar2.FieldName = "SelfVarchar2";
            this.gridCol_CustomFieldVarchar2.Caption = "自定义文本2";
            this.gridCol_CustomFieldVarchar2.Visible = false;
            this.gridCol_CustomFieldVarchar2.Tag = "Choose";

            this.gridCol_CustomFieldVarchar3.Name = "gridCol_CustomFieldVarchar3";
            this.gridCol_CustomFieldVarchar3.FieldName = "SelfVarchar3";
            this.gridCol_CustomFieldVarchar3.Caption = "自定义文本3";
            this.gridCol_CustomFieldVarchar3.Visible = false;
            this.gridCol_CustomFieldVarchar3.Tag = "Choose";

            this.gridCol_CustomFieldVarchar4.Name = "gridCol_CustomFieldVarchar4";
            this.gridCol_CustomFieldVarchar4.FieldName = "SelfVarchar4";
            this.gridCol_CustomFieldVarchar4.Caption = "自定义文本4";
            this.gridCol_CustomFieldVarchar4.Visible = false;
            this.gridCol_CustomFieldVarchar4.Tag = "Choose";

            this.gridCol_CustomFieldVarchar5.Name = "gridCol_CustomFieldVarchar5";
            this.gridCol_CustomFieldVarchar5.FieldName = "SelfVarchar5";
            this.gridCol_CustomFieldVarchar5.Caption = "自定义文本5";
            this.gridCol_CustomFieldVarchar5.Visible = false;
            this.gridCol_CustomFieldVarchar5.Tag = "Choose";

            this.gridCol_CustomFieldVarchar6.Name = "gridCol_CustomFieldVarchar6";
            this.gridCol_CustomFieldVarchar6.FieldName = "SelfVarchar6";
            this.gridCol_CustomFieldVarchar6.Caption = "自定义文本6";
            this.gridCol_CustomFieldVarchar6.Visible = false;
            this.gridCol_CustomFieldVarchar6.Tag = "Choose";


            this.gridCol_CustomFieldVarchar7.Name = "gridCol_CustomFieldVarchar7";
            this.gridCol_CustomFieldVarchar7.FieldName = "SelfVarchar7";
            this.gridCol_CustomFieldVarchar7.Caption = "自定义文本7";
            this.gridCol_CustomFieldVarchar7.Visible = false;
            this.gridCol_CustomFieldVarchar7.Tag = "Choose";

            this.gridCol_CustomFieldVarchar8.Name = "gridCol_CustomFieldVarchar8";
            this.gridCol_CustomFieldVarchar8.FieldName = "SelfVarchar8";
            this.gridCol_CustomFieldVarchar8.Caption = "自定义文本8";
            this.gridCol_CustomFieldVarchar8.Visible = false;
            this.gridCol_CustomFieldVarchar8.Tag = "Choose";

            this.gridCol_CustomFieldVarchar9.Name = "gridCol_CustomFieldVarchar9";
            this.gridCol_CustomFieldVarchar9.FieldName = "SelfVarchar9";
            this.gridCol_CustomFieldVarchar9.Caption = "自定义文本9";
            this.gridCol_CustomFieldVarchar9.Visible = false;
            this.gridCol_CustomFieldVarchar9.Tag = "Choose";

            this.gridCol_CustomFieldVarchar10.Name = "gridCol_CustomFieldVarchar10";
            this.gridCol_CustomFieldVarchar10.FieldName = "SelfVarchar10";
            this.gridCol_CustomFieldVarchar10.Caption = "自定义文本10";
            this.gridCol_CustomFieldVarchar10.Visible = false;
            this.gridCol_CustomFieldVarchar10.Tag = "Choose";

            this.gridCol_CustomFieldVarchar11.Name = "gridCol_CustomFieldVarchar11";
            this.gridCol_CustomFieldVarchar11.FieldName = "SelfVarchar11";
            this.gridCol_CustomFieldVarchar11.Caption = "自定义文本11";
            this.gridCol_CustomFieldVarchar11.Visible = false;
            this.gridCol_CustomFieldVarchar11.Tag = "Choose";

            this.gridCol_CustomFieldVarchar12.Name = "gridCol_CustomFieldVarchar12";
            this.gridCol_CustomFieldVarchar12.FieldName = "SelfVarchar12";
            this.gridCol_CustomFieldVarchar12.Caption = "自定义文本12";
            this.gridCol_CustomFieldVarchar12.Visible = false;
            this.gridCol_CustomFieldVarchar12.Tag = "Choose";

            this.gridCol_CustomFieldVarchar13.Name = "gridCol_CustomFieldVarchar13";
            this.gridCol_CustomFieldVarchar13.FieldName = "SelfVarchar13";
            this.gridCol_CustomFieldVarchar13.Caption = "自定义文本13";
            this.gridCol_CustomFieldVarchar13.Visible = false;
            this.gridCol_CustomFieldVarchar13.Tag = "Choose";

            this.gridCol_CustomFieldVarchar14.Name = "gridCol_CustomFieldVarchar14";
            this.gridCol_CustomFieldVarchar14.FieldName = "SelfVarchar14";
            this.gridCol_CustomFieldVarchar14.Caption = "自定义文本14";
            this.gridCol_CustomFieldVarchar14.Visible = false;
            this.gridCol_CustomFieldVarchar14.Tag = "Choose";

            this.gridCol_CustomFieldVarchar15.Name = "gridCol_CustomFieldVarchar15";
            this.gridCol_CustomFieldVarchar15.FieldName = "SelfVarchar15";
            this.gridCol_CustomFieldVarchar15.Caption = "自定义文本15";
            this.gridCol_CustomFieldVarchar15.Visible = false;
            this.gridCol_CustomFieldVarchar15.Tag = "Choose";

            this.gridCol_CustomFieldVarchar16.Name = "gridCol_CustomFieldVarchar16";
            this.gridCol_CustomFieldVarchar16.FieldName = "SelfVarchar16";
            this.gridCol_CustomFieldVarchar16.Caption = "自定义文本16";
            this.gridCol_CustomFieldVarchar16.Visible = false;
            this.gridCol_CustomFieldVarchar16.Tag = "Choose";

            this.gridCol_CustomFieldVarchar17.Name = "gridCol_CustomFieldVarchar17";
            this.gridCol_CustomFieldVarchar17.FieldName = "SelfVarchar17";
            this.gridCol_CustomFieldVarchar17.Caption = "自定义文本17";
            this.gridCol_CustomFieldVarchar17.Visible = false;
            this.gridCol_CustomFieldVarchar17.Tag = "Choose";

            this.gridCol_CustomFieldVarchar18.Name = "gridCol_CustomFieldVarchar18";
            this.gridCol_CustomFieldVarchar18.FieldName = "SelfVarchar18";
            this.gridCol_CustomFieldVarchar18.Caption = "自定义文本18";
            this.gridCol_CustomFieldVarchar18.Visible = false;
            this.gridCol_CustomFieldVarchar18.Tag = "Choose";

            this.gridCol_CustomFieldVarchar19.Name = "gridCol_CustomFieldVarchar19";
            this.gridCol_CustomFieldVarchar19.FieldName = "SelfVarchar19";
            this.gridCol_CustomFieldVarchar19.Caption = "自定义文本19";
            this.gridCol_CustomFieldVarchar19.Visible = false;
            this.gridCol_CustomFieldVarchar19.Tag = "Choose";

            this.gridCol_CustomFieldVarchar20.Name = "gridCol_CustomFieldVarchar20";
            this.gridCol_CustomFieldVarchar20.FieldName = "SelfVarchar20";
            this.gridCol_CustomFieldVarchar20.Caption = "自定义文本20";
            this.gridCol_CustomFieldVarchar20.Visible = false;
            this.gridCol_CustomFieldVarchar20.Tag = "Choose";
             
        }
        /// <summary>
        /// 初始化自定义数值列
        /// </summary>
        private void InitCustomFieldDecimalColumn()
        { //初始化数值自定义字段，10个
            this.gridCol_CustomFieldDecimal1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_CustomFieldDecimal10 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_CustomFieldDecimal1.Name = "gridCol_CustomFieldDecimal1";
            this.gridCol_CustomFieldDecimal1.FieldName = "SelfDecimal1";
            this.gridCol_CustomFieldDecimal1.Caption = "自定义数值1";
            this.gridCol_CustomFieldDecimal1.Visible = false;
            this.gridCol_CustomFieldDecimal1.Tag = "Choose";

            this.gridCol_CustomFieldDecimal2.Name = "gridCol_CustomFieldDecimal2";
            this.gridCol_CustomFieldDecimal2.FieldName = "SelfDecimal2";
            this.gridCol_CustomFieldDecimal2.Caption = "自定义数值2";
            this.gridCol_CustomFieldDecimal2.Visible = false;
            this.gridCol_CustomFieldDecimal2.Tag = "Choose";

            this.gridCol_CustomFieldDecimal3.Name = "gridCol_CustomFieldDecimal3";
            this.gridCol_CustomFieldDecimal3.FieldName = "SelfDecimal3";
            this.gridCol_CustomFieldDecimal3.Caption = "自定义数值3";
            this.gridCol_CustomFieldDecimal3.Visible = false;
            this.gridCol_CustomFieldDecimal3.Tag = "Choose";

            this.gridCol_CustomFieldDecimal4.Name = "gridCol_CustomFieldDecimal4";
            this.gridCol_CustomFieldDecimal4.FieldName = "SelfDecimal4";
            this.gridCol_CustomFieldDecimal4.Caption = "自定义数值4";
            this.gridCol_CustomFieldDecimal4.Visible = false;
            this.gridCol_CustomFieldDecimal4.Tag = "Choose";

            this.gridCol_CustomFieldDecimal5.Name = "gridCol_CustomFieldDecimal5";
            this.gridCol_CustomFieldDecimal5.FieldName = "SelfDecimal5";
            this.gridCol_CustomFieldDecimal5.Caption = "自定义数值5";
            this.gridCol_CustomFieldDecimal5.Visible = false;
            this.gridCol_CustomFieldDecimal5.Tag = "Choose";

            this.gridCol_CustomFieldDecimal6.Name = "gridCol_CustomFieldDecimal6";
            this.gridCol_CustomFieldDecimal6.FieldName = "SelfDecimal6";
            this.gridCol_CustomFieldDecimal6.Caption = "自定义数值6";
            this.gridCol_CustomFieldDecimal6.Visible = false;
            this.gridCol_CustomFieldDecimal6.Tag = "Choose";

            this.gridCol_CustomFieldDecimal7.Name = "gridCol_CustomFieldDecimal7";
            this.gridCol_CustomFieldDecimal7.FieldName = "SelfDecimal7";
            this.gridCol_CustomFieldDecimal7.Caption = "自定义数值7";
            this.gridCol_CustomFieldDecimal7.Visible = false;
            this.gridCol_CustomFieldDecimal7.Tag = "Choose";

            this.gridCol_CustomFieldDecimal8.Name = "gridCol_CustomFieldDecimal8";
            this.gridCol_CustomFieldDecimal8.FieldName = "SelfDecimal8";
            this.gridCol_CustomFieldDecimal8.Caption = "自定义数值8";
            this.gridCol_CustomFieldDecimal8.Visible = false;
            this.gridCol_CustomFieldDecimal8.Tag = "Choose";

            this.gridCol_CustomFieldDecimal9.Name = "gridCol_CustomFieldDecimal9";
            this.gridCol_CustomFieldDecimal9.FieldName = "SelfDecimal9";
            this.gridCol_CustomFieldDecimal9.Caption = "自定义数值9";
            this.gridCol_CustomFieldDecimal9.Visible = false;
            this.gridCol_CustomFieldDecimal9.Tag = "Choose";

            this.gridCol_CustomFieldDecimal10.Name = "gridCol_CustomFieldDecimal10";
            this.gridCol_CustomFieldDecimal10.FieldName = "SelfDecimal10";
            this.gridCol_CustomFieldDecimal10.Caption = "自定义数值10";
            this.gridCol_CustomFieldDecimal10.Visible = false;
            this.gridCol_CustomFieldDecimal10.Tag = "Choose";
             
        }
        #endregion


        #region 流动列
        /// <summary>
        /// 初始化自定义日期列
        /// </summary>
        private void InitFlowFieldDatetimeColumn()
        {
            // 初始化日期自定义字段，5个
            this.gridCol_FlowFieldDatetime1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDatetime2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDatetime3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDatetime4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDatetime5 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_FlowFieldDatetime1.Name = "gridCol_FlowFieldDatetime1";
            this.gridCol_FlowFieldDatetime1.FieldName = "FlowDatetime1";
            this.gridCol_FlowFieldDatetime1.Caption = "流动日期1";
            this.gridCol_FlowFieldDatetime1.Visible = false;
            this.gridCol_FlowFieldDatetime1.Tag = "Choose";

            this.gridCol_FlowFieldDatetime2.Name = "gridCol_FlowFieldDatetime2";
            this.gridCol_FlowFieldDatetime2.FieldName = "FlowDatetime2";
            this.gridCol_FlowFieldDatetime2.Caption = "流动日期2";
            this.gridCol_FlowFieldDatetime2.Visible = false;
            this.gridCol_FlowFieldDatetime2.Tag = "Choose";

            this.gridCol_FlowFieldDatetime3.Name = "gridCol_FlowFieldDatetime3";
            this.gridCol_FlowFieldDatetime3.FieldName = "FlowDatetime3";
            this.gridCol_FlowFieldDatetime3.Caption = "流动日期3";
            this.gridCol_FlowFieldDatetime3.Visible = false;
            this.gridCol_FlowFieldDatetime3.Tag = "Choose";

            this.gridCol_FlowFieldDatetime4.Name = "gridCol_FlowFieldDatetime4";
            this.gridCol_FlowFieldDatetime4.FieldName = "FlowDatetime4";
            this.gridCol_FlowFieldDatetime4.Caption = "流动日期4";
            this.gridCol_FlowFieldDatetime4.Visible = false;
            this.gridCol_FlowFieldDatetime4.Tag = "Choose";

            this.gridCol_FlowFieldDatetime5.Name = "gridCol_FlowFieldDatetime5";
            this.gridCol_FlowFieldDatetime5.FieldName = "FlowDatetime5";
            this.gridCol_FlowFieldDatetime5.Caption = "流动日期5";
            this.gridCol_FlowFieldDatetime5.Visible = false;
            this.gridCol_FlowFieldDatetime5.Tag = "Choose";
        }
        /// <summary>
        /// 初始化自定义文本列
        /// </summary>
        private void InitFlowFieldVarcharColumn()
        { //初始化文本自定义字段，20个
            this.gridCol_FlowFieldVarchar1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldVarchar20 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_FlowFieldVarchar1.Name = "gridCol_FlowFieldVarchar1";
            this.gridCol_FlowFieldVarchar1.FieldName = "FlowVarchar1";
            this.gridCol_FlowFieldVarchar1.Caption = "流动文本1";
            this.gridCol_FlowFieldVarchar1.Visible = false;
            this.gridCol_FlowFieldVarchar1.Tag = "Choose";

            this.gridCol_FlowFieldVarchar2.Name = "gridCol_FlowFieldVarchar2";
            this.gridCol_FlowFieldVarchar2.FieldName = "FlowVarchar2";
            this.gridCol_FlowFieldVarchar2.Caption = "流动文本2";
            this.gridCol_FlowFieldVarchar2.Visible = false;
            this.gridCol_FlowFieldVarchar2.Tag = "Choose";

            this.gridCol_FlowFieldVarchar3.Name = "gridCol_FlowFieldVarchar3";
            this.gridCol_FlowFieldVarchar3.FieldName = "FlowVarchar3";
            this.gridCol_FlowFieldVarchar3.Caption = "流动文本3";
            this.gridCol_FlowFieldVarchar3.Visible = false;
            this.gridCol_FlowFieldVarchar3.Tag = "Choose";

            this.gridCol_FlowFieldVarchar4.Name = "gridCol_FlowFieldVarchar4";
            this.gridCol_FlowFieldVarchar4.FieldName = "FlowVarchar4";
            this.gridCol_FlowFieldVarchar4.Caption = "流动文本4";
            this.gridCol_FlowFieldVarchar4.Visible = false;
            this.gridCol_FlowFieldVarchar4.Tag = "Choose";

            this.gridCol_FlowFieldVarchar5.Name = "gridCol_FlowFieldVarchar5";
            this.gridCol_FlowFieldVarchar5.FieldName = "FlowVarchar5";
            this.gridCol_FlowFieldVarchar5.Caption = "流动文本5";
            this.gridCol_FlowFieldVarchar5.Visible = false;
            this.gridCol_FlowFieldVarchar5.Tag = "Choose";

            this.gridCol_FlowFieldVarchar6.Name = "gridCol_FlowFieldVarchar6";
            this.gridCol_FlowFieldVarchar6.FieldName = "FlowVarchar6";
            this.gridCol_FlowFieldVarchar6.Caption = "流动文本6";
            this.gridCol_FlowFieldVarchar6.Visible = false;
            this.gridCol_FlowFieldVarchar6.Tag = "Choose";

            this.gridCol_FlowFieldVarchar7.Name = "gridCol_FlowFieldVarchar7";
            this.gridCol_FlowFieldVarchar7.FieldName = "FlowVarchar7";
            this.gridCol_FlowFieldVarchar7.Caption = "流动文本7";
            this.gridCol_FlowFieldVarchar7.Visible = false;
            this.gridCol_FlowFieldVarchar7.Tag = "Choose";

            this.gridCol_FlowFieldVarchar8.Name = "gridCol_FlowFieldVarchar8";
            this.gridCol_FlowFieldVarchar8.FieldName = "FlowVarchar8";
            this.gridCol_FlowFieldVarchar8.Caption = "流动文本8";
            this.gridCol_FlowFieldVarchar8.Visible = false;
            this.gridCol_FlowFieldVarchar8.Tag = "Choose";

            this.gridCol_FlowFieldVarchar9.Name = "gridCol_FlowFieldVarchar9";
            this.gridCol_FlowFieldVarchar9.FieldName = "FlowVarchar9";
            this.gridCol_FlowFieldVarchar9.Caption = "流动文本9";
            this.gridCol_FlowFieldVarchar9.Visible = false;
            this.gridCol_FlowFieldVarchar9.Tag = "Choose";

            this.gridCol_FlowFieldVarchar10.Name = "gridCol_FlowFieldVarchar10";
            this.gridCol_FlowFieldVarchar10.FieldName = "FlowVarchar10";
            this.gridCol_FlowFieldVarchar10.Caption = "流动文本10";
            this.gridCol_FlowFieldVarchar10.Visible = false;
            this.gridCol_FlowFieldVarchar10.Tag = "Choose";

            this.gridCol_FlowFieldVarchar11.Name = "gridCol_FlowFieldVarchar11";
            this.gridCol_FlowFieldVarchar11.FieldName = "FlowVarchar11";
            this.gridCol_FlowFieldVarchar11.Caption = "流动文本11";
            this.gridCol_FlowFieldVarchar11.Visible = false;
            this.gridCol_FlowFieldVarchar11.Tag = "Choose";

            this.gridCol_FlowFieldVarchar12.Name = "gridCol_FlowFieldVarchar12";
            this.gridCol_FlowFieldVarchar12.FieldName = "FlowVarchar12";
            this.gridCol_FlowFieldVarchar12.Caption = "流动文本12";
            this.gridCol_FlowFieldVarchar12.Visible = false;
            this.gridCol_FlowFieldVarchar12.Tag = "Choose";

            this.gridCol_FlowFieldVarchar13.Name = "gridCol_FlowFieldVarchar13";
            this.gridCol_FlowFieldVarchar13.FieldName = "FlowVarchar13";
            this.gridCol_FlowFieldVarchar13.Caption = "流动文本13";
            this.gridCol_FlowFieldVarchar13.Visible = false;
            this.gridCol_FlowFieldVarchar13.Tag = "Choose";

            this.gridCol_FlowFieldVarchar14.Name = "gridCol_FlowFieldVarchar14";
            this.gridCol_FlowFieldVarchar14.FieldName = "FlowVarchar14";
            this.gridCol_FlowFieldVarchar14.Caption = "流动文本14";
            this.gridCol_FlowFieldVarchar14.Visible = false;
            this.gridCol_FlowFieldVarchar14.Tag = "Choose";

            this.gridCol_FlowFieldVarchar15.Name = "gridCol_FlowFieldVarchar15";
            this.gridCol_FlowFieldVarchar15.FieldName = "FlowVarchar15";
            this.gridCol_FlowFieldVarchar15.Caption = "流动文本15";
            this.gridCol_FlowFieldVarchar15.Visible = false;
            this.gridCol_FlowFieldVarchar15.Tag = "Choose";

            this.gridCol_FlowFieldVarchar16.Name = "gridCol_FlowFieldVarchar16";
            this.gridCol_FlowFieldVarchar16.FieldName = "FlowVarchar16";
            this.gridCol_FlowFieldVarchar16.Caption = "流动文本16";
            this.gridCol_FlowFieldVarchar16.Visible = false;
            this.gridCol_FlowFieldVarchar16.Tag = "Choose";

            this.gridCol_FlowFieldVarchar17.Name = "gridCol_FlowFieldVarchar17";
            this.gridCol_FlowFieldVarchar17.FieldName = "FlowVarchar17";
            this.gridCol_FlowFieldVarchar17.Caption = "流动文本17";
            this.gridCol_FlowFieldVarchar17.Visible = false;
            this.gridCol_FlowFieldVarchar17.Tag = "Choose";

            this.gridCol_FlowFieldVarchar18.Name = "gridCol_FlowFieldVarchar18";
            this.gridCol_FlowFieldVarchar18.FieldName = "FlowVarchar18";
            this.gridCol_FlowFieldVarchar18.Caption = "流动文本18";
            this.gridCol_FlowFieldVarchar18.Visible = false;
            this.gridCol_FlowFieldVarchar18.Tag = "Choose";

            this.gridCol_FlowFieldVarchar19.Name = "gridCol_FlowFieldVarchar19";
            this.gridCol_FlowFieldVarchar19.FieldName = "FlowVarchar19";
            this.gridCol_FlowFieldVarchar19.Caption = "流动文本19";
            this.gridCol_FlowFieldVarchar19.Visible = false;
            this.gridCol_FlowFieldVarchar19.Tag = "Choose";

            this.gridCol_FlowFieldVarchar20.Name = "gridCol_FlowFieldVarchar20";
            this.gridCol_FlowFieldVarchar20.FieldName = "FlowVarchar20";
            this.gridCol_FlowFieldVarchar20.Caption = "流动文本20";
            this.gridCol_FlowFieldVarchar20.Visible = false;
            this.gridCol_FlowFieldVarchar20.Tag = "Choose";

        }
        /// <summary>
        /// 初始化自定义数值列
        /// </summary>
        private void InitFlowFieldDecimalColumn()
        { //初始化数值自定义字段，10个
            this.gridCol_FlowFieldDecimal1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCol_FlowFieldDecimal10 = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridCol_FlowFieldDecimal1.Name = "gridCol_FlowFieldDecimal1";
            this.gridCol_FlowFieldDecimal1.FieldName = "FlowDecimal1";
            this.gridCol_FlowFieldDecimal1.Caption = "流动数值1";
            this.gridCol_FlowFieldDecimal1.Visible = false;
            this.gridCol_FlowFieldDecimal1.Tag = "Choose";

            this.gridCol_FlowFieldDecimal2.Name = "gridCol_FlowFieldDecimal2";
            this.gridCol_FlowFieldDecimal2.FieldName = "FlowDecimal2";
            this.gridCol_FlowFieldDecimal2.Caption = "流动数值2";
            this.gridCol_FlowFieldDecimal2.Visible = false;
            this.gridCol_FlowFieldDecimal2.Tag = "Choose";

            this.gridCol_FlowFieldDecimal3.Name = "gridCol_FlowFieldDecimal3";
            this.gridCol_FlowFieldDecimal3.FieldName = "FlowDecimal3";
            this.gridCol_FlowFieldDecimal3.Caption = "流动数值3";
            this.gridCol_FlowFieldDecimal3.Visible = false;
            this.gridCol_FlowFieldDecimal3.Tag = "Choose";

            this.gridCol_FlowFieldDecimal4.Name = "gridCol_FlowFieldDecimal4";
            this.gridCol_FlowFieldDecimal4.FieldName = "FlowDecimal4";
            this.gridCol_FlowFieldDecimal4.Caption = "流动数值4";
            this.gridCol_FlowFieldDecimal4.Visible = false;
            this.gridCol_FlowFieldDecimal4.Tag = "Choose";

            this.gridCol_FlowFieldDecimal5.Name = "gridCol_FlowFieldDecimal5";
            this.gridCol_FlowFieldDecimal5.FieldName = "FlowDecimal5";
            this.gridCol_FlowFieldDecimal5.Caption = "流动数值5";
            this.gridCol_FlowFieldDecimal5.Visible = false;
            this.gridCol_FlowFieldDecimal5.Tag = "Choose";

            this.gridCol_FlowFieldDecimal6.Name = "gridCol_FlowFieldDecimal6";
            this.gridCol_FlowFieldDecimal6.FieldName = "FlowDecimal6";
            this.gridCol_FlowFieldDecimal6.Caption = "流动数值6";
            this.gridCol_FlowFieldDecimal6.Visible = false;
            this.gridCol_FlowFieldDecimal6.Tag = "Choose";

            this.gridCol_FlowFieldDecimal7.Name = "gridCol_FlowFieldDecimal7";
            this.gridCol_FlowFieldDecimal7.FieldName = "FlowDecimal7";
            this.gridCol_FlowFieldDecimal7.Caption = "流动数值7";
            this.gridCol_FlowFieldDecimal7.Visible = false;
            this.gridCol_FlowFieldDecimal7.Tag = "Choose";

            this.gridCol_FlowFieldDecimal8.Name = "gridCol_FlowFieldDecimal8";
            this.gridCol_FlowFieldDecimal8.FieldName = "FlowDecimal8";
            this.gridCol_FlowFieldDecimal8.Caption = "流动数值8";
            this.gridCol_FlowFieldDecimal8.Visible = false;
            this.gridCol_FlowFieldDecimal8.Tag = "Choose";

            this.gridCol_FlowFieldDecimal9.Name = "gridCol_FlowFieldDecimal9";
            this.gridCol_FlowFieldDecimal9.FieldName = "FlowDecimal9";
            this.gridCol_FlowFieldDecimal9.Caption = "流动数值9";
            this.gridCol_FlowFieldDecimal9.Visible = false;
            this.gridCol_FlowFieldDecimal9.Tag = "Choose";

            this.gridCol_FlowFieldDecimal10.Name = "gridCol_FlowFieldDecimal10";
            this.gridCol_FlowFieldDecimal10.FieldName = "FlowDecimal10";
            this.gridCol_FlowFieldDecimal10.Caption = "流动数值10";
            this.gridCol_FlowFieldDecimal10.Visible = false;
            this.gridCol_FlowFieldDecimal10.Tag = "Choose";

        }
        #endregion


    }
}
