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

    async Task<List<SystemSetting>> ISystemSettingRepository.GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
}
