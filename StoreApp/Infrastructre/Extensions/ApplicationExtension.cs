using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Concrete;

namespace StoreApp.Infrastructre.Extensions
{
    public static class ApplicationExtension
    {
        // bu methodu yazmamızın amacı migration'u elle güncellemeyeceğiz. Otomatik olarak gerçekleşecek.
        // !!! sadece update işlemini yapacak. migration'u sen oluşturacaksın.
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("af-AF")
                    .AddSupportedUICultures("af-AF")
                    .SetDefaultCulture("af-AF");
            });
            var currentCulture = CultureInfo.CurrentCulture;
        }

    }
}