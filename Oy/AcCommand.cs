
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;

using Spire.Xls;

[assembly: CommandClass(typeof(Oy.AcCommand))]
namespace Oy
{
    public class AcCommand
    {
        [CommandMethod("greating")]
        public void greating()
        {
            // Get the current document and database, and start a transaction
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;

            // Starts a new transaction with the Transaction Manager
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Block table record for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                             OpenMode.ForRead) as BlockTable;

                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                                OpenMode.ForWrite) as BlockTableRecord;

                /* Creates a new MText object and assigns it a location,
                text value and text style */
                MText objText = new MText();

                // Set the default properties for the MText object
                objText.SetDatabaseDefaults();

                // Specify the insertion point of the MText object
                objText.Location = new Autodesk.AutoCAD.Geometry.Point3d(2, 2, 0);

                // Set the text string for the MText object
                objText.Contents = "Greetings, Welcome to the AutoCAD .NET Developer's Guide";

                // Set the text style for the MText object
                objText.TextStyle = acCurDb.Textstyle;

                // Appends the new MText object to model space
                acBlkTblRec.AppendEntity(objText);

                // Appends to new MText object to the active transaction
                acTrans.AddNewlyCreatedDBObject(objText, true);

                // Saves the changes to the database and closes the transaction
                acTrans.Commit();
            }
        }

        [CommandMethod("toExcel")]
        public void toExcel()
        {
            //创建1个工作簿，相当于1个Excel文件　　　　　　　　

            //Excel的文档结构是 Workbook->Worksheet（1个book可以包含多个sheet）
            Workbook workbook = new Workbook();

            //删除所有默认sheet.
            workbook.Worksheets.Clear();
            workbook.Worksheets.Add("summary");

            //获取第一个sheet，进行操作，下标是从0开始
            Worksheet sheet = workbook.Worksheets[0];
            //当然你也可以自己添加1个命名的Worksheet到book中

            //向A1单元格写入文字
            sheet.Range["A1:A50"].Formula = "=SUM(1+2+3)";
            //将Excel文件保存到指定文件,还可以指定Excel版本
            workbook.SaveToFile("C:\\hxq.xls", ExcelVersion.Version97to2003);
            System.Diagnostics.Process.Start("C:\\hxq.xls");
        }

        [CommandMethod("loadExcel")]
        public void loadExcel()
        {
            const string filename = "resources\\Template.xls";
            Workbook workbook = new Workbook();
            workbook.LoadTemplateFromFile(filename);


            Worksheet worksheet = workbook.ActiveSheet;
            worksheet.Range["A1"].Value = "项目名称：没什么";
            worksheet.Range["B1"].Value = "项目名称：没什么";
            worksheet.Range["C1"].Value = "项目名称：没什么";
            workbook.SaveToFile("resources\\hxq.xls");
        }

        [CommandMethod("toDoc")]
        public void toDoc()
        {
            string projectNumber = "NZ-2019-0001";
            string clientName = "委托单位名称超级长的名称再重复一次委托单位名称超级长的名称再重复一次";
            string projectName = "新桥街道一号路工程超级长的名称再重复一次新桥街道一号路工程超级长的名称再重复一次";
            string year = "二零一九年";
            string month = "九月";
            string day = "十二日";
            string drawer = "黄显强";
            string checker = "林浩";
            string inspector = "邢宏斌";
            string ucs = "国家2000坐标系";
            string street = "郭溪街道";
            string village = "浦北村";

            Spire.Doc.Document document = new Spire.Doc.Document();
            document.LoadFromFile("c:\\Template.doc");

            document.Replace("[项目编号]", projectNumber, false, true);
            document.Replace("[委托单位]", clientName, false, true);
            document.Replace("[项目名称]", projectName, false, true);
            document.Replace("[年]", year, false, true);
            document.Replace("[月]", month, false, true);
            document.Replace("[日]", day, false, true);
            document.Replace("[制图员]", drawer, false, true);
            document.Replace("[检查员]", checker, false, true);
            document.Replace("[审核人员]", inspector, false, true);
            document.Replace("[坐标系]", ucs, false, true);
            document.Replace("[街道]", street, false, true);
            document.Replace("[村]", village, false, true);
            document.SaveToFile("c:\\hxq.doc", Spire.Doc.FileFormat.Doc);

            System.Diagnostics.Process.Start("C:\\hxq.doc");
        }
    }

}

