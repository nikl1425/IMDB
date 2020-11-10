using System.Collections.Generic;

namespace WebService.ObjectDto
{
    public class GenreTitleNameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TitleDto> TitleNames{
            get;
            set;
        }
    }
}