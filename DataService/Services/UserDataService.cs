using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataService.Objects;
using Microsoft.EntityFrameworkCore;

namespace DataService.Services
{
    public class UserDataService : IUserDataService
    {
        public UserDataService()
        {
            using var ctx = new ImdbContext();
        }

        public User GetUsers(int id)
        {
            using var ctx = new ImdbContext();
            return ctx.users.Find(id);
        }

        public IList<Rating> GetRatingFromUsers(int userid)
        {
            using var ctx = new ImdbContext();
            var x = ctx.rating.Where(r => r.User_Id == userid);
            return x.ToList();
        }

        public IList<Search_History> GetSearchHistories(int userid)
        {
            using var ctx = new ImdbContext();
            var x = ctx.search_history.Where(s => s.User_Id == userid);
            return x.ToList();
        }

        public IList<Person_Bookmark_list> GetPersonBookmarkLists(int userid)
        {
            using var ctx = new ImdbContext();
            var x = ctx.person_bookmark_list
                .Where(b => b.User_Id == userid)
                .ToList(); 
            return x;
        }

        /*public IList<Person_Bookmark_list> GetPersonBookmarksInList(int userid, string listname)
        {
            using var ctx = new ImdbContext();
            var x  = from pbList in ctx.person_bookmark_list
                join pb in ctx.person_bookmarks on pbList equals listname
                select new {}
            
        }*/


    }
}