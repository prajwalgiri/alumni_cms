using Alumni.Domain.Entities;
using Alumni.Domain.Interfaces;
using Alumni.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Alumni.Infrastructure.Repositories;

public class SystemSettingRepository : BaseRepository<SystemSetting>, ISystemSettingRepository
{
    public SystemSettingRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<SystemSetting?> GetByKeyAsync(string key)
    {
        return await _dbSet.FirstOrDefaultAsync(s => s.Key == key);
    }

    public async Task<List<SystemSetting>> GetAllAsync(string? type = null)
    {
        var query = _dbSet.AsQueryable();

        if (!string.IsNullOrEmpty(type))
        {
            query = query.Where(s => s.Type == type);
        }

        return await query.ToListAsync();
    }
}
