using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadingDiary.Domain.Entities;

namespace ReadingDiary.Infrastructure.Data.Configurations;

public class ReviewEntityConfiguration : IEntityTypeConfiguration<ReviewEntity>
{
    public void Configure(EntityTypeBuilder<ReviewEntity> builder)
    {
        builder.ToTable("reviews", t => t.HasCheckConstraint("CK_reviews_rating", "\"Rating\" BETWEEN 1 AND 5"));
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.User)
            .WithMany(x => x.Reviews)
            .HasForeignKey("UserId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Book)
            .WithMany(x => x.Reviews)
            .HasForeignKey("BookId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex("UserId", "BookId").IsUnique();
    }
}
