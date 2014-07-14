using CodeSharing.Pcl03;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CodeSharing.App03.Wpf
{
    public class ConfigurationViewModel : ObservableCollection<KeyValuePair<String, String>>, IConfiguration
    {
        public String this[String key]
        {
            get { return this.Where(m => m.Key == key).Select(m => m.Value).FirstOrDefault(); }
        }

        public IEnumerable<String> Keys
        {
            get { return this.Select(m => m.Key); }
        }

        public IEnumerable<String> Values
        {
            get { return this.Select(m => m.Value); }
        }
    }
}
