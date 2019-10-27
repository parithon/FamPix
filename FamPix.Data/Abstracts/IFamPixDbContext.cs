using System.Threading;
using System.Threading.Tasks;
using FamPix.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamPix.Data.Abstracts
{
    public interface IFamPixDbContext
    {
        DbSet<AlbumDAO> Albums { get; set; }
        DbSet<PhotoDAO> Photos { get; set; }

        Task ResetDb();
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
}