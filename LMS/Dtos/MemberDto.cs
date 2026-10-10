using System.ComponentModel.DataAnnotations;

namespace LMS.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public int NumberOfBooks { get; set; }
    }
}
