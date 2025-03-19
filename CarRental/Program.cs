using CarRental.Data;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddDbContext<CarDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("CarConnection")));

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

// route for sorting
app.MapControllerRoute(
name: "sortingcars",
pattern: "{controller}/{action}/{id}/orderby{sortBy}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

SeedData.EnsurePopulated(app);
app.Run();