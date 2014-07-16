using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace CodeSharing.App05
{
    static class MetroExtensions
    {
        public static Boolean IsInterfaceType(this Type type)
        {
            return type.GetTypeInfo().IsInterface;
        }

        public static Boolean IsAbstractType(this Type type)
        {
            return type.GetTypeInfo().IsAbstract;
        }

        public static ConstructorInfo GetDefaultConstructor(this Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors.Where(m => m.GetParameters().Length == 0).FirstOrDefault();
        }

        public static Boolean IsSubclassOf(this Type subClass, Type baseClass)
        {
            return subClass.GetTypeInfo().IsSubclassOf(baseClass);
        }

        public static Boolean ImplementsInterface(this Type type, Type interfaceType)
        {
            return type.GetTypeInfo().ImplementedInterfaces.Any(m => m == interfaceType);
        }
    }
}
