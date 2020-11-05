using System.Collections.Generic;

namespace DataService.Objects
{
    public class Person_Person_Known_Title
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
        public int PersonTitleId { get; set; }
        
        public Person person;

        public IList<Person_known_title> PersonKnownTitles = new List<Person_known_title>();
        
        
    }
}