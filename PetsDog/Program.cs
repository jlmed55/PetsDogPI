using Microsoft.EntityFrameworkCore;
using PetsDog.Data;
using PetsDog.Database;
using System.IO;

var baseDirectory = Directory.GetCurrentDirectory();
var contentRoot = Directory.Exists(Path.Combine(baseDirectory, "Views"))
    ? baseDirectory
    : Path.Combine(baseDirectory, "PetsDog");

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = contentRoot
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString(
    "DefaultConnection"), new MySqlServerVersion(
     new Version(8, 0, 33))));

var allowedOrigins = builder.Configuration["ALLOWED_ORIGINS"] ?? string.Empty;
var origins = allowedOrigins
    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AgendamentoCors", policy =>
    {
        policy.WithOrigins(origins)
              .WithMethods("GET", "POST", "PUT", "DELETE")
              .WithHeaders("Content-Type", "Authorization");
    });
});

var app = builder.Build();

await DatabaseBootstrapper.EnsureDatabaseAsync(
    builder.Configuration,
    app.Logger,
    builder.Environment.ContentRootPath);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Agendamento}/{action=Index}/{id?}");

app.Run();
