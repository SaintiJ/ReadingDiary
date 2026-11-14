using ReadingDiary.Domain.Enums;

namespace ReadingDiary.Domain.Entities;

public class BookInDiaryEntity
{
    public ReadingStatusEnum Status { get; set; }
    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    public DateOnly? FinishedAt { get; set; }

    public UserEntity User { get; set; } = null!;
    public BookEntity Book { get; set; } = null!;
}
