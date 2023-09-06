using AnimalApiCSharp.Data;
using AnimalApiCSharp.Models;
using AnimalApiCSharp.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AnimalContext>(options =>
{
  options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

// Non-deprecated way of using fluent validation:
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(AnimalValidator).Assembly);

builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

builder.Services.AddTransient<IValidator<Animal>, AnimalValidator>();

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
