namespace LibraryManager
{
    using System;
    using System.Text;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public abstract class User
    {
        private static int g_id = 0;

        [Required]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required]
        [DisplayName("Password")]
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

        public override int GetHashCode()
        {
            // Which is preferred?

            return base.GetHashCode();
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
    }
}