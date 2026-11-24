namespace Panteleimon.Domain.ValueObjects.Identifiers;

public readonly record struct DockId(Guid Value)
{
    public static DockId New() => new(Guid.NewGuid());
}