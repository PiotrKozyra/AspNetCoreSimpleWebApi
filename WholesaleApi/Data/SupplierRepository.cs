using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WholesaleApi.Models;

namespace WholesaleApi.Data {
    public class SupplierRepository : ISupplierRepository {
        private readonly WholesaleContext _context;

        public SupplierRepository (WholesaleContext context) {
            _context = context;
        }
        public async Task<Supplier> CreateSupplier (Supplier supplier) {
            await _context.Suppliers.AddAsync (supplier);
            await _context.SaveChangesAsync ();

            return supplier;
        }

        public async Task<Supplier> DeleteSupplier (int id) {
            var supplier = await _context.Suppliers
                .FirstOrDefaultAsync (s => s.Id == id);

            if (supplier == null)
                return null;

            _context.Suppliers.Remove (supplier);
            await _context.SaveChangesAsync ();
            return supplier;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers () {
            return await _context.Suppliers
                .Include (s => s.Products)
                .ToListAsync ();
        }

        public async Task<Supplier> GetSupplierById (int id) {
            var category = await _context.Suppliers
                .Include (p => p.Products)
                .FirstOrDefaultAsync (s => s.Id == id);

            return category;
        }

        public async Task<bool> UpdateSupplier (int id, Supplier supplier) {
            if (id != supplier.Id)
                return false;
            _context.Entry (supplier).State = EntityState.Modified;
            await _context.SaveChangesAsync ();

            return true;
        }
    }
}