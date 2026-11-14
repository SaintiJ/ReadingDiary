using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingDiary.Domain.Entities;

namespace ReadingDiary.Infrastructure.Data.Configurations;

public class BookEntityConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.ToTable("books");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.Author)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.CoverUrl)
            .HasMaxLength(500);

        builder.HasIndex(x => new { x.Title, x.Author }).IsUnique();
    }
}
