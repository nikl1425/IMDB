using System.Collections.Generic;
using DataService.Objects;

namespace WebService.ObjectDto
{
    public class GenreTitleNameDTO
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public string titleName { get; set; }
        
        public string Url { get; set; }

    }
}