using AutoMapper;
using LMS.Dtos;
using LMS.Models;
using LMS.Unit_o__Work;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly IConfiguration configuration;

        public AuthController(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher<User> passwordHasher, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.passwordHasher = passwordHasher;
            this.configuration = configuration;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if(dto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var existinguser = await unitOfWork.Auth.GetByName(dto.UserName);
            if (existinguser != null)
            {
                return Conflict("The UserName that you entered already exists!");
            }
            var user = mapper.Map<User>(dto);
            user.Role = "Member";
            user.PasswordHash = passwordHasher.HashPassword(user, dto.PasswordHash);
            await unitOfWork.Auth.AddUser(user);
           await unitOfWork.Save();
            return Created();
        }
        private string CreateToken(User user)
        {
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var signingCerdentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var tokenobj = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: Claims,
                signingCredentials: signingCerdentials,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["JWT:ExpireMinutes"]))
                );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenobj);
            return token;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if(dto == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            var existinguser = await unitOfWork.Auth.GetByName(dto.UserName);
            if (existinguser == null)
            {
                return Unauthorized("The UserName is wrong!");
            }
            
            if(passwordHasher.VerifyHashedPassword(existinguser, existinguser.PasswordHash, dto.PasswordHash) == PasswordVerificationResult.Failed)
            {
                return Unauthorized("The password that you entered is wrong");
            }
            return Ok(CreateToken(existinguser));
        }
    }
}
