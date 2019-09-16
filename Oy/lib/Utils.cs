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
        string[] ProjectInfoName = lib.AppConfig.ProjectInfoName;

        string[] tValue = new string[ProjectInfoName.Length];
            for (int i = 0; i < ProjectInfoName.Length; i++)
            {
                tValue[i] = ReadFromNOD(ProjectInfoName[i]);
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
        public static string GetFilePath()
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

        public static string GetFolderPath()//获取文件目录
        {
            using (Forms.FolderBrowserDialog FolderBrowser = new Forms.FolderBrowserDialog())
            {
                FolderBrowser.Description = "请选择保存目录";

                if (FolderBrowser.ShowDialog() == Forms.DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(FolderBrowser.SelectedPath))
                    {
                        Forms.MessageBox.Show("文件夹路径不能为空", "提示");
                        return null;
                    }
                }
                return FolderBrowser.SelectedPath;
            }
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
            string[] SampleFilePaths = { @".\Resources\外封面.docx", @".\Resources\报告书.docx", @".\Resources\委托书.docx", @".\Resources\管理表.docx", @".\Resources\流程单.docx" };
            string ProjectName= NamedObjectDictionary.ReadFromNOD(lib.AppConfig.ProjectInfoName[1]);
            string FolderPath = Interaction.GetFolderPath();

            if (strOld.Length == strNew.Length)
            {
                using (Spire.Doc.Document doc = new Spire.Doc.Document())
                {
                    foreach (string SampleFilePath in SampleFilePaths)
                    {
                            string filename = System.IO.Path.GetFileNameWithoutExtension(SampleFilePath)+"-"+ProjectName;//获取文件名
                            string extension = System.IO.Path.GetExtension(SampleFilePath);//获取扩展名
                            string saveFilePath = FolderPath +@"\"+ filename + extension;//合并成完整路径

                            doc.LoadFromFile(SampleFilePath);
                            for (int i = 0; i < strOld.Length; i++)
                            {
                                doc.Replace("[<" + strOld[i] + ">]", strNew[i], false, false);
                            }
                            if (saveFilePath != null)
                            {
                            doc.SaveToFile(saveFilePath);
                                doc.Close();
                            }
                        }
                    }
                }
            else
            {
                Forms.MessageBox.Show("要替换的新旧字符串数量不同，取消操作");
            }
        }
    }
    #endregion

    public class ArrangedPoint3d
    {
        #region 属性
        /// <summary>
        /// X点坐标
        /// </summary>

        //public double X => ExchangeXY ? Point3D.Y : Point3D.X;
        public double X;

        /// <summary>
        /// Y点坐标
        /// </summary>
        public double Y;

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
        private bool ExchangeXY;
        public Point3d PreviousPoint3D;
        public Point3d NextPoint3D;
        public Point3d CurrentPoint3D;

        #endregion
        public ArrangedPoint3d(Point3d point3D, bool ExchangeXY, bool Plus40)
        {
            this.X = Plus40 ? point3D.X + 40000000.0 : point3D.X;

            this.Y = ExchangeXY ? this.X : point3D.Y;
            this.X = ExchangeXY ? point3D.Y : this.X;

            this.ExchangeXY = ExchangeXY;
            this.CurrentPoint3D = point3D;
        }
    }

    public class ArrangedPoint3DArray
    {
        List<ArrangedPoint3d> arrangedPoint3Ds=new List<ArrangedPoint3d>();
        public ArrangedPoint3DArray(Point3d[] point3Ds, int AreaID, int CircleID, int StartBoundaryPointID, bool ExchangeXY, bool Plus40)
        {
            int Length = point3Ds.Length;
            for (int i = 0; i < Length; i++)
            {
                //上一点和下一点
                ArrangedPoint3d arrangedPoint3D = new ArrangedPoint3d(point3Ds[i], ExchangeXY, Plus40);
                if (i == 0)
                {
                    arrangedPoint3D.PreviousPoint3D = point3Ds[Length - 1];
                    arrangedPoint3D.NextPoint3D = point3Ds[1];
                }
                else if (i == Length-1)
                {
                    arrangedPoint3D.PreviousPoint3D = point3Ds[i - 1];
                    arrangedPoint3D.NextPoint3D = point3Ds[0];
                }
                else
                {
                    arrangedPoint3D.PreviousPoint3D = point3Ds[i - 1];
                    arrangedPoint3D.NextPoint3D = point3Ds[i + 1];
                }


                //界址点号赋值
                arrangedPoint3D.BoundaryPointID = StartBoundaryPointID + i;

                //指向点号赋值
                arrangedPoint3D.PointTO = arrangedPoint3D.BoundaryPointID + 1;
                if (arrangedPoint3D.PointTO ==Length+ StartBoundaryPointID)
                {
                    arrangedPoint3D.PointTO = StartBoundaryPointID;
                }

                //地块号赋值
                arrangedPoint3D.AreaID = AreaID;
                //圈号赋值
                arrangedPoint3D.CircleID = CircleID;

                //计算到下一个点的距离
                if (i<Length-1)
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
