using Microsoft.EntityFrameworkCore;
using Alumni.Domain.Entities;
using Alumni.Domain.Interfaces;
using Alumni.Infrastructure.Data;

namespace Alumni.Infrastructure.Repositories;

public class ContentRepository : BaseRepository<Content>, IContentRepository
{
    public ContentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Content>> GetPublishedContentsAsync(ContentType? type = null)
    {
        var query = _dbSet.Include(c => c.Creator)
            .Where(c => c.Status == ContentStatus.Published);

        if (type.HasValue)
        {
            query = query.Where(c => c.Type == type.Value);
        }

        return await query.OrderByDescending(c => c.PublishDate ?? c.CreatedAt)
            .ToListAsync();
    }

    public override async Task<Content?> GetByIdAsync(Guid id)
    {
        return await _dbSet.Include(c => c.Creator)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public override async Task<IEnumerable<Content>> GetAllAsync()
    {
        return await _dbSet.Include(c => c.Creator)
            .OrderByDescending(c => c.CreatedAt)
            .ToListAsync();
    }
}
