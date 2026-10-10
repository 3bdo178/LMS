using AutoMapper;
using LMS.Dtos;
using LMS.Models;

namespace LMS.Profiles
{
    public class BorrowingProfile : Profile
    {
        public BorrowingProfile() 
        {
            CreateMap<CreateBorrowingDto, Borrowing>();
            CreateMap<Borrowing, BorrowingDto>().ForMember
                (dest => dest.Member, opt => opt.MapFrom(src => src.Member)).ForMember
                (dest => dest.Book, opt => opt.MapFrom(src => src.Book));
        }
    }
}
