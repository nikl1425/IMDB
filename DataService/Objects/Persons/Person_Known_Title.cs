using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Person_known_title
    {
        
        
        public string Id { get; set; }
       
        public string TitleId { get; set; }
        
        public Person person { get; set; }
        
        public Title title { get; set; }

    }
}