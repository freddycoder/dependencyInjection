using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LearningDependencyInjection.DependencyResoler
{
    public class Container
    {
        private Assembly _assembly;
        private static object _context;
        private readonly Dictionary<Type, object> _services;

        /// <summary>
        /// Construct a container class for a given assembly
        /// </summary>
        /// <param name="assembly">The assembly where the container will find your class</param>
        public Container(Assembly assembly)
        {
            _assembly = assembly;
            _services = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Create a singleton for a context class.
        /// </summary>
        /// <remarks>The method will find the exact implementation of your type or a derivate of interface type and instanciate it.</remarks>
        /// <param name="contextAbstractionType">The abstraction or concret class</param>
        public void AddContext<TContext>()
        {
            Type givenType = typeof(TContext);

            Type findType = null;

            foreach (var type in _assembly.GetTypes())
            {
                if (type.IsClass && (type.GetInterfaces().Contains(givenType) || type.Equals(givenType)))
                {
                    findType = type;
                }
            }

            _context = (TContext)Activator.CreateInstance(findType);

            _services.Add(givenType, _context);
        }

        /// <summary>
        /// Return a new instance of the required service. Except for the context
        /// class configure with the AddContext<>() method, it will return the
        /// actual instance of the context
        /// </summary>
        /// <typeparam name="TService">The interface or concrete type you want to have</typeparam>
        /// <returns>The instance of the service</returns>
        public TService GetRequiredService<TService>()
        {
            if (_services.ContainsKey(typeof(TService)) && _context == _services[typeof(TService)])
            {
                return (TService)_services[typeof(TService)];
            }

            return (TService)GetRequiredInstance(typeof(TService));
        }

        private object GetRequiredInstance(Type type)
        {
            if (_services.ContainsKey(type) && _context == _services[type])
            {
                return _services[type];
            }

            Type findType = null;

            foreach (var assemblyType in _assembly.GetTypes())
            {
                if (assemblyType.IsClass && (assemblyType.GetInterfaces().Contains(type) || assemblyType.Equals(type)))
                {
                    findType = assemblyType;
                }
            }

            var constructor = findType.GetConstructors().Single();

            var parameters = constructor.GetParameters();

            var parametersConcreteTypes = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
                parametersConcreteTypes[i] = GetRequiredInstance(parameters[i].ParameterType);

            return Activator.CreateInstance(findType, parametersConcreteTypes);
        }
    }
}
