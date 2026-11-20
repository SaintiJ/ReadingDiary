namespace ReadingDiary.Domain.Entities;

public class BookInDiaryEntity
{
    public DateOnly AddedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    public DateOnly? FinishedAt { get; set; }
    
    public StatusEntity Status { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
    public BookEntity Book { get; set; } = null!;
}
