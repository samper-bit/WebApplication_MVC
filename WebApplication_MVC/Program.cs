using Microsoft.EntityFrameworkCore;
using WebApp.DataAccess.Data;
using WebApp.DataAccess.Repository;
using WebApp.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Stripe;
using WebApp.DataAccess.DbInitializer;
using WebApp.Utility;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication_MVC.DotEnv;

var dotenv = Path.Combine(Directory.GetCurrentDirectory(), "SECRETS.env");
DotEnv.Load(dotenv);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
builder.Services.Configure<StripeSettings>(options =>
{
	options.PublishableKey = Environment.GetEnvironmentVariable("PublishableKey");
	options.SecretKey = Environment.GetEnvironmentVariable("SecretKey");
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = $"/Identity/Account/Login";
	options.LogoutPath = $"/Identity/Account/Logout";
	options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddAuthentication().AddFacebook(option =>
{
	option.AppId = Environment.GetEnvironmentVariable("AppId");
	option.AppSecret = Environment.GetEnvironmentVariable("AppSecret");

});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(100);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

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
StripeConfiguration.ApiKey = Environment.GetEnvironmentVariable("SecretKey");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
SeedDatabase();
app.MapRazorPages();
app.MapControllerRoute(
	name: "default",
	pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

void SeedDatabase()
{
	using (var scope = app.Services.CreateScope())
	{
		var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
		dbInitializer.Initialize();
	}
}