using System;

namespace CodeSharing.Pcl01
{
    /// <summary>
    /// Shared class from a PCL with targets:
    /// * Windows Store 8.1 and higher and
    /// * .NET 4.5 Framework and higher.
    /// </summary>
    public class Sample
    {
        readonly String _name;

        public Sample(String name)
        {
            _name = name;
        }

        public String Hello()
        {
            return String.Format("Hello {0}!", _name);
        }

        public String Greetings()
        {
            return String.Format("Greetings {0}.", _name);
        }

        public String Welcome()
        {
            return String.Format("Welcome {0}!", _name);
        }
    }
}
