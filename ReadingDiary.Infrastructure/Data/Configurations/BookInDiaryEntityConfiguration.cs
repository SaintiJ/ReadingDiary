using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingDiary.Domain.Entities;

namespace ReadingDiary.Infrastructure.Data.Configurations;

public class BookInDiaryEntityConfiguration : IEntityTypeConfiguration<BookInDiaryEntity>
{
    public void Configure(EntityTypeBuilder<BookInDiaryEntity> builder)
    {
        builder.ToTable("books_in_diary");
        builder.Property<Guid>("UserId");
        builder.Property<Guid>("BookId");
        builder.HasKey("UserId", "BookId");
        
        builder.HasOne(x => x.Status)
            .WithMany(x => x.DiaryEntries)
            .HasForeignKey("StatusId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.User)
            .WithMany(x => x.DiaryEntries)
            .HasForeignKey("UserId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Book)
            .WithMany(x => x.DiaryEntries)
            .HasForeignKey("BookId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
