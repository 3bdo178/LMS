using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LMS.Dtos
{
    [Index(nameof(Name), IsUnique = true)]
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
