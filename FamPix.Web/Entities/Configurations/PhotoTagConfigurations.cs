using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamPix.Web.Entities.Configurations
{
    public class PhotoTagConfigurations : IEntityTypeConfiguration<PhotoTag>
    {
        public void Configure(EntityTypeBuilder<PhotoTag> builder)
        {
            builder.ToTable("PhotoTags");
            builder.HasKey(photoTag => new { photoTag.PhotoId, photoTag.TagId });
            builder.HasOne(photoTag => photoTag.Photo).WithMany(photo => photo.PhotoTags);
            builder.HasOne(photoTag => photoTag.Tag).WithMany(tag => tag.PhotoTags);
        }
    }
}
