using Application;
using Domain;
using Infrastructure;
using Persistence;
using Presentation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

// Add Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
    .CreateLogger();
// TODO set log level
builder.Host.UseSerilog();



// Initialize layers
builder.Services.AddDomain();
builder.Services.AddPersistence(configuration: builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration: builder.Configuration);
builder.Services.AddPresentation();

// Add Swagger generation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UsePresentation();

//app.UseHttpsRedirection();

app.Run();
