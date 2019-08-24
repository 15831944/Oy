using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;

namespace AutoCADCommands
{
    static class Extends
    {
        //TODO:还有未完成的代码,Algorithms.cs 有大量调用
        public static  void ReverseCurve(this Curve curve)
        {

        }

        //TODO:还有未完成的代码,CustomDictionary.cs 有大量调用
        //使用this object 代替 this DBDictionaryEntry
        //并将原字段Key 改为方法Key()
        public static string Key(this object curve)
        {
            return String.Empty;
        }
    }
}
