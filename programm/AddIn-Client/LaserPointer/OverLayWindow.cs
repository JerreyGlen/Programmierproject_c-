using System;
using System.Diagnostics;
using System.Drawing;
using Overlay.NET.Common;
using Overlay.NET.Directx;
using Process.NET.Windows;

namespace LaserPointer
{
    public class OverLayWindow : DirectXOverlayPlugin
    {
        private readonly TickEngine _tickEngine = new TickEngine();

        public bool active = true; //this flag tells if the overlaywindow is supposed to be shown or not

        private int _redBrush;

        //the x and y percentage which tell where the laserpointerdot is supposed to be drawn
        double _Xpercentage;
        double _Ypercentage;

        /// <summary>
        /// initializes the overlaywindow with a targetwindow on which the overlaywindow is supposed to be shown
        /// </summary>
        /// <param name="targetWindow"></param>
        public override void Initialize(IWindow targetWindow)
        {
            // Set target window by calling the base method
            base.Initialize(targetWindow);



            OverlayWindow = new DirectXOverlayWindow(targetWindow.Handle, false);

            _redBrush = OverlayWindow.Graphics.CreateBrush(0x7FFF0000); //set brush color to red

            // register events for the tick engine.

            _tickEngine.PreTick += OnPreTick; //is ivoked before every tick of the tickengine
            _tickEngine.Tick += OnTick; //is invoked on every tick of the tickengine

        }

        /// <summary>
        /// updates the overlay window and calls the internalrender method to draw the laserpointerdot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTick(object sender, EventArgs e)
        {
            OverlayWindow.Update();
            InternalRender();
        }

        /// <summary>
        /// shows the overlay window if the target window is visible and activated(the current window the user is interacting with)
        /// and hides the overlay window if the is not visible or not activated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPreTick(object sender, EventArgs e)
        {
            var targetWindowIsActivated = TargetWindow.IsActivated;
            if (!targetWindowIsActivated && OverlayWindow.IsVisible)
            {
                ClearScreen();
                OverlayWindow.Hide();
            }
            else if (targetWindowIsActivated && !OverlayWindow.IsVisible)
            {
                OverlayWindow.Show();
            }
        }

        /// <summary>
        /// enables the overlaywindow and sets the position of the laserpointerdot
        /// </summary>
        /// <param name="xpercentage"></param>
        /// <param name="ypercentage"></param>
        public override void Enable(double xpercentage, double ypercentage)
        {
            this._Xpercentage = xpercentage;
            this._Ypercentage = ypercentage;
            _tickEngine.Interval = (new TimeSpan(0, 0, 0, 0, 1000 / 30));
            _tickEngine.IsTicking = true;
            base.Enable(xpercentage,ypercentage);
        }

        /// <summary>
        /// disables the overlay window
        /// </summary>
        public override void Disable()
        {
            //stop the tickengine and therefore also the updating
            _tickEngine.IsTicking = false;
            try
            {
                _tickEngine.Stop();
                base.Disable();
            }
            catch
            {

            }
        }

        /// <summary>
        /// updates the overlaywindow
        /// </summary>
        public override void Update() => _tickEngine.Pulse();

        /// <summary>
        /// this method draws the circle on the graphics of the overlaywindow
        /// </summary>
        protected void InternalRender()
        {

            OverlayWindow.Graphics.BeginScene();
            OverlayWindow.Graphics.ClearScene();

            //draw circle on the graphics of the overlay window with the given relative position
            OverlayWindow.Graphics.DrawCircle((int)(_Xpercentage * OverlayWindow.Width), (int)(_Ypercentage * OverlayWindow.Height), 10, 4, _redBrush);


            OverlayWindow.Graphics.EndScene();
        }

        public override void Dispose()
        {
            OverlayWindow.Dispose();
            base.Dispose();
        }

        /// <summary>
        /// this method clears the window
        /// </summary>
        private void ClearScreen()
        {
            OverlayWindow.Graphics.BeginScene();
            OverlayWindow.Graphics.ClearScene();
            OverlayWindow.Graphics.EndScene();
        }
    }
}