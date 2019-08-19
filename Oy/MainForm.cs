using System;
using Forms = System.Windows.Forms;
using ApplicationServices=Autodesk.AutoCAD.ApplicationServices;
using DatabaseServices=Autodesk.AutoCAD.DatabaseServices;
using EditorInput=Autodesk.AutoCAD.EditorInput;
using Runtime=Autodesk.AutoCAD.Runtime;
using win=Autodesk.AutoCAD.Windows;
namespace Oy.CAD2006.GUI
{
    public partial class MainForm : Forms.Form
    {
        /// <summary>
        /// 初始化form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 保存文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFIleButton_Click(object sender, EventArgs e)
        {
            string filePath = new Utils.InterOperation().GetFilePath();
            textBox1.Text = filePath;
            if (filePath != null)
            {
                lib.Excel excel = new lib.Excel();
                excel.SaveExcel(filePath);
            }

        }

        private void PingButton_Click(object sender, EventArgs e)
        {
            string pingAddress = textBox1.Text;
            if (pingAddress.Length > 0)
            {
                bool pingResult = new Utils.Server().Ping(pingAddress);
                if (pingResult == true && pingAddress.Length > 0)
                {
                    Forms.MessageBox.Show("成功");
                }
                else
                {
                    Forms.MessageBox.Show("失败");
                }
            }
            else
            {
                Forms.MessageBox.Show("未输入内容");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // this is not mandatory
            ApplicationServices.Document document = ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            EditorInput.PromptSelectionResult promptSelectionResult = document.Editor.GetSelection();
            if (promptSelectionResult.Status==EditorInput.PromptStatus.OK)
            {
                document.Editor.WriteMessage(promptSelectionResult.Value.Count.ToString() + "\n");
            }
            this.Show(); // this is mandatory if the form have been hidden
        }

        private void WriteXrecord_Click(object sender, EventArgs e)
        {
            Utils.NamedObjectDictionary.WriteToNOD("项目名称2", "浙江省温州市瓯海区郭溪街道浦北村南浦路130号2");
        }
    }
}
