using System.ComponentModel.DataAnnotations;

namespace LMS.Dtos
{
    public class CreateBorrowingDto
    {
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
    }
}
