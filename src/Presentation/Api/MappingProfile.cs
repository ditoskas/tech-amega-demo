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
                //.ForCtorParam("pair", opt => opt.MapFrom(src => string.Join('-', src.BaseInstrument.Symbol, src.NonBaseInstrument.Symbol)))
                .ForMember(c => c.Pair, opt => opt.MapFrom(
                    x => string.Join('-', x.BaseInstrument.Symbol, x.NonBaseInstrument.Symbol))
                );
        }
    }
}
