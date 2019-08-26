using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.IO;
using Forms = System.Windows.Forms;

namespace Oy.CAD2006.lib
{
    #region
    /// <summary>
    /// Excel类
    /// </summary>
    class Excel
    {
        #region:data table 版本
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="FilePath"></param>
        //protected internal void SaveExcel(string FilePath)
        //{
        //    ExcelPackage package = new ExcelPackage();
        //    ExcelWorksheet excelWorksheet = package.Workbook.Worksheets.Add("汇总表");
        //    excelWorksheet.Cells["A1"].LoadFromDataTable(GetDataTable(), false);
        //    try
        //    {
        //        package.SaveAs(new FileInfo(FilePath));
        //        //询问是否打开文件
        //        Utils.Interaction.OpenFile(FilePath, true);
        //    }

        //    //TODO:可删
        //    catch (Exception)
        //    {
        //        //重试操作
        //        bool Retry = Utils.Interaction.RetrySaveDialog();
        //        if (Retry is true) SaveExcel(FilePath);
        //    }

        //    finally
        //    {
        //        package.Dispose();
        //    }
        //}

        /// <summary>
        /// /生成DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            //table.Columns.Add("序列号", Type.GetType("System.Int32"));
            //table.Columns.Add("地块号", Type.GetType("System.Int32"));
            //table.Columns.Add("圈号", Type.GetType("System.Int32"));
            //table.Columns.Add("界址点号", Type.GetType("System.Int32"));
            //table.Columns.Add("纵坐标(X)", Type.GetType("System.Double"));
            //table.Columns.Add("横坐标(Y)", Type.GetType("System.Double"));
            //table.Columns.Add("指向点号", Type.GetType("System.Int32"));
            //table.Columns.Add("距离", Type.GetType("System.Double"));

            table.Columns.Add("序列号", 0.GetType());
            table.Columns.Add("地块号", 0.GetType());
            table.Columns.Add("圈号", 0.GetType());
            table.Columns.Add("界址点号", 0.GetType());
            table.Columns.Add("纵坐标(X)", 0.0.GetType());
            table.Columns.Add("横坐标(Y)", 0.0.GetType());
            table.Columns.Add("指向点号", 0.GetType());
            table.Columns.Add("距离", 0.0.GetType());

