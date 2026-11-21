using ReadingDiary.Domain.Entities.Base;

namespace ReadingDiary.Domain.Entities;

public class UserEntity : BaseEntity
{
    public string Email { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public string? About { get; set; }
    public bool IsBlocked { get; set; }
    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

    public RoleEntity Role { get; set; } = null!;
    public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
    public ICollection<BookInDiaryEntity> DiaryEntries { get; set; } = new List<BookInDiaryEntity>();
}
