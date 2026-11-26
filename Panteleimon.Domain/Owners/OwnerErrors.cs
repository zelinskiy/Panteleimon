using Panteleimon.Domain.Errors;

namespace Panteleimon.Domain.Owners;

public static class OwnerErrors
{
    public static Error NameTaken { get; } =
        Error.Conflict(nameof(Owner), nameof(Owner.Name), new ConflictKind.AlreadyExists());

    public static Error NotFound { get; } = Error.NotFound(nameof(Owner));
}
