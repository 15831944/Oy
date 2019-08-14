using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Oy.CAD2006
{
    class Utils
    {
        internal static void OpenFileWithConfirmDialog(string filePath, string text = "是否打开文件?", string caption = "打开文件")
        {
            DialogResult dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //打卡excel文件
            if (dialogResult.Equals(DialogResult.Yes))
            {
                Process.Start(filePath);
            }
        }

        //弹出重拾对话框
        internal static DialogResult RetryDialog()
        {
            DialogResult dialogResult = MessageBox.Show("文件在被使用", "无法保持", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
            return dialogResult;
        }
    }
}

