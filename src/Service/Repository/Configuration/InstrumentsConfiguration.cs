using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class InstrumentsConfiguration : IEntityTypeConfiguration<Instrument>
    {
        /// <summary>
        /// Initial data for the Instruments table
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Instrument> builder)
        {
            builder.HasData
                (
                    new Instrument
                    {
                        Id = 1,
                        Symbol = "EUR",
                        Description = "Euro",
                        ImagePath = "/img/instruments/eur.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Instrument
                    {
                        Id = 2,
                        Symbol = "USD",
                        Description = "United States Dollar",
                        ImagePath = "/img/instruments/usd.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Instrument
                    {
                        Id = 3,
                        Symbol = "BTC",
                        Description = "Bitcoin",
                        ImagePath = "/img/instruments/btc.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Instrument
                    {
                        Id = 4,
                        Symbol = "ETH",
                        Description = "Ethereum",
                        ImagePath = "/img/instruments/eth.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Instrument
                    {
                        Id = 5,
                        Symbol = "XRP",
                        Description = "Ripple",
                        ImagePath = "/img/instruments/xrp.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Instrument
                    {
                        Id = 6,
                        Symbol = "BCH",
                        Description = "Bitcoin Cash",
                        ImagePath = "/img/instruments/bch.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new Instrument
                    {
                        Id = 7,
                        Symbol = "LTC",
                        Description = "Light Coin",
                        ImagePath = "/img/instruments/ltc.png",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                );
        }
    }
}
