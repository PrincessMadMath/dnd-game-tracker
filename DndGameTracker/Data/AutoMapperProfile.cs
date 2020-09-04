using AutoMapper;
using DndGameTracker.Dtos;
using DndGameTracker.Entities;

namespace DndGameTracker.Data
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<CampaignDto, Campaign>()
                .ReverseMap();

            CreateMap<CharacterDto, Character>()
                .ReverseMap();
        }
    }
}
