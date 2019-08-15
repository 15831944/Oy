using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Oy.CAD2006.lib
{
    class Utils
    {
        //打开文件确认框
        internal void OpenFileWithConfirmDialog(string FilePath, string text = "是否打开文件?", string caption = "打开文件")
        {
            DialogResult dialogResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //打卡excel文件
            if (dialogResult.Equals(DialogResult.Yes))
            {
                Process.Start(FilePath);
            }
        }

        //弹出重拾对话框
        internal DialogResult RetryDialog()
        {
            DialogResult dialogResult = MessageBox.Show("文件在被使用", "无法保存", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
            return dialogResult;
        }
    }
}

