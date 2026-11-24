namespace Panteleimon.Domain.Entities;

using Panteleimon.Domain.ValueObjects.Identifiers;

public sealed class OperationalArea : Entity<OperationalAreaId>
{
    public string Name { get; private set; }

    public OperationalArea(
        OperationalAreaId id,
        string name)
        : base(id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Name = name;
    }
}