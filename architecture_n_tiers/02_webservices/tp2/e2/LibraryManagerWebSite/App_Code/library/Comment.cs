namespace LibraryManager
{
    using System;
    using System.Text;

    public class Comment
    {
        public User User { get; set; }

        public String Description { get; set; }

        public Comment()
        {
        }

        public Comment(User p_User, String p_description)
	    {
            User = p_User;

            Description = p_description;
	    }

        public override String ToString()
        {
            StringBuilder r_to_string = new StringBuilder();

            r_to_string.Append(User.ID);
            r_to_string.Append(" - ");
            r_to_string.Append(Description);

            return r_to_string.ToString();
        }
    }
}