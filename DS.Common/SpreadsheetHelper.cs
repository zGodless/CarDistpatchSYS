using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.Spreadsheet;
using QuickFrame.Common.Converter;

namespace DS.Common
{
    public static class SpreadsheetHelper
    {
        public static void SetSheetColumn(Cell model, string Value)
        {
            model.Value = Value;
            model.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            model.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            model.Alignment.WrapText = true;
            model.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
        }
        /// <summary>
        /// 返回列单元格横轴编号
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <returns>返回横轴编号</returns>
        public static string ReturnCellXCode(
            int ColumnIndex
            )
        {
            string[] numsChn = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            if (ColumnIndex - 1 <= 25)
            {
                return numsChn[ColumnIndex - 1];
            }
            else if (ColumnIndex - 1 <= 675)
            {
                int firstValue = (ColumnIndex) / 26 - 1;
                int secondValue = (ColumnIndex) % 26 - 1;
                return numsChn[firstValue] + numsChn[secondValue];
            }
            return "";
        }
        public static void SetSheetColumn(Cell model, int Value)
        {
            model.Value = Value;
            model.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            model.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            model.Borders.SetAllBorders(Color.Gray, BorderLineStyle.Thin);
            model.Alignment.WrapText = true;
        }
        public static void SetSheetColumn(Cell model, double Value)
        {
            model.Value = Value;
            model.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            model.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            model.Borders.SetAllBorders(Color.Gray, BorderLineStyle.Thin);
            model.Alignment.WrapText = true;
        }
        public static void SetSheetColumn(Cell model, DateTime Value)
        {
            model.Value = Value;
            model.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            model.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            model.Borders.SetAllBorders(Color.Gray, BorderLineStyle.Thin);
            model.Alignment.WrapText = true;
        }
        public static void SetSheetColumnByFormula(Cell model, string Value)
        {
            model.Formula = Value;
            model.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            model.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            model.Borders.SetAllBorders(Color.Gray, BorderLineStyle.Thin);
            model.Alignment.WrapText = true;
        }

        public static void SetSheetColumnByFormula(Cell model, string Value, string NumberFormat)
        {
            model.Formula = Value;
            model.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            model.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            model.Borders.SetAllBorders(Color.Gray, BorderLineStyle.Thin);
            model.NumberFormat = NumberFormat;
            model.Alignment.WrapText = true;
        }

        public static void SetSheetColumnByLarge(Cell model, string Value)
        {
            model.Value = Value;
            model.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            model.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            model.Borders.SetAllBorders(Color.Gray, BorderLineStyle.Thin);
            model.ColumnWidth = 280;
            model.RowHeight = 10 * 10;
            model.Font.Size = 11;
            model.Alignment.WrapText = true;
        }
        public static void SetSheetColumnByLarge(Cell model, int Value)
        {
            model.Value = Value;
            model.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            model.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            model.Borders.SetAllBorders(Color.Gray, BorderLineStyle.Thin);
            model.RowHeight = 10 * 10;
            model.ColumnWidth = 280;
            model.Alignment.WrapText = true;
            model.Font.Size = 13;
        }
        public static void SetSheetColumnByLarge(Cell model, double Value)
        {
            model.Value = Value;
            model.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            model.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            model.Borders.SetAllBorders(Color.Gray, BorderLineStyle.Thin);
            model.RowHeight = 10 * 10;
            model.ColumnWidth = 280;
            model.Alignment.WrapText = true;
            model.Font.Size = 13;
        }

        public static void SetSheetColumnByLargeNoThin(Cell model, string Value)
        {
            model.Value = Value;
            model.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            model.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            model.ColumnWidth = 280;
            model.Alignment.WrapText = true;
            model.Font.Size = 11;
        }
        public static void SetSheetColumnByRange(Range range, string Value)
        {
            range.Value = Value;
            range.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            range.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            range.Alignment.WrapText = true;
            range.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
        }
        public static void SetSheetColumnByRange(Range range, int Value)
        {
            range.Value = Value;
            range.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            range.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            range.Alignment.WrapText = true;
            range.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
        }
        public static void SetSheetColumnByRange(Range range, double Value)
        {
            range.Value = Value;
            range.Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Center;
            range.Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center;
            range.Alignment.WrapText = true;
            range.Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
        }
    }
}
