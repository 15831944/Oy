using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;

[assembly: CommandClass(typeof(Oy.CAD2006.AutoCADCommand))]
namespace Oy.CAD2006
{
    public class AutoCADCommand
    {
        /// <summary>
        /// 注册cad命令:Test
        /// </summary>
        [CommandMethod("TT")]
        public void OpenMainFormest()
        {
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog(Application.MainWindow);
            mainForm.Dispose();
        }

        /// <summary>
        /// 注册cad命令:Greating
        /// </summary>
        [CommandMethod("Greating")]
        public void Greating()
        {
            lib.AutoCAD.Greating();
        }

        /// <summary>
        /// 注册cad命令:ExportDocument
        /// </summary>
        [CommandMethod("ExportDocument")]
        public void ExportDocument()
        {
            lib.Document.ExportDocument();
        }
        /// <summary>
        /// 写入测试数据
        /// </summary>
        [CommandMethod("WNOD")]
        public void WNOD()
        {
            lib.Utils utils = new lib.Utils();
            utils.WriteToNOD();
            System.Windows.Forms.MessageBox.Show("写入成功");
        }


        /// <summary>
        /// 读取测试数据
        /// </summary>
        [CommandMethod("RNOD")]
        public void RNOD()
        {
            lib.Utils utils = new lib.Utils();
            utils.ReadNOD();
            System.Windows.Forms.MessageBox.Show("读取成功");
        }
    }
}

