using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WholesaleApi.Models;

namespace WholesaleApi.Data {
    public class ProductRepository : IProductRepository {
        private readonly WholesaleContext _context;

        public ProductRepository (WholesaleContext context) {
            _context = context;
        }
        public async Task<Product> CreateProduct (Product product) {
            var categoryId = await _context.Categories.FirstOrDefaultAsync (c => c.Id == product.CategoryId);
            var supplierId = await _context.Suppliers.FirstOrDefaultAsync (s => s.Id == product.SupplierId);

            await _context.Products.AddAsync (product);
            await _context.SaveChangesAsync ();

            return product;
        }

        public async Task<Product> DeleteProduct (int id) {
            var product = await _context.Products
                .FirstOrDefaultAsync (p => p.Id == id);

            if (product == null)
                return null;

            _context.Products.Remove (product);
            await _context.SaveChangesAsync ();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts () {
            return await _context.Products.ToListAsync ();
        }

        public async Task<Product> GetProductById (int id) {
            return await _context.Products
                .FirstOrDefaultAsync (p => p.Id == id);

        }

        public async Task<bool> UpdateProduct (int id, Product product) {
            if (id != product.Id)
                return false;
            _context.Entry (product).State = EntityState.Modified;
            await _context.SaveChangesAsync ();

            return true;
        }
    }
}