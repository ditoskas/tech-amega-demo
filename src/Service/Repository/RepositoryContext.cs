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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                                       .Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (var entityEntry in entries)
            {
                if (entityEntry.Entity is BaseModelWithTimestamps entity)
                {
                    switch (entityEntry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedAt = DateTime.UtcNow;
                            entity.UpdatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            entity.UpdatedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Instrument>? Instruments { get; set; }
        public DbSet<InstrumentPair>? InstrumentPairs { get; set; }
        public DbSet<Quote>? Quotes { get; set; }
    }
}
