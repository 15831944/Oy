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
using Autodesk.AutoCAD.DatabaseServices;
using AutoCADCommands;

namespace Oy.CAD2006.GUI
{
    public partial class GeneralForm : Forms.Form
    {
        public GeneralForm()
        {
            InitializeComponent();
        }
        private void Form_Load(object sender, EventArgs e)
        {
            //List<string> ProjectInfoName = lib.AppConfig.ProjectInfoName.ToList();
            ///自动保存输入内容
            foreach (Forms.Control control in this.panel1.Controls)
            {
                if (control is Forms.TextBox textBox)
                {
                    textBox.TextChanged += WriteXrecord_Click;
                    //textBox.Name = ProjectInfoName[0];
                    //ProjectInfoName.RemoveAt(0);
                }
            }
            readXrecord.PerformClick();
        }

        #region:单击事件
        private void SaveFIleButton_Click(object sender, EventArgs e)
        {
            
            ObjectId[] objectId = Interaction.GetSelection("\n选择多段线", "LWPOLYLINE");//选择多段线
            if (objectId.Length == 0) return;//一个都没选的情况下退出操作

            string saveFilePath = Utils.Interaction.GetFilePath();
            if (saveFilePath != null)
            {
                new Points2Excel(saveFilePath,
                                 objectId,
                                 ExchangeXY.Checked,
                                 Plus40.Checked)
                                .Save();
            }
        }

        private void PingButton_Click(object sender, EventArgs e)
        {
            string pingAddress = AddressTextBox.Text;
            if (pingAddress.Length > 0)
                _ = new Utils.Server().Ping(pingAddress) ? Forms.MessageBox.Show("成功") : Forms.MessageBox.Show("失败");
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

        //写入Xrecord
        private void WriteXrecord_Click(object sender, EventArgs e)
        {
            Forms.TextBox textBox = sender as Forms.TextBox;
            Utils.NamedObjectDictionary.WriteToNOD(textBox.Name, textBox.Text);
        }

        //读取并显示Xrecord
        private void ReadXrecord_Click(object sender, EventArgs e)
        {
            foreach (Forms.Control control in this.panel1.Controls)
            {
                if (control is Forms.TextBox textBox)
                {
                    textBox.Text = Utils.NamedObjectDictionary.ReadFromNOD(textBox.Name);
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string[] strOld = lib.AppConfig.ProjectInfoName;
            string[] strNew = Utils.NamedObjectDictionary.ReadFromNODAll();
            Utils.Word word = new Utils.Word();
            word.WordReplace(strOld, strNew);
            Forms.MessageBox.Show("完成");
        }
        #endregion

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.日期_年.Text = dateTimePicker1.Value.Year.ToString() + "年";
            this.日期_月.Text = dateTimePicker1.Value.Month.ToString() + "月";
            this.日期_日.Text = dateTimePicker1.Value.Day.ToString() + "日";
        }

        private void PolygonizationButton_Click(object sender, EventArgs e)
        {
            double n;
            try
            {
                 n = double.Parse(polygonizationLengthtextBox.Text);
            }
            catch (Exception)
            {
                Forms.MessageBox.Show("请输入数字");
                return;
            }
            ObjectId[] ids = Interaction.GetSelection("\n选择多段线", "LWPOLYLINE");
            var entsToAdd = new List<Polyline>();
            ids.QForEach<Polyline>(poly =>
            {
                var pts = poly.GetPolylineDivPoints(n);
                var poly1 = NoDraw.Pline(pts);
                poly1.Layer = poly.Layer;
                try
                {
                    poly1.ConstantWidth = poly.ConstantWidth;
                }
                catch
                {
                }
                poly1.XData = poly.XData;
                poly.Erase();
                entsToAdd.Add(poly1);
            });
            entsToAdd.ToArray().AddToCurrentSpace();
            Interaction.WriteLine("{0} handled.", entsToAdd.Count);

            (Parent.Parent.Parent as Forms.Form).Close();
        }
    }
}