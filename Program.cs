using fbs_webApi_v2.Data;
using fbs_webApi_v2.services.Authservice;
using fbs_webApi_v2.services.IRepositories;
using fbs_webApi_v2.services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;
using fbs_webApi_v2.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<fbscontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PrimaryConnection"));
});

//builder.Services.AddC
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

//dependency injection
//builder.Services.Add(new ServiceDescriptor(
//    typeof(IUserRepository), typeof(UserRepository),ServiceLifetime.Transient
//    ));
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.Add(new ServiceDescriptor(
//    typeof(IAdminRepository), typeof(AdminRepository), ServiceLifetime.Transient
//    ));
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

//adding authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {

    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standerd Authorization header using the bearer scheme,ex: \"bearer {token} \" ",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });


c.OperationFilter<SecurityRequirementsOperationFilter>();

});

//httpcontext accessor to acces user data
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();//

app.UseAuthorization();

app.MapControllers();

app.Run();
