using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Oy.CAD2006.CommandMethod;

[assembly: CommandClass(typeof(CommandMethod))]
namespace Oy.CAD2006.CommandMethod
{
    public class CommandMethod
    {
        [CommandMethod("TT")]
        public void OpenMainForm()
        {
            GUI.MainForm mainForm= new GUI.MainForm();
            mainForm.ShowDialog(Application.MainWindow);
            mainForm.Dispose();
        }

        [CommandMethod("Greating")]
        public void Greating() => lib.AutoCAD.Greating();

        [CommandMethod("ExportDocument")]
        public void ExportDocument() => lib.Document.ExportDocument();

        /// <summary>
        /// 写入测试数据
        /// </summary>
        [CommandMethod("WNOD")]
        public void WNOD() => new Utils.NamedObjectDictionary().WriteToNOD();

        /// <summary>
        /// 读取测试数据
        /// </summary>
        [CommandMethod("RNOD")]
        public void RNOD() => new Utils.NamedObjectDictionary().ReadNOD();
    }
}