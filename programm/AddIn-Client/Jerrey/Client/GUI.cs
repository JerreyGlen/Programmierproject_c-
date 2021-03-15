using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Inventor;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace Client
{
    public partial class GUI : Form
    {
        private bool windowactive
        {
            get
            {
                if (System.Windows.Forms.Application.OpenForms.OfType<GUI>().Count() > 0) return true;
                else return false;
            }
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        
        private static extern IntPtr CreateRoundRectRgn
         (
              int nLeftRect,
              int nTopRect,
              int nRightRect,
              int nBottomRect,
              int nWidthEllipse,
                 int nHeightEllipse

          );

        public Networking.Networking network;
        Inventor.Application m_inventorApp = null;
        public delegate void updatemethod(string info);
        updatemethod UpdateInfo;
        updatemethod UpdateStatus;
        public GUI(Inventor.Application inv_App, updatemethod udstatus, updatemethod udinfo)
        {
            this.UpdateInfo = udinfo;
            this.UpdateStatus = udstatus;
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25)); // um runde
            //this.pnlForm.Hide();
            pnlFormL.Visible = false;

            pnlNav.Hide();

            frmChaat.Dock = DockStyle.Fill;
            frmChaat.TopLevel = false;
            frmChaat.TopMost = true;




        }
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        [DllImport("user32.dll")]
        private static extern IntPtr ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

        public Bitmap CaptureApplication(string procName)
        {
            Process proc;

            // Cater for cases when the process can't be located.
            try
            {
                proc = Process.GetProcessesByName(procName)[0];
            }
            catch (IndexOutOfRangeException e)
            {
                return null;
            }

            // You need to focus on the application
            SetForegroundWindow(proc.MainWindowHandle);
            ShowWindow(proc.MainWindowHandle, SW_RESTORE);

            // You need some amount of delay, but 1 second may be overkill
            Thread.Sleep(1000);

            Rect rect = new Rect();
            IntPtr error = GetWindowRect(proc.MainWindowHandle, ref rect);

            // sometimes it gives error.
            while (error == (IntPtr)0)
            {
                error = GetWindowRect(proc.MainWindowHandle, ref rect);
            }

            int width = rect.right - rect.left;
            int height = rect.bottom - rect.top;

            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics.FromImage(bmp).CopyFromScreen(rect.left,
                                                   rect.top,
                                                   0,
                                                   0,
                                                   new Size(width, height),
                                                   CopyPixelOperation.SourceCopy);

            return bmp;
        }





        private void hideSubMenu()
        {
            if (pnlTitle.Visible == true) pnlTitle.Visible = false;
        }
        private void showSubMenu(Panel panel1)
        {
            if (panel1.Visible == false)
            {
                hideSubMenu();
                panel1.Visible = true;
            }
            else panel1.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(Chaat.Instance);

            hideSubMenu();
        }




        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(childForm);
            pnlForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }


        //ALL BUTTON CLICK IN ORDER


        //Streaming button

        private void btnStream_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            pnlNav.Show();
            lblTitle.Text = "Streaming";
            /*this.pnlForm.Controls.Clear();
            streaming.FormBorderStyle = FormBorderStyle.None;
            this.pnlForm.Controls.Add(streaming);
            streaming.Show();*/
            pnlFormL.Visible = false;
            pnlNav.Height = btnStream.Height;
            pnlNav.Top = btnStream.Top;
            pnlNav.Left = btnStream.Left;
            btnStream.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
        }


        //Messages button
        public Chaat frmChaat = Chaat.Instance;
        private void btnMessages_Click(object sender, EventArgs e)
        {
            if (windowactive)
            {
                Invoke(new Action(() =>
                {
                    tableLayoutPanel1.Visible = false;
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


        public void updateimage(Image img)
        {
            if (windowactive)
            {
                Invoke(new Action(() =>
                {
                    double widthpercentage = img.Width / img.Height;
                    pBGrab.Width = (int)(widthpercentage * pBGrab.Height);
                    pBGrab.Image = img;

                }));
            }
        }

        //Disconnect button
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDisconnect.Height;
            pnlNav.Top = btnDisconnect.Top;
            btnDisconnect.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);

            Thread thread = new Thread(askclose);
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
        }

        //Help Button
        public Help frmHelp = new Help() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        private void button16_Click(object sender, EventArgs e)
        {
            pnlFormL.Visible = true;
            pnlNav.Show();
            lblTitle.Text = "Help";
            this.pnlFormL.Controls.Clear();
            frmHelp.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormL.Controls.Add(frmHelp);
            frmHelp.Show();
        }

        //BUTTONS LEAVE


        private void btnStream_Leave(object sender, EventArgs e)
        {
            btnStream.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
        }
        private void btnMessages_Leave(object sender, EventArgs e)
        {
            btnMessages.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
        }
        private void btnDisconnect_Leave(object sender, EventArgs e)
        {
            btnDisconnect.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
        }
        private void btnHelp_Leave(object sender, EventArgs e)
        {
            btnHelp.BackColor = System.Drawing.Color.FromArgb(24, 30, 54);
        }

        private void askclose()
        {

            Disconnect Session = new Disconnect();

            if (Session.getAnswer())
            {
                UpdateInfo("[-] disconnected");
                UpdateStatus("");
                network.disconnect();
                this.safeclose();
            }

        }

        private void btnAppCLose_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(askclose);
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GUI_Load(object sender, EventArgs e)
        {

            try //Try to get an active instance of Inventor
            {
                try
                {
                    m_inventorApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application") as Inventor.Application;
                }
                catch
                {
                    Type inventorAppType = System.Type.GetTypeFromProgID("Inventor.Application");

                    m_inventorApp = System.Activator.CreateInstance(inventorAppType) as Inventor.Application;

                    //Must be set visible explicitly
                    m_inventorApp.Visible = true;
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error: couldn't create Inventor instance");
            }

        }

        private void GUI_Activated(object sender, EventArgs e)
        {

        }

        private void pnlFormLoader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnModerator_Click(object sender, EventArgs e)
        {
            network.requestModerator();
            Chaat.addMessage(new Message(Message.Sender.Me, "Moderator request sent"));
        }


        //Für Streaming
        private void buttonEllipse1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(btnMessage.Text)) Chaat.Instance.sendChat(btnMessage.Text);
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        public void safeclose()
        {
            if (windowactive)
            {
                Invoke(new Action(() =>
                {
                    m_inventorApp.Visible = true;
                    this.Close();
                }));
            }
        }

        private void pBGrab_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (e as MouseEventArgs);
            double xperc = me.X / (double)pBGrab.Width;
            double yperc = me.Y / (double)pBGrab.Height;

            Interfaces.LaserPointerInfo lpinfo = new LaserPointer.LaserPointerInfo(yperc, yperc);
            network.sendLaserPointerInfo(lpinfo);
        }

    }
}
