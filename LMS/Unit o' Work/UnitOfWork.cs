using LMS.Data;
using LMS.Repo.Abstraction;

namespace LMS.Unit_o__Work
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBookRepo Books { get;}

        public IBorrowingRepo Borrowings { get; }

        public ICategoryRepo Categories { get; }

        public IMemberRepo Members { get; }
        private readonly AppDbContext Context;
        public UnitOfWork(AppDbContext context, IBookRepo books, IBorrowingRepo borrowings, ICategoryRepo categories, IMemberRepo members)
        {
            Context = context;
            Books = books;
            Borrowings = borrowings;
            Categories = categories;
            Members = members;
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

    }
}
