using AutoMapper;
using CexService.Responses;
using Contracts.DataTransferObjects;

namespace QuotesManager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LastPriceResponse, LastPriceDto>();
            CreateMap<TickerResponse, TickerDto>();
        }
    }
}
