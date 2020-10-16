using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using applestore.Application.DTOs;
using applestore.Application.Modules.Products.DTOs;
using applestore.Data.EF;
using applestore.Data.Entity;

namespace applestore.Application.Modules.Products {
    public class ManageProductServices : IManageProductServices {
        private readonly AppleDbContext _context;
        public ManageProductServices(AppleDbContext context) {
            _context = context;
        }

        public async Task<int> create(ProductCreateRequest request) {
            var product = new Product() {
                price = request.price,
            };
            _context.Products.Add(product);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> delete(int productId) {
            throw new NotImplementedException();
        }

        public async Task<List<ProductViewModel>> GetAll() {
            throw new NotImplementedException();
        }

        public async Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize) {
            throw new NotImplementedException();
        }

        public async Task<int> update(ProductEditRequest request) {
            throw new NotImplementedException();
        }
    }
}