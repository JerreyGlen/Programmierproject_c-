using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Dummy
{
    public partial class requestUI : Form
    {
        public static bool accepted;
        public requestUI()
        {
            InitializeComponent();
        }

        public static bool askUser()
        {
            Form requestui = new requestUI();
            requestui.ShowDialog();
            return accepted;
        }

        private void deny_click(object sender, EventArgs e) // deny button
        {
            accepted = false;
            this.Close();
        }

        private void acceptedbutton_Click(object sender, EventArgs e)
        {
            accepted = true;
            this.Close();
        }
    }
}
