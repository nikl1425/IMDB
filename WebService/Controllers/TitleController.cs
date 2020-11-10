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
    }
}