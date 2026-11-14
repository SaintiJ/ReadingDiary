using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingDiary.Domain.Entities;

namespace ReadingDiary.Infrastructure.Data.Configurations;

public class BookInDiaryEntityConfiguration : IEntityTypeConfiguration<BookInDiaryEntity>
{
    public void Configure(EntityTypeBuilder<BookInDiaryEntity> builder)
    {
        builder.ToTable("books_in_diary", t => t.HasCheckConstraint("CK_books_in_diary_finished", "\"FinishedAt\" IS NULL OR \"Status\" = 'Read'"));
        builder.Property<Guid>("UserId");
        builder.Property<Guid>("BookId");
        builder.HasKey("UserId", "BookId");

        builder.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasOne(x => x.User)
            .WithMany(x => x.DiaryEntries)
            .HasForeignKey("UserId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Book)
            .WithMany(x => x.DiaryEntries)
            .HasForeignKey("BookId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
