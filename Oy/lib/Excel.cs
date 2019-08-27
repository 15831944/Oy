using Autodesk.AutoCAD.Geometry;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.IO;
using Forms = System.Windows.Forms;
using System.Collections.Generic;

namespace Oy.CAD2006.lib
{
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
            //小数点位数
            this.excelWorksheet.Column(5).Style.Numberformat.Format = "0.0000";
            this.excelWorksheet.Column(6).Style.Numberformat.Format = "0.0000";
            this.excelWorksheet.Column(8).Style.Numberformat.Format = "0.00";
            //宋体，居中
            this.excelWorksheet.Cells.Style.Font.Name = DefaultFont;
            this.excelWorksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment;
            this.excelWorksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment;

            InfoHeader();
            TableRow(Utils.ConfigArray.TestPoints,5,6,7);
            TableRow(Utils.ConfigArray.TestPoints,6,6,7);
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
            //后续需要处理
            excelWorksheet.Cells[Row, 1, Row, 8].Merge = true;
            ExcelRange excelRange = excelWorksheet.Cells[excelWorksheet.MergedCells[Row, 1]];
            excelRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            excelRange.Style.Font.Bold=true;
        }


        /// <summary>
        /// 最前面三行信息栏
        /// </summary>
        /// 
        private void InfoHeader()
        {
            excelWorksheet.Cells[1, 1].Value = "项目名称:";
            excelWorksheet.Cells[2, 1].Value = "项目编号:";
            excelWorksheet.Cells[3, 1].Value = "多边形个数:";
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
        private void TableRow(Point3d[] point3Ds, int AreaID, int CircleID, int StartBoundaryPointID)
        {
            InfoRow2(EndRow + 2);
            string tableNamePrefix = "Table";

            int FromRow = EndRow + 1;
            int FromCol = 1;
            int HowManyLines = point3Ds.Length+1;
            int ToRow = FromRow+HowManyLines;
            int ToCol = 8;

            //表范围
            ExcelRange excelRange = excelWorksheet.Cells[FromRow, FromCol, ToRow, ToCol];
            //新建表
            ExcelTable excelTable = excelWorksheet.Tables.Add(excelRange, tableNamePrefix + AreaID);
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

            //写入数据
            Utils.ArrangedPoint3d[] arrangedPoint3DArray = new Utils.ArrangedPoint3DArray(point3Ds, AreaID, CircleID, StartBoundaryPointID).GetResults();
            for (int i = 0; i < arrangedPoint3DArray.Length; i++)
            {
                Utils.ArrangedPoint3d arrangedPoint3D = arrangedPoint3DArray[i];
                excelWorksheet.Cells[FromRow + i + 1, 1].Value = i+1;
                excelWorksheet.Cells[FromRow + i + 1, 2].Value = arrangedPoint3D.AreaID;
                excelWorksheet.Cells[FromRow + i + 1, 3].Value = arrangedPoint3D.CircleID;
                excelWorksheet.Cells[FromRow + i + 1, 4].Value = arrangedPoint3D.BoundaryPointID;
                excelWorksheet.Cells[FromRow + i + 1, 5].Value = arrangedPoint3D.X;
                excelWorksheet.Cells[FromRow + i + 1, 6].Value = arrangedPoint3D.Y;
                excelWorksheet.Cells[FromRow + i + 1, 7].Value = arrangedPoint3D.PointTO;
                excelWorksheet.Cells[FromRow + i + 1, 8].Value = arrangedPoint3D.Distence;
            }
        }
    }
}



