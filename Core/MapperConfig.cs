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
                cfg.CreateMap<Worker, WorkerViewModel>().ReverseMap();
            });

            return config;
        }
    }
}
