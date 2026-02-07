namespace Alumni.Domain.Entities;

public class SystemSetting : BaseEntity
{
    public string Key { get; private set; }
    public string Value { get; private set; }
    public string Type { get; private set; }
    public string? Description { get; private set; }

    private SystemSetting() { } // For EF Core

    public SystemSetting(string key, string value, string type, string? description = null)
    {
        Key = key;
        Value = value;
        Type = type;
        Description = description;
    }

    public void UpdateValue(string value)
    {
        Value = value;
        UpdateModifiedDate();
    }
}
