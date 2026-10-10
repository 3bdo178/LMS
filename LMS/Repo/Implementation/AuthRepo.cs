using LMS.Data;
using LMS.Models;
using LMS.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repo.Implementation
{
    public class AuthRepo : IAuthRepo
    {
        private readonly AppDbContext context;

        public AuthRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddUser(User user)
        {
            context.Users.Add(user);
        }

        public Task<User> GetByName(string username)
        {
            return context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}
