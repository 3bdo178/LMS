using LMS.Repo.Abstraction;

namespace LMS.Unit_o__Work
{
    public interface IUnitOfWork
    {
        IBookRepo Books { get; }
        IBorrowingRepo Borrowings { get; }
        ICategoryRepo Categories { get; }
        IMemberRepo Members { get; }
        IAuthRepo Auth { get; }
        public Task<int> Save();
    }
}
