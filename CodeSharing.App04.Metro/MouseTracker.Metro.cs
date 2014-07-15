using System;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Core;

namespace CodeSharing.App04
{
    partial class MouseTracker
    {
        Point buffer;

        public void Start()
        {
            if (!_tracking)
            {
                buffer = CoreWindow.GetForCurrentThread().PointerPosition;
                CoreWindow.GetForCurrentThread().PointerMoved += PointerMoved;
                IsTracking = true;
            }
        }

        void PointerMoved(CoreWindow sender, PointerEventArgs args)
        {
            if (args.CurrentPoint.PointerDevice.PointerDeviceType == PointerDeviceType.Mouse)
            {
                var tmp = args.CurrentPoint.RawPosition;
                var dx = tmp.X - buffer.X;
                var dy = tmp.Y - buffer.Y;
                Distance += Math.Sqrt(dx * dx + dy * dy);
                buffer = tmp;
            }
        }

        public void Stop()
        {
            if (_tracking)
            {
                CoreWindow.GetForCurrentThread().PointerMoved -= PointerMoved;
                IsTracking = false;
            }
        }
    }
}
