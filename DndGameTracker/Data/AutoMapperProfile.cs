using AutoMapper;
using DndGameTracker.Commands;
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

            CreateMap<CreateCampaignCommand, Campaign>();

            CreateMap<CharacterDto, Character>()
                .ReverseMap();
        }
    }
}
