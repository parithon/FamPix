using FamPix.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamPix.Data.Configurations
{
    public class PhotosAlbumsConfiguration : IEntityTypeConfiguration<PhotosAlbums>
    {
        public void Configure(EntityTypeBuilder<PhotosAlbums> builder)
        {
            builder.HasKey(p => new { p.PhotoId, p.AlbumId });
           
            builder.HasOne(p => p.Photo)
                .WithMany(p => p.Albums)
                .HasForeignKey(p => p.AlbumId);

            builder.HasOne(a => a.Album)
                .WithMany(a => a.Photos)
                .HasForeignKey(a => a.PhotoId);
        }
    }
}
