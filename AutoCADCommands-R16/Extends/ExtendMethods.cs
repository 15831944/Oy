using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System.ComponentModel;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;

namespace AutoCADCommands
{
    static class ExtendMethods
    {
        //TODO:还有未完成的代码,Algorithms.cs 有大量调用
        //拓展方法
        public static  void ReverseCurve(this Curve curve)
        {
            System.Windows.Forms.MessageBox.Show("未完成内容ReverseCurve()");
        }

        //TODO:目测可作废
        //使用this object 代替 this DBDictionaryEntry
        //并将原字段Key 改为方法Key()
        //后续最好新建一个DBDictionaryEntry类
        //拓展方法
        //public static string Key(this object curve)
        //{
        //    System.Windows.Forms.MessageBox.Show("未完成内容Key()");
        //    return String.Empty;
        //}


        //TODO:还有未完成的代码,Commands.cs 有小量调用
        //拓展方法
        public static ObjectId GetBlockModelSpaceId(this SymbolUtilityServices symbolUtilityServices,Database database)
        {
            System.Windows.Forms.MessageBox.Show("未完成内容GetBlockModelSpaceId()");
            return ObjectId.Null;
        }

        //TODO:还有未完成的代码,Commands.cs 有小量调用
        //拓展方法
        public static DBObjectCollection TraceBoundary(this Editor editor, Point3d seedPoint, bool detectIslands)
        {
            System.Windows.Forms.MessageBox.Show("未完成内容TraceBoundary()");
            return new DBObjectCollection();
        }


        //TODO:还有未完成的代码,Commands.cs 有小量调用
        //拓展方法
        //
        // 摘要:
        //     Gets the current Viewport entity (it does not work with ViewportTableRecords).
        //
        // 返回结果:
        //     The current Viewport entity.
        public static ViewTableRecord GetCurrentView(this Editor editor)
        {
            System.Windows.Forms.MessageBox.Show("未完成内容GetCurrentView()");
            return new ViewTableRecord();
            //using (Transaction trans = database.TransactionManager.StartTransaction())
            //{
            //    trans.GetObject(database.CurrentSpaceId, OpenMode.ForWrite, false);
            //}
        }

        //TODO:还有未完成的代码,Commands.cs 有小量调用
        //
        // 摘要:
        //     Uses the information from the ViewTableRecord value to set the view.
        //
        // 参数:
        //   value:
        //     ViewTableRecord to read data from.
        public static void SetCurrentView(this Editor editor, ViewTableRecord value)
        {
            System.Windows.Forms.MessageBox.Show("未完成内容SetCurrentView()");
        }
    }
}




