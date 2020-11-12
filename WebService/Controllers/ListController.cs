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
    [Route("api/")]
    public class ListController : ControllerBase
    {
        private IUserDataService _dataService;
        private readonly IMapper _mapper;

        public ListController(IUserDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        [HttpGet("list/{listid}")]
        public IActionResult GetPersonBookMarkList(int listid)
        {
            var bookmarklist = _dataService.GetPersonBookmarkList(listid);
            var getbookmarks = _dataService.GetBookmarks(listid);
                
            IList<PersonBookmarkListDto> listDto = bookmarklist.Select(x => new PersonBookmarkListDto
            {
                Id = x.Id,
                User_Id = x.User_Id,
                List_Name = x.List_Name,
                Url = ""
            }).ToList();
            
            IList<PersonBookmarkDto> bookmarkDtos = getbookmarks.Select(x => new PersonBookmarkDto
            {
                Id = x.Id,
                List_Id = x.List_Id,
                Person_Id = x.Person_Id,
                Url = ""
            }).ToList();

            return Ok(new {listDto, bookmarkDtos});
        }

    }
}