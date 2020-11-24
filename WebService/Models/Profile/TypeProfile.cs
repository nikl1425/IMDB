using AutoMapper;
using DataService.Objects;
using WebService.ObjectDto;

namespace WebService.Models
{
    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            CreateMap<TitleType, TypeDto>();
           
        }
    }
}