using Panteleimon.Domain.Errors;

namespace Panteleimon.Contracts.Errors;

public sealed record ApiError(string Model, ErrorKind Kind);

/// <summary>Mirrors the request body: errors at this level, plus children by field name.</summary>
public sealed record ErrorNode(
    IReadOnlyList<ApiError> Errors,
    IReadOnlyDictionary<string, ErrorNode> Fields);

/// <summary>The root node, plus the HTTP status information.</summary>
public sealed record ApiProblem(
    int Status,
    string Title,
    IReadOnlyList<ApiError> Errors,
    IReadOnlyDictionary<string, ErrorNode> Fields);
