using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace DataService.Objects
{
    public class Title_Person
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
        public string TitleId { get; set; }
        public int Ordering { get; set; }
        public string Category { get; set; }
        public string Job { get; set; }
        public string Character { get; set; }

        public IList<Person> Persons { get; set; }


        public IList<Title> Titles { get; set; }
    }
}