using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using applestore.Data.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using applestore.ViewModels.Core;
using applestore.ViewModels.Modules.Product;
using applestore.ViewModels.Modules.Product.Public;

namespace applestore.Application.Modules.Products {
    public class PublicProductServices : IPublicProductServices {
        private readonly AppleDbContext _context;
        public PublicProductServices(AppleDbContext context) {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAll() {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.id equals pt.productId
                        join pic in _context.ProductInCategories 
                            on p.id equals pic.productId
                        join c in _context.Categories on pic.categoryId equals c.id
                        select new {p, pt, pic};

            var data = await query.Select(x => new ProductViewModel() {
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

            return data;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request) {
            // SELECT JOIN
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.id equals pt.productId
                        join pic in _context.ProductInCategories on p.id equals pic.productId
                        join c in _context.Categories on pic.categoryId equals c.id
                        select new {p, pt, pic};

            // Fillter
            if (request.categoryId.HasValue && request.categoryId.Value > 0)
                query = query.Where(x => x.pic.categoryId == request.categoryId);

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
    }
}