using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataService.Objects
{
    public class Person_Person_Known_Title
    {
        public int Id { get; set; }
        public string PersonId { get; set; }
        public int PersonTitleId { get; set; }

        [Required] public Person_known_title PersonKnownTitles { get; set; }
        
        public Person person { get; set; }
    }
        
        
    }
