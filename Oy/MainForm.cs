using System;
using Forms = System.Windows.Forms;
using ApplicationServices=Autodesk.AutoCAD.ApplicationServices;
using DatabaseServices=Autodesk.AutoCAD.DatabaseServices;
using EditorInput=Autodesk.AutoCAD.EditorInput;
using Runtime=Autodesk.AutoCAD.Runtime;
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
            //this.WindowState = FormWindowState.Minimized;
            //this.SetVisibleCore(false);
            this.Hide(); // this is not mandatory


            ApplicationServices.Document document = ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            document.Editor.WriteMessage(document.Editor.GetSelection().Value.Count.ToString()+"\n");
            //ApplicationServices.Document document = ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            //EditorInput.Editor editor = document.Editor;
            //EditorInput.PromptPointResult ppr = editor.GetPoint("\n选取第一个点 ");
            //using (doc.LockDocument()) // this is needed from a modeless form
            //{
            // set focus to AutoCAD
            // do your stuff here
            // ...
            //}
            this.Show(); // this is mandatory if the form have been hidden
        }
    }
}
