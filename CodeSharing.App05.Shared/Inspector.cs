using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeSharing.App05
{
    class Inspector
    {
        readonly Assembly _assembly;

        public Inspector(Assembly assembly)
        {
            _assembly = assembly;
        }

        public IEnumerable<String> FindAllPublicClasses()
        {
            return _assembly.ExportedTypes.Select(m => m.Name);
        }
    }
}