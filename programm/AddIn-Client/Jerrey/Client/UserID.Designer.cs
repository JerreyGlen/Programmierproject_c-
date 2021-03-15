namespace Client
{
    partial class UserID
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
            this.rTBUserName = new System.Windows.Forms.RichTextBox();
            this.rTBMeetingsID = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAppCLose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSendID = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rTBUserName
            // 
            this.rTBUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.rTBUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTBUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTBUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.rTBUserName.Location = new System.Drawing.Point(140, 74);
            this.rTBUserName.MaxLength = 10;
            this.rTBUserName.Name = "rTBUserName";
            this.rTBUserName.Size = new System.Drawing.Size(214, 33);
            this.rTBUserName.TabIndex = 1;
            this.rTBUserName.Text = "User Name";
            // 
            // rTBMeetingsID
            // 
            this.rTBMeetingsID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.rTBMeetingsID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTBMeetingsID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTBMeetingsID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.rTBMeetingsID.Location = new System.Drawing.Point(140, 126);
            this.rTBMeetingsID.MaxLength = 10;
            this.rTBMeetingsID.Name = "rTBMeetingsID";
            this.rTBMeetingsID.Size = new System.Drawing.Size(214, 33);
            this.rTBMeetingsID.TabIndex = 1;
            this.rTBMeetingsID.Text = "Meeting-ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Halt!";
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
            this.btnAppCLose.Location = new System.Drawing.Point(370, 12);
            this.btnAppCLose.Name = "btnAppCLose";
            this.btnAppCLose.Size = new System.Drawing.Size(32, 32);
            this.btnAppCLose.TabIndex = 6;
            this.btnAppCLose.Text = "X";
            this.btnAppCLose.UseVisualStyleBackColor = true;
            this.btnAppCLose.Click += new System.EventHandler(this.btnAppCLose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(26, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "User Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(26, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Meeting ID:";
            // 
            // btnSendID
            // 
            this.btnSendID.AutoEllipsis = true;
            this.btnSendID.BackColor = System.Drawing.Color.Transparent;
            this.btnSendID.BackgroundImage = global::Client.Properties.Resources.rsz_email_send_icon1;
            this.btnSendID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSendID.FlatAppearance.BorderSize = 0;
            this.btnSendID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendID.Location = new System.Drawing.Point(346, 162);
            this.btnSendID.Margin = new System.Windows.Forms.Padding(0);
            this.btnSendID.Name = "btnSendID";
            this.btnSendID.Size = new System.Drawing.Size(50, 50);
            this.btnSendID.TabIndex = 7;
            this.btnSendID.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSendID.UseVisualStyleBackColor = false;
            this.btnSendID.Click += new System.EventHandler(this.btnSendID_Click);
            this.btnSendID.Leave += new System.EventHandler(this.btnSendID_Leave);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnMinimize.Location = new System.Drawing.Point(346, 10);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(27, 34);
            this.btnMinimize.TabIndex = 13;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // UserID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(405, 221);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSendID);
            this.Controls.Add(this.btnAppCLose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rTBMeetingsID);
            this.Controls.Add(this.rTBUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1000, 500);
            this.Name = "UserID";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserID";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox rTBUserName;
        private System.Windows.Forms.RichTextBox rTBMeetingsID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAppCLose;
        private System.Windows.Forms.Button btnSendID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMinimize;
    }
}