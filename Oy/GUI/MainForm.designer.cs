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
            this.MainFormTabControl = new System.Windows.Forms.TabControl();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.PropertyTabPag = new System.Windows.Forms.TabPage();
            this.SettingTabPage = new System.Windows.Forms.TabPage();
            this.MainFormTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormTabControl
            // 
            this.MainFormTabControl.Controls.Add(this.GeneralTabPage);
            this.MainFormTabControl.Controls.Add(this.PropertyTabPag);
            this.MainFormTabControl.Controls.Add(this.SettingTabPage);
            this.MainFormTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFormTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainFormTabControl.Name = "MainFormTabControl";
            this.MainFormTabControl.SelectedIndex = 0;
            this.MainFormTabControl.Size = new System.Drawing.Size(800, 450);
            this.MainFormTabControl.TabIndex = 0;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 22);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabPage.Size = new System.Drawing.Size(792, 424);
            this.GeneralTabPage.TabIndex = 0;
            this.GeneralTabPage.Text = "常规";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // PropertyTabPag
            // 
            this.PropertyTabPag.Location = new System.Drawing.Point(4, 22);
            this.PropertyTabPag.Name = "PropertyTabPag";
            this.PropertyTabPag.Padding = new System.Windows.Forms.Padding(3);
            this.PropertyTabPag.Size = new System.Drawing.Size(792, 424);
            this.PropertyTabPag.TabIndex = 1;
            this.PropertyTabPag.Text = "特性";
            this.PropertyTabPag.UseVisualStyleBackColor = true;
            // 
            // SettingTabPage
            // 
            this.SettingTabPage.Location = new System.Drawing.Point(4, 22);
            this.SettingTabPage.Name = "SettingTabPage";
            this.SettingTabPage.Size = new System.Drawing.Size(792, 424);
            this.SettingTabPage.TabIndex = 2;
            this.SettingTabPage.Text = "设置";
            this.SettingTabPage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainFormTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "HXQ-瓯越制图管理程序";
            this.MainFormTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainFormTabControl;
        private System.Windows.Forms.TabPage GeneralTabPage;
        private System.Windows.Forms.TabPage PropertyTabPag;
        private System.Windows.Forms.TabPage SettingTabPage;
    }
}