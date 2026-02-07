namespace Alumni.Domain.Entities;

public class SystemSetting : BaseEntity
{
    public string Key { get; private set; }
    public string Value { get; private set; }
    public string? Description { get; private set; }

    private SystemSetting() { } // For EF Core

    public SystemSetting(string key, string value, string? description = null)
    {
        Key = key;
        Value = value;
        Description = description;
    }

    public void UpdateValue(string value)
    {
        Value = value;
        UpdateModifiedDate();
    }
}
