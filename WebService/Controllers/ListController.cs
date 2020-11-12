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
        /*[HttpGet("{id}", Name = nameof(getList))]
        public IActionResult getList(int id)
        {
            var list = _dataService.GetPersonBookmarkList(id);
            //var bookmark = _dataService.GetBookmarks(id);
            if (list == null && bookmark == null)
            {
                return NotFound();
            }

            return Ok(list);
        }*/
        //Get a bookmark
        [HttpGet("{id}", Name = nameof(getBookmark))]
        public IActionResult getBookmark(int id)
        {
            var list = _dataService.GetBookmark(id);
            //var bookmark = _dataService.GetBookmarks(id);
            if (list == null /*&& bookmark == null*/)
            {
                return NotFound();
            }
            return Ok(list);
        }
        
        [HttpGet("{listid}")]
        public IActionResult GetPersonBookMarkList(int listid)
        {
            var bookmarklist = _dataService.GetUsersPersonBookmarkLists(listid);
            
            IList<PersonBookmarkListDto> professionDtos = bookmarklist.Select(x => new PersonBookmarkListDto
            {
                Id = x.Id,
                User_Id = x.User_Id,
                List_Name = x.List_Name,
                Url = ""
            }).ToList();
            return Ok(professionDtos);
        }


    }
}