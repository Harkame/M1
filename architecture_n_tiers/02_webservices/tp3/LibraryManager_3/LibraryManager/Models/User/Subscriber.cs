using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManager.Models
{
    public class Subscriber
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ID { get; set; }

        [Required]
        public string Password { get; set; }

        public Subscriber()
        {

        }

        public Subscriber(int id, string password)
        {
            ID = id;
            Password = password;
        }

        public override bool Equals(Object p_object)
        {
            if (p_object == null)
                return false;

            Librarian t_librarian = p_object as Librarian;

            return ID == t_librarian.ID &&
                Password.Equals(t_librarian.Password);
        }

        public override int GetHashCode()
        {
            var hashCode = 1964481176;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
}