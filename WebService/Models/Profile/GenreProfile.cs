using AutoMapper;
using DataService.Objects;
using WebService.ObjectDto;

namespace WebService.Models
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<Genre, GenreListDto>();
            CreateMap<Genre, TitleGenreDTO>();
            CreateMap<Genre, GenreTitleNameDTO>();
        }
    }
}