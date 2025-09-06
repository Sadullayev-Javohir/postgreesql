using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Profiling;
using StackExchange.Profiling.Storage;
using MyMvcApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Add EF Core with PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add MemoryCache for MiniProfiler
builder.Services.AddMemoryCache();

// Configure MiniProfiler
builder.Services.AddMiniProfiler(options =>
{
  options.RouteBasePath = "/profiler"; // Profiler URL
  options.Storage = new MemoryCacheStorage(
      builder.Services.BuildServiceProvider().GetRequiredService<IMemoryCache>(),
      TimeSpan.FromMinutes(60) // cache duration
  );
}).AddEntityFramework(); // Track EF Core queries

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable MiniProfiler
app.UseMiniProfiler();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}"
);

app.Run();
