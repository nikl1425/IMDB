using AutoMapper;
using DataService.Objects;
using WebService.ObjectDto;

namespace WebService.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            //CreateMap<User, PersonBookmarkDto>();
            //CreateMap<User, PersonBookmarkListDto>();
            //CreateMap<User, x>();
            //CreateMap<User, x>();
            //CreateMap<User, x>();
        }
    }
}