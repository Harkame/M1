using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace LibraryManager
{
    public class Comment
    {
        public Subscriber a_subscriber;

        public String a_description;

	    public Comment()
	    {
		
	    }

        public Comment(Subscriber p_subscriber, String p_description)
	    {
            a_subscriber = p_subscriber;

            a_description = p_description;
	    }

        public override String ToString()
        {
            StringBuilder r_to_string = new StringBuilder();

            r_to_string.Append(a_subscriber.a_id);
            r_to_string.Append(" - ");
            r_to_string.Append(a_description);

            return r_to_string.ToString();
        }
    }
}