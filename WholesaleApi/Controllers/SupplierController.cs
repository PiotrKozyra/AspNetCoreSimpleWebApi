using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WholesaleApi.Data;
using WholesaleApi.Models;

namespace WholesaleApi.Controllers {
    [Route ("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase {
        private readonly ISupplierRepository _repo;

        public SupplierController (ISupplierRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetAllSuppliers () {
            var suppliers = await _repo.GetAllSuppliers ();
            return suppliers.ToList ();
        }

        [HttpGet ("{id}", Name = "GetSupplierById")]
        public async Task<ActionResult<Supplier>> GetSupplierById (int id) {
            var supplier = await _repo.GetSupplierById (id);

            if (supplier == null) {
                return NotFound ();
            }

            return supplier;
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> CreateSupplier (Supplier supplier) {
            var createdSupplier = await _repo.CreateSupplier (supplier);

            return CreatedAtRoute ("GetSupplierById", new { id = createdSupplier.Id }, createdSupplier);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> PutSupplier (int id, Supplier supplier) {
            var updatedSupplier = await _repo.UpdateSupplier (id, supplier);
            if (updatedSupplier == false) {
                return BadRequest ();
            }
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Supplier>> DeleteSupplier (int id) {
            var supplier = await _repo.DeleteSupplier (id);

            if (supplier == null) {
                return NotFound ();
            }

            return supplier;
        }
    }
}