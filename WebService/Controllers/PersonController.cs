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
            var profession = _dataService.GetProfessionByPersonId2(id);
            var personKnownTitle = _dataService.GetPersonKnownTitles2(id);

            IList<ProfessionDTO> professionDtos = profession.Select(x => new ProfessionDTO
            {
                ProfessionName = x.Profession.ProfessionName,
                Id = x.Profession.Id
            }).ToList();

            IList<PersonDTO> personDtos = person.Select(x => new PersonDTO
            {
                Id = x.Id,
                Name = x.Name,
                BirthYear = x.BirthYear,
                DeathYear = x.DeathYear
            }).ToList();

            IList<PersonKnownTitleDTO> personKnownTitleDtos = personKnownTitle.Select(x => new PersonKnownTitleDTO
            {
                Id = x.Id,
                TitleId = x.TitleId
            }).ToList();


            /*
            ProfessionDTO professionDtoFinal()
            {
                ProfessionDTO professionDto = new ProfessionDTO();
                foreach (var value in profession.PersonProfessions)
                {
                }
                return professionDto;
            }
            */

            return Ok(new {personDtos, professionDtos, personKnownTitleDtos});
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