using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace LaserPointer
{
    public class LaserPointer : Interfaces.LaserPointer
    {
        private System.Diagnostics.Process _Process; //The process on whose window the laserpointer will be displayed
        private DisplayWindow _display_window;

        /// <summary>
        /// this method deserializes the given laserpointerinfo object and initializes a overlaywindow at the position
        /// given by the laserpointerinfoobject
        /// </summary>
        /// <param name="LpInfo"></param>
        public void LaserPointerCallBack(string LpInfojson)
        {
            if (_display_window == null) _display_window = new DisplayWindow(_Process);
            LaserPointerInfo lpinfo = JsonConvert.DeserializeObject<LaserPointerInfo>(LpInfojson);
            try
            {
                _display_window.show(lpinfo);
            }
            catch
            {
                MessageBox.Show("Error: Wasn't able to show the laserpointer, Make sure the Application\n" +
                    "is running. It is important, that it was running, before the Laserpointer-Object was created!");
                return;
            }
        }

        /// <summary>
        /// initializes a laserpointer object with the process on which window the laserpointer is supposed to be drawn.
        /// </summary>
        /// <param name="Inv_Process">the Process on whose mainwindow the laserpointer is supposed to be shown</param>
        public LaserPointer(System.Diagnostics.Process Inv_Process)
        {
            this._Process = Inv_Process;
        }
    }
}
