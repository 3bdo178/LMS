using AutoMapper;
using LMS.Dtos;
using LMS.Models;

namespace LMS.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile() 
        {
            CreateMap<RegisterDto, User>();        
        }
    }
}
