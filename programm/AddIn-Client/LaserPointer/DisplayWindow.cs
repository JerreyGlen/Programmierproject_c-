using System;
using System.Diagnostics;
using System.Threading;
using Process.NET;
using System.Runtime.InteropServices;
using Process.NET.Memory;

namespace LaserPointer
{
    public class DisplayWindow
    {
        private ProcessSharp _processSharp;
        private Thread displaythread;
        private System.Diagnostics.Process _Process;

        private OverLayWindow _Overlay;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="process">the process on whose window the overlaywindow is shown</param>
        public DisplayWindow(System.Diagnostics.Process process)
        {
            _Process = process;
        }

        /// <summary>
        /// this imported method from api puts the window from the specified handle to the front
        /// </summary>
        /// <param name="hWnd">the window which is supposed to be put to the front</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private bool _active = false;//flag=true:overlaywindow may be shown, flag= false: overlaywindow is not allowed to be shown


        private bool _finished = false; //tells if the thread which shows the overlaywindow is finished

        /// <summary>
        /// this method activates the overlay window for 5 seconds
        /// </summary>
        /// <param name="lpinfoobj">
        /// the object that contains the information where the laserpointerdot is supposed to be shown
        /// </param>
        void run(object lpinfoobj)
        {
            LaserPointerInfo lpinfo = (lpinfoobj as LaserPointerInfo);
            try
            {
                if (_Process == null) throw new Exception("Process to display laserpointerdot on is null");

                //initialize overlaywindow
                _Overlay = new OverLayWindow();
                _processSharp = new ProcessSharp(_Process, MemoryType.Remote);

                
                _Overlay.active = true;
                _Overlay.Initialize(_processSharp.WindowFactory.MainWindow);
                _Overlay.Enable(lpinfo.xPercentage, lpinfo.yPercentage);

                //put window of _Process in the foreground
                SetForegroundWindow(_Process.MainWindowHandle);

                DateTime starttime = DateTime.Now; //register the time when this overlay is supposed to start
                Stopwatch sw = new Stopwatch();
                sw.Start();
                //show Window for 5 seconds and as long _active is true 
                while (_active == true && sw.ElapsedMilliseconds < 5000)
                {
                    _Overlay.Update();
                }
                sw.Stop();
                //disable overlay window
                _Overlay.active = false;
                _Overlay.Disable();
                _Overlay.Dispose();

                _finished = true; //this flag tells that the thread ended

            }
            catch (Exception ex)
            {
                if (_active) throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// this method starts a thread which shows a laserpointer dot on _Process's window on the specified position
        /// </summary>
        /// <param name="lpinfo"></param>
        public void show(LaserPointerInfo lpinfo)
        {
            //if a overlaywindow is already shown, the thread that runs the current overlaywindow is stopped
            if (_active) stop();


            _active = true;
            //start a parameterized thread which shows the laserpointerdot
            displaythread = new Thread(new ParameterizedThreadStart(run));
            displaythread.Start(lpinfo);

        }

        /// <summary>
        /// this method stops the thread which shows the laserpointer dot on process's window
        /// </summary>
        public void stop()
        {
            _active = false;

            while (!_finished) //wait until the thread stopped
            {
                Thread.Sleep(20);
            }

            _finished = false;
        }
    }
}