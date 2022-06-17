using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Domain.Concrete;
using Moq;
using Ninject;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        
        private void AddBindings()
        {
            // Здесь размещаются привязки
            
            kernel.Bind<Domain.Abstract.IGameRepository>().To<Domain.Concrete.EFGameRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                    .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<Domain.Abstract.IOrderProcessor>().To<Domain.Concrete.EmailOrderProcessor>()
                .WithConstructorArgument("settings",emailSettings);
        }
    }
}