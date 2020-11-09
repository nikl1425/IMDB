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
            Assert.Equal("nm0000001", person.Id);
            Assert.Equal("Fred Astaire", person.Name);
        }

        [Fact]
        public void GetPersonKnownTitle()
        {
            var PersonKnownTitle = _personDataService.GetPersonKnownTitle(1);
            Assert.Equal(1, PersonKnownTitle.Id);
            Assert.Equal("tt3670036", PersonKnownTitle.TitleName);
        }
        
        [Fact]
        public void GetPersonPersonKnownTitles()
        {
            var PersonPersonKnownTitles = _personDataService.GetPersonPersonKnownTitle(1);
            Assert.Equal(1, PersonPersonKnownTitles.Id);
            Assert.Equal("nm10619296", PersonPersonKnownTitles.PersonId);
            Assert.Equal(196263, PersonPersonKnownTitles.PersonTitleId);
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
            var service = _personDataService.GetProfessionByPersonId("nm0000001");
            Assert.Equal("actor", service.PersonProfessions.First().Profession.ProfessionName);
            Assert.Equal("soundtrack", service.PersonProfessions.Last().Profession.ProfessionName);
        }

        [Fact]
        public void GetPersonsByProfession()
        {
            var service = _personDataService.GetPersonAmountByProfession("soundtrack");
            Assert.Equal(12507, service.PersonProfessions.Count);
        }

        [Fact]
        public void GetPersonRating()
        {
            //var personRating = _personDataService.GetPersonRating(1);
            //Assert.Equal(null, personRating.Id);
            //Assert.Equal();
        }
        

        

    }
}