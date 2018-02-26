namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Text;

    public abstract class Person
    {
        private static int g_id = 0;

        private int a_id;

        private String a_password;

        public int ID
        {
            get
            {
                return a_id;
            }
            set
            {
                a_id = value;
            }
        }

        public String Password
        {
            get
            {
                return a_password;
            }
            set
            {
                a_password = value;
            }
        }

        public Person()
        {
        }

        public Person(String p_password)
        {
            a_id = g_id++;

            a_password = p_password;
        }

        public override bool Equals(object p_subscriber)
        {
            if (p_subscriber == null)
                return false;

            Person t_person = p_subscriber as Person;

            return this.ID == t_person.ID &&
                this.Password.Equals(t_person.Password);
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