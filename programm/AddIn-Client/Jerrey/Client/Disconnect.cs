using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Client
{
    public partial class Disconnect : Form
    {
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

        private bool answer;

        public Disconnect()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        private void btnAppCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBleiben_Click(object sender, EventArgs e)
        {
            this.answer = false;
            this.Close();
        }

        private void btnverlassen_Click(object sender, EventArgs e)
        {
            this.answer = true;
            this.Close();
        }
        public bool getAnswer()
        {
            this.ShowDialog();
            return answer;
        }
    }
}
