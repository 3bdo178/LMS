using LMS.Data;
using LMS.Models;
using LMS.Repo.Abstraction;

namespace LMS.Repo.Implementation
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly AppDbContext Context;
        public CategoryRepo(AppDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
