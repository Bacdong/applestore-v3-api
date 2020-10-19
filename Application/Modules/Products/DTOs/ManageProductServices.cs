using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using applestore.Application.DTOs;
using applestore.Application.Modules.Products.DTOs;
using applestore.Application.Modules.Products.DTOs.Manage;
using applestore.Data.EF;
using applestore.Data.Entity;
using applestore.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace applestore.Application.Modules.Products {
    public class ManageProductServices : IManageProductServices {
        private readonly AppleDbContext _context;
        public ManageProductServices(AppleDbContext context) {
            _context = context;
        }

        public async Task addViewCount(int productId) {
            var product = await _context.Products.FindAsync(productId);
            product.viewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> create(ProductCreateRequest request) {
            var product = new Product() {
                price = request.price,
                originalPrice = request.originalPrice,
                stock = request.stock,
                viewCount = 0,
                created = DateTime.UtcNow,
                seoAlias = request.seoAlias,
                productTranslations = new List<ProductTranslation>() {
                    new ProductTranslation() {
                        name = request.name,
                        brief = request.brief,
                        title = request.title,
                        seoAlias = request.seoAlias,
                        languageId = request.languageId,
                    }
                }
            };
            _context.Products.Add(product);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> delete(int productId) {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) 
                throw new AppleException($"Product {productId} not found, try again!");
                
            _context.Products.Remove(product);

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetProductAllPaging(GetProductPagingRequest request) {
            // SELECT JOIN
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.id equals pt.productId
                        join pic in _context.ProductInCategories on p.id equals pic.productId
                        join c in _context.Categories on pic.categoryId equals c.id
                        select new {p, pt, pic};

            // Fillter
            if (!string.IsNullOrEmpty(request.keyword))
                query = query.Where(x => x.pt.name.Contains(request.keyword));

            if (request.categoryIds.Count > 0)
                query = query.Where(x => request.categoryIds.Contains(x.pic.categoryId));

            // Pagination
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new ProductViewModel() {
                    id = x.p.id,
                    name = x.pt.name,
                    brief = x.pt.brief,
                    title = x.pt.title,
                    price = x.p.price,
                    originalPrice = x.p.originalPrice,
                    languageId = x.pt.languageId,
                    seoAlias = x.pt.seoAlias,
                    stock = x.p.stock,
                    viewCount = x.p.viewCount,
                }).ToListAsync();

            // Select and projection
            var pageResult = new PagedResult<ProductViewModel>() {
                Items = data,
                totalRecord = totalRow,
            };

            return pageResult;
        }

        public async Task<int> update(ProductUpdateRequest request) {
            var product = await _context.Products.FindAsync(request.id);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(
                x => x.productId == request.id && x.languageId == request.languageId);

            if (product == null || productTranslation == null)
                throw new AppleException($"Product {request.id} not found, try again!");

            productTranslation.name = request.name;
            productTranslation.brief = request.brief;
            productTranslation.title = request.title;
            productTranslation.seoAlias = request.seoAlias;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> updatePrice(int productId, decimal newPrice) {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new AppleException($"Product {productId} not found, try again!");

            product.price = newPrice;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> updateStock(int productId, int newQuantity) {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new AppleException($"Product {productId} not found, try again!");

            product.stock += newQuantity;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}