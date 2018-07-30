using AutoMapper;
using Core.ViewModels;
using Data.Models;

namespace Core
{
    public class MapperConfig
    {
        public static MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Worker, WorkerViewModel>().ForMember(x => x.FullName,
                    x => x.MapFrom(m => m.LastName + " " + m.FirstName)).ReverseMap();
                cfg.CreateMap<NewWorkerModel, Worker>();
                cfg.CreateMap<Position, PositionViewModel>().ReverseMap();
            });

            return config;
        }
    }
}
