using AutoMapper;
using LMS.Dtos;
using LMS.Models;
using LMS.Unit_o__Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BorrowingsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBorrowing([FromBody] CreateBorrowingDto dto)
        {
            if(dto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingMember = unitOfWork.Members.GetById(dto.MemberId);
            var existingBook = unitOfWork.Books.GetById(dto.BookId);
            if(existingBook == null|| existingMember == null)
            {
                return BadRequest();
            }
            var borrowing = mapper.Map<Borrowing>(dto);
            existingBook.IsAvailable = false;
            unitOfWork.Borrowings.Create(borrowing);
            unitOfWork.Books.Update(existingBook);
            await unitOfWork.Save();
            return Created();
        }
        [HttpGet]
        public async Task<IActionResult> GetBorrowings()
        {
            var borrowings = await unitOfWork.Borrowings.GetBorrowingsWithMemberAndBook();
            if(borrowings==null|| borrowings.Count == 0)
            {
                return NotFound();
            }
            var dto = mapper.Map<List<BorrowingDto>>(borrowings);
            return Ok(dto);
        }
        [HttpPut("{Id}/Return")]
        public async Task<IActionResult> ReturnBorrowing(int Id)
        {
            var borrowing = await unitOfWork.Borrowings.GetBorrowingWithBook(Id);
            if(borrowing == null)
            {
                return NotFound();
            }
            borrowing.Book.IsAvailable = true;
            borrowing.ReturnDate = DateTime.UtcNow;
            unitOfWork.Borrowings.Update(borrowing);
            unitOfWork.Books.Update(borrowing.Book);
            await unitOfWork.Save();
            return NoContent();
        }
    }
}
