using System.Collections.Generic;
using DataService.Objects;

namespace DataService.Services
{
    public interface IUserDataService
    {
        User GetUsers(int id);
        IList<Rating> GetRatingFromUsers(int userid);
        IList<Search_History> GetSearchHistories(int userid);
        IList<Person_Bookmark_list> GetPersonBookmarkLists(int userid);
    }
}