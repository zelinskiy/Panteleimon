using System.Text.Json.Serialization;

namespace Panteleimon.Domain.Errors;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ErrorKind.Validation), "validation")]
[JsonDerivedType(typeof(ErrorKind.Conflict), "conflict")]
[JsonDerivedType(typeof(ErrorKind.NotFound), "not_found")]
public abstract record ErrorKind
{
    private ErrorKind() { }

    public sealed record Validation(ValidationKind Detail) : ErrorKind;
    public sealed record Conflict(ConflictKind Detail) : ErrorKind;
    public sealed record NotFound : ErrorKind;
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ValidationKind.Text), "text")]
[JsonDerivedType(typeof(ValidationKind.Invalid), "invalid")]
public abstract record ValidationKind
{
    private ValidationKind() { }

    public sealed record Text(TextError Detail) : ValidationKind;

    /// <summary>Framework-reported (DataAnnotations) failure with no structured detail.</summary>
    public sealed record Invalid(string Message) : ValidationKind;
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(TextError.Empty), "empty")]
[JsonDerivedType(typeof(TextError.TooShort), "too_short")]
[JsonDerivedType(typeof(TextError.TooLong), "too_long")]
public abstract record TextError
{
    private TextError() { }

    public sealed record Empty : TextError;
    public sealed record TooShort(int Min) : TextError;
    public sealed record TooLong(int Max) : TextError;
}

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ConflictKind.AlreadyExists), "already_exists")]
public abstract record ConflictKind
{
    private ConflictKind() { }

    public sealed record AlreadyExists : ConflictKind;
}