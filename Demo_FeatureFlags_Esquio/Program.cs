using Esquio.AspNetCore.Endpoints;
using Esquio.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEsquio(options => {
    options.ConfigureNotFoundBehavior(NotFoundBehavior.SetDisabled);
    options.ConfigureOnErrorBehavior(OnErrorBehavior.SetDisabled);
    })
    .AddAspNetCoreDefaultServices()
    .AddConfigurationStore(builder.Configuration)
    .AddEndpointFallback(EndpointFallbackAction.RedirectAnyToAction("Home","FeatureNotAvailable"));

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


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("Hello World!");
//    }).RequireFeature("HiddenGem");
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
