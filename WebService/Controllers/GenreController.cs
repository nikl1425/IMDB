using System.Collections;
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
        public IActionResult AllGenres()
        {
            var genres = _dataService.GetGenres();

            var items = genres.Select(CreateObjectOfGenre);

            return Ok(items);
        }
        
        /// <summary>
        /// return a specific genre based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}", Name = nameof(GetGenre))]
        public IActionResult GetGenre(int id)
        {
            var genre = _dataService.GetGenre(id);
            if (genre == null)
            {
                return NotFound();
            }

            var genreDto = _mapper.Map<GenreDto>(genre);
            genreDto.Url = Url.Link(nameof(GetGenre), new {id});

            var genretitles = _dataService.GetGenreTitles(id);

            IList<GenreTitleNameDTO> GenreTitleNameDto = genretitles.Select(x => new GenreTitleNameDTO
            {
                Id = x.Id,
                GenreName = x.Genre.Name,
                titleName = x.Title.PrimaryTitle,
                Url = "http://localhost:5001/api/title/" + x.Title.Id
                
            }).ToList();
            
            return Ok(new {genreDto, GenreTitleNameDto});
        }

        

        private GenreListDto CreateObjectOfGenre(Genre genre)
        {
            var dto = _mapper.Map<GenreListDto>(genre);
            dto.Url = Url.Link(nameof(GetGenre), new {genre.Id});
            return dto;
        }
    }
}