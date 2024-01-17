using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TheKings.API.Data;
using TheKings.API.Extensions;
using TheKings.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MonarchContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MonarchConnectionString")));
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<IMonarchRepository, MonarchRepository>();

var app = builder.Build();

app.MigrateDatabase<MonarchContext>((context, services) =>
{
    var logger = services.GetService<ILogger<MonarchContextSeed>>();
    MonarchContextSeed
        .SeedAsync(context, logger)
        .Wait();
});
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
