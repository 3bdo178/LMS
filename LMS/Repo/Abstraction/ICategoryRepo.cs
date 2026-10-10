using LMS.Models;

namespace LMS.Repo.Abstraction
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        Task<List<Category>> GetCategoriesWithBooks();
        Task<Category> GetCategoryWithBooks(int Id);
    }
}
