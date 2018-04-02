namespace LibraryManager
{
    using System;

    public class Librarian : User
    {
        public Librarian() : base()
        {
        }

        public Librarian(String p_password) : base(p_password)
        {
        }
    }
}