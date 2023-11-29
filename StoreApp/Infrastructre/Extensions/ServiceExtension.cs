using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Abstract;
using Repositories.Concrete;
using Repositories.UnitOfWork;
using Repositories.UnitOfWorks;
using Services;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Infrastructre.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("sqlconnection"),
                b => b.MigrationsAssembly("StoreApp"));
            });
        }
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache(); // bu bir önbellek sağlıyor, sunucu durunca session duruyor.
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10); // 10 dakka bu bilgileri tut, sonrasında sıfırla.
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(c => SessionCart.GetCart(c)); // Farklı tarayıcılarda aynı ürünün gözükmemesi için scoped
        }
        public static void ConfigureRepositoryServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
            });
        }
    }
}