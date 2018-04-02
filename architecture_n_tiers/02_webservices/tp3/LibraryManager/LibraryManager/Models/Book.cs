using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models
{

    public class Book
    {
        [Key]
        [Required]
        public int ISBN { get; set; }

        [Required]
        public String Title { get; set; }
    }
}