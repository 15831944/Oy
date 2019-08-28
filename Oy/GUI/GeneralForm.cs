using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Forms=System.Windows.Forms;
using ApplicationServices = Autodesk.AutoCAD.ApplicationServices;
using EditorInput = Autodesk.AutoCAD.EditorInput;

namespace Oy.CAD2006.GUI
{
    public partial class GeneralForm : Forms.Form
    {
        public GeneralForm()
        {
            InitializeComponent();
        }
        private void TempForm_Load(object sender, EventArgs e)
        {
            readXrecord.PerformClick();

            ///自动保存输入内容
            foreach (Forms.Control control in this.panel1.Controls)
            {
                if (control is Forms.TextBox)
                {
                    (control as Forms.TextBox).TextChanged += WriteXrecord_Click;
                }
            }
        }

        #region:单击事件
        private void SaveFIleButton_Click(object sender, EventArgs e)
        {
            string filePath = new Utils.Interaction().GetFilePath();
            AddressTextBox.Text = filePath;
            if (filePath != null)
            {
                Points2Excel excel2 = new Points2Excel(filePath, Utils.ConfigArray.tableDataArray,
                    "潘桥街道横塘村城中村改造工程二期(低效用地)", "NZ-2019-123");
                excel2.Save();
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
        private void HideButton_Click(object sender, EventArgs e)
        {
            Parent.Parent.Parent.Hide(); // this is not mandatory
            ApplicationServices.Document document = ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            EditorInput.PromptSelectionResult promptSelectionResult = document.Editor.GetSelection();
            if (promptSelectionResult.Status == EditorInput.PromptStatus.OK)
            {
                document.Editor.WriteMessage(promptSelectionResult.Value.Count.ToString() + "\n");
            }
            Parent.Parent.Parent.Show(); // this is mandatory if the form have been hidden
        }

        private void WriteXrecord_Click(object sender, EventArgs e)
        {
            string[] tKey = Utils.NamedObjectDictionary.tKey;
            for (int i = 0; i <= 11; i++)
            {
                Forms.TextBox textBox = (Forms.TextBox)panel1.Controls["infoBox" + i.ToString()];
                Utils.NamedObjectDictionary.WriteToNOD(tKey[i], textBox.Text);
            }
        }
        private void ReadXrecord_Click(object sender, EventArgs e)
        {
            string[] tValue = Utils.NamedObjectDictionary.ReadFromNODAll();
            for (int i = 0; i < tValue.Length; i++)
            {
                Forms.TextBox textBox = (Forms.TextBox)panel1.Controls["infoBox" + i.ToString()];
                textBox.Text = tValue[i];
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] strOld = Utils.NamedObjectDictionary.tKey;
            string[] strNew = Utils.NamedObjectDictionary.ReadFromNODAll();
            Utils.Word word = new Utils.Word();
            word.WordReplace(strOld, strNew);
            this.AddressTextBox.Text = "完成";
        }
        #endregion

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.infoBox9.Text = dateTimePicker1.Value.Year.ToString() + "年";
            this.infoBox10.Text = dateTimePicker1.Value.Month.ToString() + "月";
            this.infoBox11.Text = dateTimePicker1.Value.Day.ToString() + "日";
        }
    }
}
