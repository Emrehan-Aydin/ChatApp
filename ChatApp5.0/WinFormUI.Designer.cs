namespace ChatApp5._0
{
    partial class WinFormUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinFormUI));
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.listMessages = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLocalIp = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemoteIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConnect = new MagicUI.MagicControl.MagicButton();
            this.btn_logout = new MagicUI.MagicControl.MagicButton();
            this.SelectFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnEnterPassword = new MagicUI.MagicControl.MagicButton();
            this.btnSend = new MagicUI.MagicControl.MagicButton();
            this.btn_upload = new MagicUI.MagicControl.MagicButton();
            this.txtMessage = new CxFlatUI.CxFlatTextBox();
            this.MessageInputGB = new System.Windows.Forms.GroupBox();
            this.worker = new MagicUI.MagicControl.MagicProgressBar();
            this.rb_algorithm_SHA = new System.Windows.Forms.RadioButton();
            this.rb_algorithm_SPN = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            this.MessageInputGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtPassword.Name = "txtPassword";
            // 
            // listMessages
            // 
            this.listMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.listMessages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.listMessages, "listMessages");
            this.listMessages.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.listMessages.FormattingEnabled = true;
            this.listMessages.Name = "listMessages";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtLocalIp);
            this.groupBox2.Controls.Add(this.status);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtRemoteIp);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnConnect);
            this.groupBox2.Controls.Add(this.btn_logout);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.ForeColor = System.Drawing.Color.Goldenrod;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // txtLocalIp
            // 
            resources.ApplyResources(this.txtLocalIp, "txtLocalIp");
            this.txtLocalIp.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtLocalIp.Name = "txtLocalIp";
            // 
            // status
            // 
            resources.ApplyResources(this.status, "status");
            this.status.BackColor = System.Drawing.Color.Transparent;
            this.status.ForeColor = System.Drawing.Color.Red;
            this.status.Name = "status";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Goldenrod;
            this.label1.Name = "label1";
            // 
            // txtRemoteIp
            // 
            this.txtRemoteIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.txtRemoteIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtRemoteIp, "txtRemoteIp");
            this.txtRemoteIp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtRemoteIp.Name = "txtRemoteIp";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Name = "label4";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.ForestGreen;
            this.btnConnect.BackgroundColor = System.Drawing.Color.ForestGreen;
            this.btnConnect.BorderColor = System.Drawing.Color.Transparent;
            this.btnConnect.BorderRadius = 20;
            this.btnConnect.BorderSize = 2;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.ForeColor = System.Drawing.Color.White;
            this.btnConnect.Image = global::ChatApp5._0.Properties.Resources.icons8_connect_32;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.TextColor = System.Drawing.Color.White;
            this.btnConnect.UseCompatibleTextRendering = true;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.BackColor = System.Drawing.Color.DarkRed;
            this.btn_logout.BackgroundColor = System.Drawing.Color.DarkRed;
            this.btn_logout.BorderColor = System.Drawing.Color.Transparent;
            this.btn_logout.BorderRadius = 20;
            this.btn_logout.BorderSize = 0;
            this.btn_logout.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btn_logout, "btn_logout");
            this.btn_logout.ForeColor = System.Drawing.Color.White;
            this.btn_logout.Image = global::ChatApp5._0.Properties.Resources.icons8_logout_32;
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.TextColor = System.Drawing.Color.White;
            this.btn_logout.UseCompatibleTextRendering = true;
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // SelectFileDialog
            // 
            this.SelectFileDialog.FileName = "openFileDialog1";
            // 
            // btnEnterPassword
            // 
            this.btnEnterPassword.BackColor = System.Drawing.Color.Goldenrod;
            this.btnEnterPassword.BackgroundColor = System.Drawing.Color.Goldenrod;
            resources.ApplyResources(this.btnEnterPassword, "btnEnterPassword");
            this.btnEnterPassword.BorderColor = System.Drawing.Color.White;
            this.btnEnterPassword.BorderRadius = 20;
            this.btnEnterPassword.BorderSize = 0;
            this.btnEnterPassword.FlatAppearance.BorderSize = 0;
            this.btnEnterPassword.ForeColor = System.Drawing.Color.Black;
            this.btnEnterPassword.Name = "btnEnterPassword";
            this.btnEnterPassword.TextColor = System.Drawing.Color.Black;
            this.btnEnterPassword.UseCompatibleTextRendering = true;
            this.btnEnterPassword.UseVisualStyleBackColor = false;
            this.btnEnterPassword.Click += new System.EventHandler(this.btnEnterPassword_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.Goldenrod;
            this.btnSend.BackgroundColor = System.Drawing.Color.Goldenrod;
            this.btnSend.BorderColor = System.Drawing.Color.White;
            this.btnSend.BorderRadius = 20;
            this.btnSend.BorderSize = 0;
            this.btnSend.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.Name = "btnSend";
            this.btnSend.TextColor = System.Drawing.Color.Black;
            this.btnSend.UseCompatibleTextRendering = true;
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_upload.BackgroundColor = System.Drawing.Color.Goldenrod;
            this.btn_upload.BorderColor = System.Drawing.Color.White;
            this.btn_upload.BorderRadius = 16;
            this.btn_upload.BorderSize = 0;
            this.btn_upload.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btn_upload, "btn_upload");
            this.btn_upload.ForeColor = System.Drawing.Color.Black;
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.TextColor = System.Drawing.Color.Black;
            this.btn_upload.UseCompatibleTextRendering = true;
            this.btn_upload.UseVisualStyleBackColor = false;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.txtMessage, "txtMessage");
            this.txtMessage.ForeColor = System.Drawing.Color.Black;
            this.txtMessage.Hint = "";
            this.txtMessage.MaxLength = 32767;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PasswordChar = '\0';
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMessage.SelectedText = "";
            this.txtMessage.SelectionLength = 0;
            this.txtMessage.SelectionStart = 0;
            this.txtMessage.TabStop = false;
            this.txtMessage.UseSystemPasswordChar = false;
            // 
            // MessageInputGB
            // 
            this.MessageInputGB.BackColor = System.Drawing.Color.Transparent;
            this.MessageInputGB.BackgroundImage = global::ChatApp5._0.Properties.Resources._800x800_318_3182425_gradient_background_png;
            resources.ApplyResources(this.MessageInputGB, "MessageInputGB");
            this.MessageInputGB.Controls.Add(this.worker);
            this.MessageInputGB.Controls.Add(this.rb_algorithm_SHA);
            this.MessageInputGB.Controls.Add(this.rb_algorithm_SPN);
            this.MessageInputGB.Controls.Add(this.btn_upload);
            this.MessageInputGB.Controls.Add(this.txtMessage);
            this.MessageInputGB.Controls.Add(this.btnEnterPassword);
            this.MessageInputGB.Controls.Add(this.btnSend);
            this.MessageInputGB.Controls.Add(this.label7);
            this.MessageInputGB.Controls.Add(this.label6);
            this.MessageInputGB.Controls.Add(this.txtPassword);
            this.MessageInputGB.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MessageInputGB.Name = "MessageInputGB";
            this.MessageInputGB.TabStop = false;
            this.MessageInputGB.UseCompatibleTextRendering = true;
            // 
            // worker
            // 
            this.worker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.worker.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.worker.ChannelHeight = 6;
            this.worker.ForeBackColor = System.Drawing.Color.Transparent;
            this.worker.ForeColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.worker, "worker");
            this.worker.MarqueeAnimationSpeed = 1000;
            this.worker.Name = "worker";
            this.worker.ShowMaximun = false;
            this.worker.ShowValue = MagicUI.MagicControl.TextPosition.None;
            this.worker.SliderColor = System.Drawing.Color.Goldenrod;
            this.worker.SliderHeight = 10;
            this.worker.Step = 100;
            this.worker.SymbolAfter = "";
            this.worker.SymbolBefore = "";
            // 
            // rb_algorithm_SHA
            // 
            resources.ApplyResources(this.rb_algorithm_SHA, "rb_algorithm_SHA");
            this.rb_algorithm_SHA.Checked = true;
            this.rb_algorithm_SHA.Name = "rb_algorithm_SHA";
            this.rb_algorithm_SHA.TabStop = true;
            this.rb_algorithm_SHA.UseVisualStyleBackColor = true;
            // 
            // rb_algorithm_SPN
            // 
            resources.ApplyResources(this.rb_algorithm_SPN, "rb_algorithm_SPN");
            this.rb_algorithm_SPN.Name = "rb_algorithm_SPN";
            this.rb_algorithm_SPN.UseVisualStyleBackColor = true;
            // 
            // WinFormUI
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(25)))), ((int)(((byte)(35)))));
            this.CancelButton = this.btn_logout;
            this.Controls.Add(this.MessageInputGB);
            this.Controls.Add(this.listMessages);
            this.Controls.Add(this.groupBox2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WinFormUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.btn_logout_Click);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.MessageInputGB.ResumeLayout(false);
            this.MessageInputGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_SelectFile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ListBox listMessages;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRemoteIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog SelectFileDialog;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label2;
        private MagicUI.MagicControl.MagicButton btnConnect;
        private MagicUI.MagicControl.MagicButton btnEnterPassword;
        private MagicUI.MagicControl.MagicButton btnSend;
        private MagicUI.MagicControl.MagicButton btn_upload;
        private CxFlatUI.CxFlatTextBox txtMessage;
        private System.Windows.Forms.GroupBox MessageInputGB;
        private MagicUI.MagicControl.MagicButton btn_logout;
        private System.Windows.Forms.RadioButton rb_algorithm_SHA;
        private System.Windows.Forms.RadioButton rb_algorithm_SPN;
        private System.Windows.Forms.Label txtLocalIp;
        private System.Windows.Forms.Label label3;
        private MagicUI.MagicControl.MagicProgressBar worker;
    }
}

