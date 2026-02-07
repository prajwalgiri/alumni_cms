using MediatR;
using Alumni.Application.DTOs;
using Alumni.Domain.Interfaces;

namespace Alumni.Application.UseCases.Settings;

public class GetSettingsQuery : IRequest<List<SystemSettingDTO>>
{
}

public class GetSettingsHandler : IRequestHandler<GetSettingsQuery, List<SystemSettingDTO>>
{
    private readonly ISystemSettingRepository _repository;

    public GetSettingsHandler(ISystemSettingRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<SystemSettingDTO>> Handle(GetSettingsQuery request, CancellationToken cancellationToken)
    {
        var settings = await _repository.GetAllAsync();
        return settings
            .Select(s => new SystemSettingDTO
            {
                Key = s.Key,
                Value = s.Value,
                Description = s.Description
            })
            .ToList();
    }
}
