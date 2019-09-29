using FamPix.Web.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamPix.Web.Data
{
    public class FamPixDbContext : DbContext
    {
        public FamPixDbContext()
        {
        }

        public FamPixDbContext(DbContextOptions<FamPixDbContext> options) : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<PhotoTag> PhotoTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Photo).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
