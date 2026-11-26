using Panteleimon.Api.Http;
using Panteleimon.Application.Owners;
using Panteleimon.Persistence.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(o =>
        o.InvalidModelStateResponseFactory = ctx =>
            ApiProblemFactory.FromModelState(ctx.ModelState));

//builder.Services.AddPostgresPersistence(
//    builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.AddSqlServerPersistence(
    builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.AddScoped<OwnerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
