using System;
using Microsoft.EntityFrameworkCore;
using applestore.Data.Entity;
using applestore.Data.Configurations;
using applestore.Data.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace applestore.Data.EF {
    public class AppleDbContext : IdentityDbContext<Auth, AuthRole, Guid> {
        public AppleDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Configurations database using Fluent API
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderLineConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new AuthConfiguration());
            modelBuilder.ApplyConfiguration(new AuthRoleConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new {x.UserId, x.RoleId});
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

            // Seeding data for database
            modelBuilder.Seed();
            
            // base.OnModelCreating(modelBuilder);
        } 

        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Cart> Carts {get; set;}
        public DbSet<CategoryTranslation> CategoryTranslations {get; set;}
        public DbSet<ProductInCategory> ProductInCategories {get; set;}
        public DbSet<Contact> Contacts {get; set;}
        public DbSet<Language> Languages {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<OrderLine> OrderLines {get; set;}
        public DbSet<ProductTranslation> ProductTranslations {get; set;}
        public DbSet<Promotion> Promotions {get; set;}
        public DbSet<Transaction> Transactions {get; set;}
    }
}
