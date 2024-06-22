using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class InstrumentPairsConfiguration : IEntityTypeConfiguration<InstrumentPair>
    {
        /// <summary>
        /// Initial data for the InstrumentPairs table
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<InstrumentPair> builder)
        {
            builder.HasData
                (
                    new InstrumentPair
                    {//BTC-EUR
                        Id = 1,
                        BaseInstrumentId = 3,
                        NonBaseInstrumentId = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new InstrumentPair
                    {//BTC-USD
                        Id = 2,
                        BaseInstrumentId = 3,
                        NonBaseInstrumentId = 2,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new InstrumentPair
                    {//ETH-EUR
                        Id = 3,
                        BaseInstrumentId = 4,
                        NonBaseInstrumentId = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new InstrumentPair
                    {//ETH-USD
                        Id = 4,
                        BaseInstrumentId = 4,
                        NonBaseInstrumentId = 2,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new InstrumentPair
                    {//XRP-EUR
                        Id = 5,
                        BaseInstrumentId = 5,
                        NonBaseInstrumentId = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new InstrumentPair
                    {//XRP-USD
                        Id = 6,
                        BaseInstrumentId = 5,
                        NonBaseInstrumentId = 2,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new InstrumentPair
                    {//BCH-EUR
                        Id = 7,
                        BaseInstrumentId = 6,
                        NonBaseInstrumentId = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new InstrumentPair
                    {//BCH-USD
                        Id = 8,
                        BaseInstrumentId = 6,
                        NonBaseInstrumentId = 2,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new InstrumentPair
                    {//LTC-EUR
                        Id = 9,
                        BaseInstrumentId = 7,
                        NonBaseInstrumentId = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new InstrumentPair
                    {//LTC-USD
                        Id = 10,
                        BaseInstrumentId = 7,
                        NonBaseInstrumentId = 2,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                );
        }
    }
}
