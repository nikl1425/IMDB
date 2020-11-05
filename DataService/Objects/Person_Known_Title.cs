using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Person_known_title
    {
        [Key]
        public int Id { get; set; }
        public string TitleName { get; set; }

        public Person_Person_Known_Title PersonPersonKnownTitle;
    }
}