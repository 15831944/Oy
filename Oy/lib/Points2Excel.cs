using Autodesk.AutoCAD.Geometry;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Style;
using System;
using System.IO;

namespace Oy.CAD2006
{
    /// <summary>
    /// 将界址点输出到Excel文件
    /// </summary>
    class Points2Excel
    {
        #region 字段与属性
        private readonly string filePath;
        private readonly ExcelPackage excelPackage;
        private readonly ExcelWorkbook excelWorkbook;
        private readonly ExcelWorksheet excelWorksheet;

        private readonly TableStyles DefaultTableStyles = TableStyles.None;
        private readonly ExcelBorderStyle DefaultExcelBorderStyle = ExcelBorderStyle.Thin;
        private readonly ExcelHorizontalAlignment ExcelHorizontalAlignment = ExcelHorizontalAlignment.Center;
        private readonly ExcelVerticalAlignment ExcelVerticalAlignment = ExcelVerticalAlignment.Center;

        private readonly double DefaultColWidth = lib.AppConfig.DefaultColWidth;
        private readonly double LargerColWidth = lib.AppConfig.LargerColWidth;
        private readonly double DefaultRowHeight = lib.AppConfig.DefaultRowHeight;
        private readonly string DefaultFont = lib.AppConfig.DefaultFont;
        private readonly string CoordinatePrecision = lib.AppConfig.CoordinatePrecision;
        private readonly string DistencePrecision = lib.AppConfig.DistencePrecision;
        private readonly string[] ColumnNameArray = lib.AppConfig.ExcelColumnName;

        private bool ExchangeXY;
        private bool Plus40;

        private int NextRow => excelWorksheet.Dimension.End.Row+1;
        #endregion

        #region 初始化
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="FilePath">文件保存路径</param>
        /// <param name="tableDataArray">数据</param>
        /// <param name="ProjectName">项目名称</param>
        /// <param name="ProjectCode">项目编号</param>
        public Points2Excel(string FilePath, TableData[] tableDataArray, string ProjectName,string ProjectCode, bool ExchangeXY, bool Plus40)
        {
            //初始化
            filePath = FilePath;
            excelPackage = new ExcelPackage();
            excelWorkbook = excelPackage.Workbook;
            excelWorksheet = excelWorkbook.Worksheets.Add(ProjectName);
            this.ExchangeXY = ExchangeXY;
            this.Plus40 = Plus40;

            //特殊列宽
            excelWorksheet.DefaultColWidth = DefaultColWidth;
            excelWorksheet.DefaultRowHeight = DefaultRowHeight;
            excelWorksheet.Column(5).Width = LargerColWidth;
            excelWorksheet.Column(6).Width = LargerColWidth;
            excelWorksheet.Column(7).Width = DefaultColWidth;
            //数字精度
            excelWorksheet.Column(5).Style.Numberformat.Format = CoordinatePrecision;
            excelWorksheet.Column(6).Style.Numberformat.Format = CoordinatePrecision;
            excelWorksheet.Column(8).Style.Numberformat.Format = DistencePrecision;
            //宋体，居中
            excelWorksheet.Cells.Style.Font.Name = DefaultFont;
            excelWorksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment;
            excelWorksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment;

            AddHeaderInfo(ProjectName,ProjectCode,tableDataArray.Length);
            foreach (TableData tableData in tableDataArray)
            {
                AddTable(tableData);
            }
        }
        #endregion

        #region Save()
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
        #endregion

        #region MergeRow()
        /// <summary>
        /// 合并一行表格
        /// </summary>
        /// <param name="Row">要合并的行号</param>
        /// <param name="alignment">对其方式,默认左对齐</param>
        private void MergeRow(int Row, ExcelHorizontalAlignment alignment = ExcelHorizontalAlignment.Left)
        {
            //后续需要处理
            excelWorksheet.Cells[Row, 1, Row, 8].Merge = true;
            ExcelRange excelRange = excelWorksheet.Cells[excelWorksheet.MergedCells[Row, 1]];
            excelRange.Style.HorizontalAlignment = alignment;
            excelRange.Style.Font.Bold = true;
        }
        #endregion

        #region HeaderInfo()
        /// <summary>
        /// 最前面三行信息栏
        /// </summary>
        /// 
        private void AddHeaderInfo(string ProjectName, string ProjectNum,int TotalpolylineNum)
        {
            excelWorksheet.Cells[1, 1].Value = lib.AppConfig.ProjectInfoName[1]+ ":"+ ProjectName;
            excelWorksheet.Cells[2, 1].Value = lib.AppConfig.ProjectInfoName[0] + ":" + ProjectNum;
            excelWorksheet.Cells[3, 1].Value = "多边形个数:"+ TotalpolylineNum;
            MergeRow(1);
            MergeRow(2);
            MergeRow(3);
        }
        #endregion

