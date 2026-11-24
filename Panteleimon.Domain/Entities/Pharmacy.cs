namespace Panteleimon.Domain.Entities;

using Panteleimon.Domain.ValueObjects;
using Panteleimon.Domain.ValueObjects.Identifiers;

public sealed class Pharmacy : Entity<PharmacyId>
{
    public string Name { get; private set; }
    public OwnerId OwnerId { get; private set; }
    public Location Location { get; private set; }

    public Pharmacy(
        PharmacyId id,
        OwnerId ownerId,
        string name,
        Location location)
        : base(id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        OwnerId = ownerId;
        Name = name;
        Location = location;
    }
}