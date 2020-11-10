using System;
using System.Linq;
using DataService.Objects;
using DataService.Services;
using Xunit;
using DataService.Services;


namespace PortFolio2.Tests
{
    public class TitleDataServiceTest
    {
        [Fact]
        public void GetGenre()
        {
            var service = new TitleDataService();
            var genre = service.GetGenre(1);
            Assert.Equal(1, genre.Id);
            Assert.Equal("Sport", genre.Name);
        }

        [Fact]
        public void getTitle()
        {
            var service = new TitleDataService();
            var title = service.getTitle("tt9916538");
            Assert.Equal("Kuambil Lagi Hatiku", title.PrimaryTitle);
            Assert.Equal("2019", title.StartYear);
        }

        [Fact]
        public void getTitleEpisodeNumber()
        {
            var service = new TitleDataService();
            var title = service.getTitleEpisode("tt0697644");
            Assert.Equal("tt0098904", title.TitleEpisode.ParentId);
            Assert.Equal(6, title.TitleEpisode.SeasonNumber);
        }

        [Fact]
        public void getTitleGenreNames()
        {
            var service = new TitleDataService();
            var title = service.getTitleGenreName("tt0078672");
            Assert.Equal("Comedy", title.TitleGenres.First().Genre.Name);
        }

        [Fact]
        public void getTitlePerson()
        {
            var service = new TitleDataService();
            var titlePerson = service.getTitlePersons("tt0098286");
            Assert.Equal(10, titlePerson.Count);
        }

        [Fact]
        public void getTitlePersonName()
        {
            //test midlertidligt unpassable :P
            var service = new TitleDataService();
            var names = service.getTitlePersonName("tt0098286");
            Assert.Equal("Leland Gray", names.TitlePersons.First().Person.Name);
        }

        [Fact]
        public void getGenres()
        {
            var service = new TitleDataService();
            var genres = service.GetGenres();
            Assert.Equal(28, genres.Count);
        }
    }
}