using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required, Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
    }
}
