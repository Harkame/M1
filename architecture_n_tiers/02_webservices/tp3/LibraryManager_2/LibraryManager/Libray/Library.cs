using LibraryManager.Models;
using System.Collections.Generic;
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

        public static bool LibrarianIsConnected(int p_librarian_id)
        {
            foreach (Librarian t_librarian in Librarians)
                if (t_librarian.ID == p_librarian_id)
                    return true;

            return false;
        }


        public static bool SubscriberIsConnected(int p_subscriber_id)
        {
            foreach (Subscriber t_subscriber in Subscribers)
                if (t_subscriber.ID == p_subscriber_id)
                    return true;

            return false;
        }
    }
}