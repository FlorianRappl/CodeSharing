using System.Collections.Generic;
using System.Reflection;

namespace CodeSharing.App05
{
    static class MetroExtensions
    {
        public static IEnumerable<TypeInfo> GetAllTypes(this Assembly assembly)
        {
            return assembly.DefinedTypes;
        }
    }
}
