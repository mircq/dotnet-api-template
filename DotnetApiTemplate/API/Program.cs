using Application;
using Carter;
using Domain;
using Infrastructure;
using Persistence;
using Presentation;

Console.WriteLine("Running Program.cs in API layer...");


var builder = WebApplication.CreateBuilder(args);

// Initialize layers
builder.Services.InitializeDomain();
builder.Services.InitializePersistence();
builder.Services.InitializeApplication();
builder.Services.InitializeInfrastructure();
builder.Services.InitializePresentation();

// Add Swagger generation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.MapCarter();

app.Run();
