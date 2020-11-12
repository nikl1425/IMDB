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

        //Enter a userprofile. 
        [HttpGet ("{id}", Name = nameof(getUser))]
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
        [HttpPut("{id}")]
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
        [HttpDelete("{id}")]
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
        [HttpPost("{id}/lists/")] 
        public IActionResult newPersonBookmarkList(int userid, string listName)
        {
            var list = _dataService.NewPersonBookmarkList(userid, listName);
            return Created("New list: ", list);
        }
        
        //get personbookmarklists
        [HttpGet("{id}/lists", Name = nameof(getPersonBookmarkLists))]
        public IActionResult getPersonBookmarkLists(int id)
        {
            var list = _dataService.GetUsersPersonBookmarkLists(id);
            if (list == null)
            {
                return NotFound();
            }
            return Ok(list);
        }
        
        
        
        
        
    }
}