using APLICACIONASPRMVC.Models.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Scaffold - DbContext "Server=LAPTOPELKYN7; Database=ABCDataBase; Trusted_Connection=True; trustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models / Db
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AbcdataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ABCDataBase")));
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Auto",
        pattern: "Auto/{action}/{id?}",
        defaults: new { controller = "Auto", action = "Index" });

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
