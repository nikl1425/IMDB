using System.Collections.Generic;
using DataService.Objects;

namespace WebService.ObjectDto
{
    public class AkasDto
    {
        public int Id { get; set; }
        public string TitleId { get; set; }
        public string TitleUrl { get; set; }
        public int Ordering { get; set; }
        public string AkasName { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public bool IsOriginalTitle { get; set; }
        
        public string Url { get; set; }
        
    
        
        public string AkasType { get; set; }
    }
}