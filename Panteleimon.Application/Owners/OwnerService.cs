using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Panteleimon.Application.Persistence;
using Panteleimon.Contracts.Owners;
using Panteleimon.Domain.Errors;
using Panteleimon.Domain.Owners;

namespace Panteleimon.Application.Owners;

public sealed class OwnerService(AppDbContext db)
{
    public async Task<Result<OwnerId, Error>> CreateAsync(
        CreateOwnerRequest request, CancellationToken ct = default)
    {
        var created = Owner.Create(request.Name);
        if (created.IsFailure)
            return created.Error;

        var owner = created.Value;

        if (await db.Owners.AnyAsync(o => o.Name == owner.Name, ct))
            return OwnerErrors.NameTaken;

        db.Owners.Add(owner);

        try
        {
            await db.SaveChangesAsync(ct);
        }
        catch (DbUpdateException)
        {
            // Provider-neutral race handling
            db.ChangeTracker.Clear();

            if (await db.Owners.AnyAsync(o => o.Name == owner.Name, ct))
                return OwnerErrors.NameTaken;

            throw;
        }

        return owner.Id;
    }

    public async Task<Result<OwnerResponse, Error>> GetAsync(
        OwnerId id, CancellationToken ct = default)
    {
        var owner = await db.Owners
            .Where(o => o.Id == id)
            .Select(o => new OwnerResponse(o.Id, o.Name))
            .FirstOrDefaultAsync(ct);

        return owner is null
            ? OwnerErrors.NotFound
            : owner;
    }
}