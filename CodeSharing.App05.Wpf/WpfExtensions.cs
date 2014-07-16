using System;
using System.Linq;
using System.Reflection;

namespace CodeSharing.App05
{
    static class WpfExtensions
    {
        public static Boolean IsInterfaceType(this Type type)
        {
            return type.IsInterface;
        }

        public static Boolean IsAbstractType(this Type type)
        {
            return type.IsAbstract;
        }

        public static ConstructorInfo GetDefaultConstructor(this Type type)
        {
            return type.GetConstructor(Type.EmptyTypes);
        }

        public static Boolean ImplementsInterface(this Type type, Type interfaceType)
        {
            return type.GetInterfaces().Any(m => m == interfaceType);
        }
    }
}
