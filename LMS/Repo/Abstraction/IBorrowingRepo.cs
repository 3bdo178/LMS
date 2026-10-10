using LMS.Models;
using LMS.Repo.Implementation;

namespace LMS.Repo.Abstraction
{
    public interface IBorrowingRepo : IGenericRepo<Borrowing>
    {
        Task<List<Borrowing>> GetBorrowingsWithMemberAndBook();
        Task<Borrowing> GetBorrowingWithBook(int Id);
    }
}
