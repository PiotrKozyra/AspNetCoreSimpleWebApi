using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WholesaleApi.Data;
using WholesaleApi.Models;

namespace WholesaleApi.Controllers {
    [Route ("api/product")]
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly IProductRepository _repo;

        public ProductController (IProductRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts () {
            var products = await _repo.GetAllProducts ();
            return products.ToList ();
        }

        [HttpGet ("{id}", Name = "GetProductById")]
        public async Task<ActionResult<Product>> GetProductById (int id) {
            var product = await _repo.GetProductById (id);

            if (product == null) {
                return NotFound ();
            }

            return product;
        }
     

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct (Product product) {
            var createdProduct = await _repo.CreateProduct (product);

            return CreatedAtRoute ("GetSupplierById", new { id = createdProduct.Id }, createdProduct);

        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> PutProduct (int id, Product product) {
            var updatedProduct = await _repo.UpdateProduct (id, product);
            if (updatedProduct == false) {
                return BadRequest ();
            }
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct (int id) {
            var product = await _repo.DeleteProduct (id);

            if (product == null) {
                return NotFound ();
            }
            return product;
        }
    }
}