using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Person_Profession
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
        public int ProfessionId { get; set; }
        [Required] public Profession Profession { get; set; }

    }
}