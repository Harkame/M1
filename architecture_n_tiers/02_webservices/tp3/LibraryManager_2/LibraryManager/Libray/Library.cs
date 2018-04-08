using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManager.Connections
{
    public class Library
    {
        public static ICollection<Librarian> Librarians { get; set; }

        public static ICollection<Subscriber> Subscribers { get; set; }

        static Library()
        {
            Librarians = new List<Librarian>();

            Subscribers = new List<Subscriber>();
        }
    }
}