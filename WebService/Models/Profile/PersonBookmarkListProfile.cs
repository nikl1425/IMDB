using AutoMapper;
using DataService.Objects;
using WebService.ObjectDto;

namespace WebService.Models
{
    public class PersonBookmarkListProfile : Profile
    {
        public PersonBookmarkListProfile()
        {
            CreateMap<Person_Bookmark_list, PersonBookmarkListDto>();
            //CreateMap<Person_Bookmark_list, UserDto>();
        }
        
    }
}