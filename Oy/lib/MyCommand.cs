using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Oy.CAD2006.CommandMethod;
using AutoCADCommands;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;

[assembly: CommandClass(typeof(CommandMethod))]
namespace Oy.CAD2006.CommandMethod
{
    public class CommandMethod
    {
        //GUI.MainForm mainForm = new GUI.MainForm();
        //mainForm.ShowDialog(Application.MainWindow);
        //mainForm.Dispose();
        [CommandMethod("TT")]
        public void OpenMainForm() => Application.ShowModalDialog(Application.MainWindow, new GUI.MainForm());


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

        [CommandMethod("test")]
        public void Test()
        {
            // Get the configuration file.
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Get the appSettings section.
            AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
            System.Collections.IEnumerator aa = appSettings.Settings.GetEnumerator();

                Interaction.WriteLine(aa.MoveNext().ToString());
                //Interaction.WriteLine(ConfigurationManager.AppSettings.Get("Browser"));
                //Interaction.WriteLine(ConfigurationManager.AppSettings.Get("Username"));
                //Interaction.WriteLine(ConfigurationManager.AppSettings.Get("Password"));
        }
    }
}