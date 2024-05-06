using LeaveManagement.Core.Interfaces;
using LeaveManagement.Infrastructure.Data;
using LeaveManagement.Infrastructure.Persistence;
using LeaveManagement.Infrastructure.Repositories;
using LeaveManagement.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using LeaveManagement.Core.Mappings;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LeaveManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILeaveApplicationRepository, LeaveApplicationRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILeaveApplicationService, LeaveApplicationService>();

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure CORS
var corsSettings = builder.Configuration.GetSection("CorsSettings");
app.UseCors(policy =>
{
    policy.WithOrigins(corsSettings["AllowedOrigins"])
          .AllowAnyMethod()
          .AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
// Seed data initialization
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<LeaveManagementDbContext>();
        dbContext.Database.Migrate(); // Ensure database migrations are applied

        SeedData.Initialize(dbContext); // Initialize seed data
    }
    catch (Exception ex)
    {
        // Handle any errors
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leave Management");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
