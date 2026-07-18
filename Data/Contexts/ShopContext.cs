using Core.Concretes.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class ShopContext : IdentityDbContext<AppUser>
    {
        public ShopContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductFeature> ProductFeatures { get; set; }
    }
}
