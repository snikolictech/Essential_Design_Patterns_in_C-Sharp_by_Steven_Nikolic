using System;
using System.Collections.Generic;
using System.Text;

/* A ServiceLocator design pattern is an attempt to take a group of "modules" that will be called "services";
 * basically separate classes that are integral to running your entire application. A ServiceLocator has a Dictionary
 * of services that hold each service in an index and accessible by calling the index by it's exact Type. It then returns
 * that service. This avoids having to use the "new" keyword and explicitly couple one class to it's dependency. You can run it
 * all in a container instead, such as Main which will be the only place to refer to the dependencies.
 */ 

namespace ServiceLocator
{
    public class Program
    {
        static void Main()
        {
            Locator serviceLocator = new Locator();
            serviceLocator.Register<ServiceA>(new ServiceA("OrderProcessor"));

            //IService oneService = serviceLocator.Resolve<ServiceA>();
            IService anotherService = serviceLocator.Resolve<ServiceB>();

            //Console.WriteLine(oneService.serviceName);
        }
    }

    
    //-- Service Locators --//

    public interface IServiceLocator
    {
        void Register<T>(T resolver) where T : IService;
        T Resolve<T>() where T : IService, new();
    }

    public class Locator : IServiceLocator
    {
        private readonly Dictionary<Type, IService> services;

        public Locator()
        {
            this.services = new Dictionary<Type, IService>();
        }

        public void Register<T>(T resolver) where T : IService
        {
            this.services[typeof(T)] = resolver;
        }

        public T Resolve<T>() where T : IService, new()
        {
            //check returns null. Attempted check to avoid error when resolving an unregistered Service
            if (this.services[typeof(T)] == null)
                Register<T>(new T());

            return (T)this.services[typeof(T)];
        }
    }


    //-- Services --//

    public interface IService
    {
        string serviceName { get; set; }
    }

    public class ServiceA : IService
    {
        public string serviceName { get; set; }

        public ServiceA() { }

        public ServiceA(string serviceName)
        {
            this.serviceName = serviceName;
        }
    }

    public class ServiceB : IService
    {
        public string serviceName { get; set; }

        public ServiceB() { }

        public ServiceB(string serviceName)
        {
            this.serviceName = serviceName;
        }
    }
}