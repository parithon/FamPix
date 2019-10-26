using FamPix.Core;
using FamPix.Data.Abstracts;
using FamPix.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FamPix.Data.Repositories
{
    public class AlbumRepository : IRepository<Album>
    {
        private readonly IFamPixDbContext _context;

        public AlbumRepository(IFamPixDbContext context)
        {
            _context = context;
        }

        public IQueryable<Album> GetAll()
        {
            return _context.Albums
                .AsNoTracking()
                .Select(album => album.ToDTO<Album>());
        }

        public async Task<Album> GetAsync(int id)
        {
            var result = await GetAll().ToListAsync();
            return result.SingleOrDefault(a => a.Id == id);
        }

        public async Task<Album> AddAsync(Album Album)
        {
            var AlbumDAO = Album.ToDAO<AlbumDAO>();
            _context.Albums.Add(AlbumDAO);
            await _context.SaveChangesAsync();
            return AlbumDAO.ToDTO<Album>();
        }

        public async Task<bool> UpdateAsync(Album Album)
        {
            var AlbumDAO = Album.ToDAO<AlbumDAO>();
            _context.Albums.Update(AlbumDAO);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var AlbumDAO = await _context.Albums.FindAsync(id);
            _context.Albums.Remove(AlbumDAO);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
