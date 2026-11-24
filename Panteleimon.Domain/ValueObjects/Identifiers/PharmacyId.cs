namespace Panteleimon.Domain.ValueObjects.Identifiers;

public readonly record struct PharmacyId(Guid Value)
{
    public static PharmacyId New() => new(Guid.NewGuid());
}