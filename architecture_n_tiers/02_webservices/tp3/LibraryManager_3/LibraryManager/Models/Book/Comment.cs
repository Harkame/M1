using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManager.Models
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("Book")]
        [Required]
        public int BookID { get; set; }

        [JsonIgnore]
        public Book Book { get; set; }

        /*
        [Key, Column(Order = 1)]
        [ForeignKey("Subscriber")]
        [Required]
        public int SubscriberID { get; set; }
        [JsonIgnore]
        public Subscriber Subscriber { get; set; }
        */

        public Comment()
        {
        
        }
    }
}