using Alumni.Domain.Entities;

namespace Alumni.Domain.Interfaces;

public interface ISystemSettingRepository : IRepository<SystemSetting>
{
    Task<SystemSetting?> GetByKeyAsync(string key);
    Task<List<SystemSetting>> GetAllAsync(string? type = null);
}
