using CleanArchitectureApp.Application.Extensions;
using CleanArchitectureApp.API.Extensions;
using CleanArchitectureApp.Application.DependencyInjection;
using CleanArchitectureApp.Infrastructure.DependencyInjection;
using CleanArchitectureApp.Persistence.DependencyInjection; // Ensure MediatR namespace is included

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

builder.Services.AddSwaggerDocumentation(); // Add Swagger via extension

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation(); // Use Swagger via extension
}

app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

//app.UseAuthorization();

app.MapControllers();

app.Run();
