namespace DataService.Objects
{
    public class Title_Search
    {
        public string Id { get; set; }
        public string Word { get; set; }
        public string Field { get; set; }
        public string Lexeme { get; set; }
        public Title Title { get; set; }
        
    }
}