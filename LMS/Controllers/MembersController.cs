using AutoMapper;
using LMS.Dtos;
using LMS.Models;
using LMS.Unit_o__Work;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MembersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberDto dto)
        {
            var members = unitOfWork.Members.GetAll();
            if(dto == null|| !ModelState.IsValid || members.Any(m => m.Email == dto.Email))
            {
                return BadRequest(ModelState);
            }
            var member = mapper.Map<Member>(dto);
            unitOfWork.Members.Create(member);
            await unitOfWork.Save();
            return Created();
        }
        [HttpGet("top-readers")]
        public async Task<IActionResult> GetTopReaders()
        {
            var tops = await unitOfWork.Members.GetTopMembers();
            if(tops == null || tops.Count == 0)
            {
                return NotFound();
            }
            var dto = mapper.Map<List<MemberDto>>(tops);
            return Ok(dto);
        }
    }
}
