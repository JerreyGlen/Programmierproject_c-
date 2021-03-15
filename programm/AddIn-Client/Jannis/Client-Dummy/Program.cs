using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Networking;
using System.Windows.Forms;
using System.Diagnostics;

namespace Client_Dummy
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //check if inventor is running and if not stop the application
            Process checkinventor = Process.GetProcessesByName("Inventor").FirstOrDefault();
            if(checkinventor == null)
            {
                MessageBox.Show("Inventor has to be open!");
                return;
            }

            //start the gui application
            Form f = new gui();
            f.ShowDialog();

        }
    }
}
