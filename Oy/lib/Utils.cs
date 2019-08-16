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
    }
}

