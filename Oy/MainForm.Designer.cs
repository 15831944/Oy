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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PingButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.writeXrecord = new System.Windows.Forms.Button();
            this.readXrecord = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
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
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(531, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox1.Size = new System.Drawing.Size(237, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "19w07z5654.51mypc.cn";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "隐藏";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
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
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Location = new System.Drawing.Point(12, 7);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(205, 21);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "项目编号";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Location = new System.Drawing.Point(12, 34);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(205, 21);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "项目名称";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.Location = new System.Drawing.Point(12, 61);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(205, 21);
            this.textBox4.TabIndex = 9;
            this.textBox4.Text = "委托单位";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.Location = new System.Drawing.Point(12, 88);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(205, 21);
            this.textBox5.TabIndex = 12;
            this.textBox5.Text = "街道";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Location = new System.Drawing.Point(12, 142);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(205, 21);
            this.textBox7.TabIndex = 11;
            this.textBox7.Text = "制图人员";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.Location = new System.Drawing.Point(12, 115);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(205, 21);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "村";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.Location = new System.Drawing.Point(12, 169);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(205, 21);
            this.textBox8.TabIndex = 13;
            this.textBox8.Text = "检查人员";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.Location = new System.Drawing.Point(12, 196);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(205, 21);
            this.textBox9.TabIndex = 14;
            this.textBox9.Text = "审核人员";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Control;
            this.textBox10.Location = new System.Drawing.Point(12, 223);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(205, 21);
            this.textBox10.TabIndex = 15;
            this.textBox10.Text = "坐标系";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.Control;
            this.textBox11.Location = new System.Drawing.Point(12, 250);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(205, 21);
            this.textBox11.TabIndex = 16;
            this.textBox11.Text = "日期(年)";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.Control;
            this.textBox12.Location = new System.Drawing.Point(12, 277);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(205, 21);
            this.textBox12.TabIndex = 17;
            this.textBox12.Text = "日期(月)";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.SystemColors.Control;
            this.textBox13.Location = new System.Drawing.Point(12, 304);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(205, 21);
            this.textBox13.TabIndex = 18;
            this.textBox13.Text = "日期(日)";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.readXrecord);
            this.Controls.Add(this.writeXrecord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PingButton);
            this.Controls.Add(this.textBox1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button PingButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button writeXrecord;
        private System.Windows.Forms.Button readXrecord;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
    }
}