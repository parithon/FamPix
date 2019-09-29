using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamPix.Web.Entities.Configurations
{
    public class TagConfigurations : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");
            builder.HasKey(tag => tag.Id);
            builder.HasIndex(tag => tag.Value).IsUnique(true);
            builder.Ignore(tag => tag.Images);

            builder.Property(tag => tag.Value).IsRequired().HasMaxLength(50);
        }
    }
}
