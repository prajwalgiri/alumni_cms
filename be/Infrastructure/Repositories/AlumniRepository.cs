using Microsoft.EntityFrameworkCore;
using Alumni.Domain.Entities;
using Alumni.Domain.Interfaces;
using Alumni.Infrastructure.Data;

namespace Alumni.Infrastructure.Repositories;

public class AlumniRepository : BaseRepository<Alumni.Domain.Entities.Alumni>, IAlumniRepository
{
    public AlumniRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Alumni.Domain.Entities.Alumni?> GetByUserIdAsync(Guid userId)
    {
        return await _dbSet
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.UserId == userId);
    }

    public async Task<IEnumerable<Alumni.Domain.Entities.Alumni>> GetPublicAlumniAsync()
    {
        return await _dbSet
            .Include(a => a.User)
            .Where(a => a.IsPublic)
            .ToListAsync();
    }

    public async Task<IEnumerable<Alumni.Domain.Entities.Alumni>> GetByGraduationYearAsync(int year)
    {
        return await _dbSet
            .Include(a => a.User)
            .Where(a => a.GraduationYear == year && a.IsPublic)
            .ToListAsync();
    }

    public async Task<IEnumerable<Alumni.Domain.Entities.Alumni>> GetByMajorAsync(string major)
    {
        return await _dbSet
            .Include(a => a.User)
            .Where(a => a.Major.Contains(major) && a.IsPublic)
            .ToListAsync();
    }

    public async Task<IEnumerable<Alumni.Domain.Entities.Alumni>> GetByCompanyAsync(string company)
    {
        return await _dbSet
            .Include(a => a.User)
            .Where(a => a.CurrentCompany != null && a.CurrentCompany.Contains(company) && a.IsPublic)
            .ToListAsync();
    }

    public async Task<IEnumerable<int>> GetUniqueGraduationYearsAsync()
    {
        return await _dbSet
            .Select(a => a.GraduationYear)
            .Distinct()
            .OrderByDescending(y => y)
            .ToListAsync();
    }

    public async Task<IEnumerable<string>> GetUniqueDegreesAsync()
    {
        return await _dbSet
            .Select(a => a.Degree)
            .Distinct()
            .OrderBy(d => d)
            .ToListAsync();
    }

    public async Task<IEnumerable<string>> GetUniqueMajorsAsync(string? degree = null)
    {
        var query = _dbSet.AsQueryable();
        if (!string.IsNullOrEmpty(degree))
        {
            query = query.Where(a => a.Degree == degree);
        }
        return await query
            .Select(a => a.Major)
            .Distinct()
            .OrderBy(m => m)
            .ToListAsync();
    }

    public async Task<IDictionary<string, IEnumerable<string>>> GetDegreesWithMajorsAsync()
    {
        var data = await _dbSet
            .GroupBy(a => a.Degree)
            .Select(g => new
            {
                Degree = g.Key,
                Majors = g.Select(a => a.Major).Distinct().OrderBy(m => m).ToList()
            })
            .OrderBy(x => x.Degree)
            .ToListAsync();

        return data.ToDictionary(
            x => x.Degree,
            x => x.Majors.AsEnumerable()
        );
    }
}
