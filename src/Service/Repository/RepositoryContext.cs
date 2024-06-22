using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;


namespace Repository
{
    /// <summary>
    /// Main context of the database
    /// </summary>
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InstrumentsConfiguration());
            modelBuilder.ApplyConfiguration(new InstrumentPairsConfiguration());
        }

        public DbSet<Instrument>? Instruments { get; set; }
        public DbSet<InstrumentPair>? InstrumentPairs { get; set; }
    }
}
