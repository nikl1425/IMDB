using System;
using System.Linq;
using DataService.Services;
using Microsoft.EntityFrameworkCore;
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
            Assert.Equal("Jens", users.Surname);
        }

        [Fact]
        public void CreateUser()
        {
            var service = new UserDataService();
            
        }

        [Fact]
        public void GetRatingFromUser()
        {
            var service = new UserDataService();
            var rating = service.GetRatingFromUsers(1);
            Assert.Equal(1, rating.Count);
            Assert.Equal("tt0052520", rating.First().Title_Id);
            Assert.Equal(8, rating.Last().Rating_);
        }

        [Fact]
        public void GetPersonBookmarkLists()
        {
            var service = new UserDataService();
            var personBookmarkList = service.GetUsersPersonBookmarkLists(1);
            Assert.Equal(2, personBookmarkList.Count);
            Assert.Equal("My test list1", personBookmarkList.First().List_Name);
            Assert.Equal("My test list2321", personBookmarkList.Last().List_Name);
        }
        
        [Fact]
        public void GetPersonBookmark()
        {
            var service = new UserDataService();
            var personBookmark = service.GetPersonBookmark(19);
            Assert.Equal(19,personBookmark.Id);
            Assert.Equal("nm0000001",personBookmark.Person_Id);
        }


        [Fact]
        public void GetTitleBookmarks()
        {
            var service = new UserDataService();
            var titleBookmarks = service.GetTitleBookmarks(1);
            Assert.Equal(1, titleBookmarks.First().Id);
            Assert.Equal(1, titleBookmarks.First().ListId);
            Assert.Equal("tt0734773", titleBookmarks.First().TitleId);
        }


        [Fact]
        public void UpdatePersonBookmark()
        {
            var service = new UserDataService();
            
        }

        [Fact]
        public void newPersonBookmarkList()
        {
            var service = new UserDataService();
            var newbooklist = service.NewPersonBookmarkList(1, "hejsatest");
            Assert.Equal(1,newbooklist.User_Id);
            Assert.Equal("hejsatest",newbooklist.List_Name);
        }

        [Fact]
        public void newPersonBookmark()
        {
            var service = new UserDataService();
            var newBookmark = service.NewPersonBookmark("nm0000001", 4);
            Assert.Equal("nm0000001",newBookmark.Person_Id);
            Assert.Equal(4,newBookmark.List_Id);
            
        }
        
    }
}