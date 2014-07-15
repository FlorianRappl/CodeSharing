using System;
using System.Windows;
using System.Windows.Input;

namespace CodeSharing.App04
{
    partial class MouseTracker
    {
        Point buffer;

        public void Start()
        {
            if (!_tracking)
            {
                buffer = Mouse.GetPosition(Application.Current.MainWindow);
                Application.Current.MainWindow.MouseMove += MouseMoved;
                IsTracking = true;
            }
        }

        void MouseMoved(Object sender, MouseEventArgs e)
        {
            var tmp = e.GetPosition(Application.Current.MainWindow);
            var vec = tmp - buffer;
            Distance += vec.Length;
            buffer = tmp;
        }

        public void Stop()
        {
            if (_tracking)
            {
                Application.Current.MainWindow.MouseMove -= MouseMoved;
                IsTracking = false;
            }
        }
    }
}
