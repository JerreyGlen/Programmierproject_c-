using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Inventor;
using System.Text;
using System.Threading.Tasks;
using Client;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;


namespace AddIn_Client
{

    public class ButtonAction
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            private int _Left;
            private int _Top;
            private int _Right;
            private int _Bottom;

            public RECT(RECT Rectangle) : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
            {
            }
            public RECT(int Left, int Top, int Right, int Bottom)
            {
                _Left = Left;
                _Top = Top;
                _Right = Right;
                _Bottom = Bottom;
            }

            public int X
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Y
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Left
            {
                get { return _Left; }
                set { _Left = value; }
            }
            public int Top
            {
                get { return _Top; }
                set { _Top = value; }
            }
            public int Right
            {
                get { return _Right; }
                set { _Right = value; }
            }
            public int Bottom
            {
                get { return _Bottom; }
                set { _Bottom = value; }
            }
            public int Height
            {
                get { return _Bottom - _Top; }
                set { _Bottom = value + _Top; }
            }
            public int Width
            {
                get { return _Right - _Left; }
                set { _Right = value + _Left; }
            }
            public System.Drawing.Point Location
            {
                get { return new System.Drawing.Point(Left, Top); }
                set
                {
                    _Left = value.X;
                    _Top = value.Y;
                }
            }
            public Size Size
            {
                get { return new Size(Width, Height); }
                set
                {
                    _Right = value.Width + _Left;
                    _Bottom = value.Height + _Top;
                }
            }

            public static implicit operator Rectangle(RECT Rectangle)
            {
                return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
            }
            public static implicit operator RECT(Rectangle Rectangle)
            {
                return new RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
            }
            public static bool operator ==(RECT Rectangle1, RECT Rectangle2)
            {
                return Rectangle1.Equals(Rectangle2);
            }
            public static bool operator !=(RECT Rectangle1, RECT Rectangle2)
            {
                return !Rectangle1.Equals(Rectangle2);
            }

            public override string ToString()
            {
                return "{Left: " + _Left + "; " + "Top: " + _Top + "; Right: " + _Right + "; Bottom: " + _Bottom + "}";
            }

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            public bool Equals(RECT Rectangle)
            {
                return Rectangle.Left == _Left && Rectangle.Top == _Top && Rectangle.Right == _Right && Rectangle.Bottom == _Bottom;
            }

