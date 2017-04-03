using AutoMapper;
using GamerBacklog.Domain.Entities;
using GamerBacklog.MVC.ViewModels;

namespace GamerBacklog.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<GameViewModel, Game>();
            CreateMap<PlatformViewModel, Platform>();
        }
    }
}