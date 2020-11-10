using System.Collections.Generic;
using DataService.Objects;

namespace DataService.Services
{
    public interface IUserDataService
    {
        User GetUser(int id);
        User CreateUser(string surname, string lastname, int age, string email);
        bool UpdateUser(int id, string surname, string lastname, int age, string email);
        IList<Rating> GetRatingFromUsers(int userid);
        IList<Search_History> GetSearchHistories(int userid);
        IList<Person_Bookmark_list> GetPersonBookmarkLists(int userid);
    }
}