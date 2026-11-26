using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Panteleimon.Application.Persistence;

namespace Panteleimon.Persistence.Postgres;

public static class PostgresPersistence
{
    public static IServiceCollection AddPostgresPersistence(
        this IServiceCollection services, string connectionString) =>
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                connectionString,
                npgsql => npgsql.MigrationsAssembly(
                    typeof(PostgresPersistence).Assembly.GetName().Name)));
}
