namespace PropertyConfigurationFluentAPI.Entities
{
    internal interface ITimestampedEntity
    {
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
