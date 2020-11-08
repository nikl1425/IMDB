using System;
using System.Collections.Generic;
using System.Linq;
using DataService.Objects;

namespace DataService.Services
{
    public class UserDataService
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
                .Where(b => b.User_Id == userid); 
            return x.ToList();
        }
        
        public IList<Person_Bookmark> GetPersonBookmarks(int userid)
        {
            using var ctx = new ImdbContext();
            /*
             * TODO
             * Hent alle bookmarks fra en person - er det nested qeuery?
             * x = ctx.person_bookmarks
             *     .where(b=>b.list_id = ctx.personbookmark_list.Id
             *     .Include(x => x.personbookmark_list.userid)
             *     .toList();
             * 
             */
            var x = ctx.person_bookmarks
                .Where(b => b.List_Id == userid); 
            return x.ToList();
        }

    }
}