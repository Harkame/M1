using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace LibraryManager
{
    public class Subscriber
    {
        public int a_id;
        
        public String a_password;

        public Subscriber()
        {
            a_id = 0;

            a_password = "default";
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
    }
}