using System;

namespace CodeSharing.Pcl01
{
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
