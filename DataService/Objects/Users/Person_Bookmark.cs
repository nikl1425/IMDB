using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataService.Objects
{
    public class Person_Bookmark
    {
        public int Id { get; set; }
        public int List_Id { get; set; }
        public string Person_Id { get; set; }
        
        //public Person_Bookmark_list PersonBookmarkList { get; set; }
        public Person Persons { get; set; }


    }
}