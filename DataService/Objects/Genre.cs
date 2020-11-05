using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Genre
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
    }
}