using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using SiteWebTransactionnel.Data;
using SiteWebTransactionnel.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BdContexte>(options =>
		options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ProduitsService>();
builder.Services.AddControllersWithViews();
// Spécifier dans quel fichiers les vues sont stockées.
builder.Services.Configure<RazorViewEngineOptions>(o =>
{
	o.ViewLocationFormats.Clear();
	o.ViewLocationFormats.Add("/Pages/{1}/{0}" + RazorViewEngine.ViewExtension);
	o.ViewLocationFormats.Add("/Pages/Shared/{0}" + RazorViewEngine.ViewExtension);
});
builder.Services.AddMvc()
	.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
	.AddDataAnnotationsLocalization();

builder.Services.AddLocalization(options => options.ResourcesPath = "Ressources");


CultureInfo[] cultures = [new CultureInfo("en-CA"), new CultureInfo("fr-CA")];

RequestLocalizationOptions optionsLocalisation = new()
{
	DefaultRequestCulture = new RequestCulture("fr-CA"),
	SupportedCultures = [.. cultures],
	SupportedUICultures = [.. cultures]
};

builder.Services.AddSingleton(optionsLocalisation);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRequestLocalization(optionsLocalisation);

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}")
	.WithStaticAssets();


app.Run();
