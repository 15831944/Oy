using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Oy.CAD2006.CommandMethod;
using AutoCADCommands;
using System.Linq;
using System.Collections.Generic;

[assembly: CommandClass(typeof(CommandMethod))]
namespace Oy.CAD2006.CommandMethod
{
    public class CommandMethod
    {
        [CommandMethod("TT")]
        public void OpenMainForm() => Application.ShowModalDialog(Application.MainWindow, new GUI.MainForm());


        [CommandMethod("test")]
        public static void Test()
        {
            //var objectId =Interaction.GetSelection("\n选择多段线", "LWPOLYLINE");
            //DBObjectCollection dBObjectCollection = new DBObjectCollection();
            //objectId.QForEach<Polyline>(polyline =>
            //{
            //    dBObjectCollection.Add(polyline);
            //    polyline.int
            //    DBObjectCollection DBC = Region.CreateFromCurves(dBObjectCollection);
            //    Region region0 =DBC[0] as Region;
            //    Region region1 =DBC[1] as Region;
            //    try
            //    {
            //       var d= region0.Area;
            //    }
            //    catch (System.Exception)
            //    {
            //        System.Windows.Forms.MessageBox.Show("未知错误");
            //    } 
               

                //region0.BooleanOperation(BooleanOperationType.BoolIntersect, region1);
                //System.Windows.Forms.MessageBox.Show(region0.Area.ToString());
            
        }
    }
}