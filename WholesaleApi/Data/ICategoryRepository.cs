using System.Collections.Generic;
using System.Threading.Tasks;
using WholesaleApi.Models;

namespace WholesaleApi.Data {
    public interface ICategoryRepository {
        Task<IEnumerable<Category>> GetAllCategories ();
        Task<Category> GetCategoryById (int id);
        Task<Category> AddCategory (Category category);
        Task<bool> UpdateCategory (int id, Category category);
        Task<Category> DeleteCategory (int id);
    }
}