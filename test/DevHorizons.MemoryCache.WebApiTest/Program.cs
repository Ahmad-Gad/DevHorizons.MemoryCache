using DevHorizons.MemoryCache;
using DevHorizons.MemoryCache.WebApiTest.Configuration;

var builder = WebApplication.CreateBuilder(args);
var applicationConfiguration = builder.GetApplicationConfiguration();
builder.Services.RegisterMemoryCache<object>(applicationConfiguration.CacheConfig);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger(applicationConfiguration);
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
