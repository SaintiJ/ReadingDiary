using ReadingDiary.Domain.Entities.Base;

namespace ReadingDiary.Domain.Entities;

public class ReviewEntity : BaseEntity
{
    public short Rating { get; set; }
    public string? Text { get; set; }
    public bool IsHidden { get; set; }
    public DateTime PostedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public UserEntity User { get; set; } = null!;
    public BookEntity Book { get; set; } = null!;
}
