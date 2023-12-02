using TelerikBlazorEF.Data;
using TelerikBlazorEF.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<CategoryService>();

builder.Services.AddTelerikBlazor();

// Upload file size limit on ASP.NET Core
builder.Services.Configure<FormOptions>(options =>
{
    //options.MultipartBodyLengthLimit = 1 * 1024 * 1024; // 1 MB
});
// Upload file size limit on Kestrel
builder.Services.Configure<KestrelServerOptions>(options =>
{
    //options.Limits.MaxRequestBodySize = 1 * 1024 * 1024; // 1 MB
});

// SignalR max message size for Editor, FileManager, FileSelect, PDF Viewer, Signature
builder.Services.Configure<HubOptions>(options =>
{
    //options.MaximumReceiveMessageSize = 64 * 1024 * 1024; // 64 MB or use null for no limit
});

builder.Services.AddDbContextFactory<EfDbContext>(contextOptions =>
{
    contextOptions.UseSqlite($"Filename=TelerikBlazor.db", sqliteOptions =>
    {
        sqliteOptions.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
