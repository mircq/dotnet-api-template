using Carter;
using Presentation.Mappers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCarter();

#region Mappers
builder.Services.AddScoped<TemplatePostMapper>();
#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapCarter();

app.UseHttpsRedirection();

app.Run();
