using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class SimpleObjectFactory
    {
        private static ConcurrentDictionary<Type, Object> _instanceDict;

        static SimpleObjectFactory()
        {
            _instanceDict = new ConcurrentDictionary<Type, Object>();
        }

        public static T GetMYDependency<T>(bool singleInstance, params object[] parameters) where T : class
        {
            dynamic instance = null;
            if (singleInstance)
            {
                _instanceDict.TryGetValue(typeof(T), out instance);
            }

            if (instance == null)
            {
                instance = GetNewInstance<T>(parameters);
                _instanceDict.TryAdd(typeof(T), instance);
            }

            return instance;

        }

        private static dynamic GetNewInstance<T1>(params object[] parameters)
        {
            T1 newObject = default(T1);
            if (parameters.Length != 0)
            {

                var constructorInfo = typeof(T1).GetConstructors(
                                           BindingFlags.Public | BindingFlags.Static |
                                           BindingFlags.NonPublic | BindingFlags.Instance);

                var match = constructorInfo.Where(p =>
                     Enumerable.SequenceEqual(p.GetParameters().Select(x => x.ParameterType),
                                               parameters.Select(y => y.GetType()))
                    ).FirstOrDefault();

                if (match != null)
                    newObject = (T1)match.Invoke(parameters);
                else
                    throw new InvalidOperationException("constructor parameters doesn't match type");
            }
            else
                newObject = Activator.CreateInstance<T1>();


            return newObject;
        }
    }
}
