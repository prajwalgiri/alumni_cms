namespace Alumni.Application.DTOs;

public class SystemSettingDTO
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Description { get; set; }
}

public class UpdateSettingRequest
{
    public string Value { get; set; } = string.Empty;
}
