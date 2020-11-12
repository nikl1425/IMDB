using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataService.Objects;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.EntityFrameworkCore;

namespace DataService.Services
{
    public class UserDataService : IUserDataService
    {
        public UserDataService()
        {
            using var ctx = new ImdbContext();
        }

        //USER STUFF
        public User GetUser(int id)
        {
            using var ctx = new ImdbContext();
            
            return ctx.users.Find(id);
        }

        public User CreateUser(string surname, string lastname, int age, string email)
        {
            // TODO : check if names is names and email is email
            using var ctx = new ImdbContext();
            var maxId = ctx.users.Max(x => x.Id);
            ctx.users.Add(new User {Id = maxId + 1, Age = age, Surname = surname, Last_Name = lastname, Email = email});
            ctx.SaveChanges();
            return ctx.users.Find(maxId + 1);
        }
        public bool UpdateUser(int id, string surname, string lastname, int age, string email)
        {
            //TODO : check if strings is not containing numbers & email is an email
            using var ctx = new ImdbContext();
            if (id <= 0) return false;
            if(surname != null)
                ctx.users.Update(ctx.users.Find(id)).Entity.Surname = surname;
            if(lastname != null)
                ctx.users.Update(ctx.users.Find(id)).Entity.Last_Name = lastname;
            if(age != 0)
                ctx.users.Update(ctx.users.Find(id)).Entity.Age = age;
            if(email != null)
                ctx.users.Update(ctx.users.Find(id)).Entity.Email = email;
            
            ctx.SaveChanges();

            return true;
        }

        public bool DeleteUser(int id)
        {
            using var ctx = new ImdbContext();
            var dbUser = GetUser(id);
            if (dbUser == null)
            {
                return false;
            }
            ctx.users.Remove(dbUser);
            ctx.SaveChanges();
            return true;
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

        public List<Person_Bookmark_list> GetUsersPersonBookmarkLists(int userid)
        {
            using var ctx = new ImdbContext();
            var x = ctx.person_bookmark_list
                .Where(b => b.User_Id == userid)
                .ToList();
            return x;
        }
        
        public Person_Bookmark_list NewPersonBookmarkList(int userid, string listName)
        {
            using var ctx = new ImdbContext();
            var maxId = ctx.users.Max(x => x.Id);
            var dbUser = GetUser(userid).Id;
            var newPersonBookmarkList = ctx.person_bookmark_list
                .Add(new Person_Bookmark_list
                {Id = maxId + 1, List_Name = listName, User_Id = dbUser});

            return ctx.person_bookmark_list.Find(maxId+1);
        }
        
        
        public List<Person_Bookmark_list> GetPersonBookmarkList(int id)
        {
            using var ctx = new ImdbContext();
            var x = ctx.person_bookmark_list.Where(x => x.Id == id);
            return x.ToList();
        }

        
        public List<Title_Bookmark_List> GetTitleBookmarkLists(int id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title_bookmark_list.Where(x => x.Id == id);
            return query.ToList();
        }

        public List<Title_Bookmark> GetTitleBookmarks(int id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title_bookmarks.Where(x => x.Id == id);
            return query.ToList();
        }

        public Title_Bookmark GetTitleBookmark(int id)
        {
            using var ctx = new ImdbContext();
            return ctx.title_bookmarks.Find(id);
        }
        
        public bool UpdatePersonBookmark(int id, int list_id, string person_id)
        {
            using var ctx = new ImdbContext();
            if (list_id <= 0) return false;
            ctx.person_bookmarks.Update(ctx.person_bookmarks.Find(id)).Entity.List_Id = list_id;
            ctx.person_bookmarks.Update(ctx.person_bookmarks.Find(id)).Entity.Person_Id = person_id;
            ctx.SaveChanges();
            return GetPersonBookmark(id).List_Id == list_id && GetPersonBookmark(id).Person_Id == person_id;
        }


        public bool deletePersonBookmarkList(int listid)
        {
            using var ctx = new ImdbContext();
            var dbList = GetPersonBookmarkList(listid).FirstOrDefault();
            if (dbList == null)
            {
                return false;
            }

            deletePersonBookmarks(listid);
            ctx.person_bookmark_list.Remove(dbList);
            ctx.SaveChanges();
            
            return true;
        }
        
       public Person_Bookmark GetPersonBookmark(int id)
        {
            using var ctx = new ImdbContext();
            return ctx.person_bookmarks.Find(id);
        }
        
        public IList<Person_Bookmark> GetPersonBookmarks(int listid)
        {
            using var ctx = new ImdbContext();
            var x = ctx.person_bookmarks
                .Where(x => x.List_Id == listid)
                .ToList();
            return x;
        }
        public bool deletePersonBookmarks(int id)
        {
            using var ctx = new ImdbContext();
            var dbBookmark = GetPersonBookmarks(id);
            if (dbBookmark == null)
            {
                return false;
            }

            foreach (var x in ctx.person_bookmarks.Where(x=>x.List_Id == id))
            {
                ctx.person_bookmarks.Remove(x);
            }
            ctx.SaveChanges();
            return true;
        }
        public bool deletePersonBookmark(int id)
        {
            using var ctx = new ImdbContext();
            var dbBookmark = GetPersonBookmark(id);
            if (dbBookmark == null)
            {
                return false;
            }

            ctx.person_bookmarks.Remove(dbBookmark);
            ctx.SaveChanges();
            return true;
        }

        

    }
}