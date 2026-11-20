using ReadingDiary.Domain.Entities.Base;

namespace ReadingDiary.Domain.Entities;

public class StatusEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<BookInDiaryEntity> DiaryEntries { get; set; } = new List<BookInDiaryEntity>();
}
