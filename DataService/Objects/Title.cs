namespace DataService.Objects
{
    public class Title
    {
        public string Id { get; set; }
        public int TypeId { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public int RunTimeMinutes { get; set; }
        
        
        //MANGLER ALLE KLASSER
        public Title_Rating TitleRating;
    }
}