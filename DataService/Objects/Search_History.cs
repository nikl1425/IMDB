using System;

namespace DataService.Objects
{
    public class Search_History
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string Search_Name { get; set; } 
        public DateTime Timestamp { get; set; }
        public User Users;

    }
}