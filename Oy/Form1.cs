using System;
using System.Windows.Forms;

namespace Oy.CAD2006
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //保存文件按钮
        private void Button1_Click(object sender, EventArgs e)
        {
            string FilePath = GetFilePath();
            if (FilePath != null)
            {
                lib.Excel excel= new lib.Excel();
                excel.SaveExcel(FilePath);
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }


 

        //获取文件保存路径
        private string GetFilePath()
        {
            this.saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            this.saveFileDialog1.FileName = "坐标表";
            this.saveFileDialog1.Filter = "Excel 2007 工作簿(*.xlsx)|*.xlsx|Word 2007 文档(*.docx)|*.docx|所有文件(*.*)|*.*";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.OverwritePrompt = false;
            DialogResult dialogResult = this.saveFileDialog1.ShowDialog();
            if (dialogResult.Equals(DialogResult.OK) && saveFileDialog1.FileName.Length > 0)
            {
                return this.textBox1.Text = this.saveFileDialog1.FileName;
            }
            return null;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
