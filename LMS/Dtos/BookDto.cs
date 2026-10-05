using System.ComponentModel.DataAnnotations;

namespace LMS.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required, Range(1, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
