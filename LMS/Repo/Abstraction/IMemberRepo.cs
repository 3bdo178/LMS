using LMS.Models;

namespace LMS.Repo.Abstraction
{
    public interface IMemberRepo : IGenericRepo<Member>
    {
        Task<List<Member>> GetTopMembers();
    }
}
