using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Oy.CAD2006.CommandMethod;

[assembly: CommandClass(typeof(CommandMethod))]
namespace Oy.CAD2006.CommandMethod
{
    public class CommandMethod
    {
        //GUI.MainForm mainForm = new GUI.MainForm();
        //mainForm.ShowDialog(Application.MainWindow);
        //mainForm.Dispose();
        [CommandMethod("TT")]
        public void OpenMainForm() => Application.ShowModalDialog(new GUI.MainForm());


        [CommandMethod("Greating")]
        public void Greating() => lib.AutoCAD.Greating();

        [CommandMethod("ExportDocument")]
        public void ExportDocument() => lib.Document.ExportDocument();

        /// <summary>
        /// 写入测试数据
        /// </summary>
        [CommandMethod("WNOD")]
        public void WNOD() => Utils.NamedObjectDictionary.WriteToNOD("asd", "asd");

        /// <summary>
        /// 读取测试数据
        /// </summary>
        [CommandMethod("RNOD")]
        public void RNOD() => Utils.NamedObjectDictionary.ReadFromNOD("asd");
    }
}