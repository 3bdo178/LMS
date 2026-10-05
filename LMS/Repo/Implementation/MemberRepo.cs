using LMS.Data;
using LMS.Models;
using LMS.Repo.Abstraction;

namespace LMS.Repo.Implementation
{
    public class MemberRepo : GenericRepo<Member>, IMemberRepo
    {
        private readonly AppDbContext Context;
        public MemberRepo(AppDbContext context) : base(context)
        {
            Context = context;
        }
    }
}
