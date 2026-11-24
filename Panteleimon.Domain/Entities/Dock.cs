namespace Panteleimon.Domain.Entities;

using Panteleimon.Domain.ValueObjects;
using Panteleimon.Domain.ValueObjects.Identifiers;

public sealed class Dock : Entity<DockId>
{
    public string Name { get; private set; }
    public OperationalAreaId OperationalAreaId { get; private set; }
    public Location Location { get; private set; }

    public Dock(
        DockId id,
        OperationalAreaId operationalAreaId,
        string name,
        Location location)
        : base(id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        OperationalAreaId = operationalAreaId;
        Name = name;
        Location = location;
    }
}