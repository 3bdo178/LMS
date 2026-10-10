using LMS.Data;
using LMS.Models;
using LMS.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repo.Implementation
{
    public class MemberRepo : GenericRepo<Member>, IMemberRepo
    {
        private readonly AppDbContext Context;
        public MemberRepo(AppDbContext context) : base(context)
        {
            Context = context;
        }

        public Task<List<Member>> GetTopMembers()
        {
            return Context.Members.Include(m=>m.Borrowings).OrderByDescending(m=>m.Borrowings.Count()).Take(5).ToListAsync();
        }
    }
}
