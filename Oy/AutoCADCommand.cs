using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;

[assembly: CommandClass(typeof(Oy.CAD2006.AutoCADCommand))]
namespace Oy.CAD2006
{
    public class AutoCADCommand
    {
        //注册cad命令:Greating
        [CommandMethod("Test")]
        public void Test()
        {
           var  form1= new Form1();
            form1.ShowInTaskbar = false;
            form1.MinimizeBox = false;
            form1.ShowDialog();
        }

        //注册cad命令:Greating
        [CommandMethod("Greating")]
        public void Greating()
        {
            lib.AutoCAD.Greating();
        }

        //注册cad命令:SaveExcel
        [CommandMethod("SaveExcel")]
        public void SaveExcel()
        {
            lib.Excel.SaveExcel();
            
        }

        //注册cad命令:ExportDocument
        [CommandMethod("ExportDocument")]
        public void ExportDocument()
        {
            lib.Document.ExportDocument();
        }
    }
}

