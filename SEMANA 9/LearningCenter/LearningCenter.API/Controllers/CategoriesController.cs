using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using LearningCenter.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryDomain _categoryDomain;
        
        public CategoriesController(ICategoryDomain categoryDomain)
        {
            _categoryDomain = categoryDomain;
        }
        
        // GET: api/Categories
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public IEnumerable<string> Get()
        {
            var result = _categoryDomain.getAll();
            return result;
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            //var result = new CategoryDomain().getCategoryById(id);
            var result = _categoryDomain.getCategoryById(id);
            return result;
        }

        // POST: api/Categories
        [HttpPost]
        [ProducesResponseType(typeof(Boolean), 201)]
        [ProducesResponseType(typeof(List<string>), 400)]
        [ProducesResponseType(500)]
        public Boolean Post([FromBody] string value)
        {
            var result = _categoryDomain.createCategory(value);
            return result;
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public Boolean Put(int id, [FromBody] string value)
        {
            var result = _categoryDomain.updateCategory(value);
            return result;
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public Boolean Delete(int id)
        {
            var result = _categoryDomain.deleteCategory(id);
            return result;

        }
    }
}
