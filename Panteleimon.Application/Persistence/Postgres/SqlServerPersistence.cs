using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Panteleimon.Application.Persistence;

namespace Panteleimon.Persistence.SqlServer;

public static class SqlServerPersistence
{
    public static IServiceCollection AddSqlServerPersistence(
        this IServiceCollection services, string connectionString) =>
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                connectionString,
                sql => sql.MigrationsAssembly(
                    typeof(SqlServerPersistence).Assembly.GetName().Name)));
}
