using System.Collections.Generic;
using DataService.Objects;

namespace DataService.Services
{
    public interface IUserDataService
    {
        User GetUser(int id);
        User CreateUser(string surname, string lastname, int age, string email);
        bool UpdateUser(int id, string surname, string lastname, int age, string email);
        bool DeleteUser(int id);
        Person_Bookmark_list NewPersonBookmarkList(int userid, string listName);
        IList<Rating> GetRatingFromUsers(int userid);
        IList<Search_History> GetSearchHistories(int userid);
        IList<Person_Bookmark_list> GetUsersPersonBookmarkLists(int userid);
        Person_Bookmark_list GetPersonBookmarkList(int id);
    }
}