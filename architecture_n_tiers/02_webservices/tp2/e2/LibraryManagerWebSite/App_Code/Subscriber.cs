﻿namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Runtime.Serialization;
    using System.Text;

    public class Subscriber : Person
    {
        public Subscriber() : base()
        {
        }

        public Subscriber(String p_password) : base(p_password)
        {
        }
    }
}