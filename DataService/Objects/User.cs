using System.Collections.Generic;

namespace DataService.Objects
{
    public class User
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Last_Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        private List<Title_Bookmark_List> TitleBookmarkLists { get; set; }
        
    }
}