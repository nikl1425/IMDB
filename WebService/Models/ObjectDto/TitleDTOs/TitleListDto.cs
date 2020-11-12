using System;

namespace WebService.ObjectDto
{
    /// <summary>
    /// This DTO contains all information of title.
    /// </summary>
    public class TitleListDto
    {
        public string Id { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        
        public String Url { get; set; }
        
        
       
    }
}