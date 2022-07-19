
using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Mappers;
using BusinessLogic.Services;
using Core.Models.Domain;
using Core.Models.Requests;
using Core.Models.Responses;
using Core.Services;
using Infrastructure.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddAutoMapper(typeof(EmployeeProfile));

//AppDomain.CurrentDomain.GetAssemblies()


//var mapperConfig = new MapperConfiguration(cfg =>
//{
//    cfg.AddProfile(new EmployeeProfile());
//});
//builder.Services.AddSingleton(mapperConfig.CreateMapper());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
