using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WholesaleApi.Data;
using WholesaleApi.Models;

namespace WholesaleApi.Controllers {
    [Route ("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase {
        private readonly ICategoryRepository _repo;

        public CategoryController (ICategoryRepository repo) {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories () {
            var categories = await _repo.GetAllCategories ();
            return Ok(categories.ToList ());
        }

        [HttpGet ("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult<Category>> GetCategoryById (int id) {
            var category = await _repo.GetCategoryById (id);

            if (category == null) {
                return NotFound ();
            }
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory (Category category) {

            var createdCategory = await _repo.AddCategory (category);

            return CreatedAtRoute ("GetCategoryById", new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut ("{id}")]
        public async Task<ActionResult> PutCategory (int id, Category category) {
            var updatedCategory = await _repo.UpdateCategory (id, category);
            if (updatedCategory == false) {
                return BadRequest ();
            }
            return NoContent ();
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory (int id) {
            var category = await _repo.DeleteCategory (id);

            if (category == null) {
                return NotFound ();
            }

            return category;
        }
    }
}