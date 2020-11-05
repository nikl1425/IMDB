using System.Collections;
using System.Collections.Generic;

namespace DataService.Objects
{
    public class Person_Bookmark_list
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string List_Name { get; set; }
        public User Users;
        public IList<Person_Bookmarks> PersonBookmarks = new List<Person_Bookmarks>();
        
        
    }
}