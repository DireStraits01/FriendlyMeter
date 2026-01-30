using Microsoft.EntityFrameworkCore;
using FriendlyMeter.Server.Data;
using FriendlyMeter.Server.Services;
using FriendlyMeter.Server.Interfaces.Services;
using FriendlyMeter.Server.Interfaces.Repositories;
using FriendlyMeter.Server.Repositories;
using FriendlyMeter.Server.Interfaces.Mappers;
using FriendlyMeter.Shared.Models;
using Microsoft.AspNetCore.Identity;
using FriendlyMeter.Server.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlite("Data Source=friendlymeter.db"));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserMapper, UserMapper>();

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
