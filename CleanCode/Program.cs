using log4net.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Clean_Code.Contexts;
using Clean_Code.Hubs;
using Clean_Code.Services;
using CleanCode.Services;
using CleanCode.Const;
using Hangfire;
using CleanCode.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext"), sqlServerOptionsAction =>
    {
        sqlServerOptionsAction.EnableRetryOnFailure();
    })
);

builder.Services.AddScoped<DataService>();

builder.Services.AddScoped<IJobService, JobService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Data", Version = "v1" });
});

builder.Services.AddHostedService(provider =>
{
    return new ImageCleanupService(Constants.PATH_CLEANUP_IMAGE);
});

var log4netConfig = new FileInfo("log4net.config");
XmlConfigurator.Configure(log4netConfig);

builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultContext"));
});
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "data");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapHub<HomeHub>("/homeHub");

app.UseHangfireDashboard();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
