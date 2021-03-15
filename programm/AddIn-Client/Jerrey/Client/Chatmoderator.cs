using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Chatmoderator : Form
    {
        private bool windowactive
        {
            get
            {
                if (Application.OpenForms.OfType<Chatmoderator>().Count() > 0) return true;
                else return false;
            }
        }
        public Chatmoderator(Networking.Networking nv)
        {
            Chaat chatinstance = Chaat.Instance;
            InitializeComponent();
            chatinstance.Dock = DockStyle.Fill;
            chatinstance.TopLevel = false;
            chatinstance.TopMost = true;
            pnlFormL.Visible = true;
            pnlNav.Show();
            lblTitle.Text = "Messages";
            this.pnlFormL.Controls.Clear();
            frmHelp.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormL.Controls.Add(chatinstance);
            chatinstance.Show();
            network = nv;
        }
        private static Networking.Networking network;
        public Help frmHelp = new Help() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        private void btnHelp_Click(object sender, EventArgs e)
        {
            pnlFormL.Visible = true;
            pnlNav.Show();
            lblTitle.Text = "Help";
            this.pnlFormL.Controls.Clear();
            frmHelp.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormL.Controls.Add(frmHelp);
            frmHelp.Show();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnAppCLose_Click(object sender, EventArgs e)
        {
            safeClose();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDisconnect.Height;
            pnlNav.Top = btnDisconnect.Top;
            btnDisconnect.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            Disconnect Session = new Disconnect();
            Session.Show();
        }

        private void pnlFormL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSendMessages_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(btnMessage.Text)) Chaat.Instance.sendChat(btnMessage.Text);
        }
        public void safeClose()
        {
            this.pnlFormL.Controls.Remove(Chaat.Instance);
            this.Close();
        }
        private static Chaat frmChaat;
        private void btnMessages_Click(object sender, EventArgs e)
        {
            if (windowactive)
            {
                Invoke(new Action(() =>
                {

                    Chaat.remove_Thread_Dependency(network);
                    frmChaat = Chaat.Instance;
                    pnlFormL.Visible = true;
                    pnlNav.Height = btnMessages.Height;
                    pnlNav.Top = btnMessages.Top;
                    btnMessages.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);

                    pnlNav.Show();
                    lblTitle.Text = "Messages";
                    this.pnlFormL.Controls.Clear();
                    frmChaat.FormBorderStyle = FormBorderStyle.None;
                    frmChaat.TopLevel = false;

                    this.pnlFormL.Controls.Add(frmChaat);
                    frmChaat.Show();
                }));
            }
        }
    }
}
