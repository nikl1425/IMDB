using System.Collections.Generic;

namespace DataService.Objects
{
    public class Title_Genre
    {
        public int Id { get; set; }
        public string TitleId { get; set; }
        public int GenreId { get; set; }
        public Genre Genre;
        public IList<Title> Titles = new List<Title>();
    }
}