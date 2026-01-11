using BlogCommunityAssign.Core.Interfaces;
using BlogCommunityAssign.Core.Services;
using BlogCommunityAssign.Data;
using BlogCommunityAssign.Data.Entities;
using BlogCommunityAssign.Data.Interfaces;
using BlogCommunityAssign.Data.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connString));

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
