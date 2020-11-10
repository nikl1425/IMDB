using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace DataService.Objects
{
    public class Title_Genre
    {

        [Key]public int Id { get; set; }
        public string TitleId { get; set; }
        public int GenreId { get; set; }
       [Required] public Genre Genre { get; set; }
       
       public Title Title { get; set; }
    }
    }
