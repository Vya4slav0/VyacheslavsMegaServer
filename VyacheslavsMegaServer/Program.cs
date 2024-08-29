using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VyacheslavsMegaServer.Data;
using VyacheslavsMegaServer.Data.Repositories;
using VyacheslavsMegaServer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization(x =>
    x.AddPolicy("AdminAreaPolicy", policy => policy.RequireRole("Admin")));

builder.Services.AddControllersWithViews(x =>
    x.Conventions.Add(new AdminAreaAutorization("Admin", "AdminAreaPolicy")));

builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseMySQL("server=localhost;user=root;password=root;database=vms_db;"));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "auth";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/denied";
});

builder.Services.AddTransient<MainPageRepository>();

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

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
