namespace Alumni.Domain.Entities;

public class Content : BaseEntity
{
    public string Title { get; private set; }
    public string Body { get; private set; }
    public ContentType Type { get; private set; }
    public ContentStatus Status { get; private set; }
    public DateTime? PublishDate { get; private set; }
    public Guid CreatedBy { get; private set; }

    // Navigation properties
    public User Creator { get; private set; }

    private Content() { } // For EF Core

    public Content(string title, string body, ContentType type, Guid createdBy, ContentStatus status = ContentStatus.Draft, DateTime? publishDate = null)
    {
        Title = title;
        Body = body;
        Type = type;
        CreatedBy = createdBy;
        Status = status;
        PublishDate = publishDate;
    }

    public void Update(string title, string body, ContentType type)
    {
        Title = title;
        Body = body;
        Type = type;
        UpdateModifiedDate();
    }

    public void Publish(DateTime? publishDate = null)
    {
        Status = ContentStatus.Published;
        PublishDate = publishDate ?? DateTime.UtcNow;
        UpdateModifiedDate();
    }

    public void Archive()
    {
        Status = ContentStatus.Archived;
        UpdateModifiedDate();
    }

    public void SetDraft()
    {
        Status = ContentStatus.Draft;
        UpdateModifiedDate();
    }
}
