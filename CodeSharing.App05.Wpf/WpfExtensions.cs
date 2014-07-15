using System;
using System.Collections.Generic;
using System.Reflection;

namespace CodeSharing.App05
{
    static class WpfExtensions
    {
        public static IEnumerable<Type> GetAllTypes(this Assembly assembly)
        {
            return assembly.DefinedTypes;
        }
    }
}
