using DatabaseServices=Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using ApplicationServices = Autodesk.AutoCAD.ApplicationServices;

namespace Oy.CAD2006.lib
{
    /// <summary>
    /// util工具包
    /// </summary>
    class Utils
    {
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        internal void OpenFileWithConfirmDialog(string FilePath, string text = "是否打开文件?", string caption = "打开文件")
        {
            DialogResult dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //打卡excel文件
            if (dialogResult.Equals(DialogResult.Yes))
            {
                Process.Start(FilePath);
            }
        }

        /// <summary>
        /// 弹出重试对话框
        /// </summary>
        /// <returns></returns>
        internal DialogResult RetryDialog()
        {
            DialogResult dialogResult = MessageBox.Show("文件在被使用", "无法保存", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
            return dialogResult;
        }

        /// <summary>
        /// 获取文件保存路径
        /// </summary>
        /// <returns></returns>
        internal string GetFilePath()
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                FileName = "坐标表",//默认文件名
                Filter = "Excel 2007 工作簿(*.xlsx)|*.xlsx|Word 2007 文档(*.docx)|*.docx|所有文件(*.*)|*.*",
                RestoreDirectory = true,
                OverwritePrompt = false
            };
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            saveFileDialog.Dispose();
            if (dialogResult.Equals(DialogResult.OK))
            {
                return saveFileDialog.FileName;
            }
            return null;
        }



        /// <summary>  
        /// 是否能 Ping 通指定的主机  
        /// </summary>  
        /// <param name="ip">ip 地址或主机名或域名</param>  
        /// <returns>true 通，false 不通</returns>  
        internal bool Ping(string ip)
        {
            try
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                int timeout = 5000; // Timeout 时间，单位：毫秒  
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

        public void WriteToNOD()
        {
            using (ApplicationServices.Document doc = ApplicationServices.Application.DocumentManager.MdiActiveDocument)
            {
                DatabaseServices.Database db = doc.Database;
                DatabaseServices.Transaction tr = db.TransactionManager.StartTransaction();
                // 命名对象字典
                DatabaseServices.DBDictionary nod = tr.GetObject(db.NamedObjectsDictionaryId,
                    DatabaseServices.OpenMode.ForWrite) as DatabaseServices.DBDictionary;

                // 自定义数据
                DatabaseServices.Xrecord myXrecord = new DatabaseServices.Xrecord();
                myXrecord.Data = new DatabaseServices.ResultBuffer(
                    new DatabaseServices.TypedValue((int)DatabaseServices.DxfCode.Int32, 520),
                    new DatabaseServices.TypedValue((int)DatabaseServices.DxfCode.Text, "Hello www.caxdev.com"));

                // 往命名对象字典中存储自定义数据
                nod.SetAt("MyData", myXrecord);

                tr.AddNewlyCreatedDBObject(myXrecord, true);
                tr.Commit();
            }
        }

        public void ReadNOD()
        {
            ApplicationServices.Document doc = ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            DatabaseServices.Database db = doc.Database;

            using (DatabaseServices.Transaction tr = db.TransactionManager.StartTransaction())
            {
                // 命名对象字典
                DatabaseServices.DBDictionary nod = tr.GetObject(db.NamedObjectsDictionaryId,
                    DatabaseServices.OpenMode.ForWrite) as DatabaseServices.DBDictionary;

                // 查找自定义数据
                if (nod.Contains("MyData"))
                {
                    DatabaseServices.ObjectId myDataId = nod.GetAt("MyData");
                    DatabaseServices.Xrecord myXrecord = tr.GetObject(myDataId, DatabaseServices.OpenMode.ForRead) as DatabaseServices.Xrecord;

                    foreach (DatabaseServices.TypedValue tv in myXrecord.Data)
                    {
                        doc.Editor.WriteMessage("type: {0}, value: {1}\n", tv.TypeCode, tv.Value);
                    }
                }
            }
        }
    }
}

