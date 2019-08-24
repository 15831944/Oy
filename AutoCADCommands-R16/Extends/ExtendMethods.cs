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

        }

        //TODO:还有未完成的代码,CustomDictionary.cs 和 DbHelper.cs有大量调用
        //使用this object 代替 this DBDictionaryEntry
        //并将原字段Key 改为方法Key()
        //后续最好新建一个DBDictionaryEntry类
        //拓展方法
        public static string Key(this object curve)
        {
            return String.Empty;
        }


        //TODO:还有未完成的代码,Commands.cs 有小量调用
        //拓展方法
        public static ObjectId GetBlockModelSpaceId(this SymbolUtilityServices symbolUtilityServices,Database database)
        {
            return ObjectId.Null;
        }

        //TODO:还有未完成的代码,Commands.cs 有小量调用
        //拓展方法
        public static DBObjectCollection TraceBoundary(this Editor editor, Point3d seedPoint, bool detectIslands)
        {
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
            return new ViewTableRecord();
        }
    }
}




