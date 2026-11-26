namespace Panteleimon.Domain.Errors;

/// <param name="Model">The entity the error is about, e.g. nameof(Owner).</param>
/// <param name="Field">Field path in the request/model, e.g. "name" or "address.street"; null if not field-specific.</param>
public sealed record Error(string Model, string? Field, ErrorKind Kind)
{
    public static Error TextEmpty(string model, string field) =>
        new(model, field, new ErrorKind.Validation(
            new ValidationKind.Text(new TextError.Empty())));

    public static Error TextTooLong(string model, string field, int max) =>
        new(model, field, new ErrorKind.Validation(
            new ValidationKind.Text(new TextError.TooLong(max))));

    public static Error Invalid(string model, string? field, string message) =>
        new(model, field, new ErrorKind.Validation(new ValidationKind.Invalid(message)));

    public static Error Conflict(string model, string? field, ConflictKind kind) =>
        new(model, field, new ErrorKind.Conflict(kind));

    public static Error NotFound(string model) =>
        new(model, null, new ErrorKind.NotFound());
}