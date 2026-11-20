using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingDiary.Domain.Entities;

namespace ReadingDiary.Infrastructure.Data.Configurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("users");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.Nickname)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.AvatarUrl)
            .HasMaxLength(255);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey("RoleId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(x => x.Email).IsUnique();
    }
}
