using StoreApp.Infrastructre.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // artık controller olmadan da razor pages kullanabileceğiz.

builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.ConfigureSession();

builder.Services.ConfigureRepositoryServiceRegistration();

builder.Services.ConfigureRouting();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    app.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    app.MapRazorPages();
});
app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.Run();
