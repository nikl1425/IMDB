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

            //GetPersonBySubstring("red ast");
            
            
            
            Person GetPersonPersonKnownTitles(string id)
            {
                using var ctx = new ImdbContext();
                var query = ctx.Person
                    .Include(x => x.PersonKnownTitles)
                    .AsSingleQuery()
                    .FirstOrDefault(x => x.Id == id);
                return query;


            }

         




        }
    }
}