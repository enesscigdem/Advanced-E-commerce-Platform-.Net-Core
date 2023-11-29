using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasData(
                new Product() { ProductId = 1, CategoryId = 2, ImageUrl = "/images/default.jpg", ProductName = "Computer", Price = 17_000, ShowCase = false },
                new Product() { ProductId = 2, CategoryId = 2, ImageUrl = "/images/default.jpg", ProductName = "Keyboard", Price = 1_000, ShowCase = false },
                new Product() { ProductId = 3, CategoryId = 2, ImageUrl = "/images/default.jpg", ProductName = "Mouse", Price = 500, ShowCase = false },
                new Product() { ProductId = 4, CategoryId = 2, ImageUrl = "/images/default.jpg", ProductName = "Monitor", Price = 7_000, ShowCase = false },
                new Product() { ProductId = 5, CategoryId = 2, ImageUrl = "/images/default.jpg", ProductName = "Deck", Price = 1_500, ShowCase = false },
                new Product() { ProductId = 6, CategoryId = 1, ImageUrl = "/images/default.jpg", ProductName = "History", Price = 1_500, ShowCase = false },
                new Product() { ProductId = 7, CategoryId = 1, ImageUrl = "/images/default.jpg", ProductName = "Hamlet", Price = 1_500, ShowCase = false },
                new Product() { ProductId = 8, CategoryId = 1, ImageUrl = "/images/default.jpg", ProductName = "Xp-Pen", Price = 1_200, ShowCase = true },
                new Product() { ProductId = 9, CategoryId = 2, ImageUrl = "/images/default.jpg", ProductName = "Galaxy FE", Price = 10_999, ShowCase = true },
                new Product() { ProductId = 10, CategoryId = 1, ImageUrl = "/images/default.jpg", ProductName = "Hp Mouse", Price = 1_999, ShowCase = true }
            );
        }
    }
}