using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Person
    {
        
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        
    }
}