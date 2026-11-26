using CSharpFunctionalExtensions;
using Panteleimon.Domain.Errors;

using Panteleimon.Domain.Owners;

public sealed class Owner
{
    public const int NameMaxLength = 250;

    public OwnerId Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    private Owner() { } // EF

    public static Result<Owner, Error> Create(string? name)
    {
        var normalized = Normalize(name);

        if (normalized.Length == 0)
            return Result.Failure<Owner, Error>(
                Error.TextEmpty(nameof(Owner), nameof(Name)));

        if (normalized.Length > NameMaxLength)
            return Result.Failure<Owner, Error>(
                Error.TextTooLong(nameof(Owner), nameof(Name), NameMaxLength));

        return Result.Success<Owner, Error>(
            new Owner { Id = OwnerId.From(Guid.CreateVersion7()), Name = normalized });
    }

    private static string Normalize(string? name) => name?.Trim() ?? string.Empty;
}
