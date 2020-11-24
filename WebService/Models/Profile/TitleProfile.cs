using AutoMapper;
using DataService.Objects;
using WebService.ObjectDto;

namespace WebService.Models
{
    public class TitleProfile : Profile
    {
        public TitleProfile()
        {
            CreateMap<Title, TitleDto>();
            CreateMap<Title, TitleListDto>();
            CreateMap<Title, NameOfTitleDTO>();
            CreateMap<Title, TypeTitlesDto>();
        }
    }
}