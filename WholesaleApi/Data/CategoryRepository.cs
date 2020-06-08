using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WholesaleApi.Models;

namespace WholesaleApi.Data {
    public class CategoryRepository : ICategoryRepository {
        private readonly WholesaleContext _context;

        public CategoryRepository (WholesaleContext context) {
            _context = context;
        }
        public async Task<Category> AddCategory (Category category) {
            await _context.Categories.AddAsync (category);
            await _context.SaveChangesAsync ();

            return category;
        }

        public async Task<Category> DeleteCategory (int id) {
            var category = await _context.Categories
                .FirstOrDefaultAsync (c => c.Id == id);

            if (category == null)
                return null;

            _context.Categories.Remove (category);
            await _context.SaveChangesAsync ();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories () {
            return await _context.Categories
                .Include (p => p.Products)
                .ToListAsync ();
        }

        public async Task<Category> GetCategoryById (int id) {
            return await _context.Categories
                .Include (p => p.Products)
                .FirstOrDefaultAsync (p => p.Id == id);
        }

        public async Task<bool> UpdateCategory (int id, Category category) {
            if (id != category.Id)
                return false;
            _context.Entry (category).State = EntityState.Modified;
            await _context.SaveChangesAsync ();

            return true;
        }
    }
}