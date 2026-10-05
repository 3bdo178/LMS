using AutoMapper;
using LMS.Dtos;
using LMS.Models;
using LMS.Unit_o__Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper _mapper;
        public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofwork = unitOfWork;
        }
        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBookDto dto)
        {
            if(dto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = _mapper.Map<Book>(dto);
            _unitofwork.Books.Create(res);
            _unitofwork.Save();
            return Created();
        }
        [HttpGet("Search/{KeyWord}")]
        public IActionResult SearchByName(string KeyWord)
        {
            var books = _unitofwork.Books.SearchByName(KeyWord);
            if(books == null || books.Count == 0)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<BookDto>>(books));
        }
        [HttpGet("Most-Expensive")]
        public IActionResult GetMostExpensiveBook()
        {
            var book = _unitofwork.Books.GetMostExpensive();
            
            return Ok(_mapper.Map<BookDto>(book));
        }
    }
}
