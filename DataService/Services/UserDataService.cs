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

        public User GetUser(int id)
        {
            using var ctx = new ImdbContext();
            
            return ctx.users.Find(id);
        }

        public User CreateUser(string surname, string lastname, int age, string email)
        {
            using var ctx = new ImdbContext();
            var maxId = ctx.users.Max(x => x.Id);
            ctx.users.Add(new User {Id = maxId + 1, Age = age, Surname = surname, Last_Name = lastname, Email = email});
            ctx.SaveChanges();
            return ctx.users.Find(maxId + 1);
        }
        public bool UpdateUser(int id, string surname, string lastname, int age, string email)
        {
            using var ctx = new ImdbContext();
            if (id <= 0) return false;
            ctx.users.Update(ctx.users.Find(id)).Entity.Surname = surname;
            ctx.users.Update(ctx.users.Find(id)).Entity.Last_Name = lastname;
            ctx.users.Update(ctx.users.Find(id)).Entity.Age = age;
            ctx.users.Update(ctx.users.Find(id)).Entity.Email = email;
            ctx.SaveChanges();

            return GetUser(id).Email == email;
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