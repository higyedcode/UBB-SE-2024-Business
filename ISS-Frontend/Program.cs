using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ISS_Frontend.Data;
using ISS_Frontend.Service;
using Celebration_Of_Capitalism___The_Finale.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ISS_FrontendContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ISS_FrontendContext") ?? throw new InvalidOperationException("Connection string 'ISS_FrontendContext' not found.")));

// Dependency Injection (merge-sensitive)
builder.Services.AddSingleton<COCUserService>();
builder.Services.AddSingleton<COCProductService>();
builder.Services.AddSingleton<COCReviewService>();
builder.Services.AddSingleton<COCFavouriteProductService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Session Management (merge-sensitive)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromDays(1);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSpaStaticFiles(configuration => {
    configuration.RootPath = "reactfe/build";
});

builder.Services.AddHttpClient<IProductService, ProductService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5049/");
});
builder.Services.AddHttpClient<IBankAccountService, BankAccountService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5049/");
});
builder.Services.AddScoped<IPaymentFormService, PaymentFormService>();

builder.Services.AddScoped<IExportRequestService, ExportRequestService>();

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

// Session management (merge-sensitive)
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "MainPage",
    pattern: "MainPage",
    defaults: new { controller = "PaymentsAndBillings", action = "MainPage" });

app.MapControllerRoute(
    name:"BankAccountDetails",
    pattern:"BankAccountDetails",
    defaults: new { controller = "PaymentsAndBillings", action = "BankAccountDetails" });


var spaPath = "/app";
if (app.Environment.IsDevelopment())
{
    app.MapWhen(y => y.Request.Path.StartsWithSegments(spaPath), client =>
    {
        client.UseSpa(spa =>
        {
            spa.UseProxyToSpaDevelopmentServer("https://localhost:3333");
        });
    });
}
else
{
    app.Map(new PathString(spaPath), client =>
    {
        client.UseSpaStaticFiles();
        client.UseSpa(spa => {
            spa.Options.SourcePath = "clientapp";

            // adds no-store header to index page to prevent deployment issues (prevent linking to old .js files)
            // .js and other static resources are still cached by the browser
            spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ResponseHeaders headers = ctx.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        NoCache = true,
                        NoStore = true,
                        MustRevalidate = true
                    };
                }
            };
        });
    });
}

app.Run();
