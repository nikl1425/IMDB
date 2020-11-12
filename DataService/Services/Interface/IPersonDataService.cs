using System.Collections.Generic;
using DataService.Objects;

namespace DataService.Services
{
    public interface IPersonDataService
    {
        Person GetPerson(string id);
        IList<Person> GetPersons();
        Person_known_title GetPersonKnownTitle(string person_id, string title_id);
  
        Person GetProfessionByPersonId(string id);
        Profession GetPersonAmountByProfession (string profession);
        Person_Profession GetPersonProfession(int id);
        Profession GetProfession(int id);
    }
}