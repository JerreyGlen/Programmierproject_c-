using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Networking;
using Interfaces;
using LaserPointer;
using System.IO;
using System.Drawing.Imaging;

namespace Client_Dummy
{
    public partial class gui : Form
    {
        Networking.Networking nw;
        LaserPointer.LaserPointer _LaserPointer;

        private Process _Process; //the process on which the laserpointer is shown later

        public gui()
        {
            InitializeComponent();

            this.requestmodbutton.Hide();

            //subscribe to the events of the networking object with all the callback methods
            nw = new Networking.Networking();
            nw.SessionInfoAvailable += sessioncallback;
            nw.ChatMSGAvailable += chatCallBack;
            nw.ViewerJoinedSession += viewerJoinedCallBack;
            nw.ViewerQuitSession += onquitCallBack;
            nw.SessionEnded += onEndCallBack;
            nw.FileAvailable += fileCallBack;
            nw.IMGAvailable += IMGCallBack;
            nw.ConnectionProblems += ConncectionProblemCallBack;
            nw.RequestAnswerAvailable += requestAnswerCallback;
            nw.ModeratorRequest += ModeratorRequestCallBack;



            //initialize the chatoutput
            this.chatoutput.FullRowSelect = true;
            chatoutput.Columns.Add("col1", -2, HorizontalAlignment.Left);
            chatoutput.GridLines = true;
            chatoutput.View = System.Windows.Forms.View.List;

            


        }


        #region screenshotting

