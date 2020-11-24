namespace DataService.Objects
{
    public class TitleType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        
        public Title Title { get; set; }
    }
}