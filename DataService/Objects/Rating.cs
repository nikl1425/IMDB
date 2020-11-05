namespace DataService.Objects
{
    public class Rating
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public int Title_Id { get; set; } 
        public float rating { get; set; }
        
        public Users Users { get; set; }

    }
}