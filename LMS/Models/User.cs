using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
