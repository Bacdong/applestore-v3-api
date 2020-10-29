using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using applestore.Application.Core;
using applestore.Data.EF;
using applestore.Data.Entity;
using applestore.Utilities.Exceptions;
using applestore.APIs.Core;
using applestore.APIs.Modules.Product.Serializers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace applestore.Application.Modules.Products {
    public class ManageProductServices : IManageProductServices {
        private readonly AppleDbContext _context;
        private readonly IStorageServices _storageService;
        public ManageProductServices(
            AppleDbContext context, IStorageServices storageServices) {
            _context = context;
            _storageService = storageServices;
        }

        public Task<int> AddImages(int productId, List<IFormFile> files) {
            throw new NotImplementedException();
        }

        public async Task addViewCount(int productId) {
            var product = await _context.Products.FindAsync(productId);
            product.viewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> create(ProductCreateSerializer request) {
            var product = new Product() {
                price = request.price,
                originalPrice = request.originalPrice,
                inventory = request.inventory,
                viewCount = 0,
                created = DateTime.UtcNow,
                productTranslations = new List<ProductTranslation>() {
                    new ProductTranslation() {
                        name = request.name,
                        brief = request.brief,
                        title = request.title,
                        slug = request.slug,
                        languageId = request.languageId,
                    }
                }
            };

            // Save image
            if (request.thumbnail != null)
                product.productImages = new List<ProductImage>() {
                    new ProductImage() {
                        created = DateTime.UtcNow,
                        imagePath = await this.SaveFile(request.thumbnail),
                        isDefault = true,
                        sortOrder = 1, 
                    }
                };

            _context.Products.Add(product);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> delete(int productId) {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) 
                throw new AppleException($"Product {productId} not found, try again!");
                
            var images = _context.ProductImages
                .Where(x => x.productId == productId);

            foreach (var image in images)
                await _storageService.DeleteFileAsync(image.imagePath);
            
            _context.Products.Remove(product);
            
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductImageViewModel>> 
            GetListImage(int productId) {
                return await _context.ProductImages
                    .Where(x => x.productId == productId)
                    .Select(images => new ProductImageViewModel() {
                        id = images.id,
                        imagePath = images.imagePath,
                        isDefault = images.isDefault,
                    }).ToListAsync();   
        }

        public async Task<PaginationSerializer<ProductSerializer>> 
            ProductPaginationListView(ProductPaginationListSerializer request) {
                // SELECT JOIN
                var query = from p in _context.Products
                            join pt in _context.ProductTranslations 
                                on p.id equals pt.productId
                            join pic in _context.ProductInCategories 
                                on p.id equals pic.productId
                            join c in _context.Categories on pic.categoryId equals c.id
                            select new {p, pt, pic};

                // Fillter
                if (!string.IsNullOrEmpty(request.keyword))
                    query = query.Where(x => x.pt.name.Contains(request.keyword));

                if (request.categoryIds.Count > 0)
                    query = query.Where(x => request.categoryIds
                                .Contains(x.pic.categoryId));

                // Pagination
                int totalRow = await query.CountAsync();
                var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                    .Take(request.pageSize)
                    .Select(x => new ProductSerializer() {
                        id = x.p.id,
                        name = x.pt.name,
                        brief = x.pt.brief,
                        title = x.pt.title,
                        price = x.p.price,
                        originalPrice = x.p.originalPrice,
                        languageId = x.pt.languageId,
                        slug = x.pt.slug,
                        inventory = x.p.inventory,
                        viewCount = x.p.viewCount,
                    }).ToListAsync();

                // Select and projection
                var pageResult = new PaginationSerializer<ProductSerializer>() {
                    Items = data,
                    totalRecord = totalRow,
                };

                return pageResult;
        }

        public async Task<int> RemoveImages(int imageId) {
            var image = await _context.ProductImages.FindAsync(imageId);

            if (image == null)
                throw new AppleException($"Image {imageId} not found, try again!");

            _context.ProductImages.Remove(image);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> update(ProductUpdateSerializer request) {
            var product = await _context.Products.FindAsync(request.id);
            var productTranslation = await _context
                .ProductTranslations.FirstOrDefaultAsync(
                    x => x.productId == request.id && x.languageId == request.languageId);

            if (product == null || productTranslation == null)
                throw new AppleException($"Product {request.id} not found, try again!");

            productTranslation.name = request.name;
            productTranslation.brief = request.brief;
            productTranslation.title = request.title;
            productTranslation.slug = request.slug;

            // Save images
            if (request.thumbnail != null) {
                var productUpdate = await _context.ProductImages
                    .FirstOrDefaultAsync(
                        x => x.isDefault == true && x.productId == request.id);

                if (productUpdate != null)
                    productUpdate.imagePath = await this.SaveFile(request.thumbnail);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImages(int imageId, bool isDefault) {
            var images = _context.ProductImages.Where(x => x.id == imageId);
            if (images == null)
                throw new AppleException($"Image {imageId} not found, try again!");

            var imageUpdate = await _context.ProductImages
                .FirstOrDefaultAsync(x => x.id == imageId);

            if (imageUpdate != null)
                imageUpdate.isDefault = isDefault;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> PriceUpdate(int productId, decimal newPrice) {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new AppleException($"Product {productId} not found, try again!");

            product.price = newPrice;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> InventoryUpdate(int productId, int newQuantity) {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new AppleException($"Product {productId} not found, try again!");

            product.inventory += newQuantity;

            return await _context.SaveChangesAsync() > 0;
        }
    
        private async Task<string> SaveFile(IFormFile file) {
            var originalFileName = ContentDispositionHeaderValue.Parse(
                file.ContentDisposition).FileName.Trim('"');
            
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);

            return fileName;
        }
    }
}