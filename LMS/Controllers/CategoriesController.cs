using AutoMapper;
using LMS.Dtos;
using LMS.Models;
using LMS.Unit_o__Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork unitofwork;
        private readonly IMapper mapper;

        public CategoriesController(IUnitOfWork _unitofwork, IMapper _mapper)
        {
            unitofwork = _unitofwork;
            mapper = _mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto dto)
        {
            var categories = unitofwork.Categories.GetAll();
            
            if(dto == null || !ModelState.IsValid||categories.Any(c=>c.Name==dto.Name))
            {
                return BadRequest(ModelState);
            }
            var category = mapper.Map<Category>(dto);
            unitofwork.Categories.Create(category);
           await unitofwork.Save();
            return Created();
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var cateogries = await unitofwork.Categories.GetCategoriesWithBooks();
            if (cateogries == null) {
                return NotFound();
            }
            var dto = mapper.Map<List<CategoryDto>>(cateogries);
            return Ok(dto);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DelleteCategory(int Id)
        {
            var category = await unitofwork.Categories.GetCategoryWithBooks(Id);
            if(category == null|| category.Books.Count != 0)
            {
                return BadRequest();
            }
            unitofwork.Categories.Delete(category);
            await unitofwork.Save();
            return NoContent();
        }
    }
}
