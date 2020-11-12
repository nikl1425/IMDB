using System;
using System.Linq;
using DataService.Services;
using Xunit;
using Xunit.Abstractions;

namespace PortFolio2.Tests
{
    public class PersonDataServiceTest
    {
        private PersonDataService _personDataService;
        private readonly ITestOutputHelper output;
        public PersonDataServiceTest(ITestOutputHelper output)
        {
            _personDataService = new PersonDataService();
            this.output = output;
        }
        
        [Fact]
        public void GetPerson()
        {
            var person = _personDataService.GetPerson("nm0000001");
            Assert.Equal("nm0000001", person.First().Id);
            Assert.Equal("Fred Astaire", person.First().Name);
        }

        [Fact]
        public void GetPersonKnownTitle()
        {
            var PersonKnownTitle = _personDataService.GetPersonKnownTitle("nm4517670", "tt5188450");
            Assert.Equal("nm4517670", PersonKnownTitle.Id);
            Assert.Equal("tt5188450", PersonKnownTitle.TitleId);
        }
 
        
        [Fact]
        public void GetPersonProfession()
        {
            var PersonProfession = _personDataService.GetPersonProfession(1);
            Assert.Equal(1, PersonProfession.Id);
            Assert.Equal("nm0000001", PersonProfession.PersonId);
            Assert.Equal(13, PersonProfession.ProfessionId);
        }

        [Fact]
        public void GetProfession()
        {
            var Profession = _personDataService.GetProfession(1);
            Assert.Equal(1, Profession.Id);
            Assert.Equal("editor", Profession.ProfessionName);
        }

        [Fact]
        public void GetProfessionByPersonId()
        {
            var service = _personDataService.GetProfessionByPersonId2("nm0000001");
            Assert.Equal(3, service.Count);
            Assert.Equal("actor", service.First().Profession.ProfessionName);
            Assert.Equal("soundtrack", service.Last().Profession.ProfessionName);
        }

        [Fact]
        public void GetPersonKnownTitles()
        {
            var service = _personDataService.GetPersonKnownTitles("nm4517670");
            Assert.Equal("tt5188450", service.PersonKnownTitles.First().TitleId);
        }
        
        
        [Fact]
        public void GetPersonKnownTitles2()
        {
            var service = _personDataService.GetPersonKnownTitles2("nm4517670");
            Assert.Equal("tt5188450", service.First().TitleId);
        }

        [Fact]
        public void GetPersonsByProfession()
        {
            var service = _personDataService.GetPersonAmountByProfession("soundtrack");
            Assert.Equal(12507, service.PersonProfessions.Count);
        }
        
        
        

        [Fact]
        public void GetPersonBySubstring()
        {
            var service = _personDataService.GetPersonBySubstring("red");
            Assert.Equal("Fred Astaire", service.First().Name);
        }
        

        

    }
}