using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManager.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("Book")]
        [Required]
        public int BookID { get; set; }
        public Book Book { get; set; }

        [ForeignKey("Subscriber")]
        [Required]
        public int SubscriberID { get; set; }
        public Subscriber Subscriber { get; set; }
    }
}