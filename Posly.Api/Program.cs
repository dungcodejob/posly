using Microsoft.AspNetCore.Mvc.Infrastructure;
using Posly.Api.Common.Errors;
using Posly.Api.Common.Handlers;
using Posly.Application;
using Posly.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

builder.Services
.AddInfrastructure()
.AddApplication();



builder.Services.AddControllers();
builder.Services.AddTransient<ProblemDetailsFactory, PoslyProblemDetailsFactory>();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();
app.Run();

