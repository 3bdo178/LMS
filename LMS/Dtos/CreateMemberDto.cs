using System.ComponentModel.DataAnnotations;

namespace LMS.Dtos
{
    public class CreateMemberDto
    {
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
