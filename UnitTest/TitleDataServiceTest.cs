using System;
using System.Linq;
using Xunit;


namespace PortFolio2.Tests
{
    
    //nik
    public class TitleDataServiceTest
    {
        [Fact]
        public void GetGenre()
        {
            var service = new DataService.Services.TitleDataService();
            var genre = service.GetGenre(1);
            Assert.Equal(1, genre.Id);
            Assert.Equal("Sport", genre.Name);
        }
    }
}