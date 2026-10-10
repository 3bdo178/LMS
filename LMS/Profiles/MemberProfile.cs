using AutoMapper;
using LMS.Dtos;
using LMS.Models;

namespace LMS.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile() 
        {
            CreateMap<CreateMemberDto, Member>();
            CreateMap<Member, MemberDto>().ForMember
                (dest => dest.NumberOfBooks, opt => opt.MapFrom(src => src.Borrowings.Count()));
        }
    }
}
