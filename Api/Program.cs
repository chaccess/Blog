using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Main.Data;
using Main.Models;
using Main.Queries;
using Api.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAuthorQuery).Assembly));

//Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//EntityFramework
builder.Services.AddDbContext<ApplicationDBContext>(
    opt => opt.UseNpgsql(
        builder.Configuration.GetConnectionString("BlogDB")
    ));

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
