using System.ComponentModel.DataAnnotations;

namespace LMS.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
