namespace LibraryManager.Models
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Text;

    public class Comment
    {
        public User a_User;
        public String a_description;
        public User User
        {
            get
            {
                return a_User;
            }
            set
            {
                a_User = value;
            }
        }
        public String Description
        {
            get
            {
                return a_description;
            }
            set
            {
                a_description = value;
            }
        }
        public Comment()
        {
        }
        public Comment(User p_User, String p_description)
        {
            a_User = p_User;
            a_description = p_description;
        }
        public override String ToString()
        {
            StringBuilder r_to_string = new StringBuilder();
            r_to_string.Append(a_User.ID);
            r_to_string.Append(" - ");
            r_to_string.Append(a_description);
            return r_to_string.ToString();
        }
    }
}