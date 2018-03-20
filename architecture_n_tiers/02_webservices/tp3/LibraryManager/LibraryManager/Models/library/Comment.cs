namespace LibraryManager
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Text;

    public class Comment
    {
        private int a_user_id;

        private String a_description;

        public int UserID
        {
            get
            {
                return a_user_id;
            }
            set
            {
                a_user_id = value;
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

        public Comment(int p_user_id, String p_description)
	    {
            a_user_id = p_user_id;

            a_description = p_description;
	    }

        public override String ToString()
        {
            StringBuilder r_to_string = new StringBuilder();

            r_to_string.Append(UserID);
            r_to_string.Append(" - ");
            r_to_string.Append(a_description);

            return r_to_string.ToString();
        }
    }
}