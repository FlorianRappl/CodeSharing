using System;
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

        public T GetInstance<T>()
            where T : class
        {
            if (typeof(T).IsInterfaceType())
                return GetInstanceFromInterface(typeof(T)) as T;
            else if (typeof(T).IsAbstractType())
                return GetInstanceFromBaseClass(typeof(T)) as T;

            return CreateInstance(typeof(T)) as T;
        }

        Object CreateInstance(Type type)
        {
            var constructor = type.GetDefaultConstructor();

            if (constructor != null)
                return constructor.Invoke(null);

            return null;
        }

        Object GetInstanceFromBaseClass(Type baseType)
        {
            foreach (var definedType in _assembly.ExportedTypes)
            {
                if (definedType.IsSubclassOf(baseType) && !definedType.IsAbstractType())
                {
                    var obj = CreateInstance(definedType);

                    if (obj != null)
                        return obj;
                }
            }

            return null;
        }

        Object GetInstanceFromInterface(Type requiredInterface)
        {
            foreach (var definedType in _assembly.ExportedTypes)
            {
                if (definedType.ImplementsInterface(requiredInterface) && !definedType.IsAbstractType() && !definedType.IsInterfaceType())
                {
                    var obj = CreateInstance(definedType);

                    if (obj != null)
                        return obj;
                }
            }

            return null;
        }
    }
}