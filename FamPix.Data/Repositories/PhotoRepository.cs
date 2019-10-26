using FamPix.Data.Abstracts;
using FamPix.Data.Entities;
using FamPix.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FamPix.Data.Repositories
{
    public static class PhotoRepositoryExtensions
    {
        public static Task<List<T>> ToListAsync<T>(this IQueryable<T> query)
        {
            return EntityFrameworkQueryableExtensions.ToListAsync(query);
        }
    }

    public class PhotoRepository
    {
        private readonly IFamPixDbContext _context;

        public PhotoRepository(IFamPixDbContext context)
        {
            _context = context;
        }

        public IQueryable<Photo> GetAll()
        {
            return _context.Photos
                .AsNoTracking()
                .Select(photo => photo.ToDTO<Photo>());
        }

        public async Task<Photo> GetAsync(int id)
        {
            var result = await GetAll().ToListAsync();                
            return result.SingleOrDefault(p => p.Id == id);
        }

        public async Task<Photo> AddAsync(Photo photo)
        {
            var photoDAO = photo.ToDAO<PhotoDAO>();
            _context.Photos.Add(photoDAO);
            await _context.SaveChangesAsync();
            return photoDAO.ToDTO<Photo>();
        }

        public async Task<bool> UpdateAsync(Photo photo)
        {
            var photoDAO = photo.ToDAO<PhotoDAO>();
            _context.Photos.Update(photoDAO);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var photoDAO = await _context.Photos.FindAsync(id);
            _context.Photos.Remove(photoDAO);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
