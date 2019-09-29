using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamPix.Web.Entities.Configurations
{
    public class PhotoConfigurations : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Images");
            builder.HasKey(photo => photo.Id);
            builder.HasIndex(photo => photo.Name).IsUnique(false);
            builder.Ignore(photo => photo.Albums);
            builder.Ignore(photo => photo.Tags);

            builder.Property(photo => photo.Name).HasMaxLength(255);
        }
    }
}
