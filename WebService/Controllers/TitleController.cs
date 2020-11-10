using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataService.Objects;
using DataService.Services;
using Microsoft.AspNetCore.Mvc;
using WebService.ObjectDto;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/titles")]
    public class TitleController : ControllerBase
    {
        private ITitleDataService _dataService;
        private readonly IMapper _mapper;

        public TitleController(ITitleDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("genre")]
        public IActionResult getGenres()
        {
            var genre = _dataService.GetGenres();

            IList<GenreDto> newGenreDtos = genre.Select(x => new GenreDto
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();

            return Ok(newGenreDtos);
        }

        [HttpGet("genre/{id}", Name = nameof(getGenre))]
        public IActionResult getGenre(int id)
        {
            var genre = _dataService.GetGenre(id);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        [HttpGet("genreTitle/{id}", Name = nameof(getGenreTitles))]
        public IActionResult getGenreTitles(int id)
        {
            var genreTitle = _dataService.getGenreTitles(id);
            IList<GenreTitleNameDTO> genreTitleNameDto = genreTitle.Select(x => new GenreTitleNameDTO
            {
                Id = x.Id,
                Name = x.Name,
                TitleNames = x.TitleGenres.Select(x => new TitleDto
                {
                    Name = x.Title.PrimaryTitle
                }).ToList()
            }).ToList();

            return Ok(genreTitleNameDto);
        }
    }
}