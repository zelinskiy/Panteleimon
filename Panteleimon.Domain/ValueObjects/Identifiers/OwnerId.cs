namespace Panteleimon.Domain.ValueObjects.Identifiers;

public readonly record struct OwnerId(Guid Value)
{
    public static OwnerId New() => new(Guid.NewGuid());
}