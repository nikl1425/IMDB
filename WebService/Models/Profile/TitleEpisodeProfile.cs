using AutoMapper;
using DataService.Objects;
using WebService.ObjectDto;

namespace WebService.Models
{
    public class TitleEpisodeProfile : Profile
    {
        public TitleEpisodeProfile()
        {
            CreateMap<Title_Episode, TitleEpisodeDto>();
            CreateMap<Title, TitleEpisodeDto>();
        }
    }
}