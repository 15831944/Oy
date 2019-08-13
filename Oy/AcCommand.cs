using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;

[assembly: CommandClass(typeof(Oy.CAD2006.AcCommand))]
namespace Oy.CAD2006
{
    public class AcCommand
    {
        //注释
        [CommandMethod("greating")]
        public void greating()
        {
            Oy.CAD2006.lib.Greating.greating();
        }


        //注释
        [CommandMethod("toExcel")]
        public void toExcel()
        {

        }

        //注释
        [CommandMethod("loadExcel")]
        public void loadExcel()
        {

        }

        //注释
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

