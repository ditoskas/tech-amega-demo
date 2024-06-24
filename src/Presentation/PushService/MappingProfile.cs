using AutoMapper;
using Contracts.DataTransferObjects;
using Entities.Models;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Quote, QuoteDto>();
            CreateMap<QuoteForCreationDto, Quote>();
        }
    }
}
