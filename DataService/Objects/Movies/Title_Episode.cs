namespace DataService.Objects
{
    public class Title_Episode
    {
        public int Id { get; set; }
        public string TitleId { get; set; }
        public string ParentId { get; set; }
        public int SeasonNumber { get; set; }
        public int EpisodeNumber { get; set; }
        
        public Title Title { get; set; }
    }
}