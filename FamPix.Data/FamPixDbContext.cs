using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FamPix.Data.Abstracts;
using FamPix.Data.Configurations;
using FamPix.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace FamPix.Data
{
    public class FamPixDbContext : DbContext, IFamPixDbContext
    {
        public FamPixDbContext(DbContextOptions<FamPixDbContext> options)
            : base(options)
        {
        }

        public DbSet<PhotoDAO> Photos { get; set; }

        public DbSet<AlbumDAO> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhotoConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration(new PhotosAlbumsConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.UpdateModifiedProperty();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.UpdateModifiedProperty();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.UpdateModifiedProperty();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.UpdateModifiedProperty();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateModifiedProperty()
        {
            foreach (var entry in this.ChangeTracker.Entries<EntityDAO>())
            {
                entry.Property(nameof(EntityDAO.Modified)).CurrentValue = SystemClock.Instance.GetCurrentInstant();
            }
        }
    }
}
