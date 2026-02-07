using MediatR;
using Alumni.Application.DTOs;
using Alumni.Domain.Interfaces;

namespace Alumni.Application.UseCases.Settings;

public class UpdateSettingCommand : IRequest<bool>
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class UpdateSettingHandler : IRequestHandler<UpdateSettingCommand, bool>
{
    private readonly ISystemSettingRepository _repository;

    public UpdateSettingHandler(ISystemSettingRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
    {
        var setting = await _repository.GetByKeyAsync(request.Key);

        if (setting == null)
        {
            return false;
        }

        setting.UpdateValue(request.Value);
        await _repository.UpdateAsync(setting);

        return true;
    }
}
