global using DriverManagement.Database;
global using DriverManagement.Models;
global using DriverManagement.Services;
global using DriverManagement.DTO.Driver;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using DriverManagement.Services.DataObject;
global using DriverManagement.Services.LoginObject;
global using DriverManagement.DTO.Admin;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

// Logger


// Database connection
builder.Services.AddDbContext<DataContext>(options => {
  options.UseSqlServer(builder.Configuration["Database:SqlServerConnection"]);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
  options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
    Description = "JWT Bearer (add 'bearer' before the token)",
    In = ParameterLocation.Header,
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey
  });

  options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Dependency injection
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Service injection
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IAdminService, AdminService>();

// Authentication policy
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
  options.TokenValidationParameters = new TokenValidationParameters {
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"])),
    ValidateIssuer = false,
    ValidateAudience = false
  };
});

/*  var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secret["JWT:SecretKey"]));
var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
