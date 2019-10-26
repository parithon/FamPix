using FamPix.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamPix.Data.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<AlbumDAO>
    {
        public void Configure(EntityTypeBuilder<AlbumDAO> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Name).IsUnique();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Created)
                .HasInstantConverter()
                .HasValueGenerator<InstantGenerator>()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Modified)
                .HasInstantConverter()
                .HasValueGenerator<InstantGenerator>()
                .ValueGeneratedOnAdd();
        }
    }
}
