using System.Collections.Generic;
using System.Threading.Tasks;
using WholesaleApi.Models;

namespace WholesaleApi.Data {
    public interface IProductRepository {
        Task<IEnumerable<Product>> GetAllProducts ();
        Task<Product> GetProductById (int id);
        Task<Product> CreateProduct (Product product);
        Task<bool> UpdateProduct (int id, Product product);
        Task<Product> DeleteProduct (int id);
    }
}