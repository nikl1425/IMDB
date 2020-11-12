using System;

namespace WebService.ObjectDto
{
    /// <summary>
    /// This DTO contains all information of title.
    /// </summary>
    public class TitleDto
    {
        public string Id { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public int RunTimeMinutes { get; set; }
        
        // Rating
        
        // Link to the type
        public string TypeUrl { get; set; }
        
        // Link to the Genre
        
        public string GenreUrl { get; set; }
        
        // List of Akas (aka. different language and so on of that title)
        
        
        // Bookmark
        
        // omdb data
        
    }
}