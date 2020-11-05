using System.Collections.Generic;

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
        public string Type { get; set; }
        public bool IsOriginalTitle { get; set; }
        public Akas_Akas_Type AkasAkasType { get; set; }
        public Title Title { get; set; }
        public IList<Akas_Attribute> AkasAttributes { get; set; }
    }
}