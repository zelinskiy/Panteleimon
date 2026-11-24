namespace Panteleimon.Domain.ValueObjects.Identifiers;

public readonly record struct OperationalAreaId(Guid Value)
{
    public static OperationalAreaId New() => new(Guid.NewGuid());
}