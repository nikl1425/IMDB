using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Title_Genre
    {

        [Key]public int Id { get; set; }
        public string TitleId { get; set; }
        public int GenreId { get; set; }
       [Required] public Genre Genre { get; set; }
        public IList<Title> Titles = new List<Title>();
    }
}