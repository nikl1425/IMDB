using System.Collections.Generic;

namespace DataService.Objects
{
    public class Title_Rating
    {
        public int Id { get; set; }
        public string Title_Id { get; set; }
        public double Average_Rating { get; set; }
        public int Num_Votes { get; set; }
        public Title Title { get; set; }
    }
}