using Microsoft.EntityFrameworkCore;
using movieCollection.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:CollectionConnection"]);
}
    );

var dbPath = Path.Combine(builder.Environment.ContentRootPath, "JoelHiltonMovieCollection.sqlite");
builder.Configuration["ConnectionStrings:CollectionConnection"] = $"Data Source={dbPath}";
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CollectionConnection")));


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{wallace?}"); // wallace part is passed to part where you edit/delete in collection.cs

app.Run();