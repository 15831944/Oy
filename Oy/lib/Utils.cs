using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Oy.CAD2006.lib
{
    /// <summary>
    /// util工具包
    /// </summary>
    class Utils
    {
        /// <summary>
        /// 打开文件确认框
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
    }
}

