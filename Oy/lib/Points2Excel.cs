using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;
using AutoCADCommands;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Style;
using System;
using System.IO;
using System.Linq;

namespace Oy.CAD2006
{
    /// <summary>
    /// 将界址点输出到Excel文件
    /// </summary>
    sealed class Points2Excel
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

        private readonly double DefaultColWidth = lib.AppConfig.DefaultColWidth;//默认列宽
        private readonly double LargerColWidth = lib.AppConfig.LargerColWidth;//加大列宽
        private readonly double DefaultRowHeight = lib.AppConfig.DefaultRowHeight;//默认行高
        private readonly string DefaultFont = lib.AppConfig.DefaultFont;//默认字体
        private readonly string CoordinatePrecision = lib.AppConfig.CoordinatePrecision;//坐标精度
        private readonly string DistencePrecision = lib.AppConfig.DistencePrecision;//长度零度
        private readonly decimal SideMargin = lib.AppConfig.SideMargin / 2.54M;//边距(英寸)
        private readonly string[] ColumnNameArray = lib.AppConfig.ExcelColumnName;


        private readonly bool ExchangeXY;
        private readonly bool Plus40;

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
        public Points2Excel(string FilePath, ObjectId[] objectId, bool ExchangeXY, bool Plus40)
        {
            string ProjectName = Utils.NamedObjectDictionary.ReadFromNOD(lib.AppConfig.ProjectInfoName[1]);
            string ProjectCode = Utils.NamedObjectDictionary.ReadFromNOD(lib.AppConfig.ProjectInfoName[0]);

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
            //数字精度设置
            excelWorksheet.Column(5).Style.Numberformat.Format = CoordinatePrecision;
            excelWorksheet.Column(6).Style.Numberformat.Format = CoordinatePrecision;
            excelWorksheet.Column(8).Style.Numberformat.Format = DistencePrecision;
            //宋体，居中
            excelWorksheet.Cells.Style.Font.Name = DefaultFont;
            excelWorksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment;//单元格水平居中
            excelWorksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment;//单元格垂直居中

            //打印设置
            excelWorksheet.PrinterSettings.LeftMargin = SideMargin;//左边距
            excelWorksheet.PrinterSettings.RightMargin = SideMargin;//右边距
            excelWorksheet.PrinterSettings.HorizontalCentered = true;//水平页面居中

            //写入项目信息到前三行
            excelWorksheet.Cells[1, 1].Value = lib.AppConfig.ProjectInfoName[1] + ":" + ProjectName;
            excelWorksheet.Cells[2, 1].Value = lib.AppConfig.ProjectInfoName[0] + ":" + ProjectCode;
            excelWorksheet.Cells[3, 1].Value = "多边形个数:" + objectId.Length;
            MergeRow(1);
            MergeRow(2);
            MergeRow(3);
            
            //接着写入各个多段线的端点坐标
            int StartBoundaryPointID = 1;
            int BlockID = 1;
            int CircleID = 1;
            objectId.QForEach<Polyline>(polyline =>
            {
                Algorithms.PolyClean_ReducePoints(polyline, lib.AppConfig.ReduceVertexEpsilon);//删除重复点
                double Area = Math.Round(polyline.Area, lib.AppConfig.AreaPrecision); //获取面积
                Point3d[] point3Ds = polyline.GetPolyPoints().ToArray();//获取端点坐标
                //TODO:blockID和LabelName暂时是随便填写的
                AddTable(point3Ds, Area, BlockID++, CircleID, StartBoundaryPointID, polyline.Handle.Value.ToString());
                StartBoundaryPointID += point3Ds.Length;
            });
        }
        #endregion
        # region AddTable()
        // 插入一列数据表
        private void AddTable(Point3d[] point3Ds, double Area, int BlockID, int CircleID, int StartBoundaryPointID, string polylineLabelName)
        {
            # region 添加多段线信息
            int Row = NextRow;
            MergeRow(Row++);
            ExcelRange excelRange13 = excelWorksheet.Cells[Row, 1, Row, 3];
            ExcelRange excelRange45 = excelWorksheet.Cells[Row, 4, Row, 5];
            ExcelRange excelRange68 = excelWorksheet.Cells[Row, 6, Row, 8];
            excelRange13.Merge = true;
            excelRange45.Merge = true;
            excelRange68.Merge = true;
            excelRange13.Value = "多边形编号:" + BlockID;
            excelRange45.Value = "界址点数:" + point3Ds.Length;
            excelRange68.Value = "用地面积(㎡)：" + Area.ToString();
            #endregion

            string tableNamePrefix = "Table";
            int FromRow = NextRow;
            int FromCol = 1;
            int HowManyLines = point3Ds.Length + 1;
            int ToRow = FromRow + HowManyLines;
            int ToCol = 8;
            
            ExcelRange excelRange = excelWorksheet.Cells[FromRow, FromCol, ToRow, ToCol];//表范围
            ExcelTable excelTable = excelWorksheet.Tables.Add(excelRange, tableNamePrefix + polylineLabelName);//新建表
            excelTable.TableStyle = DefaultTableStyles;//表样式
            excelTable.ShowFilter = false;//关闭筛选

            //边框样式
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
        #region MergeRow()
        // 合并一行表格
        private void MergeRow(int Row, ExcelHorizontalAlignment alignment = ExcelHorizontalAlignment.Left)
        {
            //后续需要处理
            excelWorksheet.Cells[Row, 1, Row, 8].Merge = true;
            ExcelRange excelRange = excelWorksheet.Cells[excelWorksheet.MergedCells[Row, 1]];
            excelRange.Style.HorizontalAlignment = alignment;
            excelRange.Style.Font.Bold = true;
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
    }
}