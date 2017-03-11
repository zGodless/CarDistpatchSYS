using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using DevExpress.XtraCharts;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraBars;

namespace DS.MSClient
{
    public static class ChartServices
    {
        /// <summary>
        /// 绘制图形
        /// </summary>
        /// <param name="control">图表控件</param>
        /// <param name="seriesName">系列名</param>
        /// <param name="type">类型</param>
        /// <param name="dt">数据源</param>
        /// <param name="column1"></param>
        /// <param name="column2"></param>
        public static void DrawChart(DevExpress.XtraCharts.ChartControl control, string seriesName, ViewType type, DataTable dt, string column1, string column2)
        {
            Series series = new Series(seriesName, type);
            DataTable table = dt;
            SeriesPoint point=null;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(table.Rows[i][column2].ToString()))
                {
                    point = new SeriesPoint(table.Rows[i][column1].ToString(), 0);
                }
                else
                {
                    point= new SeriesPoint(table.Rows[i][column1].ToString(), Convert.ToDouble(table.Rows[i][column2].ToString()));
                }

                series.Points.Add(point);
            }
            SideBySideBarSeriesLabel label = series.Label as SideBySideBarSeriesLabel;
            series.LabelsVisibility = DefaultBoolean.True;
            label.Position = BarSeriesLabelPosition.Center;
            BarSeriesView barview = series.View as BarSeriesView;
            barview.BarWidth = 0.3;
            control.Series.Add(series);
            //针对饼图的特殊处理
            if(type==ViewType.Pie)
            {
                //设置显示方式(Argument:显示图例说明，ArgumentAndValues:显示图例内容和数据)
                series.Label.PointOptions.PointView = PointView.ArgumentAndValues;
                //设置数据显示形式(Percent:百分比,Currency:货币类型，数据前添加￥,Scientific:科学计数法)
                series.Label.PointOptions.ValueNumericOptions.Format = NumericFormat.Percent;
                //数据是否保留小数(0：不保留小数位，1保留一位小数，2保留两位小数)
                series.Label.PointOptions.ValueNumericOptions.Precision = 0;

                //数据以百分比显示时只能是Default和None
                ((PieSeriesLabel)series.Label).ResolveOverlappingMode =ResolveOverlappingMode.Default;
            }
        }

        /// <summary>
        /// 设置图表标题
        /// </summary>
        /// <param name="control">图表控件</param>
        /// /// <param name="isVisible">标题是否可见</param>
        /// <param name="text">标题文本</param>
        /// <param name="isWordWrop">是否换行</param>
        /// <param name="maxLineCount">最大允许行数</param>
        /// <param name="alignment">对齐方式</param>
        /// <param name="dock">位置</param>
        /// <param name="isAntialiasing">是否允许设置外观</param>
        /// <param name="font">字体</param>
        /// <param name="textColor">文本颜色</param>
        /// <param name="indent">字体缩进值</param>
        public static void SetChartTitle(DevExpress.XtraCharts.ChartControl control, bool isVisible, String text, bool isWordWrop, int maxLineCount, StringAlignment alignment, ChartTitleDockStyle dock, bool isAntialiasing, Font font, Color textColor, int indent)
        {
            //设置标题
            ChartTitle title = new ChartTitle();
            title.Visible = isVisible;
            //显示文本 
            title.Text = text;
            //是否允许换行
            title.WordWrap = isWordWrop;
            //最大允许行数
            title.MaxLineCount = maxLineCount;
            //对齐方式
            title.Alignment = alignment;
            //位置
            title.Dock = dock;
            //是否允许设置外观
            title.Antialiasing = isAntialiasing;
            //字体
            title.Font = font;
            //字体颜色
            title.TextColor = textColor;
            //缩进值
            title.Indent = indent;
            control.Titles.Add(title);
        }


        /// <summary>
        /// 为X轴添加标题
        /// </summary>
        /// <param name="control">图形控件</param>
        /// <param name="isVisible">标题是否可见</param>
        /// <param name="aligment">对齐方式</param>
        /// <param name="text">标题显示文本</param>
        /// <param name="color">标题字体颜色</param>
        /// <param name="isAntialiasing">是否允许设置外观</param>
        /// <param name="font">字体</param>
        public static void SetAxisX(DevExpress.XtraCharts.ChartControl control, bool isVisible, StringAlignment aligment, string text, Color color, bool isAntialiasing, Font font)
        {
            XYDiagram xydiagram = (XYDiagram)control.Diagram;
            xydiagram.AxisX.Title.Visible = isVisible;
            xydiagram.AxisX.Title.Alignment = aligment;
            xydiagram.AxisX.Title.Text = text;
            xydiagram.AxisX.Title.TextColor = color;
            xydiagram.AxisX.Title.Antialiasing = isAntialiasing;
            xydiagram.AxisX.Title.Font = font;
        }

        /// <summary>
        /// 为X轴添加标题
        /// </summary>
        /// <param name="control">图形控件</param>
        /// <param name="isVisible">标题是否可见</param>
        /// <param name="aligment">对齐方式</param>
        /// <param name="text">标题显示文本</param>
        /// <param name="color">标题字体颜色</param>
        /// <param name="isAntialiasing">是否允许设置外观</param>
        /// <param name="font">字体</param>
        public static void SetAxisY(DevExpress.XtraCharts.ChartControl control, bool isVisible, StringAlignment aligment, string text, Color color, bool isAntialiasing, Font font)
        {
            XYDiagram xydiagram = (XYDiagram)control.Diagram;
            xydiagram.AxisY.Title.Visible = isVisible;
            xydiagram.AxisY.Title.Alignment = aligment;
            xydiagram.AxisY.Title.Text = text;
            xydiagram.AxisY.Title.TextColor = color;
            xydiagram.AxisY.Title.Antialiasing = isAntialiasing;
            xydiagram.AxisY.Title.Font = font;
        }
    }
}