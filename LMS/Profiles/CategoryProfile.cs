using AutoMapper;
using LMS.Dtos;
using LMS.Models;

namespace LMS.Profiles
{
    public class CategoryProfile : Profile
    { 
        public CategoryProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CategoryDto>().ForMember
                (dest => dest.NumberOfBooks, opt => opt.MapFrom(src => src.Books.Count()));
        }
    }
}
