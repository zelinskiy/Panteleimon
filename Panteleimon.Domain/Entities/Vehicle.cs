namespace Panteleimon.Domain.Entities;

using Panteleimon.Domain.ValueObjects;
using Panteleimon.Domain.ValueObjects.Identifiers;

public sealed class Vehicle : Entity<VehicleId>
{
    public OwnerId OwnerId { get; private set; }
    public OperationalAreaId? AssignedOperationalAreaId { get; private set; }
    public Location? CurrentLocation { get; private set; }

    public Vehicle(
        VehicleId id,
        OwnerId ownerId)
        : base(id)
    {
        OwnerId = ownerId;
    }
}