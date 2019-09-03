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
            List<string> ProjectInfoName = lib.AppConfig.ProjectInfoName.ToList();
            ///自动保存输入内容
            foreach (Forms.Control control in this.panel1.Controls)
            {
                if (control is Forms.TextBox textBox)
                {
                    textBox.TextChanged += WriteXrecord_Click;
                    textBox.Name = ProjectInfoName[0];
                    ProjectInfoName.RemoveAt(0);
                }
            }




            //ProjectInfoName = lib.AppConfig.ProjectInfoName.ToList();
            //foreach (Forms.Control control in this.panel1.Controls)
            //{
            //    if (control is Forms.Label label)
            //    {
            //        label.Text = ProjectInfoName[0];
            //        ProjectInfoName.RemoveAt(0);
            //    }
            //}




            readXrecord.PerformClick();
        }

        #region:单击事件
        private void SaveFIleButton_Click(object sender, EventArgs e)
        {
            ObjectId[] objectId = Interaction.GetSelection("\n选择多段线", "LWPOLYLINE");
            if (objectId.Length==0)
            {
                Interaction.WriteLine("取消");
                return;
            }

            List<TableData> tableDataList = new List<TableData>();
            int StartBoundaryPointID = 1;
            objectId.QForEach<Polyline>(polyline =>
            {
                int count = Algorithms.PolyClean_ReducePoints(polyline, lib.AppConfig.ReduceVertexEpsilon);//删除重复点
                var point3Ds = polyline.GetPolyPoints().ToArray();
                double Area = Math.Round(polyline.Area, lib.AppConfig.AreaPrecision); //获取面积

                //TODO:blockID和LabelName暂时是随便填写的
                TableData tableData = new TableData(point3Ds, Area, (int)polyline.Handle.Value, 1, StartBoundaryPointID, polyline.Handle.Value.ToString());
                StartBoundaryPointID += point3Ds.Length;
                tableDataList.Add(tableData);
            });

            string saveFilePath = new Utils.Interaction().GetFilePath();
            if (saveFilePath != null)
            {
                Points2Excel excel2 = new Points2Excel(saveFilePath,
                                                       tableDataList.ToArray(),
                                                       Utils.NamedObjectDictionary.ReadFromNOD(lib.AppConfig.ProjectInfoName[1]),
                                                       Utils.NamedObjectDictionary.ReadFromNOD(lib.AppConfig.ProjectInfoName[0]),
                                                       this.ExchangeXY.Checked,
                                                       this.Plus40.Checked);
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