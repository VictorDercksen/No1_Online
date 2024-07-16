using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using No1_Online.Data;
using No1_Online.Interfaces;
using No1_Online.Models;
using No1_Online.Services;
using OfficeOpenXml;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Add Razor Pages support
builder.Services.AddServerSideBlazor(); // Add Blazor Server support
builder.Services.AddDbContext<AppDbContext>(
        options => options.UseSqlServer(connectionString)
    );
builder.Services.AddIdentity<AppUser, IdentityRole>(
        options =>
        {
            // Change these before production    
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
        }
    )
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60); // Adjust the timeout as needed
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpClient();
builder.Services.AddHttpClient("default", client =>
{
    var apiBaseAddress = builder.Configuration["ApiBaseAddress"];
    if (!Uri.TryCreate(apiBaseAddress, UriKind.Absolute, out var baseAddress))
    {
        throw new InvalidOperationException("The ApiBaseAddress setting is invalid.");
    }
    client.BaseAddress = baseAddress;
    // Add any other HttpClient configuration here if needed
});
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddSingleton<GoogleCloudStorageService>(provider =>
    new GoogleCloudStorageService("no1-online-reports-bucket"));
QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

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
app.UseSession();
app.UseAuthentication(); // Ensure authentication is used
app.UseAuthorization();

app.MapRazorPages(); // Map Razor Pages
app.MapBlazorHub(); // Map Blazor Hub
/*app.MapFallbackToPage("/_Host");*/ // Commented out as it is not needed for MVC

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
