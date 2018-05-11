namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class User
    {
        private static int G_ID = 0;

        public int ID { get; set; }

        public String Password { get; set; }

        public User()
        {
        }

        public User(String p_password)
        {
            ID = G_ID++;

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
            var hashCode = 1964481176;
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            return hashCode;
        }
    }
}