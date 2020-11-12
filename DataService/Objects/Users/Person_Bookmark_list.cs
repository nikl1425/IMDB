using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Person_Bookmark_list
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string List_Name { get; set; }
        [Required] public IList<Person_Bookmark> PersonBookmarks { get; set; }


    }
}