using AutoMapper;
using DataService.Objects;
using WebService.ObjectDto;

namespace WebService.Models
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();
            CreateMap<Person, TitlePersonDTO>();
        }
    }
}