using System.Collections.Generic;

namespace DataService.Objects
{
    public class Akas_Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Akas_Akas_Type> AkasAkasTypes { get; set; }
    }
}