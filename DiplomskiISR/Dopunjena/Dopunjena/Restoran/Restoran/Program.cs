using Microsoft.EntityFrameworkCore;
using Restoran.API.MappingProfiles;
using Restoran.BLL.Interfaces;
using Restoran.BLL.Services;
using Restoran.DAL.Data;
using Restoran.DAL.Interfaces;
using Restoran.DAL.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Restoran.Models;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddIdentity<Korisnici, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"]);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            ValidateLifetime = true
        };
    });


builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IMeniRepository, MeniRepository>();
builder.Services.AddScoped<INarudzbaRepository, NarudzbaRepository>();
builder.Services.AddScoped<IRezervacijaRepository, RezervacijaRepository>();
builder.Services.AddScoped<IRacunRepository, RacunRepository>();
builder.Services.AddScoped<IStoloviRepository, StoloviRepository>();
builder.Services.AddScoped<IKorisniciRepository, KorisniciRepository>();

builder.Services.AddScoped<IMeniService, MeniService>();
builder.Services.AddScoped<INarudzbaService, NarudzbaService>();
builder.Services.AddScoped<IRezervacijaService, RezervacijaService>();
builder.Services.AddScoped<IRacunService, RacunService>();
builder.Services.AddScoped<IStoloviService, StoloviService>();
builder.Services.AddScoped<IKorisniciService, KorisniciService>();

builder.Services.AddTransient<EmailService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("*") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var stripeSettings = builder.Configuration.GetSection("Stripe");
StripeConfiguration.ApiKey = stripeSettings["SecretKey"];


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});
app.UseCors();

app.MapControllers();

app.Run();