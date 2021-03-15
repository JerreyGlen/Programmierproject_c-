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

    public partial class Chaat : Form
    {
        public Networking.Networking network;
        //singleton:
        public static Chaat Instance
        {
            get
            {
                if (chatinstance == null) chatinstance = new Chaat();
                return chatinstance;
            }
        }
        private static Chaat chatinstance;

        private static ListView chatmessages;
        private static List<ListViewItem> messageslist;
        public static void remove_Thread_Dependency(Networking.Networking nw)
        {
            messageslist = new List<ListViewItem>();
            foreach (ListViewItem lvi in chatmessages.Items) messageslist.Add(lvi);
            if (Application.OpenForms.OfType<Chaat>().Count() > 0)
                chatinstance.Invoke(new Action(() =>
                {
                    chatinstance.Controls.Remove(chatmessages);
                    chatinstance.Close();
                }));
            chatinstance = new Chaat();
            chatinstance.network = nw;
        }
        private Chaat()
        {
            InitializeComponent();

            chatmessages = new ListView();
            chatmessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            chatmessages.HideSelection = false;
            chatmessages.Location = new System.Drawing.Point(12, 24);
            chatmessages.Name = "listView1";
            chatmessages.Size = new System.Drawing.Size(794, 416);
            chatmessages.TabIndex = 13;
            chatmessages.UseCompatibleStateImageBehavior = false;
            chatmessages.FullRowSelect = true;
            chatmessages.Columns.Add("col1", -2, HorizontalAlignment.Left);
            chatmessages.GridLines = true;
            chatmessages.View = System.Windows.Forms.View.List;
            this.Controls.Add(chatmessages);
            if(messageslist != null && messageslist.Count > 0)
            {
                foreach (ListViewItem lvi in messageslist)
                {
                    ListViewItem li = new ListViewItem();
                    li.ForeColor = Color.Gray;
                    li.Text = $"{lvi.Text}";
                    chatmessages.Items.Add(li);
                }
            }
        }
        public void reduirer()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void dGVMessages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void sendChat(string msg)
        {
            network.sendChatMSG(msg);

            addMessage(new Message(Message.Sender.Me, msg));
        }
        public static void addMessage(Message msg)
        {
            if (Application.OpenForms.OfType<Chaat>().Count() > 0)
            {
                Instance.Invoke(new Action(() =>
                {
                    ListViewItem li = new ListViewItem();
                    li.ForeColor = Color.Gray;
                    li.Text = $"{msg.sender.ToString()}> {msg.message}";
                    chatmessages.Items.Add(li);
                }));
            }
            else
            {
                ListViewItem li = new ListViewItem();
                li.ForeColor = Color.Gray;
                li.Text = $"{msg.sender.ToString()}> {msg.message}";
                chatmessages.Items.Add(li);
            }
        }
    }
    public class Message
    {
        public enum Sender
        {
            Me,
            Partner
        }
        public Sender sender;
        public string message;

        public Message(Sender s, string msg)
        {
            this.sender = s;
            this.message = msg;
        }

    }
}
