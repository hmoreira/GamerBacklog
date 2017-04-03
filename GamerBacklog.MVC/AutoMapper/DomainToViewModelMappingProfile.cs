using AutoMapper;
using GamerBacklog.Domain.Entities;
using GamerBacklog.MVC.ViewModels;

namespace GamerBacklog.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Game,GameViewModel>();
            CreateMap<Platform,PlatformViewModel>();
        }
    }
}