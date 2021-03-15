namespace Client
{
    partial class Disconnect
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
            this.btnAppCLose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnverlassen = new System.Windows.Forms.Button();
            this.btnBleiben = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.btnAppCLose.Location = new System.Drawing.Point(293, 12);
            this.btnAppCLose.Name = "btnAppCLose";
            this.btnAppCLose.Size = new System.Drawing.Size(30, 34);
            this.btnAppCLose.TabIndex = 7;
            this.btnAppCLose.Text = "X";
            this.btnAppCLose.UseVisualStyleBackColor = true;
            this.btnAppCLose.Click += new System.EventHandler(this.btnAppCLose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(32, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Leave the Meeting ?";
            // 
            // btnverlassen
            // 
            this.btnverlassen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.btnverlassen.FlatAppearance.BorderSize = 0;
            this.btnverlassen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnverlassen.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnverlassen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnverlassen.Location = new System.Drawing.Point(184, 102);
            this.btnverlassen.Name = "btnverlassen";
            this.btnverlassen.Size = new System.Drawing.Size(106, 42);
            this.btnverlassen.TabIndex = 10;
            this.btnverlassen.Text = "Verlassen";
            this.btnverlassen.UseVisualStyleBackColor = false;
            this.btnverlassen.Click += new System.EventHandler(this.btnverlassen_Click);
            // 
            // btnBleiben
            // 
            this.btnBleiben.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBleiben.FlatAppearance.BorderSize = 0;
            this.btnBleiben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBleiben.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBleiben.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnBleiben.Location = new System.Drawing.Point(48, 102);
            this.btnBleiben.Name = "btnBleiben";
            this.btnBleiben.Size = new System.Drawing.Size(106, 42);
            this.btnBleiben.TabIndex = 10;
            this.btnBleiben.Text = "Bleiben";
            this.btnBleiben.UseVisualStyleBackColor = false;
            this.btnBleiben.Click += new System.EventHandler(this.btnBleiben_Click);
            // 
            // Disconnect
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(335, 175);
            this.Controls.Add(this.btnBleiben);
            this.Controls.Add(this.btnverlassen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAppCLose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Disconnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Disconnect";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAppCLose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnverlassen;
        private System.Windows.Forms.Button btnBleiben;
    }
}