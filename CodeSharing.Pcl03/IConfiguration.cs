using System;
using System.Collections.Generic;

namespace CodeSharing.Pcl03
{
    public interface IConfiguration : IEnumerable<KeyValuePair<String, String>>
    {
        String this[String key] { get; }

        Int32 Count { get; }

        IEnumerable<String> Keys { get; }

        IEnumerable<String> Values { get; }
    }
}
