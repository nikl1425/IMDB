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

        [HttpGet("plist/{listid}")]
        public IActionResult GetPersonBookMarkList(int listid)
        {
            var bookmarklist = _dataService.GetPersonBookmarkList(listid);
            var getbookmarks = _dataService.GetPersonBookmarks(listid);
                
            IList<PersonBookmarkListDto> listDto = bookmarklist.Select(x => new PersonBookmarkListDto
            {
                Id = x.Id,
                User_Id = x.User_Id,
                List_Name = x.List_Name,
                Url = "http://localhost:5001/api/user/"+x.User_Id //URL to user
            }).ToList();
            
            IList<PersonBookmarkDto> bookmarkDtos = getbookmarks.Select(x => new PersonBookmarkDto
            {
                Id = x.Id,
                List_Id = x.List_Id,
                Person_Id = x.Person_Id,
                Url = "http://localhost:5001/api/name/"+x.Person_Id
            }).ToList();

            return Ok(new {listDto, bookmarkDtos});
        }
        
        [HttpGet("tlist/{listid}")]
        public IActionResult GetTitleBookMarkList(int listid)
        {
            var bookmarklist = _dataService.GetTitleBookmarkLists(listid);
            var getbookmarks = _dataService.GetTitleBookmarks(listid);
                
            //ÆNDRE TIL TITLEBOOKMARKLISTDTO
            IList<TitleBookmarkListDTO> listDto = bookmarklist.Select(x => new TitleBookmarkListDTO
            {
                Id = x.Id,
                UserId = x.UserId,
                ListName = x.ListName,
                Url = "http://localhost:5001/api/user/"+x.UserId //URL to user
            }).ToList();
            
            //KEEP
            IList<TitleBookmarkDTO> bookmarkDtos = getbookmarks.Select(x => new TitleBookmarkDTO
            {
             Id = x.Id,
             TitleId = x.TitleId,
             ListId = x.ListId,
             Url = "http://localhost:5001/api/title/" + x.TitleId 
            }).ToList();

            return Ok(new {listDto, bookmarkDtos});
        }
    }
}