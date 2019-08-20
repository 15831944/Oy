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
            if (promptSelectionResult.Status == EditorInput.PromptStatus.OK)
            {
                document.Editor.WriteMessage(promptSelectionResult.Value.Count.ToString() + "\n");
            }
            this.Show(); // this is mandatory if the form have been hidden
        }

        private void WriteXrecord_Click(object sender, EventArgs e)
        {
            Utils.NamedObjectDictionary.WriteToNOD("项目编号",textBox2.Text);
            Utils.NamedObjectDictionary.WriteToNOD("项目名称",textBox3.Text);
            Utils.NamedObjectDictionary.WriteToNOD("委托单位",textBox4.Text);
            Utils.NamedObjectDictionary.WriteToNOD("街道",textBox5.Text);
            Utils.NamedObjectDictionary.WriteToNOD("村",textBox6.Text);
            Utils.NamedObjectDictionary.WriteToNOD("制图人员",textBox7.Text);
            Utils.NamedObjectDictionary.WriteToNOD("检查人员",textBox8.Text);
            Utils.NamedObjectDictionary.WriteToNOD("审核人员",textBox9.Text);
            Utils.NamedObjectDictionary.WriteToNOD("坐标系",textBox10.Text);
            Utils.NamedObjectDictionary.WriteToNOD("年",textBox11.Text);
            Utils.NamedObjectDictionary.WriteToNOD("月",textBox12.Text);
            Utils.NamedObjectDictionary.WriteToNOD("日",textBox13.Text);
        }

        private void ReadXrecord_Click(object sender, EventArgs e)
        {
            Utils.NamedObjectDictionary.ReadFromNOD("项目编号");
            Utils.NamedObjectDictionary.ReadFromNOD("项目名称");
            Utils.NamedObjectDictionary.ReadFromNOD("委托单位");
            Utils.NamedObjectDictionary.ReadFromNOD("街道");
            Utils.NamedObjectDictionary.ReadFromNOD("村");
            Utils.NamedObjectDictionary.ReadFromNOD("制图人员");
            Utils.NamedObjectDictionary.ReadFromNOD("检查人员");
            Utils.NamedObjectDictionary.ReadFromNOD("审核人员");
            Utils.NamedObjectDictionary.ReadFromNOD("坐标系");
            Utils.NamedObjectDictionary.ReadFromNOD("年");
            Utils.NamedObjectDictionary.ReadFromNOD("月");
            Utils.NamedObjectDictionary.ReadFromNOD("日");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Utils.NamedObjectDictionary.ReadFromNOD("街道")!="")
            {
                this.readXrecord.PerformClick();
            }
        }
    }
}
