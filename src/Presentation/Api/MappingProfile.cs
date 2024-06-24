using AutoMapper;
using Contracts.DataTransferObjects;
using Entities.Models;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InstrumentPair, InstrumentPairDto>()
                .ForMember(c => c.Pair, opt => opt.MapFrom(
                    x => string.Join('-', x.BaseInstrument.Symbol, x.NonBaseInstrument.Symbol))
                )
                .ForMember(c => c.QuotesPair, opt => opt.MapFrom(
                    x => x.BaseInstrument.Symbol.Trim() + x.NonBaseInstrument.Symbol.Trim())
                )
                .ForMember(c => c.BaseCurrency, opt => opt.MapFrom(
                    x => x.BaseInstrument.Symbol)
                )
                .ForMember(c => c.NonBaseCurrency, opt => opt.MapFrom(
                    x => x.NonBaseInstrument.Symbol)
                )
                .ForMember(c => c.Description, opt => opt.MapFrom(
                    x => x.BaseInstrument.Description)
                )
                .ForMember(c => c.ImagePath, opt => opt.MapFrom(
                    x => x.BaseInstrument.ImagePath)
                );
        }
    }
}
