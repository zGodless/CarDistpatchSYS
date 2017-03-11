using System;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using QuickFrame.Common.Converter;

namespace DS.Common
{
	public class ExcelHelper : IDisposable
	{
		private bool _disposed;
		private FileStream _fs;
		private IWorkbook _workbook;
		private readonly string _fileName; //文件名

		public ExcelHelper(string fileName)
		{
			_fileName = fileName;
			_disposed = false;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		///     将DataTable数据导入到excel中
		/// </summary>
		/// <param name="data">要导入的数据</param>
		/// <param name="isColumnWritten">DataTable的列名是否要导入</param>
		/// <param name="sheetName">要导入的excel的sheet的名称</param>
		/// <returns>导入数据行数(包含列名那一行)</returns>
		public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
		{
			_fs = new FileStream(_fileName, FileMode.Create, FileAccess.ReadWrite);
			if (_fileName.IndexOf(".xlsx", StringComparison.OrdinalIgnoreCase) > 0) // 2007版本
				_workbook = new XSSFWorkbook();
			else if (_fileName.IndexOf(".xls", StringComparison.OrdinalIgnoreCase) > 0) // 2003版本
				_workbook = new HSSFWorkbook();

			//日期格式
			var dateCellStyle = _workbook.CreateCellStyle();
			var dateFormat = _workbook.CreateDataFormat();
			dateCellStyle.DataFormat = dateFormat.GetFormat("yyyy/M/d");

			ISheet sheet = null;
			if (_workbook != null)
			{
				sheet = _workbook.CreateSheet(sheetName);
			}
			else
			{
				return -1;
			}

			int count;
			if (isColumnWritten) //写入DataTable的列名
			{
				var row = sheet.CreateRow(0);
				for (var j = 0; j < data.Columns.Count; ++j)
				{
					var cell = row.CreateCell(j);
					cell.SetCellValue(data.Columns[j].ColumnName);
					sheet.AutoSizeColumn(j);
				}
				count = 1;
			}
			else
			{
				count = 0;
			}

			for (var i = 0; i < data.Rows.Count; ++i)
			{
				var row = sheet.CreateRow(count);
				for (var j = 0; j < data.Columns.Count; ++j)
				{
					var column = data.Columns[j];
					var cell = row.CreateCell(j);
					var val = data.Rows[i][j];
					if (val == DBNull.Value) continue;
					switch (column.DataType.Name)
					{
						case "Int16":
						case "Int32":
						case "Int64":
						case "Decimal":
						case "Double":
							cell.SetCellValue(ValueConvert.ToDouble(val));
							break;
						case "Boolean":
							cell.SetCellValue(ValueConvert.ToBoolean(val));
							break;
						case "DateTime":
							var dt = ValueConvert.ToNullableDateTime(val);
							if (dt == null)
							{
								cell.SetCellValue("");
							}
							else
							{
								cell.CellStyle = dateCellStyle;
								cell.SetCellValue(dt.Value);
							}
							break;
						default:
							cell.SetCellValue((string) val);
							break;
					}
				}
				++count;
			}
			for (int i = 0; i < data.Columns.Count; i++)
			{
				sheet.AutoSizeColumn(i);
			}
			_workbook.Write(_fs); //写入到excel
			return count;
		}

		/// <summary>
		///     将excel中的数据导入到DataTable中
		/// </summary>
		/// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>
		/// <param name="index">数据起始行索引</param>
		/// <returns>返回的DataTable</returns>
		public DataTable ExcelToDataTable(bool isFirstRowColumn, int index = 0)
		{
			var data = new DataTable();

			_fs = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
			if (_fileName.IndexOf(".xlsx", StringComparison.OrdinalIgnoreCase) > 0) // 2007版本
				_workbook = new XSSFWorkbook(_fs);
			else if (_fileName.IndexOf(".xls", StringComparison.OrdinalIgnoreCase) > 0) // 2003版本
				_workbook = new HSSFWorkbook(_fs);
			var sheet = _workbook.GetSheetAt(0);
			if (sheet != null)
			{
				var firstRow = sheet.GetRow(0);
				int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数

				int startRow;
				if (isFirstRowColumn)
				{
					for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
					{
						var column = new DataColumn(firstRow.GetCell(i).StringCellValue);
						data.Columns.Add(column);
					}
					startRow = index == 0 ? sheet.FirstRowNum + 1 : index;
				}
				else
				{
					startRow = index == 0 ? sheet.FirstRowNum : index;
				}

				//最后一列的标号
				var rowCount = sheet.LastRowNum;
				for (var i = startRow; i <= rowCount; ++i)
				{
					var row = sheet.GetRow(i);
					if (row == null) continue; //没有数据的行默认是null　　　　　　　

					var dataRow = data.NewRow();
					for (int j = row.FirstCellNum; j < cellCount; ++j)
					{
						if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
							dataRow[j] = row.GetCell(j).ToString();
					}
					data.Rows.Add(dataRow);
				}
			}

			return data;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed) return;
			if (_workbook != null)
			{
				
			}
			if (disposing)
			{
				if (_fs != null) _fs.Close();
			}
			_fs = null;
			_disposed = true;
		}
	}
}