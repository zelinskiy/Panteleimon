namespace Panteleimon.Domain.Entities;

using Panteleimon.Domain.ValueObjects.Identifiers;

// An organisation running pharmacies, deliveries, etc.
public sealed class Owner : Entity<OwnerId>
{
    public string Name { get; private set; }
    public ContactDetails ContactDetails { get; private set; }

    public Owner(OwnerId id, string name, ContactDetails contactDetails)
        : base(id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        
        Name = name;
        ContactDetails = contactDetails;
    }
}