using FamPix.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamPix.Data.Configurations
{
    internal class PhotoConfiguration : IEntityTypeConfiguration<PhotoDAO>
    {
        public void Configure(EntityTypeBuilder<PhotoDAO> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Name);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Created)
                .HasValueGenerator<InstantGenerator>()
                .HasInstantConverter()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Modified)
                .HasValueGenerator<InstantGenerator>()
                .HasInstantConverter()
                .ValueGeneratedOnAdd();
        }
    }
}
