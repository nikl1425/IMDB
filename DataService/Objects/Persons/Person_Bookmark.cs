using System.Collections.Generic;

namespace DataService.Objects
{
    public class Person_Bookmark
    {
        public int Id { get; set; }
        public int List_Id { get; set; }
        public string Person_Id { get; set; }
        public Person_Bookmark_list PersonBookmarkList;
        public Person Persons;


    }
}