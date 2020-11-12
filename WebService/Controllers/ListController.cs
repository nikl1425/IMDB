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
    [Route("api/list")]
    public class ListController : ControllerBase
    {
        private IUserDataService _dataService;
        private readonly IMapper _mapper;

        public ListController(IUserDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
        
        //Get a list
        [HttpGet("{id}", Name = nameof(getList))]
        public IActionResult getList(int id)
        {
            var list = _dataService.GetPersonBookmarkList(id);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }


       
    }
}