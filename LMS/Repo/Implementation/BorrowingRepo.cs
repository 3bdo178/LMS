using LMS.Data;
using LMS.Models;
using LMS.Repo.Abstraction;

namespace LMS.Repo.Implementation
{
    public class BorrowingRepo : GenericRepo<Borrowing>, IBorrowingRepo
    {
        private readonly AppDbContext Context;
        public BorrowingRepo(AppDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
