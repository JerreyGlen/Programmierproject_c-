namespace Client
{
    partial class GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnMessages = new System.Windows.Forms.Button();
            this.btnStream = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.labelUserName = new System.Windows.Forms.Label();
            this.lblMeetingID = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.buttonSendMessages = new System.Windows.Forms.Button();
            this.btnMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessages = new System.Windows.Forms.Button();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.pnlFormL = new System.Windows.Forms.Panel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.btnModerator = new System.Windows.Forms.Button();
            this.btnAppCLose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pBGrab = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelPlayer.SuspendLayout();
            this.panelChildForm.SuspendLayout();
            this.pnlFormL.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBGrab)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelSideMenu.Controls.Add(this.pnlNav);
            this.panelSideMenu.Controls.Add(this.btnDisconnect);
            this.panelSideMenu.Controls.Add(this.btnHelp);
            this.panelSideMenu.Controls.Add(this.btnMessages);
            this.panelSideMenu.Controls.Add(this.btnStream);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(233, 710);
            this.panelSideMenu.TabIndex = 0;
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 181);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(5, 131);
            this.pnlNav.TabIndex = 9;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDisconnect.FlatAppearance.BorderSize = 0;
            this.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisconnect.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnDisconnect.Image = global::Client.Properties.Resources.rsz_1rsz_power;
            this.btnDisconnect.Location = new System.Drawing.Point(0, 268);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDisconnect.Size = new System.Drawing.Size(233, 45);
            this.btnDisconnect.TabIndex = 8;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDisconnect.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            this.btnDisconnect.Leave += new System.EventHandler(this.btnDisconnect_Leave);
            // 
            // btnHelp
            // 
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnHelp.Image = global::Client.Properties.Resources.rsz_actions_help;
            this.btnHelp.Location = new System.Drawing.Point(0, 665);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHelp.Size = new System.Drawing.Size(233, 45);
            this.btnHelp.TabIndex = 7;
            this.btnHelp.Text = "Help         ";
            this.btnHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.button16_Click);
            this.btnHelp.Leave += new System.EventHandler(this.btnHelp_Leave);
            // 
            // btnMessages
            // 
            this.btnMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMessages.FlatAppearance.BorderSize = 0;
            this.btnMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMessages.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMessages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnMessages.Image = global::Client.Properties.Resources.rsz_messages;
            this.btnMessages.Location = new System.Drawing.Point(0, 223);
            this.btnMessages.Name = "btnMessages";
            this.btnMessages.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMessages.Size = new System.Drawing.Size(233, 45);
            this.btnMessages.TabIndex = 3;
            this.btnMessages.Text = "Messages  ";
            this.btnMessages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMessages.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMessages.UseVisualStyleBackColor = true;
            this.btnMessages.Click += new System.EventHandler(this.btnMessages_Click);
            this.btnMessages.Leave += new System.EventHandler(this.btnMessages_Leave);
            // 
            // btnStream
            // 
            this.btnStream.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStream.FlatAppearance.BorderSize = 0;
            this.btnStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStream.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStream.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnStream.Image = global::Client.Properties.Resources.rsz_camera_icon;
            this.btnStream.Location = new System.Drawing.Point(0, 178);
            this.btnStream.Name = "btnStream";
            this.btnStream.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStream.Size = new System.Drawing.Size(233, 45);
            this.btnStream.TabIndex = 1;
            this.btnStream.Text = "Streaming ";
            this.btnStream.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStream.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStream.UseVisualStyleBackColor = true;
            this.btnStream.Click += new System.EventHandler(this.btnStream_Click);
            this.btnStream.Leave += new System.EventHandler(this.btnStream_Leave);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.labelUserName);
            this.panelLogo.Controls.Add(this.lblMeetingID);
            this.panelLogo.Controls.Add(this.pictureBox2);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(233, 178);
            this.panelLogo.TabIndex = 0;
            // 
            // labelUserName
            // 
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.labelUserName.Location = new System.Drawing.Point(34, 103);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(134, 25);
            this.labelUserName.TabIndex = 1;
            this.labelUserName.Text = "User Name";
            // 
            // lblMeetingID
            // 
            this.lblMeetingID.AutoSize = true;
            this.lblMeetingID.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeetingID.ForeColor = System.Drawing.Color.Gray;
            this.lblMeetingID.Location = new System.Drawing.Point(34, 128);
            this.lblMeetingID.Name = "lblMeetingID";
            this.lblMeetingID.Size = new System.Drawing.Size(118, 28);
            this.lblMeetingID.TabIndex = 5;
            this.lblMeetingID.Text = "Meeting ID";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(54, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 70);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panelPlayer
            // 
            this.panelPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelPlayer.Controls.Add(this.buttonSendMessages);
            this.panelPlayer.Controls.Add(this.btnMessage);
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPlayer.Location = new System.Drawing.Point(233, 631);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(1003, 79);
            this.panelPlayer.TabIndex = 1;
            // 
            // buttonSendMessages
            // 
            this.buttonSendMessages.AutoEllipsis = true;
            this.buttonSendMessages.BackColor = System.Drawing.Color.Transparent;
            this.buttonSendMessages.BackgroundImage = global::Client.Properties.Resources.rsz_email_send_icon1;
            this.buttonSendMessages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSendMessages.FlatAppearance.BorderSize = 0;
            this.buttonSendMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSendMessages.Location = new System.Drawing.Point(769, 15);
            this.buttonSendMessages.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSendMessages.Name = "buttonSendMessages";
            this.buttonSendMessages.Size = new System.Drawing.Size(50, 39);
            this.buttonSendMessages.TabIndex = 15;
            this.buttonSendMessages.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSendMessages.UseVisualStyleBackColor = false;
            this.buttonSendMessages.Click += new System.EventHandler(this.buttonEllipse1_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.btnMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.btnMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnMessage.Location = new System.Drawing.Point(276, 18);
            this.btnMessage.Multiline = true;
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(474, 35);
            this.btnMessage.TabIndex = 3;
            this.btnMessage.Text = " Enter a Message";
            // 
            // btnSendMessages
            // 
            this.btnSendMessages.AutoEllipsis = true;
            this.btnSendMessages.BackColor = System.Drawing.Color.Transparent;
            this.btnSendMessages.BackgroundImage = global::Client.Properties.Resources.rsz_email_send_icon1;
            this.btnSendMessages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendMessages.FlatAppearance.BorderSize = 0;
            this.btnSendMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessages.Location = new System.Drawing.Point(771, 11);
            this.btnSendMessages.Margin = new System.Windows.Forms.Padding(0);
            this.btnSendMessages.Name = "btnSendMessages";
            this.btnSendMessages.Size = new System.Drawing.Size(50, 50);
            this.btnSendMessages.TabIndex = 1;
            this.btnSendMessages.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSendMessages.UseVisualStyleBackColor = false;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panelChildForm.Controls.Add(this.pnlFormL);
            this.panelChildForm.Controls.Add(this.pnlTitle);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(233, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1003, 631);
            this.panelChildForm.TabIndex = 2;
            this.panelChildForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChildForm_Paint);
            // 
            // pnlFormL
            // 
            this.pnlFormL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlFormL.Controls.Add(this.pnlForm);
            this.pnlFormL.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlFormL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormL.Location = new System.Drawing.Point(0, 75);
            this.pnlFormL.Name = "pnlFormL";
            this.pnlFormL.Size = new System.Drawing.Size(1003, 556);
            this.pnlFormL.TabIndex = 8;
            this.pnlFormL.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFormLoader_Paint);
            // 
            // pnlForm
            // 
            this.pnlForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlForm.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(0, 0);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(1003, 556);
            this.pnlForm.TabIndex = 4;
            this.pnlForm.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFormLoader_Paint);
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.btnModerator);
            this.pnlTitle.Controls.Add(this.btnAppCLose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Controls.Add(this.label1);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1003, 75);
            this.pnlTitle.TabIndex = 7;
            // 
            // btnModerator
            // 
            this.btnModerator.FlatAppearance.BorderSize = 0;
            this.btnModerator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModerator.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModerator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnModerator.Image = global::Client.Properties.Resources.m_crown;
            this.btnModerator.Location = new System.Drawing.Point(276, 28);
            this.btnModerator.Name = "btnModerator";
            this.btnModerator.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnModerator.Size = new System.Drawing.Size(251, 45);
            this.btnModerator.TabIndex = 8;
            this.btnModerator.Text = "Moderator werden";
            this.btnModerator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModerator.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnModerator.UseVisualStyleBackColor = true;
            this.btnModerator.Click += new System.EventHandler(this.btnModerator_Click);
            this.btnModerator.Leave += new System.EventHandler(this.btnDisconnect_Leave);
            // 
            // btnAppCLose
            // 
            this.btnAppCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAppCLose.FlatAppearance.BorderSize = 0;
            this.btnAppCLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppCLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppCLose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnAppCLose.Location = new System.Drawing.Point(973, 12);
            this.btnAppCLose.Name = "btnAppCLose";
            this.btnAppCLose.Size = new System.Drawing.Size(27, 37);
            this.btnAppCLose.TabIndex = 5;
            this.btnAppCLose.Text = "X";
            this.btnAppCLose.UseVisualStyleBackColor = true;
            this.btnAppCLose.Click += new System.EventHandler(this.btnAppCLose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(171, 37);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Dashboard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.label1.Location = new System.Drawing.Point(611, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to AddOut";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pBGrab, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(233, 81);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1003, 550);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // pBGrab
            // 
            this.pBGrab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBGrab.Location = new System.Drawing.Point(3, 3);
            this.pBGrab.Name = "pBGrab";
            this.pBGrab.Size = new System.Drawing.Size(997, 544);
            this.pBGrab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pBGrab.TabIndex = 0;
            this.pBGrab.TabStop = false;
            this.pBGrab.Click += new System.EventHandler(this.pBGrab_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 710);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelPlayer);
            this.Controls.Add(this.panelSideMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddOut";
            this.Activated += new System.EventHandler(this.GUI_Activated);
            this.Load += new System.EventHandler(this.GUI_Load);
            this.panelSideMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelPlayer.ResumeLayout(false);
            this.panelPlayer.PerformLayout();
            this.panelChildForm.ResumeLayout(false);
            this.pnlFormL.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBGrab)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnMessages;
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Button btnDisconnect;
        public System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox btnMessage;
        private System.Windows.Forms.Button btnAppCLose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Button btnSendMessages;
        public  System.Windows.Forms.Label lblMeetingID;
        private System.Windows.Forms.Button btnStream;
        public System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Button btnModerator;
        public System.Windows.Forms.Panel pnlFormL;
        private System.Windows.Forms.Button buttonSendMessages;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pBGrab;
    }
}