        /// <summary>
        /// creates a screenshot
        /// </summary>
        /// <param name="s">the screen to take the screenshot from</param>
        /// <returns>the captured image as an byte array from a bitmap</returns>
        private byte[] captureScreen(Screen s)
        {
            //create a bitmap with the size of the screen
            Bitmap bmp = new Bitmap(s.Bounds.Width,
                               s.Bounds.Height,
                               PixelFormat.Format32bppArgb);
            //create a graphics object on it
            Graphics gfx = Graphics.FromImage(bmp);

            //take the screenshot
            gfx.CopyFromScreen(s.Bounds.X, s.Bounds.Y, 0, 0, s.Bounds.Size, CopyPixelOperation.SourceCopy);
            byte[] ret;
            //convert the bitmap into a byte-array
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, ImageFormat.Png);
                ret = ms.ToArray();
            }
            return ret;
        }



        #endregion

        #region callback methods
        //using Invoke() in the callback method because otherwise it wouldn't be possible to access
        //this form's controls from another thread
        void ConncectionProblemCallBack(string msg)
        {
            Invoke(new Action(() =>
            {
                ListViewItem li = new ListViewItem();
                li.ForeColor = Color.Blue;
                li.Text = msg;
                chatoutput.Items.Add(li);
            }));

        }

        void IMGCallBack(byte[] imgadata)
        {

            Image img;
            using (MemoryStream ms = new MemoryStream(imgadata))
            {
                //img = Bitmap.FromStream(ms);
                img = Image.FromStream(ms);
            }
            double widthperc = img.Width / (float)img.Height;
            Invoke(new Action(()=> {
                
                this.pictureBox1.Width = (int)(widthperc * pictureBox1.Height);
                
            }));
            this.pictureBox1.Image = img;

        }
        void fileCallBack(byte[] file)
        {
            using (FileStream fs = File.OpenWrite(filenameinput.Text))
            {
                fs.Write(file, 0, file.Length);
            }
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "notepad.exe";
            psi.Arguments = filenameinput.Text;
            Process.Start(psi);
        }
        void viewerJoinedCallBack()
        {
            Invoke(new Action(() =>
            {
                ListViewItem li = new ListViewItem();
                li.ForeColor = Color.Blue;
                li.Text = "[*]Viewer Joined";
                chatoutput.Items.Add(li);
            }));
        }
        void onquitCallBack()
        {
            Invoke(new Action(() =>
            {
                ListViewItem li = new ListViewItem();
                li.ForeColor = Color.Blue;
                li.Text = "[!]Viewer Quit the session....";
                chatoutput.Items.Add(li);
            }));
        }
        void onEndCallBack()
        {
            Invoke(new Action(() =>
            {
                ListViewItem li = new ListViewItem();
                li.ForeColor = Color.Blue;
                li.Text = "[!] The Session ended";
                chatoutput.Items.Add(li);
                this.Close();
            }));
            MessageBox.Show("The Session endend!");

        }
        void chatCallBack(string msg)
        {
            Invoke(new Action(() =>
            {
                ListViewItem li = new ListViewItem();
                li.ForeColor = Color.Red;
                li.Text = "partner> " + msg;
                chatoutput.Items.Add(li);
            }));
        }

        void ModeratorRequestCallBack()
        {
            bool useranswer = requestUI.askUser();
            nw.sendRequestAnswer(useranswer);
        }

        void requestAnswerCallback(bool accepted)
        {
            string message;
            if (accepted) message = "Moderator accepted your Request";
            else message = "Moderator denied your Request";
            Invoke(new Action(() =>
            {
                ListViewItem li = new ListViewItem();
                li.ForeColor = Color.Red;
                li.Text = "[*] " + message;
                chatoutput.Items.Add(li);
            }));

        }

        private void sessioncallback(string id, delegates.Roles r)
        {
            Invoke(new Action(() =>
            {
                if (r == delegates.Roles.Moderator)
                {
                    requestmodbutton.Hide();
                    disconnectbutton.Text = "End Session";
                }
                else
                {
                    requestmodbutton.Show();
                    disconnectbutton.Text = "disconnect";
                }
                info.Text = $"info: Du bist {r.ToString()} in der Session \"{id}\"";
                sessionid.Text = id;
            }));
        }

        #endregion

        #region gui event handling
        private void connect_Click(object sender, EventArgs e) //connect button
        {
            if (nw.connected)
            {
                //exit if already connected:
                MessageBox.Show("Already connected!");
                return;
            }
            try
            {
                if (!string.IsNullOrEmpty(sessionid.Text) && !string.IsNullOrEmpty(filenameinput.Text))
                {
                    //if user put a sessionid in the input field, try to connect to the session on the server

                    nw.connect(sessionid.Text, filenameinput.Text);
                }
                else
                {
                    //if user put nothing in the sessionid input field try to create a new session on the server
                    nw.connect("new", filenameinput.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during connection process: {ex.Message}");
            }

            //get the inventor's process and initialize the laserpointer with it
            _Process = Process.GetProcessesByName("Inventor").FirstOrDefault(); //LaserPointer initialisieren und ihn an den inventor Prozess anmelden
            _LaserPointer = new LaserPointer.LaserPointer(_Process);
            //then subscribe the laserpointers callback to the laserpointerinfoavailable event of the networking object
            nw.LaserPointerInfoAvailable += _LaserPointer.LaserPointerCallBack; //laserpointercallback am nw event anmelden

        }

        private void sendChat_Click(object sender, EventArgs e) //send chat button
        {
            if (!string.IsNullOrEmpty(chatinput.Text))
            {
                nw.sendChatMSG(chatinput.Text); //send chat message
                //display chat message in chat window
                ListViewItem li = new ListViewItem();
                li.ForeColor = Color.Green;
                li.Text = "me> " + chatinput.Text;
                chatoutput.Items.Add(li);
                chatinput.Text = "";

            }
        }
        private void chooseFile_Click(object sender, EventArgs e) //choose file button
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.ShowDialog();

                filenameinput.Text = ofd.FileName;
            }
        }

        private void ChatInput_Keyboard(object sender, KeyEventArgs e)//when enter is pressed while typing a chat message
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendChat_Click(new object(), new EventArgs());
                
            }
        }

        private void disconnect_Click(object sender, EventArgs e)//disconnect button
        {
            nw.disconnect();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e) //laserpointer click button
        {
            MouseEventArgs me = (e as MouseEventArgs);
            if (me == null) return;
            double xpercentage_click = (double)me.Location.X / (double)this.pictureBox1.Width;
            double ypercentage_click = (double)me.Location.Y / (double)this.pictureBox1.Height;
            nw.sendLaserPointerInfo(new LaserPointer.LaserPointerInfo(xpercentage_click, ypercentage_click));
            //LaserPointer.LaserPointerInfo lpinfo = new LaserPointer.LaserPointerInfo(xpercentage_click, ypercentage_click);

        }

        private void send_File_Click(object sender, EventArgs e) //send file button
        {
            nw.sendFile(this.filenameinput.Text);
        }

        private void sendScreenshot_Click
            (object sender, EventArgs e)//screenshot button
        {
            Screen s;
            s = Screen.PrimaryScreen;
            nw.sendIMG(captureScreen(s));
            File.WriteAllBytes(@"C:\Users\janni\Desktop\out.png", captureScreen(s));
        }

        private void requestmodbutton_Click(object sender, EventArgs e) //request moderator button
        {
            nw.requestModerator();
        }
        #endregion


    }
}
