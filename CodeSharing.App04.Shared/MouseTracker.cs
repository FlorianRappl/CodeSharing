using CodeSharing.Pcl04;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CodeSharing.App04
{
    public partial class MouseTracker : ITracker, INotifyPropertyChanged
    {
        Double _distance;
        Boolean _tracking;

        public MouseTracker()
        {
            _distance = 0.0;
            _tracking = false;
        }

        void RaisePropertyChanged([CallerMemberName] String propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); 
        }

        public Double Distance 
        {
            get { return _distance; }
            private set 
            { 
                _distance = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Boolean IsTracking
        {
            get { return _tracking; }
            private set
            {
                _tracking = value;
                RaisePropertyChanged();
            }
        }
    }
}