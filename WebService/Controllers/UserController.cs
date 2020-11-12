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
        [HttpPost]
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
        [HttpPost("user/{id}/lists/")] 
        public IActionResult newPersonBookmarkList(int userid, string listName)
        {
            var list = _dataService.NewPersonBookmarkList(userid, listName);
            return Created("New list: ", list);
        }
        //new titlebookmarklist
        [HttpPost("user/{id}/lists/")] 
        public IActionResult newTitleBookmarkList(int userid, string listName)
        {
            var list = _dataService.NewTitleBookmarkList(userid, listName);
            return Created("New list: ", list);
        }
        
        //Delete Users personbookmarklist
        [HttpDelete("list/{listid}")] 
        public IActionResult deletePersonBookmarkList(int listid)
        {
            var delete = _dataService.deletePersonBookmarkList(listid);
            return Ok(delete);
        }
        
        //Delete Users Person Bookmark
        [HttpDelete("list/{listid}/{bookmarkid}")]
        public IActionResult deletePersonBookmark(int bookmarkid)
        {
            var delete = _dataService.deletePersonBookmark(bookmarkid);
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