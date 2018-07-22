using Ninject.Modules;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Mvc;
using Core;

namespace Web
{
    public class ContainerConfig
    {
        public static void ConfigureContainer()
        {
            NinjectModule registerModule = new ServiceModule();
            var kernel = new StandardKernel(registerModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}