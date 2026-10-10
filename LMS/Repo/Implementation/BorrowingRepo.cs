using LMS.Data;
using LMS.Models;
using LMS.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repo.Implementation
{
    public class BorrowingRepo : GenericRepo<Borrowing>, IBorrowingRepo
    {
        private readonly AppDbContext Context;
        public BorrowingRepo(AppDbContext context) : base(context)
        {
            Context = context;
        }

        public Task<List<Borrowing>> GetBorrowingsWithMemberAndBook()
        {
            return Context.Borrowings.Include(b=>b.Member).Include(b=>b.Book).OrderByDescending(b=>b.BorrowDate).ToListAsync();
        }

        public Task<Borrowing> GetBorrowingWithBook(int Id)
        {
            return Context.Borrowings.Include(b => b.Book).FirstOrDefaultAsync(b => b.Id == Id);
        }
    }
}
