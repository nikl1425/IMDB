using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataService.Services;
using Microsoft.AspNetCore.Mvc;
using WebService.ObjectDto;

namespace WebService.Controllers
{
    
    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private ITitleDataService _dataService;
        private readonly IMapper _mapper;

        public GenreController(ITitleDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
        
        /// <summary>
        /// Lists all genres when entering the genre page
        /// </summary>
        /// <returns></returns>
        
        [HttpGet]
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
        
        /// <summary>
        /// return a specific genre based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}", Name = nameof(getGenre))]
        public IActionResult getGenre(int id)
        {
            var genre = _dataService.GetGenre(id);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }
        
        /// <summary>
        /// Get list of all movie title names within a specific genre.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("Title/{id}", Name = nameof(getGenreTitles))]
        public IActionResult getGenreTitles(int id)
        {
            var genreTitle = _dataService.getGenreTitles(id);
            IList<GenreTitleNameDTO> genreTitleNameDto = genreTitle.Select(x => new GenreTitleNameDTO
            {
                Id = x.Id,
                Name = x.Name,
                TitleNames = x.TitleGenres.Select(x => new NameOfTitleDTO
                {
                     Name = x.Title.PrimaryTitle
                }).ToList()
            }).ToList();

            return Ok(genreTitleNameDto);
        }
    }
}