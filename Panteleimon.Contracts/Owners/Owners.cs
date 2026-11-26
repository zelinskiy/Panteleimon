using System.ComponentModel.DataAnnotations;
using Panteleimon.Domain.Owners;

namespace Panteleimon.Contracts.Owners;

public sealed record CreateOwnerRequest
{
    [Required, StringLength(Owner.NameMaxLength)]
    public string? Name { get; init; }
}

public sealed record CreateOwnerResponse(OwnerId Id);

public sealed record OwnerResponse(OwnerId Id, string Name);