            table.Rows.Add(new object[] { 1, 1, 1, 1, 111.111, 222.2222, 2, 10 });
            table.Rows.Add(new object[] { 1, 1, 1, 1, 111.111, 222.2222, 2, 10 });
            table.Rows.Add(new object[] { 2, 1, 1, 2, 333.300, 444.440, 3, 20 });
            table.Rows.Add(new object[] { 3, 1, 1, 3, 555.000, 666.666, 4, 30 });
            table.Rows.Add(new object[] { 4, 1, 1, 4, 777.7, 888.88, 5, 40 });
            return table;
        }
        #endregion

    }

    #endregion

    class Excel2
    {
        private int row;
        private int column;
        private string filePath;
        private ExcelPackage excelPackage;
        private ExcelWorkbook excelWorkbook;
        private ExcelWorksheet excelWorksheet;
        private double DefaultColWidth = 9.71;
        private double LargerColWidth = 15.71;
        private double DefaultRowHeight = 13.5;
        private TableStyles DefaultTableStyles = TableStyles.None;
        private ExcelBorderStyle DefaultExcelBorderStyle = ExcelBorderStyle.Thin;
        private string DefaultFont = "宋体";
        private ExcelHorizontalAlignment ExcelHorizontalAlignment = ExcelHorizontalAlignment.Center;
        private ExcelVerticalAlignment ExcelVerticalAlignment = ExcelVerticalAlignment.Center;
        private string[] ColumnNameArray = Utils.ConfigArray.ColumnNameArray;
        private int EndRow => excelWorksheet.Dimension.End.Row;

        /// <summary>
        /// 构造函数，默认表名为"Sheet"
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="WorkSheetName"></param>
        public Excel2(string FilePath, string WorkSheetName = "Sheet")
        {
            //初始化
            this.filePath = FilePath;
            this.excelPackage = new ExcelPackage();
            this.excelWorkbook = this.excelPackage.Workbook;
            this.excelWorksheet = this.excelWorkbook.Worksheets.Add(WorkSheetName);
            //列宽
            this.excelWorksheet.DefaultColWidth = this.DefaultColWidth;
            this.excelWorksheet.DefaultRowHeight = this.DefaultRowHeight;
            this.excelWorksheet.Column(5).Width = LargerColWidth;
            this.excelWorksheet.Column(6).Width = LargerColWidth;
            this.excelWorksheet.Column(7).Width = DefaultColWidth;
            //宋体，居中
            this.excelWorksheet.Cells.Style.Font.Name = DefaultFont;
            this.excelWorksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment;
            this.excelWorksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment;
            InfoRow1();
            InfoRow2(4);
            TableRow(EndRow+1,2,3,Utils.ConfigArray.TestPoints);
            Forms.MessageBox.Show(EndRow.ToString());
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        protected internal void Save()
        {
            try
            {
                excelPackage.SaveAs(new FileInfo(filePath));
                //询问是否打开文件
                Utils.Interaction.OpenFile(filePath);
            }
            catch (Exception)
            {
                //重试
                bool Retry = Utils.Interaction.RetrySaveDialog();
                if (Retry is true) Save();
            }
        }


        /// <summary>
        /// 合并一行
        /// </summary>
        /// <param name="Row"></param>
        private void MergeRow(int Row)
        {
            excelWorksheet.Cells[Row, 1, Row, 8].Merge = true;
        }


        /// <summary>
        /// 最前面三行信息栏
        /// </summary>
        /// 
        private void InfoRow1()
        {
            MergeRow(1);
            MergeRow(2);
            MergeRow(3);
        }


        /// <summary>
        /// 二号信息栏
        /// </summary>
        /// <param name="Row"></param>
        private void InfoRow2(int Row)
        {
            excelWorksheet.Cells[Row, 1, Row, 3].Merge = true;
            excelWorksheet.Cells[Row, 4, Row, 5].Merge = true;
            excelWorksheet.Cells[Row, 6, Row, 8].Merge = true;
            excelWorksheet.Cells[excelWorksheet.MergedCells[Row, 1]].Value = "多边形编号:1";
            excelWorksheet.Cells[excelWorksheet.MergedCells[Row, 4]].Value = "界址点数:16";
            excelWorksheet.Cells[excelWorksheet.MergedCells[Row, 6]].Value = "用地面积(㎡)：164";
        }


        /// <summary>
        /// 一个table
        /// </summary>
        /// <param name="FromRow"></param>
        private void TableRow(int FromRow,int dikuaihao,int quanhao,double[] points)
        {
            string tableNamePrefix = "Table";
            string polylineNumber = "1";
            double area = 0;

            int FromCol = 1;
            int HowManyLines = points.Length+1;
            int ToRow = FromRow+HowManyLines;
            int ToCol = 8;

            //表范围
            ExcelRange excelRange = excelWorksheet.Cells[FromRow, FromCol, ToRow, ToCol];
            //新建表
            ExcelTable excelTable = excelWorksheet.Tables.Add(excelRange, tableNamePrefix + polylineNumber);
            //表样式
            excelTable.TableStyle = DefaultTableStyles;
            excelTable.ShowFilter = false;
            //Range样式
            excelRange.Style.Border.Top.Style = DefaultExcelBorderStyle;
            excelRange.Style.Border.Right.Style = DefaultExcelBorderStyle;
            excelRange.Style.Border.Bottom.Style = DefaultExcelBorderStyle;
            excelRange.Style.Border.Left.Style = DefaultExcelBorderStyle;

            //写入列名
            for (int i = 0; i < ColumnNameArray.Length; i++)
            {
                excelTable.Columns[i].Name = ColumnNameArray[i];
            }
            for (int i = 1; i < HowManyLines; i++)
            {
                excelWorksheet.Cells[FromRow + i, 1].Value = i;
                excelWorksheet.Cells[FromRow + i, 2].Value = dikuaihao;
                excelWorksheet.Cells[FromRow + i, 3].Value = quanhao;
                excelWorksheet.Cells[FromRow + i, 4].Value = i;
                excelWorksheet.Cells[FromRow + i, 5].Value = points[i-1];
                excelWorksheet.Cells[FromRow + i, 6].Value = points[i-1];
                excelWorksheet.Cells[FromRow + i, 7].Value = i+1;
                excelWorksheet.Cells[FromRow + i, 8].Value = 123.456789;
            }
        }
    }
}



