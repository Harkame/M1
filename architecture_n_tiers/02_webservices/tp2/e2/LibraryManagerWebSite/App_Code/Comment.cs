namespace LibraryManager
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Text;

    public class Comment
    {
        public Person a_person;

        public String a_description;

        public Person Person
        {
            get
            {
                return a_person;
            }
            set
            {
                a_person = value;
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

        public Comment(Person p_person, String p_description)
	    {
            a_person = p_person;

            a_description = p_description;
	    }

        public override String ToString()
        {
            StringBuilder r_to_string = new StringBuilder();

            r_to_string.Append(a_person.ID);
            r_to_string.Append(" - ");
            r_to_string.Append(a_description);

            return r_to_string.ToString();
        }
    }
}