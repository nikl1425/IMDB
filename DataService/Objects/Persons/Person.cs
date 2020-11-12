using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }

        public ICollection<Person_Bookmark> PersonBookmark { get; set; }
        public IList<Person_known_title> PersonKnownTitles { get; set; }
        
        public IList<Title_Person> TitlePersons { get; set; }

        public IList<Person_Profession> PersonProfessions {get; set;}

        public Person_Rating PersonRating;

    }
}