using System;

namespace IoCContainer.BusinessLayer.Contracts
{
    public interface IContainer
    {
        /// <summary>
        /// Register pair Interface - Class and add it to container.
        /// Every time this registered type will be called new instance
        /// will be created.
        /// </summary>
        /// <typeparam name="TContract">Interface to register</typeparam>
        /// <typeparam name="TClass">Specific class to register</typeparam>
        void Register<TContract, TClass>();

        /// <summary>
        /// Register pair Interface - Class and add it to container.
        /// Instance of the class will be initialize only one per one
        /// app run. 
        /// </summary>
        /// <typeparam name="T">Interface to register</typeparam>
        /// <param name="obj">Assosiated object</param>
        void RegisterSingleton<T>(T obj);

        /// <summary>
        /// Get instance of class as object and
        /// map it to exact type
        /// </summary>
        /// <typeparam name="T">Type to map</typeparam>
        /// <returns>T</returns>
        T GetInstance<T>();

        /// <summary>
        /// Get instance of class base on type
        /// registered in container
        /// </summary>
        /// <param name="type">Type of object</param>
        /// <returns>Object</returns>
        object GetInstance(Type type);
    }
}
