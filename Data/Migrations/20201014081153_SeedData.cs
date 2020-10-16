using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace applestore.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 14, 8, 11, 52, 788, DateTimeKind.Utc).AddTicks(3284),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2020, 10, 13, 8, 42, 2, 725, DateTimeKind.Utc).AddTicks(5687));

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "id", "key", "value" },
                values: new object[,]
                {
                    { 1, "Home", "This is a home page Apple Store!" },
                    { 2, "Search", "This is a search page Apple Store!" },
                    { 3, "Product", "This is a product page Apple Store!" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id", "isPublic", "parentId", "sortOrder", "status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 1, 1 },
                    { 3, true, null, 1, 1 },
                    { 4, true, null, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "id", "isDefault", "name" },
                values: new object[,]
                {
                    { 1, true, "English" },
                    { 2, false, "Vietnamese" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "created", "originalPrice", "price", "seoAlias", "stock" },
                values: new object[] { 1, new DateTime(2020, 10, 14, 8, 11, 52, 850, DateTimeKind.Utc).AddTicks(3330), 800m, 868m, "iphone-11-promax", 100 });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "id", "brief", "categoryId", "languageId", "name", "seoAlias", "title" },
                values: new object[,]
                {
                    { 1, "Smartphone Apple", 1, 1, "iPhone", "iphone", "Smartphone" },
                    { 3, "Tablet Apple", 2, 1, "iPad", "ipad", "Tablet" },
                    { 5, "Macbook Apple", 3, 1, "Macbook", "macbook", "Macbook" },
                    { 7, "Apple Watch", 4, 1, "Watch", "apple-watch", "Apple Watch" },
                    { 2, "Điện thoại thông minh Apple", 1, 2, "Điện thoại", "dien-thoai", "Điện thoại thông minh" },
                    { 4, "Máy tính bảng thông minh Apple", 2, 2, "Máy tính bảng", "may-tinh-bang", "Máy tính bảng thông minh" },
                    { 6, "Máy tính xách tay Apple", 3, 2, "Máy tính xách tay", "may-tinh-xach-tay", "Máy tính xách tay" },
                    { 8, "Đồng hồ thông minh Apple", 4, 2, "Đồng hồ", "dong-ho", "Đồng hồ thông minh" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "categoryId", "productId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductTranslations",
                columns: new[] { "id", "brief", "languageId", "name", "productId", "seoAlias", "title" },
                values: new object[,]
                {
                    { 1, "Smartphone Apple", 1, "iPhone 11 Pro Max", 1, "iphone-11-promax", "Smartphone Apple" },
                    { 2, "Điện thoại thông minh Apple", 2, "iPhone 11 Pro Max", 1, "iphone-11-promax", "Điện thoại thông minh Apple" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "categoryId", "productId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "Products",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2020, 10, 13, 8, 42, 2, 725, DateTimeKind.Utc).AddTicks(5687),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 10, 14, 8, 11, 52, 788, DateTimeKind.Utc).AddTicks(3284));
        }
    }
}
