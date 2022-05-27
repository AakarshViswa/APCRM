using APCRM.Web.Data;
using APCRM.Web.DataAccess;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("APCRM_DB")).EnableSensitiveDataLogging(); 
});

SqlProvider.SqlConnectionString = builder.Configuration.GetConnectionString("APCRM_DB");

builder.Services.AddScoped<IDataAccess, DataAccess>();
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddTransient<IDataProvider, DataProvider>();
builder.Services.AddTransient<ISqlProvider, SqlProvider>();

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Lockout.AllowedForNewUsers = false;
});

builder.Services.ConfigureApplicationCookie(options => {
    options.AccessDeniedPath = new PathString("/Home/AccessDenied");
});

builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
