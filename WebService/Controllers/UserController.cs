using System.Collections;
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
    public class UserController : ControllerBase
    {
        private IUserDataService _dataService;
        private readonly IMapper _mapper;
        public UserController(IUserDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        //Enter a userprofile. 
        [HttpGet ("user/{id}", Name = nameof(getUser))]
        public IActionResult getUser(int id)
        {
            var user = _dataService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            //to implement; show users bookmarklists & their link
            return Ok(user);
        }
        
        //New user
        [HttpPost("user")]
        public IActionResult createUser(UserDto userDto)
        {
            //string surname, string lastname, int age, string email
            var user = _dataService.CreateUser(userDto.Surname, userDto.LastName, userDto.Age, userDto.Email);

            return Created("New user: ", user);

        }

        //Update user
        [HttpPut("user/{id}")]
        public IActionResult updateUser(int id, UserDto userDto)
        {
            if (id <= 0)
            {
                return NotFound();
            }
            // If all is getting updated:
            var updateUser = _dataService.UpdateUser(id, userDto.Surname, userDto.LastName, userDto.Age, userDto.Email);
            return Ok(updateUser);
        }
        
        //Delete user
        [HttpDelete("user/{id}")]
        public IActionResult deleteUser(int id)
        {
            var delete = _dataService.DeleteUser(id);
            if (id <= 0)
            {
                return NotFound();
            }
            return Ok(delete);
        }
        
        //new personbookmarklist
        [HttpPost("user/{userid}/plists/")] 
        public IActionResult newPersonBookmarkList(PersonBookmarkListDto pblDto)
        {
            var list = _dataService.NewPersonBookmarkList(pblDto.User_Id, pblDto.List_Name);
            return Created("New list: ", list);
        }
        
        
        //new titlebookmarklist
        [HttpPost("user/{userid}/tlists/")] 
        public IActionResult newTitleBookmarkList(TitleBookmarkListDTO tblDto)
        {
            var list = _dataService.NewTitleBookmarkList(tblDto.UserId, tblDto.ListName);
            return Created("New list: ", list);
        }
        //new person bookmark
        [HttpPost("user/{userid}/plist/bookmark")]
        //[HttpPost("name/{personid}/bookmark/")] 
        public IActionResult newPersonBookmark(PersonBookmarkDto pbDto)
        {
            var newBookmark = _dataService.NewPersonBookmark(pbDto.Person_Id, pbDto.List_Id);
            return Created("",newBookmark);
        }
        //new title bookmark
        [HttpPost("user/{userid}/tlist/bookmark")]
        //[HttpPost("title/{titleid}/bookmark/")]
        public IActionResult newTitleBookmark(TitleBookmarkDTO tbDto)
        {
            var newBookmark = _dataService.NewTitleBookmark(tbDto.TitleId, tbDto.ListId);
            return Created("",newBookmark);
        }
        
        //Delete Users personbookmarklist
        [HttpDelete("plist/{listid}")] 
        public IActionResult deletePersonBookmarkList(int listid)
        {
            var delete = _dataService.deletePersonBookmarkList(listid);
            return Ok(delete);
        }
        
        //Delete Users Person Bookmark
        [HttpDelete("plist/{listid}/{bookmarkid}")]
        public IActionResult deletePersonBookmark(int bookmarkid)
        {
            var delete = _dataService.deletePersonBookmark(bookmarkid);
            return Ok(delete);
        }
        
        //Delete Users titlebookmarklist
        [HttpDelete("tlist/{listid}")] 
        public IActionResult deleteTitleBookmarkList(int listid)
        {
            var delete = _dataService.deleteTitleBookmarkList(listid);
            return Ok(delete);
        }
        
        //Delete Users title Bookmark
        [HttpDelete("tlist/{listid}/{bookmarkid}")]
        public IActionResult deleteTitleBookmark(int bookmarkid)
        {
            var delete = _dataService.deleteTitleBookmark(bookmarkid);
            return Ok(delete);
        }

        //Get Users lists
        [HttpGet("user/{id}/lists")]
        public IActionResult getPersonBookmarkLists(int id)
        {
            var personBookmarkList = _dataService.GetUsersPersonBookmarkLists(id);
            var titleBookmarkList = _dataService.GetTitleBookmarkLists(id);
            
            IList<TitleBookmarkListDTO> titleList = titleBookmarkList.Select(x => new TitleBookmarkListDTO
            {
                Id = x.Id,
                UserId = x.UserId,
                ListName = x.ListName,
                Url = ""
            }).ToList();
            
            IList<PersonBookmarkListDto> personList = personBookmarkList.Select(x => new PersonBookmarkListDto
            {
                Id = x.Id,
                User_Id = x.User_Id,
                List_Name = x.List_Name,
                Url = ""
            }).ToList();
            
            return Ok(new {personList, titleList});
        }
        
        
    }
}