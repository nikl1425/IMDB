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

            IList<TitleListDto> titleDto = titles.Select(x => new TitleListDto
            {
                Id = x.Id,
                PrimaryTitle = x.PrimaryTitle,
                OriginalTitle = x.OriginalTitle,
                IsAdult = x.IsAdult,
                StartYear = x.StartYear,
                EndYear = x.EndYear
            }).ToList();

            var items = _mapper.Map<IEnumerable<TitleListDto>>(titleDto);
            
            
            return Ok(items);
        }

        private TitleListDto CreateObjectOfTitle(Title title)
        {
            var dto = _mapper.Map<TitleListDto>(title);
            dto.Url
        }
    }
    
}