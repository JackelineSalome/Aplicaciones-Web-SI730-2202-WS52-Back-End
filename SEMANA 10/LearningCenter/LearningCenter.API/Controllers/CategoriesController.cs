using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using LearningCenter.API.Resources;
using LearningCenter.Domain;
using LearningCenter.Infraestructure;
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
        private IMapper _mapper;
        
        public CategoriesController(ICategoryDomain categoryDomain,IMapper _mapper)
        {
            _categoryDomain = categoryDomain;
            _mapper = this._mapper;
        }
        
        // GET: api/Categories
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public IEnumerable<Category> Get()
        {
            var result = _categoryDomain.getAll();
            return result;
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "Get")]
        public Category Get(int id)
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
        public async Task<IActionResult> Post([FromBody] CategoryResource categoryInput)
        {
            /*var category = new Category()
            {
                Name = categoryInput.Name,
                Description = categoryInput.Description
            };*/

            /*if (categoryInput.Name == "" || categoryInput.Name == null)
            {
                throw CheckoutException.Canceled;
            }*/

            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest("error de formato");
                }

                var category = _mapper.Map<CategoryResource, Category>(categoryInput);

                var result = await _categoryDomain.createCategory(category);
                return StatusCode(StatusCodes.Status201Created,"Category created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error al procesar");
            }
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public Boolean Put(int id, [FromBody] string value)
        {
            var result = _categoryDomain.updateCategory(id, value);
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
