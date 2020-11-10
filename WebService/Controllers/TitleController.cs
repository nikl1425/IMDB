using AutoMapper;
using DataService.Services;
using Microsoft.AspNetCore.Mvc;

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

            if (genre == null)
            {
                return null;
            }

            return Ok(genre);
        }
    }
}