using WebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new StrictlyRoundedDecimalJsonConverter());
});

builder.Services.AddDbContext<FactoryDbContext>(options => options.UseSqlite("Data Source=production.db"));
var app = builder.Build();

app.MapGet("/production-history", async (FactoryDbContext context) =>
{
    var history = await context.ProductionHistory.ToListAsync();
    return Results.Ok(history);
});

app.Run();