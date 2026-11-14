using ReadingDiary.Domain.Entities.Base;
using ReadingDiary.Domain.Enums;

namespace ReadingDiary.Domain.Entities;

public class UserEntity : BaseEntity
{
    public UserRoleEnum Role { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    public string? AvatarUrl { get; set; }
    public string? About { get; set; }
    public bool IsBlocked { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
    public ICollection<BookInDiaryEntity> DiaryEntries { get; set; } = new List<BookInDiaryEntity>();
}
