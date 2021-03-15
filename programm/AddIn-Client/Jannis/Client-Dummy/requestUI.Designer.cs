
namespace Client_Dummy
{
    partial class requestUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.acceptedbutton = new System.Windows.Forms.Button();
            this.denybutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(533, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Partner requested to get Moderator rights";
            // 
            // acceptedbutton
            // 
            this.acceptedbutton.Location = new System.Drawing.Point(110, 65);
            this.acceptedbutton.Name = "acceptedbutton";
            this.acceptedbutton.Size = new System.Drawing.Size(124, 44);
            this.acceptedbutton.TabIndex = 1;
            this.acceptedbutton.Text = "Accept";
            this.acceptedbutton.UseVisualStyleBackColor = true;
            this.acceptedbutton.Click += new System.EventHandler(this.acceptedbutton_Click);
            // 
            // denybutton
            // 
            this.denybutton.Location = new System.Drawing.Point(261, 65);
            this.denybutton.Name = "denybutton";
            this.denybutton.Size = new System.Drawing.Size(147, 44);
            this.denybutton.TabIndex = 2;
            this.denybutton.Text = "Deny";
            this.denybutton.UseVisualStyleBackColor = true;
            this.denybutton.Click += new System.EventHandler(this.deny_click);
            // 
            // requestUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 131);
            this.Controls.Add(this.denybutton);
            this.Controls.Add(this.acceptedbutton);
            this.Controls.Add(this.label1);
            this.Name = "requestUI";
            this.Text = "requestUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button acceptedbutton;
        private System.Windows.Forms.Button denybutton;
    }
}