using HealthWoman.Application.Extension;
using HealthWoman.Infrastructure.AssemblyExtension;
using HealthWoman.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExtensions(builder.Configuration);
builder.Services.AddApplicationLayer();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContextMigrate = scope.ServiceProvider.GetRequiredService<HealthWomanDbContext>();
    dbContextMigrate.Database.Migrate();

}

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
