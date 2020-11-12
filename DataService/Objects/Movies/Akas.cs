using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataService.Objects
{
    public class Akas
    {
        
        public int Id { get; set; }
        public string TitleId { get; set; }
        public int Ordering { get; set; }
        public string AkasName { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public bool IsOriginalTitle { get; set; }
        
        public List<Akas_Type> AkasType { get; set; }
        
        public Title Title { get; set; }
        
        
    }
}