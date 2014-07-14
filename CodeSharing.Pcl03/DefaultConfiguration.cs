using System;
using System.Collections;
using System.Collections.Generic;

namespace CodeSharing.Pcl03
{
    sealed class DefaultConfiguration : IConfiguration
    {
        readonly Dictionary<String, String> _config;

        public DefaultConfiguration()
        {
            _config = new Dictionary<String, String>();
        }

        internal void Add(String key, String value)
        {
            _config.Add(key, value);
        }

        public String this[String key]
        {
            get { return _config[key]; }
        }

        public Int32 Count
        {
            get { return _config.Count; }
        }

        public IEnumerable<String> Keys
        {
            get { return _config.Keys; }
        }

        public IEnumerable<String> Values
        {
            get { return _config.Values; }
        }

        public IEnumerator<KeyValuePair<String, String>> GetEnumerator()
        {
            return _config.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
