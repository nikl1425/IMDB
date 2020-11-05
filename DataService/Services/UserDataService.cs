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

        public IList<Rating> GetRatingFromUsers(int user)
        {
            using var ctx = new ImdbContext();
            var x = ctx.rating.Where(r => r.User_Id == user);
            return x.ToList();
        }
        
        public 
    }
}