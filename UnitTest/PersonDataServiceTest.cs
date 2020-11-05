using DataService.Services;
using Xunit;

namespace PortFolio2.Tests
{
    public class PersonDataServiceTest
    {
        
        [Fact]
        public void GetPerson()
        {
            var service = new PersonDataService();
            var person = service.GetPerson("nm0000453");
            Assert.Equal("nm0000453", person.Id);
            Assert.Equal("Fred Astaire", person.Name);
        }
    }
}