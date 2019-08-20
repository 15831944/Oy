using System;
using ApplicationServices = Autodesk.AutoCAD.ApplicationServices;
using EditorInput = Autodesk.AutoCAD.EditorInput;
using Forms = System.Windows.Forms;
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            readXrecord.PerformClick();
        }

        /// <summary>
        /// 保存文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFIleButton_Click(object sender, EventArgs e)
        {
            string filePath = new Utils.InterOperation().GetFilePath();
            AddressTextBox.Text = filePath;
            if (filePath != null)
            {
                lib.Excel excel = new lib.Excel();
                excel.SaveExcel(filePath);
            }

        }

        private void PingButton_Click(object sender, EventArgs e)
        {
            string pingAddress = AddressTextBox.Text;
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



        #region:buttonClickEvent
        #region:hideButton_Click
        private void HideButton_Click(object sender, EventArgs e)
        {
            Hide(); // this is not mandatory
            ApplicationServices.Document document = ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            EditorInput.PromptSelectionResult promptSelectionResult = document.Editor.GetSelection();
            if (promptSelectionResult.Status == EditorInput.PromptStatus.OK)
            {
                document.Editor.WriteMessage(promptSelectionResult.Value.Count.ToString() + "\n");
            }
            Show(); // this is mandatory if the form have been hidden
        }
        #endregion:hideButton_Click

        private void WriteXrecord_Click(object sender, EventArgs e)
        {
            string[] tKey = Utils.NamedObjectDictionary.tKey;
            for (int i = 0; i <= 11; i++)
            {
                Forms.TextBox textBox = (Forms.TextBox)Controls["infoBox" + i.ToString()];
                Utils.NamedObjectDictionary.WriteToNOD(tKey[i], textBox.Text);
            }
        }
        private void ReadXrecord_Click(object sender, EventArgs e)
        {
            string[] tValue = Utils.NamedObjectDictionary.ReadFromNODAll();
            for (int i = 0; i < tValue.Length; i++)
            {
                Forms.TextBox textBox = (Forms.TextBox)Controls["infoBox" + i.ToString()];
                textBox.Text = tValue[i];
            }
        }
        #endregion


    }
}