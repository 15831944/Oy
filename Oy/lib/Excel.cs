using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using OfficeOpenXml;
using System.IO;

namespace Oy.CAD2006.lib
{
    //Excel类
    class Excel
    {
        protected internal static void LoadExcel()
        {

            lib.AutoCAD.Greating();
            ExcelPackage package = new ExcelPackage();

            ExcelWorksheet excelWorksheet = package.Workbook.Worksheets.Add("aaa");
            excelWorksheet.Cells["c3"].LoadFromDataTable(GetDataTable(), false);
            package.SaveAs(new FileInfo("c:\\myworkbook.xlsx"));
        }

        private static DataTable GetDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("strName", Type.GetType("System.String"));
            table.Columns.Add("strSex", Type.GetType("System.String"));
            table.Columns.Add("strEmail", Type.GetType("System.String"));

            table.Rows.Add(new object[] { "Tom", "男", "Tom@atguigu.com" });
            table.Rows.Add(new object[] { "Lucy", "女", "Lucy@atguigu.com" });
            table.Rows.Add(new object[] { "Jack", "男", "Jack@atguigu.com" });

            return table;
        }
    }

}
