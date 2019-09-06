namespace Oy.CAD2006.GUI
{
    partial class GeneralForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.infoLabel0 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.项目编号 = new System.Windows.Forms.TextBox();
            this.项目名称 = new System.Windows.Forms.TextBox();
            this.infoLabel11 = new System.Windows.Forms.Label();
            this.委托单位 = new System.Windows.Forms.TextBox();
            this.infoLabel10 = new System.Windows.Forms.Label();
            this.制图人员 = new System.Windows.Forms.TextBox();
            this.infoLabel9 = new System.Windows.Forms.Label();
            this.街道_乡镇 = new System.Windows.Forms.TextBox();
            this.infoLabel8 = new System.Windows.Forms.Label();
            this.村落_社区 = new System.Windows.Forms.TextBox();
            this.infoLabel7 = new System.Windows.Forms.Label();
            this.infoLabel5 = new System.Windows.Forms.Label();
            this.检查人员 = new System.Windows.Forms.TextBox();
            this.infoLabel6 = new System.Windows.Forms.Label();
            this.审核人员 = new System.Windows.Forms.TextBox();
            this.infoLabel4 = new System.Windows.Forms.Label();
            this.坐标系统 = new System.Windows.Forms.TextBox();
            this.日期_年 = new System.Windows.Forms.TextBox();
            this.infoLabel3 = new System.Windows.Forms.Label();
            this.日期_月 = new System.Windows.Forms.TextBox();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.日期_日 = new System.Windows.Forms.TextBox();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.readXrecord = new System.Windows.Forms.Button();
            this.writeXrecord = new System.Windows.Forms.Button();
            this.pickButton = new System.Windows.Forms.Button();
            this.PingButton = new System.Windows.Forms.Button();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.ExchangeXY = new System.Windows.Forms.CheckBox();
            this.Plus40 = new System.Windows.Forms.CheckBox();
            this.polygonizationButton = new System.Windows.Forms.Button();
            this.polygonizationLengthtextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.infoLabel0);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.项目编号);
            this.panel1.Controls.Add(this.项目名称);
            this.panel1.Controls.Add(this.infoLabel11);
            this.panel1.Controls.Add(this.委托单位);
            this.panel1.Controls.Add(this.infoLabel10);
            this.panel1.Controls.Add(this.制图人员);
            this.panel1.Controls.Add(this.infoLabel9);
            this.panel1.Controls.Add(this.街道_乡镇);
            this.panel1.Controls.Add(this.infoLabel8);
            this.panel1.Controls.Add(this.村落_社区);
            this.panel1.Controls.Add(this.infoLabel7);
            this.panel1.Controls.Add(this.infoLabel5);
            this.panel1.Controls.Add(this.检查人员);
            this.panel1.Controls.Add(this.infoLabel6);
            this.panel1.Controls.Add(this.审核人员);
            this.panel1.Controls.Add(this.infoLabel4);
            this.panel1.Controls.Add(this.坐标系统);
            this.panel1.Controls.Add(this.日期_年);
            this.panel1.Controls.Add(this.infoLabel3);
            this.panel1.Controls.Add(this.日期_月);
            this.panel1.Controls.Add(this.infoLabel2);
            this.panel1.Controls.Add(this.日期_日);
            this.panel1.Controls.Add(this.infoLabel1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 413);
            this.panel1.TabIndex = 42;
            // 
            // infoLabel0
            // 
            this.infoLabel0.Location = new System.Drawing.Point(8, 8);
            this.infoLabel0.Name = "infoLabel0";
            this.infoLabel0.Size = new System.Drawing.Size(60, 15);
            this.infoLabel0.TabIndex = 19;
            this.infoLabel0.Text = "项目编号";
            this.infoLabel0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(74, 330);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(205, 21);
            this.dateTimePicker1.TabIndex = 20;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.DateTimePicker1_ValueChanged);
            // 
            // 项目编号
            // 
            this.项目编号.BackColor = System.Drawing.SystemColors.Control;
            this.项目编号.Location = new System.Drawing.Point(74, 6);
            this.项目编号.Name = "项目编号";
            this.项目编号.Size = new System.Drawing.Size(205, 21);
            this.项目编号.TabIndex = 7;
            this.项目编号.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 项目名称
            // 
            this.项目名称.BackColor = System.Drawing.SystemColors.Control;
            this.项目名称.Location = new System.Drawing.Point(74, 33);
            this.项目名称.Name = "项目名称";
            this.项目名称.Size = new System.Drawing.Size(205, 21);
            this.项目名称.TabIndex = 8;
            this.项目名称.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoLabel11
            // 
            this.infoLabel11.Location = new System.Drawing.Point(8, 305);
            this.infoLabel11.Name = "infoLabel11";
            this.infoLabel11.Size = new System.Drawing.Size(60, 15);
            this.infoLabel11.TabIndex = 30;
            this.infoLabel11.Text = "日期_日";
            this.infoLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 委托单位
            // 
            this.委托单位.BackColor = System.Drawing.SystemColors.Control;
            this.委托单位.Location = new System.Drawing.Point(74, 60);
            this.委托单位.Name = "委托单位";
            this.委托单位.Size = new System.Drawing.Size(205, 21);
            this.委托单位.TabIndex = 9;
            this.委托单位.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoLabel10
            // 
            this.infoLabel10.Location = new System.Drawing.Point(8, 278);
            this.infoLabel10.Name = "infoLabel10";
            this.infoLabel10.Size = new System.Drawing.Size(60, 15);
            this.infoLabel10.TabIndex = 29;
            this.infoLabel10.Text = "日期_月";
            this.infoLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 制图人员
            // 
            this.制图人员.BackColor = System.Drawing.SystemColors.Control;
            this.制图人员.Location = new System.Drawing.Point(74, 141);
            this.制图人员.Name = "制图人员";
            this.制图人员.Size = new System.Drawing.Size(205, 21);
            this.制图人员.TabIndex = 12;
            this.制图人员.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoLabel9
            // 
            this.infoLabel9.Location = new System.Drawing.Point(8, 251);
            this.infoLabel9.Name = "infoLabel9";
            this.infoLabel9.Size = new System.Drawing.Size(60, 15);
            this.infoLabel9.TabIndex = 28;
            this.infoLabel9.Text = "日期_年";
            this.infoLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 街道_乡镇
            // 
            this.街道_乡镇.BackColor = System.Drawing.SystemColors.Control;
            this.街道_乡镇.Location = new System.Drawing.Point(74, 114);
            this.街道_乡镇.Name = "街道_乡镇";
            this.街道_乡镇.Size = new System.Drawing.Size(205, 21);
            this.街道_乡镇.TabIndex = 11;
            this.街道_乡镇.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoLabel8
            // 
            this.infoLabel8.Location = new System.Drawing.Point(8, 224);
            this.infoLabel8.Name = "infoLabel8";
            this.infoLabel8.Size = new System.Drawing.Size(60, 15);
            this.infoLabel8.TabIndex = 27;
            this.infoLabel8.Text = "坐标系统";
            this.infoLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 村落_社区
            // 
            this.村落_社区.BackColor = System.Drawing.SystemColors.Control;
            this.村落_社区.Location = new System.Drawing.Point(74, 87);
            this.村落_社区.Name = "村落_社区";
            this.村落_社区.Size = new System.Drawing.Size(205, 21);
            this.村落_社区.TabIndex = 10;
            this.村落_社区.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoLabel7
            // 
            this.infoLabel7.Location = new System.Drawing.Point(8, 197);
            this.infoLabel7.Name = "infoLabel7";
            this.infoLabel7.Size = new System.Drawing.Size(60, 15);
            this.infoLabel7.TabIndex = 26;
            this.infoLabel7.Text = "审核人员";
            this.infoLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel5
            // 
            this.infoLabel5.Location = new System.Drawing.Point(8, 143);
            this.infoLabel5.Name = "infoLabel5";
            this.infoLabel5.Size = new System.Drawing.Size(60, 15);
            this.infoLabel5.TabIndex = 23;
            this.infoLabel5.Text = "制图人员";
            this.infoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 检查人员
            // 
            this.检查人员.BackColor = System.Drawing.SystemColors.Control;
            this.检查人员.Location = new System.Drawing.Point(74, 168);
            this.检查人员.Name = "检查人员";
            this.检查人员.Size = new System.Drawing.Size(205, 21);
            this.检查人员.TabIndex = 13;
            this.检查人员.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoLabel6
            // 
            this.infoLabel6.Location = new System.Drawing.Point(8, 170);
            this.infoLabel6.Name = "infoLabel6";
            this.infoLabel6.Size = new System.Drawing.Size(60, 15);
            this.infoLabel6.TabIndex = 25;
            this.infoLabel6.Text = "检查人员";
            this.infoLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 审核人员
            // 
            this.审核人员.BackColor = System.Drawing.SystemColors.Control;
            this.审核人员.Location = new System.Drawing.Point(74, 195);
            this.审核人员.Name = "审核人员";
            this.审核人员.Size = new System.Drawing.Size(205, 21);
            this.审核人员.TabIndex = 14;
            this.审核人员.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoLabel4
            // 
            this.infoLabel4.Location = new System.Drawing.Point(8, 116);
            this.infoLabel4.Name = "infoLabel4";
            this.infoLabel4.Size = new System.Drawing.Size(60, 15);
            this.infoLabel4.TabIndex = 24;
            this.infoLabel4.Text = "街道_乡镇";
            this.infoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 坐标系统
            // 
            this.坐标系统.BackColor = System.Drawing.SystemColors.Control;
            this.坐标系统.Location = new System.Drawing.Point(74, 222);
            this.坐标系统.Name = "坐标系统";
            this.坐标系统.Size = new System.Drawing.Size(205, 21);
            this.坐标系统.TabIndex = 15;
            this.坐标系统.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 日期_年
            // 
            this.日期_年.BackColor = System.Drawing.SystemColors.Control;
            this.日期_年.Location = new System.Drawing.Point(74, 249);
            this.日期_年.Name = "日期_年";
            this.日期_年.Size = new System.Drawing.Size(205, 21);
            this.日期_年.TabIndex = 17;
            this.日期_年.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoLabel3
            // 
            this.infoLabel3.Location = new System.Drawing.Point(8, 89);
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(60, 15);
            this.infoLabel3.TabIndex = 22;
            this.infoLabel3.Text = "村落_社区";
            this.infoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 日期_月
            // 
            this.日期_月.BackColor = System.Drawing.SystemColors.Control;
            this.日期_月.Location = new System.Drawing.Point(74, 276);
            this.日期_月.Name = "日期_月";
            this.日期_月.Size = new System.Drawing.Size(205, 21);
            this.日期_月.TabIndex = 18;
            this.日期_月.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoLabel2
            // 
            this.infoLabel2.Location = new System.Drawing.Point(8, 62);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(60, 15);
            this.infoLabel2.TabIndex = 21;
            this.infoLabel2.Text = "委托单位";
            this.infoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 日期_日
            // 
            this.日期_日.BackColor = System.Drawing.SystemColors.Control;
            this.日期_日.Location = new System.Drawing.Point(74, 303);
            this.日期_日.Name = "日期_日";
            this.日期_日.Size = new System.Drawing.Size(205, 21);
            this.日期_日.TabIndex = 19;
            this.日期_日.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoLabel1
            // 
            this.infoLabel1.Location = new System.Drawing.Point(8, 35);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(60, 15);
            this.infoLabel1.TabIndex = 20;
            this.infoLabel1.Text = "项目名称";
            this.infoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(700, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "测试(文档)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // readXrecord
            // 
            this.readXrecord.Location = new System.Drawing.Point(700, 20);
            this.readXrecord.Name = "readXrecord";
            this.readXrecord.Size = new System.Drawing.Size(75, 23);
            this.readXrecord.TabIndex = 40;
            this.readXrecord.Text = "读取";
            this.readXrecord.UseVisualStyleBackColor = true;
            this.readXrecord.Click += new System.EventHandler(this.ReadXrecord_Click);
            // 
            // writeXrecord
            // 
            this.writeXrecord.Location = new System.Drawing.Point(619, 20);
            this.writeXrecord.Name = "writeXrecord";
            this.writeXrecord.Size = new System.Drawing.Size(75, 23);
            this.writeXrecord.TabIndex = 39;
            this.writeXrecord.Text = "写入";
            this.writeXrecord.UseVisualStyleBackColor = true;
            this.writeXrecord.Click += new System.EventHandler(this.WriteXrecord_Click);
            // 
            // pickButton
            // 
            this.pickButton.Location = new System.Drawing.Point(538, 20);
            this.pickButton.Name = "pickButton";
            this.pickButton.Size = new System.Drawing.Size(75, 23);
            this.pickButton.TabIndex = 38;
            this.pickButton.Text = "隐藏";
            this.pickButton.UseVisualStyleBackColor = true;
            this.pickButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // PingButton
            // 
            this.PingButton.Location = new System.Drawing.Point(538, 76);
            this.PingButton.Name = "PingButton";
            this.PingButton.Size = new System.Drawing.Size(75, 23);
            this.PingButton.TabIndex = 35;
            this.PingButton.Text = "连接服务器";
            this.PingButton.UseVisualStyleBackColor = true;
            this.PingButton.Click += new System.EventHandler(this.PingButton_Click);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.AddressTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.AddressTextBox.Location = new System.Drawing.Point(538, 49);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AddressTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.AddressTextBox.Size = new System.Drawing.Size(237, 21);
            this.AddressTextBox.TabIndex = 34;
            this.AddressTextBox.Text = "19w07z5654.51mypc.cn";
            this.AddressTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(321, 74);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(75, 23);
            this.SaveFileButton.TabIndex = 36;
            this.SaveFileButton.Text = "保存Excel";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFIleButton_Click);
            // 
            // ExchangeXY
            // 
            this.ExchangeXY.Checked = true;
            this.ExchangeXY.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ExchangeXY.Location = new System.Drawing.Point(321, 26);
            this.ExchangeXY.Name = "ExchangeXY";
            this.ExchangeXY.Size = new System.Drawing.Size(75, 16);
            this.ExchangeXY.TabIndex = 43;
            this.ExchangeXY.Text = "交换XY";
            this.ExchangeXY.UseVisualStyleBackColor = true;
            // 
            // Plus40
            // 
            this.Plus40.Checked = true;
            this.Plus40.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Plus40.Location = new System.Drawing.Point(321, 49);
            this.Plus40.Name = "Plus40";
            this.Plus40.Size = new System.Drawing.Size(75, 16);
            this.Plus40.TabIndex = 44;
            this.Plus40.Text = "添加40";
            this.Plus40.UseVisualStyleBackColor = true;
            // 
            // polygonizationButton
            // 
            this.polygonizationButton.Location = new System.Drawing.Point(321, 144);
            this.polygonizationButton.Name = "polygonizationButton";
            this.polygonizationButton.Size = new System.Drawing.Size(75, 23);
            this.polygonizationButton.TabIndex = 45;
            this.polygonizationButton.Text = "折线化";
            this.polygonizationButton.UseVisualStyleBackColor = true;
            this.polygonizationButton.Click += new System.EventHandler(this.PolygonizationButton_Click);
            // 
            // polygonizationLengthtextBox
            // 
            this.polygonizationLengthtextBox.Location = new System.Drawing.Point(321, 122);
            this.polygonizationLengthtextBox.Name = "polygonizationLengthtextBox";
            this.polygonizationLengthtextBox.Size = new System.Drawing.Size(75, 21);
            this.polygonizationLengthtextBox.TabIndex = 46;
            this.polygonizationLengthtextBox.Text = "2";
            this.polygonizationLengthtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.polygonizationLengthtextBox);
            this.Controls.Add(this.polygonizationButton);
            this.Controls.Add(this.Plus40);
            this.Controls.Add(this.ExchangeXY);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.readXrecord);
            this.Controls.Add(this.writeXrecord);
            this.Controls.Add(this.pickButton);
            this.Controls.Add(this.PingButton);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.SaveFileButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "GeneralForm";
            this.Text = "GeneralForm";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label infoLabel0;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox 项目编号;
        private System.Windows.Forms.TextBox 项目名称;
        private System.Windows.Forms.Label infoLabel11;
        private System.Windows.Forms.TextBox 委托单位;
        private System.Windows.Forms.Label infoLabel10;
        private System.Windows.Forms.TextBox 制图人员;
        private System.Windows.Forms.Label infoLabel9;
        private System.Windows.Forms.TextBox 街道_乡镇;
        private System.Windows.Forms.Label infoLabel8;
        private System.Windows.Forms.TextBox 村落_社区;
        private System.Windows.Forms.Label infoLabel7;
        private System.Windows.Forms.TextBox 检查人员;
        private System.Windows.Forms.Label infoLabel6;
        private System.Windows.Forms.TextBox 审核人员;
        private System.Windows.Forms.Label infoLabel4;
        private System.Windows.Forms.TextBox 坐标系统;
        private System.Windows.Forms.Label infoLabel5;
        private System.Windows.Forms.TextBox 日期_年;
        private System.Windows.Forms.Label infoLabel3;
        private System.Windows.Forms.TextBox 日期_月;
        private System.Windows.Forms.Label infoLabel2;
        private System.Windows.Forms.TextBox 日期_日;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button readXrecord;
        private System.Windows.Forms.Button writeXrecord;
        private System.Windows.Forms.Button pickButton;
        private System.Windows.Forms.Button PingButton;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.CheckBox ExchangeXY;
        private System.Windows.Forms.CheckBox Plus40;
        private System.Windows.Forms.Button polygonizationButton;
        private System.Windows.Forms.TextBox polygonizationLengthtextBox;
    }
}