            public override bool Equals(object Object)
            {
                if (Object is RECT)
                {
                    return Equals((RECT)Object);
                }
                else if (Object is Rectangle)
                {
                    return Equals(new RECT((Rectangle)Object));
                }

                return false;
            }
        }
        //fDie neueste Screenshot funktion
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        public static Bitmap PrintWindow(IntPtr hwnd)
        {
            RECT rc;
            GetWindowRect(hwnd, out rc);

            Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            PrintWindow(hwnd, hdcBitmap, 0);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            return bmp;
        }

        /*Process p = Process.GetProcessesByName("Inventor").FirstOrDefault();
        IntPtr handle = p.MainWindowHandle;
        pBGrab.BackgroundImage = PrintWindow(handle);*/

        //Bis Hier


        public static Thread Streaming;
        public static Networking.Networking network;
        public static Inventor.Application InventorApp;
        public static List<CommandControl> infobutton = new List<CommandControl>();
        public static List<CommandControl> statusbutton = new List<CommandControl>();
        private static LaserPointer.LaserPointer laserpointer;
        private static GUI Session;
        private static string sessionid;
        private static bool streamingflag;
        private static Thread viewerWindow;

        private static byte[] bmptobytes(Image img)
        {
            byte[] ret;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                ret =  ms.ToArray();
            }
            return ret;
        }

        private static void Startstreaming()
        {
            Process p = Process.GetCurrentProcess();
            streamingflag = true;
            while (streamingflag)
            {
                network.sendIMG(bmptobytes(PrintWindow(p.MainWindowHandle)));
                Thread.Sleep(2000);
            }
        }
        private static void showviewerwindow()
        {
            viewerWindow = new Thread(() => { try { Session.ShowDialog(); } catch { } });
            viewerWindow.Start();
        }

        private static void togglerole()
        {
            if (InventorApp.Visible)
            {
                streamingflag = false;
                InventorApp.ActiveDocument.Save();
                network.sendFile(InventorApp.ActiveDocument.FullFileName);
                InventorApp.Visible = false;
                if (Session == null)
                {
                    Session = new GUI(InventorApp, updatestatus, updateinfo);
                    Session.lblMeetingID.Text = sessionid;

                }
                Session.network = network;
                showviewerwindow();
            }
            else
            {
                InventorApp.Visible = true;
                Session?.safeclose();
                Streaming = new Thread(Startstreaming);
                Streaming.Start();

            }

        }
        private static void updateinfo(string info)
        {
            //updating the text of the info button in all working modes
            lock (infobutton)
            {
                while (infobutton.Count > 0)
                {
                    infobutton[0].Delete();
                    infobutton.RemoveAt(0);
                }
                InventorButton button = new InventorButton(
                        info, "InventorAddinServer.Button_" + Guid.NewGuid().ToString(), "Button 1 description", "Info",
                        null, null,
                        CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                button.SetBehavior(true, true, true);
                infobutton.Add(AddinGlobal.assemblyRibbonPanel.CommandControls.AddButton(button.ButtonDef, button.DisplayBigIcon, button.DisplayText, "", button.InsertBeforeTarget));
                infobutton.Add(AddinGlobal.partRibbonPanel.CommandControls.AddButton(button.ButtonDef, button.DisplayBigIcon, button.DisplayText, "", button.InsertBeforeTarget));
                infobutton.Add(AddinGlobal.drawingRibbonPanel.CommandControls.AddButton(button.ButtonDef, button.DisplayBigIcon, button.DisplayText, "", button.InsertBeforeTarget));
            }
        }
        private static void updatestatus(string status)
        {
            //updating the text of the status button in all working modes
            //first delete all the old buttons
            lock (statusbutton)
            {
                while (statusbutton.Count > 0)
                {
                    statusbutton[0].Delete();
                    statusbutton.RemoveAt(0);
                }
                InventorButton button = new InventorButton(
                        status, "InventorAddinServer.Button_" + Guid.NewGuid().ToString(), "Button 1 description", "Info",
                        null, null,
                        CommandTypesEnum.kShapeEditCmdType, ButtonDisplayEnum.kDisplayTextInLearningMode);
                button.SetBehavior(true, true, true);
                //then create updated buttons
                statusbutton.Add(AddinGlobal.assemblyRibbonPanel.CommandControls.AddButton(button.ButtonDef, button.DisplayBigIcon, button.DisplayText, "", button.InsertBeforeTarget));
                statusbutton.Add(AddinGlobal.partRibbonPanel.CommandControls.AddButton(button.ButtonDef, button.DisplayBigIcon, button.DisplayText, "", button.InsertBeforeTarget));
                statusbutton.Add(AddinGlobal.drawingRibbonPanel.CommandControls.AddButton(button.ButtonDef, button.DisplayBigIcon, button.DisplayText, "", button.InsertBeforeTarget));
            }
        }

        #region networkcallbacks
        private static void SessionInfoCallback(string sessionid, Interfaces.delegates.Roles r)
        {
            ButtonAction.sessionid = sessionid;
            updatestatus($"SessionID: {sessionid}\n Rolle: {r.ToString()}");
        }
        private static void ViewerJoinedSessionCallBack()
        {
            updateinfo("[*] a viewer joined the session!");
            Streaming = new Thread(Startstreaming);
            Streaming.Start();
        }
        private static void ModeratorRequestCallBack()
        {
            Moderator mod = new Moderator();
            if (mod.getanswer())
            {
                network.sendRequestAnswer(true);
                togglerole();
            }
            else
            {
                network.sendRequestAnswer(false);
            }
        }
        private static void RequestAnswerCallBack(bool answer)
        {
            if (answer)
            {
                togglerole();
                updateinfo("[*] Moderator-Reques was accepted!");
            }
            else
            {
                MessageBox.Show("Request denied! You have to keep your role.");
            }
        }
        private static void SessionEndedCallBack()
        {
            updateinfo("[!] The Session ended!");
            updatestatus("");
            Session?.safeclose();
            InventorApp.Visible = true;
            streamingflag = false;
            network = null;
        }
        private static void ViewerquitSessionCallBack()
        {
            updateinfo("[*] The Viewer quit the Session!");
            streamingflag = false;
        }
        private static void ConnectionProblemsCallBack(string msg)
        {
            updateinfo("[!] " + msg);
        }

        private static void ChatMSGCallBack(string msg)
        {
            Chaat.addMessage(new Client.Message(Client.Message.Sender.Partner, msg));
        }
        private static void IMGAvailableCallBack(byte[] imgdata)
        {
            Image img;
            using (MemoryStream ms = new MemoryStream(imgdata))
            {
                //img = Bitmap.FromStream(ms);
                img = Image.FromStream(ms);
            }
            Session?.updateimage(img);
        }
        private static void FileAvailableCallBack(byte[] file)
        {
            //overwriting current open file and reopening it:
            string filename = InventorApp.ActiveDocument.FullFileName;
            InventorApp.ActiveDocument.Close();
            System.IO.File.Delete(filename);
            System.IO.File.WriteAllBytes(filename, file);
            InventorApp.Documents.Open(filename);
        }
        #endregion

        private static void initializenw()
        {
            network = new Networking.Networking();
            Process p = Process.GetCurrentProcess();
            laserpointer = new LaserPointer.LaserPointer(p);
            network.SessionInfoAvailable += SessionInfoCallback;
            network.ViewerJoinedSession += ViewerJoinedSessionCallBack;
            network.LaserPointerInfoAvailable += laserpointer.LaserPointerCallBack;
            network.ModeratorRequest += ModeratorRequestCallBack;
            network.SessionEnded += SessionEndedCallBack;
            network.ViewerQuitSession += ViewerquitSessionCallBack;
            network.ConnectionProblems += ConnectionProblemsCallBack;
            network.RequestAnswerAvailable += RequestAnswerCallBack;
            network.IMGAvailable += IMGAvailableCallBack;
            network.ChatMSGAvailable += ChatMSGCallBack;
            network.FileAvailable += FileAvailableCallBack;
            Chaat.Instance.network = network;

        }

        //Seesion erstellen
        public static void Button1_Execute()
        {
            if (network == null || network.connected == false)
            {
                initializenw();
                try
                {
                    network.connect("new", InventorApp.ActiveDocument.FullFileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //Meeting beitreten
        public static void Button2_Execute()
        {
            InventorApp.ActiveDocument.Save();
            UserID Sesion = new UserID();
            //Session = Sesion;
            string sessionid = Sesion.getID();
            if (network != null && network.connected) return;
            if (network == null || network.connected == false)
            {
                initializenw();
                try
                {
                    network.connect(sessionid, InventorApp.ActiveDocument.FullFileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            InventorApp.Visible = false;
            Session = new GUI(InventorApp, updatestatus, updateinfo);
            Session.network = network;
            Session.lblMeetingID.Text = sessionid;
            Session.ShowDialog();
            InventorApp.Visible = true;



        }
        //Messages
        public static void Button3_Execute()
        {
            if (network != null && network.connected)
            {
                Chatmoderator cm = new Chatmoderator(network);
                cm.Show();
            }
        }
        //Sesion Enden
        public static void Button4_Execute()
        {
            Disconnect disco = new Disconnect();
            if (disco.getAnswer() && network.connected)
            {
                InventorApp.ActiveDocument.Save();
                network.sendFile(InventorApp.ActiveDocument.FullFileName);
                network.disconnect();
                updatestatus("");
                updateinfo("[#] Sesion ended");
            }
            
        }
        //Information
        public static void Button5_Execute()
        {
            MessageBox.Show("Your Information");
        }
    }
}
