using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataService.Objects;
using DataService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using WebService.ObjectDto;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/name")]
    public class PersonController : ControllerBase
    {
        private IPersonDataService _dataService;
        private readonly IMapper _mapper;

        public PersonController(IPersonDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }


        [HttpGet("{id}", Name = nameof(GetPerson))]
        public IActionResult GetPerson(string id)
        {
            var person = _dataService.GetPerson(id);
            var profession = _dataService.GetProfessionByPersonId(id);
            if (person == null && profession == null)
            {
                return NotFound();
            }
            
            PersonDTO personDto1 = new PersonDTO();
            personDto1.Id = person.Id;
            personDto1.Name = person.Name;
            personDto1.BirthYear = person.BirthYear;
            personDto1.DeathYear = person.DeathYear;
            
            ProfessionDTO professionDto1 = new ProfessionDTO();
            
            foreach (var value in profession.PersonProfessions)
            {
                professionDto1.Id = value.ProfessionId;
                professionDto1.ProfessionName = value.Profession.ProfessionName;
                Console.WriteLine(professionDto1.ProfessionName);
            }

            return Ok(new {professionDto1, personDto1});
        }
        
        [HttpGet]
        public IActionResult GetPersons()
        {
            var person = _dataService.GetPersons();

            IList<PersonDTO> newPersonDTO = person.Select(x => new PersonDTO
            {
                Id = x.Id,
                Name = x.Name,
                BirthYear = x.BirthYear,
                DeathYear = x.DeathYear,
                Url = "http://localhost:5001/api/name/" + x.Id
            }).ToList();
            
            return Ok(newPersonDTO);
        }

        [HttpGet("{id}/profession")]
        public IActionResult GetProfession(string id)
        {
            var personProfessions = _dataService.GetProfessionByPersonId(id);
            return Ok(personProfessions);
        }

       /* [HttpGet("genreTitle/{id}", Name = nameof(getGenreTitles))]
        public IActionResult getGenreTitles(int id)
        {
            var genreTitle = _dataService.getGenreTitles(id);
            IList<GenreTitleNameDTO> genreTitleNameDto = genreTitle.Select(x => new GenreTitleNameDTO
            {
                Id = x.Id,
                Name = x.Name,
                TitleNames = x.TitleGenres.Select(x => new TitleDto
                {
                    Name = x.Title.PrimaryTitle
                }).ToList()
            }).ToList();

            return Ok(genreTitleNameDto);
        }*/
    }
}