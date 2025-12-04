using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartBiz.Application.Services;
using SmartBiz.Core.Interfaces;
using SmartBiz.Infrastructure.Data;
using SmartBiz.Infrastructure.Repositories;
using System.Text;
var builder = WebApplication.CreateBuilder(args);
// ---------------------- DB CONTEXT ----------------------
builder.Services.AddDbContext<SmartBizDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ---------------------- CORS FOR ANGULAR ----------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin());
});

// ---------------------- JWT AUTH ----------------------
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

// ---------------------- DEPENDENCY INJECTION ----------------------
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<JwtService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.UseCors("AllowAngular");

app.UseAuthentication();  // <-- VERY IMPORTANT (comes before authorization)
app.UseAuthorization();

app.MapControllers();

app.Run();