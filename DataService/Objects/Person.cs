using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Person
    {
        
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        
        public Person_Bookmarks PersonBookmarks;
        
        public IList<Person_Person_Known_Title> PersonPersonKnownTitles = new List<Person_Person_Known_Title>();

        

    }
}