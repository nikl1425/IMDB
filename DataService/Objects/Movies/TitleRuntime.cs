namespace DataService.Objects
{
    public class TitleRuntime
    {
        public string Id { get; set; }
        public int Runtime { get; set; }
        
        public Title Title { get; set; }
    }
}