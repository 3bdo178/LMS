using LMS.Models;

namespace LMS.Repo.Abstraction
{
    public interface IBookRepo : IGenericRepo<Book>
    {
        List<Book> SearchByName(string name);
        Book GetMostExpensive();
    }
}
