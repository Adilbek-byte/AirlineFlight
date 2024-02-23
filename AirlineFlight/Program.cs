using AirlineFlight.Configuration;
using AirlineFlight.Controllers;
using AirlineFlight.DataBase;
using AirlineFlight.Services;
using AirlineFlight.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var builderHost = Host.CreateDefaultBuilder();
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FlightDb>(
    options =>
    {
        options.UseSqlServer(connectionString);
    });
builder.Services.AddSingleton<IFlightService, FlightService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
