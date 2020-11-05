using System.Collections.Generic;

namespace DataService.Objects
{
    public class Profession
    {
        public int Id { get; set; }
        
        public string ProfessionName { get; set; }

        public IList<Person_Profession> PersonProfessions = new List<Person_Profession>();
        
        
    }
}