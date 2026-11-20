using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingDiary.Domain.Entities;

namespace ReadingDiary.Infrastructure.Data.Configurations;

public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("roles");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(x => x.Name).IsUnique();

        builder.HasData(
            new RoleEntity { Id = new Guid("00000000-0000-0000-0000-0000000000a1"), Name = "Reader" },
            new RoleEntity { Id = new Guid("00000000-0000-0000-0000-0000000000a2"), Name = "Admin" });
    }
}
