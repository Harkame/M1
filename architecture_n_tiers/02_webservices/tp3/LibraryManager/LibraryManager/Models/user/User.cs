using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace LibraryManager
{
    public abstract class User
    {
        private static int g_id = 0;

        [Required]
        public int ID { get; set; }

        [Required]
        public string Password { get; set; }

        public User()
        {
        }

        public User(String p_password)
        {
            ID = g_id++;

            Password = p_password;
        }

        public override bool Equals(object p_subscriber)
        {
            if (p_subscriber == null)
                return false;

            User t_User = p_subscriber as User;

            return this.ID == t_User.ID &&
                this.Password.Equals(t_User.Password);
        }

        public override String ToString()
        {
            StringBuilder r_to_string = new StringBuilder();

            r_to_string.Append("ID : ");
            r_to_string.Append(ID);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("Password : ");
            r_to_string.Append(Password);

            return r_to_string.ToString();
        }

        public override int GetHashCode()
        {
            int r_hashcode = 1964481176;
            r_hashcode = r_hashcode * -1521134295 + ID.GetHashCode();
            r_hashcode = r_hashcode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return r_hashcode;
        }
    }
}