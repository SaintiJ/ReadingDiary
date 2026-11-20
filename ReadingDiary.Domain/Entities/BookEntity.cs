using ReadingDiary.Domain.Entities.Base;

namespace ReadingDiary.Domain.Entities;

public class BookEntity : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? CoverUrl { get; set; }
    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
    public ICollection<BookInDiaryEntity> DiaryEntries { get; set; } = new List<BookInDiaryEntity>();
}
