using System;
using applestore.Data.Entity;
using applestore.Data.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace applestore.Data.Extensions {
    public static class ModelBuiderExtensions {
        public static void Seed(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() {id=1, key = "Home", value = "This is a home page Apple Store!"},
                new AppConfig() {id=2, key = "Search", value = "This is a search page Apple Store!"},
                new AppConfig() {id=3, key = "Product", value = "This is a product page Apple Store!"});

            modelBuilder.Entity<Language>().HasData(
                new Language() {id=1, name="English", isDefault=true},
                new Language() {id=2, name="Vietnamese", isDefault=false});

            modelBuilder.Entity<Category>().HasData(
                new Category() {
                    id=1,
                    isPublic=true, 
                    parentId=null, 
                    sortOrder=1, 
                    status=Status.active, },

                new Category() {
                    id=2,
                    isPublic=true, 
                    parentId=null, 
                    sortOrder=1, 
                    status=Status.active, },
                    
                new Category() {
                    id=3,
                    isPublic=true, 
                    parentId=null, 
                    sortOrder=1, 
                    status=Status.active, },
                    
                new Category() {
                    id=4,
                    isPublic=true, 
                    parentId=null, 
                    sortOrder=1, 
                    status=Status.active, });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation() {
                    id=1,
                    categoryId=1,
                    name="iPhone", 
                    languageId=1, 
                    seoAlias="iphone", 
                    brief="Smartphone Apple",
                    title="Smartphone"},

                new CategoryTranslation() {
                    id=2,
                    categoryId=1,
                    name="Điện thoại", 
                    languageId=2, 
                    seoAlias="dien-thoai", 
                    brief="Điện thoại thông minh Apple",
                    title="Điện thoại thông minh"},

                new CategoryTranslation() {
                    id=3,
                    categoryId=2,
                    name="iPad", 
                    languageId=1, 
                    seoAlias="ipad", 
                    brief="Tablet Apple",
                    title="Tablet"},

                new CategoryTranslation() {
                    id=4,
                    categoryId=2,
                    name="Máy tính bảng", 
                    languageId=2, 
                    seoAlias="may-tinh-bang", 
                    brief="Máy tính bảng thông minh Apple",
                    title="Máy tính bảng thông minh"},

                new CategoryTranslation() {
                    id=5,
                    categoryId=3,
                    name="Macbook", 
                    languageId=1, 
                    seoAlias="macbook", 
                    brief="Macbook Apple",
                    title="Macbook"},

                new CategoryTranslation() {
                    id=6,
                    categoryId=3,
                    name="Máy tính xách tay", 
                    languageId=2, 
                    seoAlias="may-tinh-xach-tay", 
                    brief="Máy tính xách tay Apple",
                    title="Máy tính xách tay"},

                new CategoryTranslation() {
                    id=7,
                    categoryId=4,
                    name="Watch", 
                    languageId=1, 
                    seoAlias="apple-watch", 
                    brief="Apple Watch",
                    title="Apple Watch"},

                new CategoryTranslation() {
                    id=8,
                    categoryId=4,
                    name="Đồng hồ", 
                    languageId=2, 
                    seoAlias="dong-ho", 
                    brief="Đồng hồ thông minh Apple",
                    title="Đồng hồ thông minh", });

            modelBuilder.Entity<Product>().HasData(
                new Product() {
                    id=1,
                    created=DateTime.UtcNow, 
                    originalPrice=800, 
                    price=868,
                    seoAlias="iphone-11-promax",
                    stock=100,
                    viewCount=0, });

            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation() {
                    id=1,
                    productId=1,
                    name="iPhone 11 Pro Max",
                    brief="Smartphone Apple",
                    title="Smartphone Apple",
                    languageId=1,
                    seoAlias="iphone-11-promax",},

                new ProductTranslation() {
                    id=2,
                    productId=1,
                    name="iPhone 11 Pro Max",
                    brief="Điện thoại thông minh Apple",
                    title="Điện thoại thông minh Apple",
                    languageId=2,
                    seoAlias="iphone-11-promax", });
        
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() {productId=1, categoryId=1, } 
            );

            var ROLE_ID = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var ADMIN_ID = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AuthRole>().HasData(
                new AuthRole {
                    Id = ROLE_ID,
                    Name = "admin",
                    NormalizedName = "admin",
                    brief = "Administrator role", }
            );

            var hasher = new PasswordHasher<Auth>();
            modelBuilder.Entity<Auth>().HasData(
                new Auth {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "duongdong2203@gmail.com",
                NormalizedEmail = "duongdong2203@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abc123456!"),
                SecurityStamp = string.Empty,
                firstName = "Bac Dong",
                lastName = "Duong",
                address = "Hem 566/137 Nguyen Thai Son, Phuong 10, Quan Go Vap, TP. HCM", }
            );

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid> {
                    RoleId = ROLE_ID,
                    UserId = ADMIN_ID, }
            );
        }
    }
}