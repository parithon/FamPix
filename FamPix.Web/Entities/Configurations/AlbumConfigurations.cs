using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamPix.Web.Entities.Configurations
{
    public class AlbumConfigurations : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("Albums");
            builder.HasKey(album => album.Id);
            builder.HasIndex(album => album.Name).IsUnique(true);
            builder.Ignore(album => album.Images);

            builder.Property(album => album.Name).IsRequired(true).HasMaxLength(255);
        }
    }
}
