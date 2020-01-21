namespace DirectSelling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.paneMain = new System.Windows.Forms.Panel();
            this.paneLog = new System.Windows.Forms.Panel();
            this.gBLog = new System.Windows.Forms.GroupBox();
            this.lblCode = new System.Windows.Forms.LinkLabel();
            this.btnLog = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panePass = new System.Windows.Forms.Panel();
            this.gBCode = new System.Windows.Forms.GroupBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCode = new System.Windows.Forms.Button();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.btnOut = new System.Windows.Forms.Button();
            this.btnFB = new System.Windows.Forms.Button();
            this.paneMain.SuspendLayout();
            this.paneLog.SuspendLayout();
            this.gBLog.SuspendLayout();
            this.panePass.SuspendLayout();
            this.gBCode.SuspendLayout();
            this.SuspendLayout();
            // 
            // paneMain
            // 
            this.paneMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paneMain.Controls.Add(this.paneLog);
            this.paneMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneMain.Location = new System.Drawing.Point(0, 0);
            this.paneMain.Name = "paneMain";
            this.paneMain.Size = new System.Drawing.Size(342, 196);
            this.paneMain.TabIndex = 0;
            // 
            // paneLog
            // 
            this.paneLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paneLog.Controls.Add(this.gBLog);
            this.paneLog.Controls.Add(this.panePass);
            this.paneLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneLog.Location = new System.Drawing.Point(0, 0);
            this.paneLog.Name = "paneLog";
            this.paneLog.Size = new System.Drawing.Size(340, 194);
            this.paneLog.TabIndex = 0;
            // 
            // gBLog
            // 
            this.gBLog.Controls.Add(this.btnOut);
            this.gBLog.Controls.Add(this.btnFB);
            this.gBLog.Controls.Add(this.lblCode);
            this.gBLog.Controls.Add(this.btnLog);
            this.gBLog.Controls.Add(this.tbPass);
            this.gBLog.Controls.Add(this.label2);
            this.gBLog.Controls.Add(this.tbUser);
            this.gBLog.Controls.Add(this.label1);
            this.gBLog.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBLog.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gBLog.Location = new System.Drawing.Point(10, 10);
            this.gBLog.Name = "gBLog";
            this.gBLog.Size = new System.Drawing.Size(318, 172);
            this.gBLog.TabIndex = 2;
            this.gBLog.TabStop = false;
            this.gBLog.Text = "Login";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Lucida Calligraphy", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.LinkColor = System.Drawing.Color.Red;
            this.lblCode.Location = new System.Drawing.Point(122, 145);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(97, 15);
            this.lblCode.TabIndex = 6;
            this.lblCode.TabStop = true;
            this.lblCode.Text = "Request Code";
            this.lblCode.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCode_LinkClicked);
            // 
            // btnLog
            // 
            this.btnLog.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnLog.FlatAppearance.BorderSize = 2;
            this.btnLog.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.ForeColor = System.Drawing.Color.Black;
            this.btnLog.Location = new System.Drawing.Point(237, 136);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 30);
            this.btnLog.TabIndex = 5;
            this.btnLog.Text = "LOGIN";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // tbPass
            // 
            this.tbPass.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPass.Location = new System.Drawing.Point(125, 99);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(187, 31);
            this.tbPass.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // tbUser
            // 
            this.tbUser.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUser.Location = new System.Drawing.Point(125, 62);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(187, 31);
            this.tbUser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // panePass
            // 
            this.panePass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panePass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panePass.Controls.Add(this.gBCode);
            this.panePass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panePass.Location = new System.Drawing.Point(0, 0);
            this.panePass.Name = "panePass";
            this.panePass.Size = new System.Drawing.Size(338, 192);
            this.panePass.TabIndex = 1;
            // 
            // gBCode
            // 
            this.gBCode.Controls.Add(this.btnBack);
            this.gBCode.Controls.Add(this.btnCode);
            this.gBCode.Controls.Add(this.tbCode);
            this.gBCode.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBCode.ForeColor = System.Drawing.Color.DodgerBlue;
            this.gBCode.Location = new System.Drawing.Point(9, 9);
            this.gBCode.Name = "gBCode";
            this.gBCode.Size = new System.Drawing.Size(318, 172);
            this.gBCode.TabIndex = 3;
            this.gBCode.TabStop = false;
            this.gBCode.Text = "Enter Code:";
            // 
            // btnBack
            // 
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnBack.FlatAppearance.BorderSize = 2;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(27, 128);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(113, 32);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCode
            // 
            this.btnCode.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnCode.FlatAppearance.BorderSize = 2;
            this.btnCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCode.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCode.ForeColor = System.Drawing.Color.White;
            this.btnCode.Location = new System.Drawing.Point(180, 128);
            this.btnCode.Name = "btnCode";
            this.btnCode.Size = new System.Drawing.Size(113, 32);
            this.btnCode.TabIndex = 5;
            this.btnCode.Text = "LOGIN";
            this.btnCode.UseVisualStyleBackColor = true;
            this.btnCode.Click += new System.EventHandler(this.btnCode_Click);
            // 
            // tbCode
            // 
            this.tbCode.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCode.Location = new System.Drawing.Point(27, 69);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(266, 37);
            this.tbCode.TabIndex = 1;
            this.tbCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOut
            // 
            this.btnOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOut.FlatAppearance.BorderSize = 0;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.Image = global::DirectSelling.Properties.Resources.Button_Close_icon_16_;
            this.btnOut.Location = new System.Drawing.Point(295, -2);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(22, 23);
            this.btnOut.TabIndex = 105;
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnFB
            // 
            this.btnFB.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFB.FlatAppearance.BorderSize = 0;
            this.btnFB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnFB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnFB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFB.Image = global::DirectSelling.Properties.Resources.social_facebook_box_blue_icon;
            this.btnFB.Location = new System.Drawing.Point(3, 147);
            this.btnFB.Name = "btnFB";
            this.btnFB.Size = new System.Drawing.Size(22, 23);
            this.btnFB.TabIndex = 104;
            this.btnFB.UseVisualStyleBackColor = true;
            this.btnFB.Click += new System.EventHandler(this.btnFB_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(342, 196);
            this.Controls.Add(this.paneMain);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.paneMain.ResumeLayout(false);
            this.paneLog.ResumeLayout(false);
            this.gBLog.ResumeLayout(false);
            this.gBLog.PerformLayout();
            this.panePass.ResumeLayout(false);
            this.gBCode.ResumeLayout(false);
            this.gBCode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paneMain;
        private System.Windows.Forms.Panel paneLog;
        private System.Windows.Forms.Panel panePass;
        private System.Windows.Forms.GroupBox gBLog;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBCode;
        private System.Windows.Forms.Button btnCode;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.LinkLabel lblCode;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnFB;
        private System.Windows.Forms.Button btnOut;
    }
}