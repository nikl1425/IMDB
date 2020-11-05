using System.Collections.Generic;

namespace DataService.Objects
{
    public class Akas_Akas_Type
    {
        public int Id { get; set; }
        public int AkasAkasId { get; set; }
        public int AkasTypeId { get; set; }
        public Akas_Type AkasType { get; set; }
        public IList<Akas> Akases { get; set; }
    }
}