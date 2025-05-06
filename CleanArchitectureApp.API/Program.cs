using CleanArchitectureApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using CleanArchitectureApp.Persistence;
using CleanArchitectureApp.Application.Dependencies;
using CleanArchitectureApp.Application.Middleware;
using CleanArchitectureApp.Infrastructure.Dependencies;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR; // Ensure MediatR namespace is included

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<DatabaseService>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

// Register Dependencies

builder.Services.AddApplicationDependencies(builder.Configuration)
                .AddInfrustructureDependencies(builder.Configuration)
                .AddPersistenceDependencies(builder.Configuration);
//.AddIdentityDependencies(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

//app.UseAuthorization();

app.MapControllers();

app.Run();
