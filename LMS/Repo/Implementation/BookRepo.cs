using LMS.Data;
using LMS.Models;
using LMS.Repo.Abstraction;

namespace LMS.Repo.Implementation
{
    public class BookRepo : GenericRepo<Book>, IBookRepo
    {
        private readonly AppDbContext Context;
        public BookRepo(AppDbContext context) : base(context)
        {
            Context = context;
        }

        public Book GetMostExpensive()
        {
            return Context.Books.OrderByDescending(b => b.Price).Take(1).FirstOrDefault();
        }

        public List<Book> SearchByName(string name)
        {
            return Context.Books.Where(s => s.Title.Contains(name)).ToList();
        }
    }
}
