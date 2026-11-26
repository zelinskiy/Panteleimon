using Microsoft.AspNetCore.Mvc;
using Panteleimon.Application.Owners;
using Panteleimon.Contracts.Errors;
using Panteleimon.Contracts.Owners;
using Panteleimon.Domain.Owners;

namespace Panteleimon.Api.Controllers;

[Route("api/owners")]
public sealed class OwnersController(OwnerService ownerService) : ApiControllerBase
{
    [HttpPost]
    [ProducesResponseType<CreateOwnerResponse>(StatusCodes.Status201Created)]
    [ProducesResponseType<ApiProblem>(StatusCodes.Status400BadRequest)]
    [ProducesResponseType<ApiProblem>(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Create(
        CreateOwnerRequest request, CancellationToken ct)
    {
        var result = await ownerService.CreateAsync(request, ct);

        if (result.IsFailure)
            return Problem(result.Error);

        var id = result.Value;
        return CreatedAtAction(
            nameof(GetById), new { id = id.Value }, new CreateOwnerResponse(id));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType<OwnerResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ApiProblem>(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var result = await ownerService.GetAsync(OwnerId.From(id), ct);

        return result.IsSuccess ? Ok(result.Value) : Problem(result.Error);
    }
}
