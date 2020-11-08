using System.Linq;
using DataService.Objects;

namespace DataService.Services
{
    public class PersonDataService
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

        public Person_known_title GetPersonKnownTitle(int id)
        {
            using var ctx = new ImdbContext();
            return ctx.PersonKnownTitles.Find(id);
        }

        public Person_Person_Known_Title GetPersonPersonKnownTitle(int id)
        {
            using var ctx = new ImdbContext();
            return ctx.PersonPersonKnownTitles.Find(id);
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