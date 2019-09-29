using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamPix.Web.Entities.Configurations
{
    public class PhotoAlbumConfigurations : IEntityTypeConfiguration<PhotoAlbum>
    {
        public void Configure(EntityTypeBuilder<PhotoAlbum> builder)
        {
            builder.ToTable("PhotoAlbums");
            builder.HasKey(photoAlbum => new { photoAlbum.PhotoId, photoAlbum.AlbumId });
            builder.HasOne(photoAlbum => photoAlbum.Photo).WithMany(photo => photo.PhotoAlbums);
            builder.HasOne(photoAlbum => photoAlbum.Album).WithMany(album => album.PhotoAlbums);
        }
    }
}
