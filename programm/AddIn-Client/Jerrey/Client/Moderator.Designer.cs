namespace Client
{
    partial class Moderator
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
            this.btnNichtmehr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAppCLose = new System.Windows.Forms.Button();
            this.btnmoderat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNichtmehr
            // 
            this.btnNichtmehr.BackColor = System.Drawing.Color.Silver;
            this.btnNichtmehr.FlatAppearance.BorderSize = 0;
            this.btnNichtmehr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNichtmehr.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNichtmehr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnNichtmehr.Location = new System.Drawing.Point(53, 111);
            this.btnNichtmehr.Name = "btnNichtmehr";
            this.btnNichtmehr.Size = new System.Drawing.Size(110, 42);
            this.btnNichtmehr.TabIndex = 17;
            this.btnNichtmehr.Text = "Nein";
            this.btnNichtmehr.UseVisualStyleBackColor = false;
            this.btnNichtmehr.Click += new System.EventHandler(this.btnNichtmehr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(22, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 40);
            this.label1.TabIndex = 16;
            this.label1.Text = "Anfrage akzeptieren?";
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
            this.btnAppCLose.Location = new System.Drawing.Point(283, 22);
            this.btnAppCLose.Name = "btnAppCLose";
            this.btnAppCLose.Size = new System.Drawing.Size(30, 34);
            this.btnAppCLose.TabIndex = 15;
            this.btnAppCLose.Text = "X";
            this.btnAppCLose.UseVisualStyleBackColor = true;
            this.btnAppCLose.Click += new System.EventHandler(this.btnAppCLose_Click);
            // 
            // btnmoderat
            // 
            this.btnmoderat.BackColor = System.Drawing.Color.Transparent;
            this.btnmoderat.FlatAppearance.BorderSize = 0;
            this.btnmoderat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmoderat.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmoderat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnmoderat.Image = global::Client.Properties.Resources.m_crown2;
            this.btnmoderat.Location = new System.Drawing.Point(211, 111);
            this.btnmoderat.Name = "btnmoderat";
            this.btnmoderat.Size = new System.Drawing.Size(70, 42);
            this.btnmoderat.TabIndex = 18;
            this.btnmoderat.UseVisualStyleBackColor = false;
            this.btnmoderat.Click += new System.EventHandler(this.btnmoderat_Click);
            // 
            // Moderator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(335, 175);
            this.Controls.Add(this.btnNichtmehr);
            this.Controls.Add(this.btnmoderat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAppCLose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Moderator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Moderator";
            this.MouseLeave += new System.EventHandler(this.Moderator_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNichtmehr;
        private System.Windows.Forms.Button btnmoderat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAppCLose;
    }
}