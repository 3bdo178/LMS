using LMS.Models;

namespace LMS.Repo.Abstraction
{
    public interface IAuthRepo
    {
        Task<User> GetByName(string username);
        Task AddUser(User user);
    }
}
