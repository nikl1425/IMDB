using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataService.Services;
using Microsoft.AspNetCore.Mvc;
using WebService.ObjectDto;

namespace WebService.Controllers
{
    
    [ApiController]
    [Route("api/type")]
    public class TypeController : ControllerBase
    {
        private ITitleDataService _dataService;
        private readonly IMapper _mapper;

        public TypeController(ITitleDataService dataService, IMapper mapper)
        {
            _mapper = mapper;
            _dataService = dataService;
        }
        
        [HttpGet]
        public IActionResult AllTypes()
        {
            var types = _dataService.GetAllTypes().Select(x => new TypeDto
            {
                Id = x.Id,
                Name = x.TypeName,
                Url = "http://localhost:5001/api/type/" + x.Id
            }).ToList();

            return Ok(types);
        }

        

        [HttpGet("{id}", Name = nameof(GetType))]
        public IActionResult GetType(int id)
        {
            var types = _dataService.GetTypeTitles(id);
            var singleType = _dataService.GetType(id);

            if (singleType == null)
            {
                return NotFound();
            }
           
            TypeDto typeDto = new TypeDto();
            
            typeDto.Id = singleType.Id;
            typeDto.Name = singleType.TypeName;
            typeDto.Url = "http://localhost:5001/api/title" + singleType.Id;

            IList<TypeTitlesDto> typeTitles = types.Select(x => new TypeTitlesDto
            {
                TypeId = x.TypeId,
                TitleName = x.PrimaryTitle,
                TitleUrl = "http://localhost:5001/api/title/" + x.Id
            }).ToList();

            return Ok(new {typeDto, typeTitles});
        }

    }
}