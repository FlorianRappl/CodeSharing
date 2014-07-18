using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CodeSharing.App02
{
    class SampleViewModel : INotifyPropertyChanged
    {
        String _name;
        readonly String _message;

        public event PropertyChangedEventHandler PropertyChanged;

        public SampleViewModel()
        {
#if NETFX_CORE
            _message = "Windows store development";
#else
            _message = "the Windows Desktop";
#endif
        }

        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();

                //Refresh other properties
                Hello = value;
                Greetings = value;
                Welcome = value;
            }
        }

        public String Hello
        {
            get { return String.Format("Hello my friend {0}!", _name); }
            private set { RaisePropertyChanged(); }
        }

        public String Greetings
        {
            get { return String.Format("Greetings {0}.", _name); }
            private set { RaisePropertyChanged(); }
        }

        public String Welcome
        {
            get { return String.Format("Welcome {0} to {1}!", _name, _message); }
            private set { RaisePropertyChanged(); }
        }

        void RaisePropertyChanged([CallerMemberName] String propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
