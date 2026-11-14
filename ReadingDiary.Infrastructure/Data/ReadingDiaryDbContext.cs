using Microsoft.EntityFrameworkCore;
using ReadingDiary.Infrastructure.Data.Configurations;
using ReadingDiary.Domain.Entities;

namespace ReadingDiary.Infrastructure.Data;

public class ReadingDiaryDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }
    public DbSet<BookInDiaryEntity> BooksInDiary { get; set; }

    public ReadingDiaryDbContext(DbContextOptions<ReadingDiaryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BookInDiaryEntityConfiguration());
    }
}
