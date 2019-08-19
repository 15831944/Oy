using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Diagnostics;
using Forms = System.Windows.Forms;

namespace Oy.CAD2006.Utils
{
    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// </summary>
    class NamedObjectDictionary
    {
        /// <summary>
        /// 写入字典
        /// </summary>
        public static void WriteToNOD(string NodKey, string NodValue)
        {
            Document document = Application.DocumentManager.MdiActiveDocument;
            Database db = document.Database;
            //try
            //{
            using (Transaction transaction = db.TransactionManager.StartTransaction())
            {
                // 命名对象字典
                DBDictionary nod = transaction.GetObject(db.NamedObjectsDictionaryId,
                    OpenMode.ForWrite) as DBDictionary;

                // 自定义数据
                Xrecord OyXrecord = new Xrecord
                {
                    Data = new ResultBuffer(
                    new TypedValue((int)DxfCode.Text, NodKey),
                    new TypedValue((int)DxfCode.Text, NodValue))
                };

                // 往命名对象字典中存储自定义数据
                nod.SetAt("OyXrecord", OyXrecord);
                transaction.AddNewlyCreatedDBObject(OyXrecord, true);
                transaction.Commit();
                // Now let's read the data back and print them out 
                //  to the Visual Studio's Output window
                //ObjectId myDataId = nod.GetAt("OyXrecord");
                //Xrecord readBack = (Xrecord)transaction.GetObject(
                //                              myDataId, OpenMode.ForRead);
                //foreach (TypedValue typedValue in readBack.Data)
                //    document.Editor.WriteMessage(
                //              "===== OUR DATA: " + typedValue.TypeCode
                //              + ". " + typedValue.Value.ToString()
                //              );

            }
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }


        /// <summary>
        /// 读取字典
        /// </summary>
        public void ReadFromNOD()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                // 命名对象字典
                DBDictionary nod = tr.GetObject(db.NamedObjectsDictionaryId,
                    OpenMode.ForWrite) as DBDictionary;

                // 查找自定义数据
                if (nod.Contains("MyData"))
                {
                    ObjectId myDataId = nod.GetAt("MyData");
                    Xrecord myXrecord = tr.GetObject(myDataId, OpenMode.ForRead) as Xrecord;
                    foreach (TypedValue tv in myXrecord.Data)
                    {
                        doc.Editor.WriteMessage("type: {0}, value: {1}\n", tv.TypeCode, tv.Value);
                    }
                }
                Forms.MessageBox.Show("读取成功");
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
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
}