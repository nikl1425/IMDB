using AutoMapper;
using DataService.Objects;
using WebService.ObjectDto;

namespace WebService.Models
{
    public class AkasProfile : Profile
    {
        public AkasProfile()
        {
            CreateMap<Akas, TitleAkasDTO>();
            CreateMap<Akas, AkasDto>();
        }
    }
}