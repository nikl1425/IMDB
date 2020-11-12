using System;
using System.Linq;
using DataService.Services;
using Xunit;



namespace PortFolio2.Tests
{
    public class UserDataServiceTest
    {
        [Fact]
        public void GetUser()
        {
            var service = new UserDataService();
            var users = service.GetUser(1);
            Assert.Equal(1, users.Id);
            Assert.Equal("TestSurname", users.Surname);
        }

        [Fact]
        public void GetRatingFromUser()
        {
            var service = new UserDataService();
            var rating = service.GetRatingFromUsers(1);
            Assert.Equal(2, rating.Count);
            Assert.Equal("tt0052520", rating.First().Title_Id);
            Assert.Equal(8, rating.Last().Rating_);
        }

        [Fact]
        public void GetPersonBookmarkLists()
        {
            var service = new UserDataService();
            var personBookmarkList = service.GetUsersPersonBookmarkLists(1);
            Assert.Equal(2, personBookmarkList.Count);
            Assert.Equal("My Fav Actors", personBookmarkList.First().List_Name);
            Assert.Equal("My Fav Directors", personBookmarkList.Last().List_Name);
        }

        [Fact]
        public void GetBookmarks()
        {
            var service = new UserDataService();
            var personBookmark = service.GetBookmarks(1);
            Assert.Equal(1,personBookmark.First().Id);
            Assert.Equal("nm0000001",personBookmark.First().Person_Id);
        }
    }
}