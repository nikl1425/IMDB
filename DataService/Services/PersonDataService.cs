using System.Collections.Generic;
using System.Linq;
using DataService.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DataService.Services
{
    public class PersonDataService : IPersonDataService
    {
        public PersonDataService()
        {
            using var ctx = new ImdbContext();
        }
        
        public Person GetPerson(string id)
        {
            using var ctx = new ImdbContext();
            //var smthing = ctx.Person.FirstOrDefault(t => t.Id.Trim().ToLower() == id.Trim().ToLower());

            return ctx.Person.Find(id);
        }

        public IQueryable<Person> GetPersonBySubstring(string substring)
        {
            var ctx = new ImdbContext();
            var query = ctx.Person.Where(x => x.Name.Contains(substring));
            return query;
        }
        
        public IList<Person> GetPersons()
        {
            using var ctx = new ImdbContext();
            return ctx.Person.ToList();
        }

        public Person_known_title GetPersonKnownTitle(string person_id, string title_id)
        {
            using var ctx = new ImdbContext();
            return ctx.PersonKnownTitles.Find(person_id, title_id);
        }
        


        
        public Person GetProfessionByPersonId(string id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.Person
                .Include(x => x.PersonProfessions)
                .ThenInclude(z => z.Profession)
                .AsSingleQuery()
                .FirstOrDefault(c => c.Id == id);
            return query;
        }
        
        public Person GetPersonKnownTitles(string id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.Person
                .Include(x => x.PersonKnownTitles)
                .AsSingleQuery()
                .FirstOrDefault(x => x.Id == id);
            return query;
        }


        public Profession GetPersonAmountByProfession (string profession)
        {
            var ctx = new ImdbContext();
            var personList = ctx.Professions
                .Include(x => x.PersonProfessions)
                .AsSingleQuery()
                .FirstOrDefault(v => v.ProfessionName == profession);

            return personList;
        }
        
        public Person_Profession GetPersonProfession(int id)
        {
            using var ctx = new ImdbContext();
            return ctx.PersonProfessions.Find(id);
        }
        
        public Profession GetProfession(int id)
        {
            using var ctx = new ImdbContext();
            return ctx.Professions.Find(id);
        }
    }
}