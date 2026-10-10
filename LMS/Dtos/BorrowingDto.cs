using System.ComponentModel.DataAnnotations;

namespace LMS.Dtos
{
    public class BorrowingDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BookDto Book { get; set; }
        public MemberDto Member { get; set; }
    }
}
