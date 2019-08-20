using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Diagnostics;
using Forms = System.Windows.Forms;

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
            Database db = document.Database;
            using (Transaction transaction = db.TransactionManager.StartTransaction())
            {
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
    class InterOperation
    {
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        public void SaveFileDialog(string FilePath)
        {
            Forms.DialogResult dialogResult = Forms.MessageBox.Show("是否打开文件?", "打开文件", Forms.MessageBoxButtons.YesNo, Forms.MessageBoxIcon.Question);
            //打卡excel文件
            if (dialogResult.Equals(Forms.DialogResult.Yes))
            {
                Process.Start(FilePath);
            }
        }

        /// <summary>
        /// 弹出重试对话框
        /// </summary>
        /// <returns></returns>
        public System.Windows.Forms.DialogResult RetryDialog()
        {
            var dialogResult = System.Windows.Forms.MessageBox.Show("文件在被使用", "无法保存", Forms.MessageBoxButtons.RetryCancel, Forms.MessageBoxIcon.Asterisk);
            return dialogResult;
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
                Filter = "Excel 2007 工作簿(*.xlsx)|*.xlsx|Word 2007 文档(*.docx)|*.docx|所有文件(*.*)|*.*",
                RestoreDirectory = true,
                OverwritePrompt = false
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
        public void WordReplace(string filePath, string[] strOld, string[] strNew)
        {


            if (strOld.Length==strNew.Length)
            {
                Spire.Doc.Document doc = new Spire.Doc.Document();
                doc.LoadFromFile(filePath);
                for (int i = 0; i < strOld.Length; i++)
                {
                    doc.Replace(strOld[i], strNew[i], false, false);
                }

                doc.SaveToFile(filePath);
                doc.Close();
            }
            else
            {
                Forms.MessageBox.Show("要替换的新旧字符串数量不同，取消操作");
            }
        }
    }
    #endregion




}