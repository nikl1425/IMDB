using AutoMapper;
using DataService.Objects;
using WebService.ObjectDto;

namespace WebService.Models
{
    public class PersonBookmarkProfile : Profile
    {
        public PersonBookmarkProfile()
        {
            CreateMap<Person_Bookmark, PersonBookmarkDto>();
            CreateMap<Person_Bookmark, UserDto>();
        }
    }
}