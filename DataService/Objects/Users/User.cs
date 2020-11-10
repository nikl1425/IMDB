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

        private List<Rating> Ratings { get; set; }
        
        private List<Person_Bookmark_list> PersonBookmarkLists { get; set; }
        
        private List<Search_History> SearchHistories { get; set; }

    }
}