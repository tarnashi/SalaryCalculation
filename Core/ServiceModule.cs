using Core.Abstract;
using Core.Services;
using Ninject.Modules;
using AutoMapper;
using Ninject;

namespace Core
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //Services
            Bind<IDataService>().To<DataService>();

            //Automapper
            var mapperConfiguration = MapperConfig.CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();
            Bind<IMapper>().ToMethod(ctx => new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }
    }
}
