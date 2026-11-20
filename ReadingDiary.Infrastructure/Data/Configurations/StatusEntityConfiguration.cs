using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingDiary.Domain.Entities;

namespace ReadingDiary.Infrastructure.Data.Configurations;

public class StatusEntityConfiguration : IEntityTypeConfiguration<StatusEntity>
{
    public void Configure(EntityTypeBuilder<StatusEntity> builder)
    {
        builder.ToTable("statuses");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasData(
            new StatusEntity { Id = new Guid("00000000-0000-0000-0000-0000000000b1"), Name = "Planned" },
            new StatusEntity { Id = new Guid("00000000-0000-0000-0000-0000000000b2"), Name = "Reading" },
            new StatusEntity { Id = new Guid("00000000-0000-0000-0000-0000000000b3"), Name = "Read" });
    }
}
