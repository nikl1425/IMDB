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
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IUserDataService _dataService;
        private readonly IMapper _mapper;

       
        public UserController(IUserDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getUser()
        {
            var user = _dataService.GetUsers(1);

            /*IList<PersonBookmarkDto> newGenreDtos = genre.Select(x => new GenreDto
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();*/

            return Ok();
        }
    }
}