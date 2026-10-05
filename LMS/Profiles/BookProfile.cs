using AutoMapper;
using LMS.Dtos;
using LMS.Models;

namespace LMS.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookDto, Book>();
            CreateMap<Book, BookDto>();
        }
    }
}
