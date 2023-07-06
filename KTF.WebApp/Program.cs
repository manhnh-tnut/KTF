using KTF.Repository;
using KTF.Shared.Data;
using KTF.Shared.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using KTF.WebApp.Hubs;
using KTF.WebApp.Services;
using KTF.Repository.Interfaces;
using KTF.Service;
using KTF.Service.Interfaces;
using Microsoft.Extensions.FileProviders;
using Serilog;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using KTF.WebApp.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddOptions();
builder.Services.Configure<Setting>(builder.Configuration.GetSection(nameof(Setting)));

builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
    options.UseSqlite(builder.Configuration.GetConnectionString("SqLiteConnection"));
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddRazorPages()
    .AddControllersAsServices()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddSignalR();

builder.Services.AddSingleton<IGpioService, GpioService>();
builder.Services.AddSingleton<IUartService, UartService>();
builder.Services.AddHostedService<BackgroundWorker>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddResponseCaching();

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.SmallestSize;
});
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    scope.ServiceProvider.GetRequiredService<ApplicationDbContext>().Database.Migrate();
}
var app = builder.Build();

app.UseSerilogRequestLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMigrationsEndPoint();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseResponseCompression();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Statics")),
    RequestPath = "/Statics"
});

app.UseLicense();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.MapHub<MonitorHub>("/hubs/monitor");

app.Run();
