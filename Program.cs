using fbs_webApi_v2.Data;
using fbs_webApi_v2.IRepositories;
using fbs_webApi_v2.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<fbscontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PrimaryConnection"));
});

//dependency injection
builder.Services.Add(new ServiceDescriptor(
    typeof(IUserRepository), typeof(UserRepository),ServiceLifetime.Transient
    ));

builder.Services.Add(new ServiceDescriptor(
    typeof(IAdminRepository), typeof(AdminRepository), ServiceLifetime.Transient
    ));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
