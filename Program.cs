global using StudentManagement.Enums;
global using StudentManagement.Models;

global using StudentManagement.Services;
global using StudentManagement.Services.Student;
global using StudentManagement.Services.Profile;

global using StudentManagement.Data;

global using StudentManagement.DTOs.UserProfileDTO;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;

global using System.ComponentModel.DataAnnotations.Schema;
global using System.ComponentModel;

global using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

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
