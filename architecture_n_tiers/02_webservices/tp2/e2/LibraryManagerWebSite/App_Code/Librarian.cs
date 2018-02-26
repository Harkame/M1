namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Runtime.Serialization;
    using System.Text;

    public class Librarian : Person
    {
        public Librarian() : base()
        {
        }

        public Librarian(String p_password) : base(p_password)
        {
        }
    }
}