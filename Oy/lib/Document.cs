
namespace Oy.CAD2006.lib
{
    /// <summary>
    /// Document类
    /// </summary>
    class Document
    {
        internal static string projectNumber = "NZ-2019-0001";
        internal static string clientName = "委托单位名称超级长的名称再重复一次委托单位名称超级长的名称再重复一次";
        internal static string projectName = "新桥街道一号路工程超级长的名称再重复一次新桥街道一号路工程超级长的名称再重复一次";
        internal static string year = "二零一九年";
        internal static string month = "九月";
        internal static string day = "十二日";
        internal static string drawer = "黄显强";
        internal static string checker = "林浩";
        internal static string inspector = "邢宏斌";
        internal static string ucs = "国家2000坐标系";
        internal static string street = "郭溪街道";
        internal static string village = "浦北村";
        //替换word关键字并生成新文本导出
        protected internal static void ExportDocument()
        {
            Spire.Doc.Document document = new Spire.Doc.Document();
            document.LoadFromFile("c:\\Template.doc");

            document.Replace("[项目编号]",projectNumber , false, true);
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
