using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System;
using System.Diagnostics;
using Forms = System.Windows.Forms;
using System.Collections.Generic;

namespace Oy.CAD2006.Utils
{
    #region:Server
    class Server
    {
        /// <summary>  
        /// 是否能 Ping 通指定的主机  
        /// </summary>  
        /// <param name="ip">ip 地址或主机名或域名</param>  
        /// <returns>true 通，false 不通</returns>  
        public bool Ping(string ip)
        {
            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                int timeout = 500; // Timeout 时间，单位：毫秒  
                System.Net.NetworkInformation.PingReply reply = ping.Send(ip, timeout);
                ping.Dispose();
                if (reply == null || reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    return true;
                }
                return false;
            }
            catch (System.Net.NetworkInformation.PingException)
            {
                return false;
            }
        }
    }
    #endregion

    #region:NOD
    class NamedObjectDictionary
    {
        public static readonly string[] tKey = { "项目编号", "项目名称", "委托单位", "街道-乡镇", "村落-社区", "制图人员", "检查人员", "审核人员", "坐标系统", "日期(年)", "日期(月)", "日期(日)" };

        /// <summary>
        /// 写入字典
        /// </summary>
        public static void WriteToNOD(string NodKey, string NodValue)
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            using (document.LockDocument())
            {
                Database db = document.Database;
                Transaction transaction = db.TransactionManager.StartTransaction();
                // 命名对象字典
                DBDictionary nod = transaction.GetObject(db.NamedObjectsDictionaryId,
                    OpenMode.ForWrite) as DBDictionary;

                // 自定义数据
                Xrecord OyXrecord = new Xrecord
                {
                    Data = new ResultBuffer(new TypedValue((int)DxfCode.Text, NodValue))
                };
                // 往命名对象字典中存储自定义数据
                nod.SetAt(NodKey, OyXrecord);
                transaction.AddNewlyCreatedDBObject(OyXrecord, true);
                transaction.Commit();
            }
        }

        /// <summary>
        /// 读取字典（单个）
        /// </summary>
        public static string ReadFromNOD(string NodKey)
        {
            try
            {
                Document document = Application.DocumentManager.MdiActiveDocument;
                Database db = document.Database;

                using (Transaction transaction = db.TransactionManager.StartTransaction())
                {
                    // 命名对象字典
                    DBDictionary nod = transaction.GetObject(db.NamedObjectsDictionaryId,
                        OpenMode.ForWrite) as DBDictionary;
                    //Now let's read the data back and print them out 
                    //to the Visual Studio's Output window
                    ObjectId myDataId = nod.GetAt(NodKey);
                    Xrecord readBack = (Xrecord)transaction.GetObject(myDataId, OpenMode.ForRead);
                    transaction.Dispose();
                    return readBack.Data.AsArray()[0].Value.ToString();
                }
            }
            catch (Exception)
            {
                return "0";
            }
        }

        /// <summary>
        /// 读取字典（全部）
        /// </summary>
        public static string[] ReadFromNODAll()
        {
            string[] tValue = new string[tKey.Length];
            for (int i = 0; i < tKey.Length; i++)
            {
                tValue[i] = ReadFromNOD(tKey[i]);
            }
            return tValue;
        }
    }
    #endregion


    #region InterOperation
    class Interaction
    {
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        public static void OpenFile(string FilePath, bool WithDialog = false)
        {
            if (WithDialog is true)
            {
                Forms.DialogResult dialogResult = Forms.MessageBox.Show("是否打开文件?", "打开文件", Forms.MessageBoxButtons.YesNo, Forms.MessageBoxIcon.Question);
                if (dialogResult.Equals(Forms.DialogResult.Yes))
                {
                    Process.Start(FilePath);
                }
            }
            else
            {
                Process.Start(FilePath);
            }
        }

        /// <summary>
        /// 弹出重试对话框
        /// </summary>
        /// <returns></returns>
        public static bool RetrySaveDialog()
        {
            Forms.DialogResult dialogResult = Forms.MessageBox.Show("文件在被使用", "无法保存", Forms.MessageBoxButtons.RetryCancel, Forms.MessageBoxIcon.Asterisk);
            if (dialogResult == Forms.DialogResult.Retry) return true;
            return false;
        }

        /// <summary>
        /// 获取文件保存路径
        /// </summary>
        /// <returns></returns>
        public string GetFilePath()
        {
            Forms.SaveFileDialog saveFileDialog = new Forms.SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                FileName = "坐标表",//默认文件名
                Filter = "所有文件(*.*)|*.*|Excel 2007 工作簿(*.xlsx)|*.xlsx|Word 2007 文档(*.docx)|*.docx",
                RestoreDirectory = false,
                OverwritePrompt = false,
            };
            Forms.DialogResult dialogResult = saveFileDialog.ShowDialog();
            saveFileDialog.Dispose();
            if (dialogResult.Equals(Forms.DialogResult.OK))
            {
                return saveFileDialog.FileName;
            }
            return null;
        }
    }
    #endregion


    #region Word
    class Word
    {
        /// <summary>
        /// 查找替换文本
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="strOld">查找文本</param>
        /// <param name="strNew">替换文本</param>
        public void WordReplace(string[] strOld, string[] strNew)
        {

            string[] SampleFilePaths = { @".\Resources\Cover.docx" };
            //string[] filePaths = { @".\Resources\Report.docx",@".\Resources\Authorisation.docx"};

            foreach (string filePath in SampleFilePaths)
            {
                if (strOld.Length == strNew.Length)
                {
                    Spire.Doc.Document doc = new Spire.Doc.Document();
                    doc.LoadFromFile(filePath);
                    for (int i = 0; i < strOld.Length; i++)
                    {
                        doc.Replace("[<" + strOld[i] + ">]", strNew[i], false, false);
                    }
                    string saveFilePath = new Interaction().GetFilePath();
                    if (saveFilePath !=null)
                    {
                        doc.SaveToFile(saveFilePath);
                        doc.Close();
                        doc.Dispose();
                    }
                }
                else
                {
                    Forms.MessageBox.Show("要替换的新旧字符串数量不同，取消操作");
                }
            }
        }
    }
    #endregion
    public static class ConfigArray
    {
        public static string[] ColumnNameArray = { "序列号", "地块号", "圈号", "界址点号", "纵坐标（X）", "横坐标（Y）", "指向点号", "距离" };

        public static Point3d[] TestPoints = 
        {
        new Point3d(3095550.875,40555852.6016,0),
        new Point3d(3095539.8399,40555852.5772,0),
        new Point3d(3095539.8399,40555852.5219,0),
        new Point3d(3095526.7366,40555852.4436,0),
        new Point3d(3095520.6082,40555852.3724,0),
        new Point3d(3095518.308,40555852.3357,0),
        new Point3d(3095513.847,40555852.2379,0),
        new Point3d(3095508.9408,40555852.1369,0),
        new Point3d(3095505.4739,40555852.0288,0),
        new Point3d(3095504.9238,40555851.8527,0),
        };

        public static TableData[] tableDataArray =
        {
        new TableData(TestPoints, 45.67, 1, 2, 1, "1"),
        new TableData(TestPoints, 23423.123, 2, 1, 21, "2"),
        new TableData(TestPoints, 245.123, 3, 1, 31, "3"),
        new TableData(TestPoints, 245.123, 4, 1, 31, "4"),
        new TableData(TestPoints, 245.123, 5, 1, 31, "5"),
        new TableData(TestPoints, 245.123, 6, 1, 31, "6"),
        new TableData(TestPoints, 312233.34, 7, 1, 41, "7")
        };

    };

    public class ArrangedPoint3d
    {
        #region 属性
        /// <summary>
        /// X点坐标
        /// </summary>
        public double X => this.Point3D.X;
        /// <summary>
        /// Y点坐标
        /// </summary>
        public double Y => this.Point3D.Y;

        /// <summary>
        /// 地块号
        /// </summary>
        public int AreaID;
        /// <summary>
        /// 全号
        /// </summary>
        public int CircleID;
        /// <summary>
        /// 界址点号
        /// </summary>
        public int BoundaryPointID;
        /// <summary>
        /// 指向点号
        /// </summary>
        public int PointTO;
        /// <summary>
        /// 距离
        /// </summary>
        public double Distence;
        private Point3d Point3D;

        #endregion

        public ArrangedPoint3d(Point3d point3D)
        {
            this.Point3D = point3D;
        }
    }


    public class ArrangedPoint3DArray
    {
        List<ArrangedPoint3d> arrangedPoint3Ds=new List<ArrangedPoint3d>();

        public ArrangedPoint3DArray(Point3d[] point3Ds, int AreaID, int CircleID, int StartBoundaryPointID)
        {
            for (int i = 0; i < point3Ds.Length; i++)
            {
                ArrangedPoint3d arrangedPoint3D = new ArrangedPoint3d(point3Ds[i]);

                //界址点号赋值
                arrangedPoint3D.BoundaryPointID = StartBoundaryPointID + i;

                //指向点号赋值
                arrangedPoint3D.PointTO = arrangedPoint3D.BoundaryPointID + 1;
                if (arrangedPoint3D.PointTO == point3Ds.Length+ StartBoundaryPointID)
                {
                    arrangedPoint3D.PointTO = StartBoundaryPointID;
                }

                //地块号赋值
                arrangedPoint3D.AreaID = AreaID;
                //圈号赋值
                arrangedPoint3D.CircleID = CircleID;

                //计算到下一个点的距离
                if (i<point3Ds.Length-1)
                {
                    arrangedPoint3D.Distence = point3Ds[i].DistanceTo(point3Ds[i + 1]);
                }
                else
                {
                    arrangedPoint3D.Distence = point3Ds[i].DistanceTo(point3Ds[0]);
                }

                //添加到list中
                this.arrangedPoint3Ds.Add(arrangedPoint3D);
            }
            //回圈
            arrangedPoint3Ds.Add(arrangedPoint3Ds[0]);
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        /// <returns></returns>
        public ArrangedPoint3d[] GetResults()
        {
            return arrangedPoint3Ds.ToArray();
        }
    }

}
