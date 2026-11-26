using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Panteleimon.Contracts.Errors;
using Panteleimon.Domain.Errors;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Error = Panteleimon.Domain.Errors.Error;

namespace Panteleimon.Api.Http;

internal static class ApiProblemFactory
{
    public static ObjectResult ToResult(IReadOnlyList<Error> errors)
    {
        var status = errors[0].Kind switch
        {
            ErrorKind.Validation => StatusCodes.Status400BadRequest,
            ErrorKind.Conflict => StatusCodes.Status409Conflict,
            ErrorKind.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        var root = new Node();
        foreach (var error in errors)
        {
            var node = root;
            foreach (var segment in Segments(error.Field))
                node = node.Child(segment);

            node.Errors.Add(new ApiError(error.Model, error.Kind));
        }

        var tree = root.Build();
        var body = new ApiProblem(
            status, ReasonPhrases.GetReasonPhrase(status), tree.Errors, tree.Fields);

        return new ObjectResult(body)
        {
            StatusCode = status,
            ContentTypes = { "application/problem+json" }
        };
    }

    public static ObjectResult FromModelState(ModelStateDictionary modelState)
    {
        var errors = modelState
            .Where(entry => entry.Value is { Errors.Count: > 0 })
            .SelectMany(entry => entry.Value!.Errors.Select(e =>
                Error.Invalid(
                    "Request",
                    entry.Key.Length == 0 ? null : entry.Key,
                    e.ErrorMessage)))
            .ToList();

        return ToResult(errors);
    }

    // "address.street" and "items[0].name" both become path segments.
    private static IEnumerable<string> Segments(string? field) =>
        (field ?? string.Empty)
            .Split(new[] { '.', '[', ']' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(JsonNamingPolicy.CamelCase.ConvertName);

    private sealed class Node
    {
        private readonly Dictionary<string, Node> _fields = [];

        public List<ApiError> Errors { get; } = [];

        public Node Child(string name)
        {
            if (!_fields.TryGetValue(name, out var child))
                _fields[name] = child = new Node();
            return child;
        }

        public ErrorNode Build() =>
            new(Errors, _fields.ToDictionary(f => f.Key, f => f.Value.Build()));
    }
}
