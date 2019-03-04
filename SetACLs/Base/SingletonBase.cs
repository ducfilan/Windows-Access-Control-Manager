using System;
using System.Reflection;

namespace SetACLs.Base
{
    public abstract class SingletonBase<T> where T : SingletonBase<T>
    {
        private static readonly Lazy<T> _instance;

        public static T Instance => _instance.Value;

        static SingletonBase()
        {
            _instance = new Lazy<T>(InstanceFactory);
        }

        private static T InstanceFactory()
        {
            var type = typeof(T);
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (constructors.Length != 1)
                throw new TypeInitializationException(type.FullName,
                    new TypeAccessException(
                        "Type must contain a single (non-public) constructor if derived from SingletonBase<T>."));

            var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null);

            if ((ctor == null) || (!ctor.IsPrivate && !ctor.IsFamily))
                throw new TypeInitializationException(type.FullName,
                    new TypeAccessException(
                        "Type must contain a single (non-public) constructor if derived from SingletonBase<T>."));

            var instance = ctor.Invoke(new object[] { }) as T;

            if (instance == null)
            {
                throw new TypeInitializationException(type.FullName, new NullReferenceException());
            }

            return instance;
        }
    }
}