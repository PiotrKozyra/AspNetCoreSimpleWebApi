using System.Collections.Generic;
using System.Threading.Tasks;
using WholesaleApi.Models;

namespace WholesaleApi.Data
{
    public interface ISupplierRepository
    {
         
        Task<IEnumerable<Supplier>> GetAllSuppliers ();
        Task<Supplier> GetSupplierById (int id);
        Task<Supplier> CreateSupplier (Supplier supplier);
        Task<bool> UpdateSupplier (int id, Supplier supplier);
        Task<Supplier> DeleteSupplier (int id);
    }
}