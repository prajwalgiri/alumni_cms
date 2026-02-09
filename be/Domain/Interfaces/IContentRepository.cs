using Alumni.Domain.Entities;

namespace Alumni.Domain.Interfaces;

public interface IContentRepository : IRepository<Content>
{
    Task<IEnumerable<Content>> GetPublishedContentsAsync(ContentType? type = null);
}
