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
    [Route("api/title")]
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
        public IActionResult AllTitles()
        {

            var titles = _dataService.GetTitles();

            var items = titles.Select(CreateObjectOfTitle);


            return Ok(items);
        }

        [HttpGet ("{id}", Name = nameof(GetTitle))]
        public IActionResult GetTitle(string id)
        {
            var title = _dataService.getTitle(id);

            if (title == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<TitleDto>(title);

            dto.Url = Url.Link(nameof(GetTitle), new {id});

            return Ok(dto);
        }
       
        private TitleListDto CreateObjectOfTitle(Title title)
        {
            var dto = _mapper.Map<TitleListDto>(title);
            dto.Url = Url.Link(nameof(GetTitle), new {title.Id});
            return dto;
        }
        
    }
    
}