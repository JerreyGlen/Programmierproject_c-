
namespace Client_Dummy
{
    partial class gui
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.sessionid = new System.Windows.Forms.TextBox();
            this.chatinput = new System.Windows.Forms.TextBox();
            this.chatoutput = new System.Windows.Forms.ListView();
            this.filenameinput = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.info = new System.Windows.Forms.Label();
            this.disconnectbutton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.requestmodbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.connect_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.sendChat_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(597, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(172, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "choose file";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.chooseFile_Click);
            // 
            // sessionid
            // 
            this.sessionid.Location = new System.Drawing.Point(12, 33);
            this.sessionid.Name = "sessionid";
            this.sessionid.Size = new System.Drawing.Size(100, 22);
            this.sessionid.TabIndex = 3;
            // 
            // chatinput
            // 
            this.chatinput.Location = new System.Drawing.Point(13, 366);
            this.chatinput.Name = "chatinput";
            this.chatinput.Size = new System.Drawing.Size(245, 22);
            this.chatinput.TabIndex = 4;
            this.chatinput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChatInput_Keyboard);
            // 
            // chatoutput
            // 
            this.chatoutput.HideSelection = false;
            this.chatoutput.Location = new System.Drawing.Point(12, 78);
            this.chatoutput.Name = "chatoutput";
            this.chatoutput.ShowGroups = false;
            this.chatoutput.Size = new System.Drawing.Size(246, 282);
            this.chatoutput.TabIndex = 5;
            this.chatoutput.UseCompatibleStateImageBehavior = false;
            // 
            // filenameinput
            // 
            this.filenameinput.Location = new System.Drawing.Point(389, 13);
            this.filenameinput.Name = "filenameinput";
            this.filenameinput.Size = new System.Drawing.Size(202, 22);
            this.filenameinput.TabIndex = 6;
            this.filenameinput.Text = "C:\\Users\\janni\\Documents\\uni\\sem3\\programmierprojekt\\git\\grp10\\programm\\AddIn-Cli" +
    "ent\\Jannis\\Client-Dummy\\test.txt";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 257);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(386, 394);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(31, 17);
            this.info.TabIndex = 9;
            this.info.Text = "info";
            // 
            // disconnectbutton
            // 
            this.disconnectbutton.Location = new System.Drawing.Point(389, 415);
            this.disconnectbutton.Name = "disconnectbutton";
            this.disconnectbutton.Size = new System.Drawing.Size(90, 23);
            this.disconnectbutton.TabIndex = 10;
            this.disconnectbutton.Text = "disconnect";
            this.disconnectbutton.UseVisualStyleBackColor = true;
            this.disconnectbutton.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(597, 41);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "send file";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.send_File_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "bild:";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(389, 366);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(241, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Screenshot senden";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.sendScreenshot_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "put in session id to join or leave empty for new session";
            // 
            // requestmodbutton
            // 
            this.requestmodbutton.Location = new System.Drawing.Point(548, 415);
            this.requestmodbutton.Name = "requestmodbutton";
            this.requestmodbutton.Size = new System.Drawing.Size(177, 23);
            this.requestmodbutton.TabIndex = 14;
            this.requestmodbutton.Text = "request Moderator";
            this.requestmodbutton.UseVisualStyleBackColor = true;
            this.requestmodbutton.Click += new System.EventHandler(this.requestmodbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(386, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "click anywhere on the pic to send laserpointerinfo";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(389, 97);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(336, 263);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.requestmodbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.disconnectbutton);
            this.Controls.Add(this.info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filenameinput);
            this.Controls.Add(this.chatoutput);
            this.Controls.Add(this.chatinput);
            this.Controls.Add(this.sessionid);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "gui";
            this.Text = "gui";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox sessionid;
        private System.Windows.Forms.TextBox chatinput;
        private System.Windows.Forms.ListView chatoutput;
        private System.Windows.Forms.TextBox filenameinput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button disconnectbutton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button requestmodbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}