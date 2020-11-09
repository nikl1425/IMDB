using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Profession
    {
        public int Id { get; set; }
        
        public string ProfessionName { get; set; }

        [Required] public IList<Person_Profession> PersonProfessions { get; set; }
        
        
        
    }
}