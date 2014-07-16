using System;

namespace CodeSharing.App05.Metro
{
    public class MetroMessage : IMessageHolder
    {
        public String Message
        {
            get { return "Hello from the Windows Store application"; }
        }
    }
}
