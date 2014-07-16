using System;

namespace CodeSharing.App05.Wpf
{
    public class WpfMessage : IMessageHolder
    {
        public String Message
        {
            get { return "Hello from the Windows Desktop application"; }
        }
    }
}
