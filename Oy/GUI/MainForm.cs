using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oy.CAD2006.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            AddFormToTagPage(new GeneralForm(), GeneralTabPage);
        }

        /// <summary>
        /// 将子窗体绑定至标签页
        /// </summary>
        /// <param name="tabPage">标签页</param>
        /// <param name="form">子窗体</param>
        private void AddFormToTagPage(Form form,TabPage tabPage)
        {
            form.TopLevel = false;      //设置为非顶级控件
            tabPage.Controls.Add(form);
            form.Show();               //让窗体form显示出来
            form.FormBorderStyle = FormBorderStyle.None;  //外边框干掉
        }
    }
}
