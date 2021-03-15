using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class UserID : Form
    {
        //rien
        public UserID()
        {
            InitializeComponent();
        }

        private void btnAppCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string id;
        private void btnSendID_Click(object sender, EventArgs e)
        {
            
            //Session.ShowDialog();
            //Session.labelUserName.Text = rTBUserName.Text;
            //Session.lblMeetingID.Text = rTBMeetingsID.Text;
            id = rTBMeetingsID.Text;
            //this.Hide();
            this.Close();

        }

        private void btnSendID_Leave(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }
        public string getID()
        {
            this.ShowDialog();
            return id;
        }
    }
}
