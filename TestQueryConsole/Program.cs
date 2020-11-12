using System;
using System.Collections.Generic;
using System.Linq;
using DataService;
using DataService.Objects;
using DataService.Services;
using Microsoft.EntityFrameworkCore;

namespace TestQueryConsole
{
    class Program
    {


        static void Main(string[] args)
        {
            using var ctx = new ImdbContext();


            PersonDataService personDataService = new PersonDataService();

            //Console.WriteLine(personDataService.GetPersonKnownTitles("nm0000001"));

            IQueryable<Person> GetPersonBySubstring(string substring)
            {
                var ctx = new ImdbContext();
                var query = ctx.Person.Where(x => x.Name.Contains(substring));
                return query;
            }

            //GetPersonBySubstring("red ast")


            List<Person_Profession> GetProfessionByPersonId(string id)
            {
                var query = ctx.PersonProfessions
                    .Include(c => c.person)
                    .Include(v => v.Profession)
                    .Where(p => p.person.Id == id)
                    .ToList();

                ctx.SaveChanges();

                return query.ToList();
            }
            
            List<Title_Bookmark> GetTitleBookmarks(int id)
            {
                using var ctx = new ImdbContext();
                var query = ctx.title_bookmarks.Where(x => x.Id == id);
                return query.ToList();
            }


            Console.WriteLine(GetTitleBookmarks(1));






        }
    }
}