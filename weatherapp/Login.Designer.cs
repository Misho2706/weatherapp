
namespace weatherapp
{
    partial class Login
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
            this.LoginBtn = new DevExpress.XtraEditors.SimpleButton();
            this.RegBtn = new DevExpress.XtraEditors.SimpleButton();
            this.RememberMe = new DevExpress.XtraEditors.CheckEdit();
            this.Passwordtxt = new DevExpress.XtraEditors.TextEdit();
            this.Usernametxt = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.forget = new DevExpress.XtraEditors.LabelControl();
            this.txtemail = new DevExpress.XtraEditors.TextEdit();
            this.progressPanel = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.RememberMe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Passwordtxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Usernametxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtemail.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginBtn
            // 
            this.LoginBtn.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.LoginBtn.Appearance.Options.UseBorderColor = true;
            this.LoginBtn.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.LoginBtn.AppearanceDisabled.Options.UseBorderColor = true;
            this.LoginBtn.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.LoginBtn.AppearanceHovered.Options.UseBorderColor = true;
            this.LoginBtn.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.LoginBtn.AppearancePressed.Options.UseBorderColor = true;
            this.LoginBtn.AutoSize = true;
            this.LoginBtn.Location = new System.Drawing.Point(98, 148);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(32, 22);
            this.LoginBtn.TabIndex = 3;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_ClickAsync);
            // 
            // RegBtn
            // 
            this.RegBtn.AutoSize = true;
            this.RegBtn.Location = new System.Drawing.Point(151, 148);
            this.RegBtn.Name = "RegBtn";
            this.RegBtn.Size = new System.Drawing.Size(47, 22);
            this.RegBtn.TabIndex = 4;
            this.RegBtn.Text = "Register";
            this.RegBtn.Click += new System.EventHandler(this.RegBtn_Click);
            // 
            // RememberMe
            // 
            this.RememberMe.Location = new System.Drawing.Point(98, 122);
            this.RememberMe.Name = "RememberMe";
            this.RememberMe.Properties.Appearance.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RememberMe.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.RememberMe.Properties.Appearance.Options.UseFont = true;
            this.RememberMe.Properties.Appearance.Options.UseForeColor = true;
            this.RememberMe.Properties.AutoWidth = true;
            this.RememberMe.Properties.Caption = "Remember me";
            this.RememberMe.Size = new System.Drawing.Size(122, 23);
            this.RememberMe.TabIndex = 2;
            this.RememberMe.CheckedChanged += new System.EventHandler(this.RememberMe_CheckedChanged);
            // 
            // Passwordtxt
            // 
            this.Passwordtxt.Location = new System.Drawing.Point(98, 70);
            this.Passwordtxt.Name = "Passwordtxt";
            this.Passwordtxt.Properties.NullValuePrompt = "Password";
            this.Passwordtxt.Properties.PasswordChar = '*';
            this.Passwordtxt.Size = new System.Drawing.Size(100, 20);
            this.Passwordtxt.TabIndex = 1;
            // 
            // Usernametxt
            // 
            this.Usernametxt.Location = new System.Drawing.Point(98, 44);
            this.Usernametxt.Name = "Usernametxt";
            this.Usernametxt.Properties.NullValuePrompt = "Username";
            this.Usernametxt.Size = new System.Drawing.Size(100, 20);
            this.Usernametxt.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(83, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(127, 26);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Weather App";
            // 
            // forget
            // 
            this.forget.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.forget.Appearance.Options.UseForeColor = true;
            this.forget.Location = new System.Drawing.Point(232, 102);
            this.forget.Name = "forget";
            this.forget.Size = new System.Drawing.Size(84, 13);
            this.forget.TabIndex = 5;
            this.forget.Text = "forgot password?";
            this.forget.Click += new System.EventHandler(this.forget_Click);
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(61, 95);
            this.txtemail.Name = "txtemail";
            this.txtemail.Properties.NullValuePrompt = "email (only for registration)";
            this.txtemail.Size = new System.Drawing.Size(165, 20);
            this.txtemail.TabIndex = 2;
            // 
            // progressPanel
            // 
            this.progressPanel.AnimationElementImage = global::weatherapp.Properties.Resources.nightsky;
            this.progressPanel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel.Appearance.Options.UseBackColor = true;
            this.progressPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.progressPanel.Location = new System.Drawing.Point(34, 188);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(371, 157);
            this.progressPanel.TabIndex = 7;
            this.progressPanel.Text = "progressPanel1";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = global::weatherapp.Properties.Resources.night;
            this.ClientSize = new System.Drawing.Size(503, 357);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.forget);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.RememberMe);
            this.Controls.Add(this.RegBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.Passwordtxt);
            this.Controls.Add(this.Usernametxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.RememberMe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Passwordtxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Usernametxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtemail.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit Usernametxt;
        private DevExpress.XtraEditors.TextEdit Passwordtxt;
        private DevExpress.XtraEditors.SimpleButton LoginBtn;
        private DevExpress.XtraEditors.SimpleButton RegBtn;
        private DevExpress.XtraEditors.CheckEdit RememberMe;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl forget;
        private DevExpress.XtraEditors.TextEdit txtemail;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel;
    }
}