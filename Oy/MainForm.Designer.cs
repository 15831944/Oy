namespace Oy.CAD2006.GUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.PingButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.pickButton = new System.Windows.Forms.Button();
            this.writeXrecord = new System.Windows.Forms.Button();
            this.readXrecord = new System.Windows.Forms.Button();
            this.infoBox0 = new System.Windows.Forms.TextBox();
            this.infoBox1 = new System.Windows.Forms.TextBox();
            this.infoBox2 = new System.Windows.Forms.TextBox();
            this.infoBox3 = new System.Windows.Forms.TextBox();
            this.infoBox5 = new System.Windows.Forms.TextBox();
            this.infoBox4 = new System.Windows.Forms.TextBox();
            this.infoBox6 = new System.Windows.Forms.TextBox();
            this.infoBox7 = new System.Windows.Forms.TextBox();
            this.infoBox8 = new System.Windows.Forms.TextBox();
            this.infoBox9 = new System.Windows.Forms.TextBox();
            this.infoBox10 = new System.Windows.Forms.TextBox();
            this.infoBox11 = new System.Windows.Forms.TextBox();
            this.infoLabel0 = new System.Windows.Forms.Label();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.infoLabel3 = new System.Windows.Forms.Label();
            this.infoLabel4 = new System.Windows.Forms.Label();
            this.infoLabel5 = new System.Windows.Forms.Label();
            this.infoLabel6 = new System.Windows.Forms.Label();
            this.infoLabel7 = new System.Windows.Forms.Label();
            this.infoLabel8 = new System.Windows.Forms.Label();
            this.infoLabel9 = new System.Windows.Forms.Label();
            this.infoLabel10 = new System.Windows.Forms.Label();
            this.infoLabel11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(612, 63);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(75, 23);
            this.SaveFileButton.TabIndex = 2;
            this.SaveFileButton.Text = "保存文件";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFIleButton_Click);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.AddressTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.AddressTextBox.Location = new System.Drawing.Point(531, 36);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AddressTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.AddressTextBox.Size = new System.Drawing.Size(237, 21);
            this.AddressTextBox.TabIndex = 0;
            this.AddressTextBox.Text = "19w07z5654.51mypc.cn";
            this.AddressTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PingButton
            // 
            this.PingButton.Location = new System.Drawing.Point(531, 63);
            this.PingButton.Name = "PingButton";
            this.PingButton.Size = new System.Drawing.Size(75, 23);
            this.PingButton.TabIndex = 1;
            this.PingButton.Text = "连接服务器";
            this.PingButton.UseVisualStyleBackColor = true;
            this.PingButton.Click += new System.EventHandler(this.PingButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(693, 63);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "取消";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // pickButton
            // 
            this.pickButton.Location = new System.Drawing.Point(531, 7);
            this.pickButton.Name = "pickButton";
            this.pickButton.Size = new System.Drawing.Size(75, 23);
            this.pickButton.TabIndex = 4;
            this.pickButton.Text = "隐藏";
            this.pickButton.UseVisualStyleBackColor = true;
            this.pickButton.Click += new System.EventHandler(this.HideButton_Click);
            // 
            // writeXrecord
            // 
            this.writeXrecord.Location = new System.Drawing.Point(612, 7);
            this.writeXrecord.Name = "writeXrecord";
            this.writeXrecord.Size = new System.Drawing.Size(75, 23);
            this.writeXrecord.TabIndex = 5;
            this.writeXrecord.Text = "写入";
            this.writeXrecord.UseVisualStyleBackColor = true;
            this.writeXrecord.Click += new System.EventHandler(this.WriteXrecord_Click);
            // 
            // readXrecord
            // 
            this.readXrecord.Location = new System.Drawing.Point(693, 7);
            this.readXrecord.Name = "readXrecord";
            this.readXrecord.Size = new System.Drawing.Size(75, 23);
            this.readXrecord.TabIndex = 6;
            this.readXrecord.Text = "读取";
            this.readXrecord.UseVisualStyleBackColor = true;
            this.readXrecord.Click += new System.EventHandler(this.ReadXrecord_Click);
            // 
            // infoBox0
            // 
            this.infoBox0.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox0.Location = new System.Drawing.Point(78, 9);
            this.infoBox0.Name = "infoBox0";
            this.infoBox0.Size = new System.Drawing.Size(205, 21);
            this.infoBox0.TabIndex = 7;
            this.infoBox0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoBox1
            // 
            this.infoBox1.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox1.Location = new System.Drawing.Point(78, 36);
            this.infoBox1.Name = "infoBox1";
            this.infoBox1.Size = new System.Drawing.Size(205, 21);
            this.infoBox1.TabIndex = 8;
            this.infoBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoBox2
            // 
            this.infoBox2.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox2.Location = new System.Drawing.Point(78, 63);
            this.infoBox2.Name = "infoBox2";
            this.infoBox2.Size = new System.Drawing.Size(205, 21);
            this.infoBox2.TabIndex = 9;
            this.infoBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoBox3
            // 
            this.infoBox3.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox3.Location = new System.Drawing.Point(78, 90);
            this.infoBox3.Name = "infoBox3";
            this.infoBox3.Size = new System.Drawing.Size(205, 21);
            this.infoBox3.TabIndex = 10;
            this.infoBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoBox5
            // 
            this.infoBox5.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox5.Location = new System.Drawing.Point(78, 144);
            this.infoBox5.Name = "infoBox5";
            this.infoBox5.Size = new System.Drawing.Size(205, 21);
            this.infoBox5.TabIndex = 12;
            this.infoBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoBox4
            // 
            this.infoBox4.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox4.Location = new System.Drawing.Point(78, 117);
            this.infoBox4.Name = "infoBox4";
            this.infoBox4.Size = new System.Drawing.Size(205, 21);
            this.infoBox4.TabIndex = 11;
            this.infoBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoBox6
            // 
            this.infoBox6.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox6.Location = new System.Drawing.Point(78, 171);
            this.infoBox6.Name = "infoBox6";
            this.infoBox6.Size = new System.Drawing.Size(205, 21);
            this.infoBox6.TabIndex = 13;
            this.infoBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoBox7
            // 
            this.infoBox7.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox7.Location = new System.Drawing.Point(78, 198);
            this.infoBox7.Name = "infoBox7";
            this.infoBox7.Size = new System.Drawing.Size(205, 21);
            this.infoBox7.TabIndex = 14;
            this.infoBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoBox8
            // 
            this.infoBox8.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox8.Location = new System.Drawing.Point(78, 225);
            this.infoBox8.Name = "infoBox8";
            this.infoBox8.Size = new System.Drawing.Size(205, 21);
            this.infoBox8.TabIndex = 15;
            this.infoBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoBox9
            // 
            this.infoBox9.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox9.Location = new System.Drawing.Point(78, 252);
            this.infoBox9.Name = "infoBox9";
            this.infoBox9.Size = new System.Drawing.Size(205, 21);
            this.infoBox9.TabIndex = 16;
            this.infoBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoBox10
            // 
            this.infoBox10.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox10.Location = new System.Drawing.Point(78, 279);
            this.infoBox10.Name = "infoBox10";
            this.infoBox10.Size = new System.Drawing.Size(205, 21);
            this.infoBox10.TabIndex = 17;
            this.infoBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoBox11
            // 
            this.infoBox11.BackColor = System.Drawing.SystemColors.Control;
            this.infoBox11.Location = new System.Drawing.Point(78, 306);
            this.infoBox11.Name = "infoBox11";
            this.infoBox11.Size = new System.Drawing.Size(205, 21);
            this.infoBox11.TabIndex = 18;
            this.infoBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // infoLabel0
            // 
            this.infoLabel0.Location = new System.Drawing.Point(12, 11);
            this.infoLabel0.Name = "infoLabel0";
            this.infoLabel0.Size = new System.Drawing.Size(60, 15);
            this.infoLabel0.TabIndex = 19;
            this.infoLabel0.Text = "项目编号";
            this.infoLabel0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel1
            // 
            this.infoLabel1.Location = new System.Drawing.Point(12, 38);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(60, 15);
            this.infoLabel1.TabIndex = 20;
            this.infoLabel1.Text = "项目名称";
            this.infoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel2
            // 
            this.infoLabel2.Location = new System.Drawing.Point(12, 65);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(60, 15);
            this.infoLabel2.TabIndex = 21;
            this.infoLabel2.Text = "委托单位";
            this.infoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel3
            // 
            this.infoLabel3.Location = new System.Drawing.Point(12, 92);
            this.infoLabel3.Name = "infoLabel3";
            this.infoLabel3.Size = new System.Drawing.Size(60, 15);
            this.infoLabel3.TabIndex = 22;
            this.infoLabel3.Text = "街道";
            this.infoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel4
            // 
            this.infoLabel4.Location = new System.Drawing.Point(12, 119);
            this.infoLabel4.Name = "infoLabel4";
            this.infoLabel4.Size = new System.Drawing.Size(60, 15);
            this.infoLabel4.TabIndex = 23;
            this.infoLabel4.Text = "村";
            this.infoLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel5
            // 
            this.infoLabel5.Location = new System.Drawing.Point(12, 146);
            this.infoLabel5.Name = "infoLabel5";
            this.infoLabel5.Size = new System.Drawing.Size(60, 15);
            this.infoLabel5.TabIndex = 24;
            this.infoLabel5.Text = "制图人员";
            this.infoLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel6
            // 
            this.infoLabel6.Location = new System.Drawing.Point(12, 173);
            this.infoLabel6.Name = "infoLabel6";
            this.infoLabel6.Size = new System.Drawing.Size(60, 15);
            this.infoLabel6.TabIndex = 25;
            this.infoLabel6.Text = "检查人员";
            this.infoLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel7
            // 
            this.infoLabel7.Location = new System.Drawing.Point(12, 200);
            this.infoLabel7.Name = "infoLabel7";
            this.infoLabel7.Size = new System.Drawing.Size(60, 15);
            this.infoLabel7.TabIndex = 26;
            this.infoLabel7.Text = "审核人员";
            this.infoLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel8
            // 
            this.infoLabel8.Location = new System.Drawing.Point(12, 227);
            this.infoLabel8.Name = "infoLabel8";
            this.infoLabel8.Size = new System.Drawing.Size(60, 15);
            this.infoLabel8.TabIndex = 27;
            this.infoLabel8.Text = "坐标系";
            this.infoLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel9
            // 
            this.infoLabel9.Location = new System.Drawing.Point(12, 254);
            this.infoLabel9.Name = "infoLabel9";
            this.infoLabel9.Size = new System.Drawing.Size(60, 15);
            this.infoLabel9.TabIndex = 28;
            this.infoLabel9.Text = "日期(年)";
            this.infoLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel10
            // 
            this.infoLabel10.Location = new System.Drawing.Point(12, 281);
            this.infoLabel10.Name = "infoLabel10";
            this.infoLabel10.Size = new System.Drawing.Size(60, 15);
            this.infoLabel10.TabIndex = 29;
            this.infoLabel10.Text = "日期(月)";
            this.infoLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoLabel11
            // 
            this.infoLabel11.Location = new System.Drawing.Point(12, 308);
            this.infoLabel11.Name = "infoLabel11";
            this.infoLabel11.Size = new System.Drawing.Size(60, 15);
            this.infoLabel11.TabIndex = 30;
            this.infoLabel11.Text = "日期(日)";
            this.infoLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.PingButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.CloseButton;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(794, 458);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.infoLabel11);
            this.Controls.Add(this.infoLabel10);
            this.Controls.Add(this.infoLabel9);
            this.Controls.Add(this.infoLabel8);
            this.Controls.Add(this.infoLabel7);
            this.Controls.Add(this.infoLabel6);
            this.Controls.Add(this.infoLabel5);
            this.Controls.Add(this.infoLabel4);
            this.Controls.Add(this.infoLabel3);
            this.Controls.Add(this.infoLabel2);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.infoLabel0);
            this.Controls.Add(this.infoBox11);
            this.Controls.Add(this.infoBox10);
            this.Controls.Add(this.infoBox9);
            this.Controls.Add(this.infoBox8);
            this.Controls.Add(this.infoBox7);
            this.Controls.Add(this.infoBox6);
            this.Controls.Add(this.infoBox3);
            this.Controls.Add(this.infoBox5);
            this.Controls.Add(this.infoBox4);
            this.Controls.Add(this.infoBox2);
            this.Controls.Add(this.infoBox1);
            this.Controls.Add(this.infoBox0);
            this.Controls.Add(this.readXrecord);
            this.Controls.Add(this.writeXrecord);
            this.Controls.Add(this.pickButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PingButton);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.SaveFileButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "HXQ-瓯越制图管理程序";
            this.TransparencyKey = System.Drawing.Color.Aqua;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Button PingButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button pickButton;
        private System.Windows.Forms.Button writeXrecord;
        private System.Windows.Forms.Button readXrecord;
        private System.Windows.Forms.TextBox infoBox0;
        private System.Windows.Forms.TextBox infoBox1;
        private System.Windows.Forms.TextBox infoBox2;
        private System.Windows.Forms.TextBox infoBox3;
        private System.Windows.Forms.TextBox infoBox5;
        private System.Windows.Forms.TextBox infoBox4;
        private System.Windows.Forms.TextBox infoBox6;
        private System.Windows.Forms.TextBox infoBox7;
        private System.Windows.Forms.TextBox infoBox8;
        private System.Windows.Forms.TextBox infoBox9;
        private System.Windows.Forms.TextBox infoBox10;
        private System.Windows.Forms.TextBox infoBox11;
        private System.Windows.Forms.Label infoLabel0;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.Label infoLabel2;
        private System.Windows.Forms.Label infoLabel3;
        private System.Windows.Forms.Label infoLabel4;
        private System.Windows.Forms.Label infoLabel5;
        private System.Windows.Forms.Label infoLabel6;
        private System.Windows.Forms.Label infoLabel7;
        private System.Windows.Forms.Label infoLabel8;
        private System.Windows.Forms.Label infoLabel9;
        private System.Windows.Forms.Label infoLabel10;
        private System.Windows.Forms.Label infoLabel11;
        private System.Windows.Forms.Button button1;
    }
}