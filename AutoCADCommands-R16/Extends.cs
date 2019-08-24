using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;

namespace AutoCADCommands
{
    static class Extends
    {
        //TODO:还有未完成的代码,Algorithms.cs 有大量调用
        public static  void ReverseCurve(this Curve curve)
        {

        }

        //TODO:还有未完成的代码,CustomDictionary.cs 和 DbHelper.cs有大量调用
        //使用this object 代替 this DBDictionaryEntry
        //并将原字段Key 改为方法Key()
        //后续最好新建一个DBDictionaryEntry类
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
    }
}
public void ReadDwgFile(IntPtr drawingFile, bool allowCPConversion, string password);
public void ReadDwgFile(IntPtr drawingFile, bool allowCPConversion, string password);


public void ReadDwgFile(string fileName, FileShare fileSharing, bool allowCPConversion, string password);
public void ReadDwgFile(string fileName, FileShare fileSharing, bool allowCPConversion, string password);


public void ReadDwgFile(string fileName, FileOpenMode mode, bool allowCPConversion, string password);



namespace Autodesk.AutoCAD.DatabaseServices
{
    [Wrapper("AcDbDatabase::OpenMode")]
    public enum FileOpenMode
    {
        OpenForReadAndReadShare = 1,
        OpenForReadAndWriteNoShare = 2,
        OpenForReadAndAllShare = 3,
        OpenTryForReadShare = 4
    }
}