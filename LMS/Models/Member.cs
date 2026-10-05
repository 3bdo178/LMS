using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
    }
}
