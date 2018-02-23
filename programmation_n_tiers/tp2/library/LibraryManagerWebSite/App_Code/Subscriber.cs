using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.Text;

namespace LibraryManager
{
    public class Subscriber
    {
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

        public Subscriber()
        {
        }
        
        public Subscriber(int p_id, String p_password)
        {
            a_id = p_id;

            a_password = p_password;
        }

        public override bool Equals(object p_subscriber)
        {
            if (p_subscriber == null)
                return false;

            Subscriber t_subscriber = p_subscriber as Subscriber;

            return a_id == t_subscriber.a_id &&
                a_password.Equals(t_subscriber.a_password);
        }

        public override String ToString()
        {
            StringBuilder r_to_string = new StringBuilder();

            r_to_string.Append("ID : ");
            r_to_string.Append(a_id);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("Password : ");
            r_to_string.Append(a_password);

            return r_to_string.ToString();
        }
    }
}