        #region TableData()
        /// <summary>
        /// 二号信息栏
        /// </summary>
        /// <param name="Row">起始行号</param>
        /// <param name="BoundaryAmount">界址点数量</param>
        /// <param name="Area">面积</param>
        /// <param name="polylineID">多边形编号</param>
        private void TableInfo(int Row, int BoundaryAmount, double Area, string polylineLabelName)
        {
            MergeRow(Row);
            Row += 1;
            ExcelRange excelRange13 = excelWorksheet.Cells[Row, 1, Row, 3];
            ExcelRange excelRange45 = excelWorksheet.Cells[Row, 4, Row, 5];
            ExcelRange excelRange68 = excelWorksheet.Cells[Row, 6, Row, 8];
            excelRange13.Merge = true;
            excelRange45.Merge = true;
            excelRange68.Merge = true;

            excelRange13.Value = "多边形编号:" + polylineLabelName;
            excelRange45.Value = "界址点数:" + BoundaryAmount;
            excelRange68.Value = "用地面积(㎡)：" + Area.ToString();
        }


        /// <summary>
        /// 插入一列数据表
        /// </summary>
        private void AddTable(TableData tableData)
        {
            Point3d[] point3Ds = tableData.Point3Ds;
            double Area = tableData.Area;
            int BlockID = tableData.BlockID;
            int CircleID = tableData.CircleID;
            int StartBoundaryPointID = tableData.StartBoundaryPointID;
            string polylineLabelName = tableData.polylineLabelName;

        TableInfo(NextRow, point3Ds.Length, Area, polylineLabelName);

            string tableNamePrefix = "Table";
            int FromRow = NextRow;
            int FromCol = 1;
            int HowManyLines = point3Ds.Length + 1;
            int ToRow = FromRow + HowManyLines;
            int ToCol = 8;

            //表范围
            ExcelRange excelRange = excelWorksheet.Cells[FromRow, FromCol, ToRow, ToCol];
            //新建表
            ExcelTable excelTable = excelWorksheet.Tables.Add(excelRange, tableNamePrefix + polylineLabelName);
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
            Utils.ArrangedPoint3d[] arrangedPoint3DArray = new Utils.ArrangedPoint3DArray(point3Ds, BlockID, CircleID, StartBoundaryPointID,ExchangeXY,Plus40).GetResults();
            for (int i = 0; i < arrangedPoint3DArray.Length; i++)
            {
                Utils.ArrangedPoint3d arrangedPoint3D = arrangedPoint3DArray[i];
                excelWorksheet.Cells[FromRow + i + 1, 1].Value = i + 1;
                excelWorksheet.Cells[FromRow + i + 1, 2].Value = arrangedPoint3D.AreaID;
                excelWorksheet.Cells[FromRow + i + 1, 3].Value = arrangedPoint3D.CircleID;
                excelWorksheet.Cells[FromRow + i + 1, 4].Value = arrangedPoint3D.BoundaryPointID;
                excelWorksheet.Cells[FromRow + i + 1, 5].Value = arrangedPoint3D.X;
                excelWorksheet.Cells[FromRow + i + 1, 6].Value = arrangedPoint3D.Y;
                excelWorksheet.Cells[FromRow + i + 1, 7].Value = arrangedPoint3D.PointTO;
                excelWorksheet.Cells[FromRow + i + 1, 8].Value = arrangedPoint3D.Distence;
            }
        }
        #endregion
    }






    public class TableData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="point3Ds">多段线点数组</param>
        /// <param name="Area">面积</param>
        /// <param name="BlockID">地块号</param>
        /// <param name="CircleID">圈号</param>
        /// <param name="StartBoundaryPointID">起始点号</param>
        /// <param name="polylineLabelName">多边形编号</            //public Point3d[] Point3Ds { get => Point3Ds; set => Point3Ds = value; }
        public Point3d[] Point3Ds;
        public double Area;
        public int BlockID;
        public int CircleID;
        public int StartBoundaryPointID;
        public string polylineLabelName;
        public TableData(Point3d[] point3Ds, double Area, int BlockID, int CircleID, int StartBoundaryPointID, string polylineLabelName)
        {
            this.Point3Ds = point3Ds;
            this.Area = Area;
            this.BlockID = BlockID;
            this.CircleID = CircleID;
            this.StartBoundaryPointID = StartBoundaryPointID;
            this.polylineLabelName = polylineLabelName;
        }
    }
}