using System.Collections.Generic;
using DataService.Objects;

namespace DataService.Services
{
    public interface IPersonDataService
    {
        Person GetPerson(string id);
        IList<Person> GetPersons();
        Person_known_title GetPersonKnownTitle(int id);
        Person_Person_Known_Title GetPersonPersonKnownTitle(int id);
        Person GetProfessionByPersonId(string id);
        Profession GetPersonAmountByProfession (string profession);
        Person_Profession GetPersonProfession(int id);
        Profession GetProfession(int id);
    }
}