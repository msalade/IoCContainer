using System;
using System.Collections.Generic;
using System.Linq;
using IoCContainer.BusinessLayer.Contracts;

namespace IoCContainer.BusinessLayer
{
    public class Container : IContainer
    {
        private readonly IDictionary<Type, Func<object>> _registeredTypes;

        public Container()
        {
            _registeredTypes = new Dictionary<Type, Func<object>>();
        }

        /// <inheritdoc />
        public void Register<TContract, TClass>()
        {
            _registeredTypes.Add(typeof(TContract), () => GetInstance(typeof(TClass)));
        }

        /// <inheritdoc />
        public void RegisterSingleton<T>(T obj)
        {
            _registeredTypes.Add(typeof(T), () => obj);
        }

        /// <inheritdoc />
        public T GetInstance<T>()
        {
            return (T) GetInstance(typeof(T));
        }

        /// <inheritdoc />
        public object GetInstance(Type type)
        {
            if (_registeredTypes.ContainsKey(type))
                return _registeredTypes[type]();

            var constructor = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .First();

            var args = constructor.GetParameters()
                .Select(param => GetInstance(param.ParameterType))
                .ToArray();

            return Activator.CreateInstance(type, args);
        }
    }
}
