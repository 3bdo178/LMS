using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LMS.Dtos
{
    [Index(nameof(ISBN),IsUnique =true)]
    public class CreateBookDto
    {

        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required, Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
    }
}
