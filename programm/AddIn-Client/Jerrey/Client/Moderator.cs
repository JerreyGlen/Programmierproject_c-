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
    public partial class Moderator : Form
    {
        private bool answer;
        public Moderator()
        {
            InitializeComponent();
        }

        private void btnNichtmehr_Click(object sender, EventArgs e)
        {
            answer = false;
            this.Close();
        }

        private void btnAppCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmoderat_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Sie sind jetzt Moderator");
            answer = true;
            this.Close();
        }

        private void Moderator_MouseLeave(object sender, EventArgs e)
        {
            
        }

        public bool getanswer()
        {
            this.ShowDialog();
            return answer;
        }
    }
}
