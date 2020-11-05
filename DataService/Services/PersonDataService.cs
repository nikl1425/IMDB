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
            return ctx.Person.Find(id);
        }
    }
}