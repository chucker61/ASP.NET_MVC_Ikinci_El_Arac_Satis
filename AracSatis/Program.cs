using AracSatis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AracSatis.Models.Entity;
using AracSatis.DesignPatterns.GenericRepository.IntRep;
using AracSatis.DesignPatterns.GenericRepository.ConcRep;
using Microsoft.Build.Framework;
using AracSatis.DesignPatterns.GenericRepository.BaseRep;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<AppUser>().AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<AppUser>();
builder.Services.AddScoped<IExtraTypeRepository, ExtraTypeRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IExtraRepository, ExtraRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IFuelTypeRepository, FuelTypeRepository>();
builder.Services.AddScoped<ITransmissionTypeRepository, TransmissionTypeRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ICarExtraRepository, CarExtraRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=HomeAdmin}/{action=Index}/{id?}"
    );
    endpoints.MapDefaultControllerRoute();
});

app.Run();

