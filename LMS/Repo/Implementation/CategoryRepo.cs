using LMS.Data;
using LMS.Models;
using LMS.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repo.Implementation
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly AppDbContext Context;
        public CategoryRepo(AppDbContext context) : base(context)
        {
            Context = context;
        }

        public Task<List<Category>> GetCategoriesWithBooks()
        {
            return Context.Categories.Include(c => c.Books).ToListAsync();
        }

        public Task<Category> GetCategoryWithBooks(int Id)
        {
            return Context.Categories.Include(c=>c.Books).FirstOrDefaultAsync(c => c.Id == Id);
        }
    }
}
